using System.ComponentModel;

namespace Core.LLama.Common
{
    public interface ISessionConfig
    {
        String AntiPrompt { get; set; }
        [DisplayName("Anti Prompts")]
        List<String> AntiPrompts { get; set; }
        [DisplayName("Executor Type")]
        LLamaExecutorType ExecutorType { get; set; }
        String Model { get; set; }
        [DisplayName("Output Filter")]
        String OutputFilter { get; set; }
        List<String> OutputFilters { get; set; }
        String Prompt { get; set; }
    }
}
