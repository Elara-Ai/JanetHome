namespace Janet.Core.Models;

public class JChatCompletion
{
    public string Id { get; set; }
    public string Object { get; set; }
    public long Created { get; set; }
    public string Model { get; set; }
    public List<PromptFilterResult> PromptFilterResults { get; set; }
    public List<Choice> Choices { get; set; }
    public Usage Usage { get; set; }
    public string SystemFingerprint { get; set; }
}

public class PromptFilterResult
{
    public int PromptIndex { get; set; }
    public ContentFilterResults ContentFilterResults { get; set; }
}

public class ContentFilterResults
{
    public FilterResult Hate { get; set; }
    public FilterResult SelfHarm { get; set; }
    public FilterResult Sexual { get; set; }
    public FilterResult Violence { get; set; }
}

public class FilterResult
{
    public bool Filtered { get; set; }
    public string Severity { get; set; }
}

public class Choice
{
    public string FinishReason { get; set; }
    public int Index { get; set; }
    public Message Message { get; set; }
    public ContentFilterResults ContentFilterResults { get; set; }
}

public class Message
{
    public string Role { get; set; }
    public string Content { get; set; }
}

public class Usage
{
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens { get; set; }
}