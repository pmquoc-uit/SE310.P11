namespace Core.Interfaces
{
    public interface IJobService
    {
        Task FireAndForgetJobAsync();
        Task ReccuringJobAsync();
        Task DelayedJobAsync();
        Task ContinuationJobAsync();
    }
}
