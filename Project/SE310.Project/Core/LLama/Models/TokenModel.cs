namespace Core.LLama.Models
{
    public class TokenModel
    {
        public TokenModel(String id, String content, TokenType tokenType = TokenType.Content)
        {
            Id = id;
            Content = content;
            TokenType = tokenType;
        }
        public String Id { get; set; }
        public String Content { get; set; }
        public TokenType TokenType { get; set; }
    }
    public enum TokenType
    {
        Begin = 0,
        Content = 2,
        End = 4,
        Cancel = 10
    }
}
