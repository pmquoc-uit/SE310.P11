namespace Core.LLama.Models
{
    public class SendMessageInput
    {
        public String Text { get; set; } = String.Empty;
    }
    public class HistoryInput
    {
        public List<HistoryItem> Messages { get; set; } = [];
        public class HistoryItem
        {
            public String Role { get; set; } = "User";
            public String Content { get; set; } = String.Empty;
        }
    }
}
