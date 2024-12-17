using API.Configurations;
using API.Middleware;
using API.SignalR;
using Core.Entities;
using Core.Interfaces;
using Core.LLama.Common;
using dotenv.net;
using Hangfire;
using Hangfire.MySql;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OpenAI;
using StackExchange.Redis;
using System.Text.Json.Serialization;
using CouponService = Infrastructure.Services.CouponService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions
    (opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddDbContext<StoreContext>(opt =>
{
    DotEnv.Load();
    var dataSourceBuilder =
        //new NpgsqlDataSourceBuilder(Environment.GetEnvironmentVariable("POSTGRES-DOCKER"));
        new NpgsqlDataSourceBuilder(Environment.GetEnvironmentVariable("POSTGRES-DOCKER"));
    dataSourceBuilder.EnableDynamicJson();
    opt.UseNpgsql(dataSourceBuilder.Build());
    //opt.EnableSensitiveDataLogging().UseNpgsql(dataSourceBuilder.Build());
    //opt.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"));
}, optionsLifetime: ServiceLifetime.Singleton);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors();
builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
{
    //var connString = builder.Configuration.GetConnectionString("Redis-Docker")
    var connString = builder.Configuration.GetConnectionString("Redis-Docker")
        ?? throw new Exception("Cannot get redis connection string");
    var configuration = ConfigurationOptions.Parse(connString, true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddSingleton<IResponseCacheService, ResponseCacheService>();

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StoreContext>();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddSignalR();

builder.Services.Configure<MailKitOptions>(builder.Configuration.GetSection("MailConfiguration"));
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddHostedService<EmailConsumerService>();
builder.Services.AddScoped<IEmailPublisherService, EmailPublisherService>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IPhotoService, PhotoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();

//builder.Services.AddHangfire(config =>
//{
//    config.UseSimpleAssemblyNameTypeSerializer()
//        .UseRecommendedSerializerSettings()
//        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
builder.Services.AddHangfire(config =>
{
    config
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        //.UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("MySQL-Docker"),
        .UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("MySQL-Docker"),
            new MySqlStorageOptions
            {
                QueuePollInterval = TimeSpan.FromSeconds(10),
                JobExpirationCheckInterval = TimeSpan.FromHours(1),
                CountersAggregateInterval = TimeSpan.FromMinutes(5),
                PrepareSchemaIfNecessary = true,
                DashboardJobListLimit = 25000,
                TransactionTimeout = TimeSpan.FromMinutes(1),
                TablesPrefix = "Hangfire",
            }));
});
builder.Services.AddHangfireServer(options => options.WorkerCount = 1);
builder.Services.AddScoped<RecurringJobService>();
builder.Services.AddScoped<JobTestService>();

builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var apiKey = configuration["OpenAI:ApiKey"];
    return new OpenAIClient(apiKey);
});
builder.Services.AddOptions<LLamaOptions>().BindConfiguration(nameof(LLamaOptions));
builder.Services.AddSingleton<StatefulChatService>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(options => options.DisplayRequestDuration());

// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
    .WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:5000", "https://localhost:5001"));

app.UseHangfireDashboard();

app.UseAuthentication();
app.UseAuthorization();

//app.UseHangfireDashboard(pathMatch: "/hangfire");

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapGroup("api").WithTags("Identity").MapIdentityApi<AppUser>(); // api/login
app.MapHub<NotificationHub>("/hub/notifications");
app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapFallbackToController("Index", "Fallback");

try
{
    var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = serviceScopeFactory.CreateScope())
    {
        var recurringJobService = scope.ServiceProvider.GetRequiredService<RecurringJobService>();
        RecurringJob.AddOrUpdate(
            "send-marketing-email",
            () => recurringJobService.SendMarketingEmail(),
            Cron.Daily);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error occurred while setting up recurring job: {ex.Message}");
}

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context, userManager);
}
catch (Exception ex)
{
    Console.WriteLine("Error occurred while setting up database\n" + ex);
    throw;
}

app.Run();
