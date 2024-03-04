using Azure;
using Azure.AI.OpenAI;
using Janet.Common;
using Janet.Core.Models;

namespace Janet.Core.Services;

public class ConversationService : IConversationService
{
    private static readonly Secrets _secrets = new();
    private OpenAIClient Client { get; set; }
    public List<JConversation> Conversations { get; set; } = new();
    public JConversation ActiveConversation { get; set; }
    
    public ConversationService(OpenAIClient p_client)
    {
        if(Conversations.Count == 0)
        {
            Conversations.Add(new JConversation(p_client));
            ActiveConversation = Conversations[0];
        }
        
    }
    
    public JConversation GetActiveConversation()
    {
        return ActiveConversation;
    }
    
    public void SetActiveConversation(JConversation p_conversation)
    {
        ActiveConversation = p_conversation;
    }
    
    public void StartConversation()
    {
        Conversations.Add(new(Client));
        ActiveConversation = Conversations[^1];
    }
    
    public List<JConversation> GetConversations()
    {
        return Conversations;
    }
    

    
}