using Janet.Core.Models;

namespace Janet.Core.Services;

public interface IConversationService
{
    public JConversation GetActiveConversation();
    public void SetActiveConversation(JConversation p_conversation);
    public void StartConversation();
    public List<JConversation> GetConversations();

}