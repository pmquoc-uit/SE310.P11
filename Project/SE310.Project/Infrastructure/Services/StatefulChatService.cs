using Core.LLama.Models;
using LLama;
using LLama.Common;
using LLama.Sampling;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using ChatHistory = LLama.Common.ChatHistory;

namespace Infrastructure.Services
{
    public class StatefulChatService : IDisposable
    {
        private readonly ChatSession _session;
        private readonly LLamaContext _context;
        private readonly ILogger<StatefulChatService> _logger;
        private bool _continue = false;
        //private const String SystemPrompt = "Transcript of a dialog, where the User interacts with an Assistant. Assistant is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.";
        private const String SystemPrompt = "Transcript of a dialog, where the User interacts with a Pharmacist. The Pharmacist is knowledgeable, professional, kind, and provides accurate information about medicines, their uses, and dosages.";

        public StatefulChatService(IConfiguration configuration, ILogger<StatefulChatService> logger)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var modelPath = Path.Combine(path!, configuration["ModelPath"]!);
            var @params = new ModelParams(modelPath)
            {
                ContextSize = 512,
                GpuLayerCount = 5
            };
            // todo: share weights from a central service
            using var weights = LLamaWeights.LoadFromFile(@params);
            _logger = logger;
            _context = new LLamaContext(weights, @params);
            _session = new ChatSession(new InteractiveExecutor(_context));
            _session.History.AddMessage(AuthorRole.System, SystemPrompt);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        public async Task<String> Send(SendMessageInput input)
        {
            if (!_continue)
            {
                _logger.LogInformation("Prompt: {text}", SystemPrompt);
                _continue = true;
            }
            _logger.LogInformation("Input: {text}", input.Text);
            var outputs = _session.ChatAsync(
                new ChatHistory.Message(AuthorRole.User, input.Text),
                new InferenceParams
                {
                    AntiPrompts = ["User:"],
                    SamplingPipeline = new DefaultSamplingPipeline
                    {
                        RepeatPenalty = 1.0f
                    }
                });

            var result = String.Empty;
            await foreach (var output in outputs)
            {
                _logger.LogInformation("Message: {output}", output);
                result += output;
            }

            //return result;
            return StripRoles(result);
        }
        private String StripRoles(String text)
        {
            var strippedText = text;

            // Remove "You:" from the start of the String
            if (strippedText.StartsWith("You:"))
            {
                strippedText = strippedText.Substring("You:".Length).TrimStart();
            }

            // Remove "User:" from the end of the String
            if (strippedText.EndsWith("User:"))
            {
                strippedText = strippedText.Substring(0, strippedText.Length - "User:".Length).TrimEnd();
            }

            return strippedText;
        }
        public async IAsyncEnumerable<String> SendStream(SendMessageInput input)
        {
            if (!_continue)
            {
                _logger.LogInformation(SystemPrompt);
                _continue = true;
            }

            _logger.LogInformation(input.Text);

            var outputs = _session.ChatAsync(
                new ChatHistory.Message(AuthorRole.User, input.Text),
                new InferenceParams
                {
                    MaxTokens = 256,
                    AntiPrompts = ["User:"],
                    SamplingPipeline = new DefaultSamplingPipeline
                    {
                        RepeatPenalty = 1.0f
                    }
                });

            await foreach (var output in outputs)
            {
                _logger.LogInformation(output);
                yield return output;
            }
        }
    }
}
