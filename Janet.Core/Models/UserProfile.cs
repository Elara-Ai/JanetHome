namespace Janet.Core.Models;

public class UserProfile
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    
    public List<JConversation> Conversations { get; set; } = new();
    public JConversation ActiveConversation { get; set; }
    
}