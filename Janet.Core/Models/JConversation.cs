using Azure;
using Azure.AI.OpenAI;
using Janet.Common;

namespace Janet.Core.Models;

public class JConversation
{
    private List<ChatRequestMessage> Messages { get; set; } = [];
    private ChatCompletionsOptions ChatOptions { get; set; } = new();

    private readonly OpenAIClient _client;
    public JConversation(OpenAIClient p_client)
    {
        _client = p_client;
        ChatOptions.DeploymentName = "janet-35";
        ChatOptions.MaxTokens = 100;
    }
    
    public string GetResponse(ChatRequestMessage p_message)
    {
        ChatOptions.Messages.Add(p_message);
        Response<ChatCompletions> response = _client.GetChatCompletions(ChatOptions);
        return response.Value.Choices[0].Message.Content;
    }

    public List<ChatRequestMessage> GetMessages()
    {
        return Messages;
    }
    
    public void AddMessage(ChatRequestMessage p_message)
    {
        Messages.Add(p_message);
    }
    
    public void ClearMessages()
    {
        Messages.Clear();
    }
    
}