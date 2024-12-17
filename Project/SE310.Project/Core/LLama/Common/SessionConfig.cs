namespace Core.LLama.Common
{
    public class SessionConfig : ISessionConfig
    {
        public String Model { get; set; } = String.Empty;
        public String Prompt { get; set; } = String.Empty;
        public String AntiPrompt { get; set; } = String.Empty;
        public List<String> AntiPrompts { get; set; } = [];
        public String OutputFilter { get; set; } = String.Empty;
        public List<String> OutputFilters { get; set; } = [];
        public LLamaExecutorType ExecutorType { get; set; }
    }
}
