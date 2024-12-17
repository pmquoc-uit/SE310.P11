using Hangfire;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class JobTestController
        (JobTestService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
            : BaseApiController
    {
        [HttpGet("FireAndForgetJob")]
        [AllowAnonymous]
        public ActionResult<string> CreateFireAndForgetJob()
        {
            backgroundJobClient.Enqueue(() => jobTestService.FireAndForgetJob());
            return Ok("Job sent!");
        }
        [HttpGet("DelayedJob")]
        [AllowAnonymous]
        public ActionResult CreateDelayedJob()
        {
            backgroundJobClient.Schedule(() => jobTestService.DelayedJob(), TimeSpan.FromSeconds(60));
            return Ok("Job sent!");
        }
        [HttpGet("ReccuringJob")]
        [AllowAnonymous]
        public ActionResult CreateReccuringJob()
        {
            recurringJobManager.AddOrUpdate("jobId", () => jobTestService.ReccuringJob(), Cron.Minutely);
            return Ok("Job sent!");
        }
        [HttpGet("ContinuationJob")]
        [AllowAnonymous]
        public ActionResult CreateContinuationJob()
        {
            var parentJobId = backgroundJobClient.Enqueue(() => jobTestService.FireAndForgetJob());
            backgroundJobClient.ContinueJobWith(parentJobId, () => jobTestService.ContinuationJob());
            return Ok("Job sent!");
        }
    }
}
