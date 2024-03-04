using Azure;
using Azure.AI.OpenAI;
using Janet.Common;
using Janet.Core.Services;

namespace Janet.Core;

public class Janet : IJanet
{
    private readonly OpenAIClient _client;
    private readonly Secrets _secrets = new();
    
    public IConversationService ConversationService { get; set; }

    public Janet()
    {
        DataIntegration.Initialize();
        
        _client = new(
            new Uri(_secrets.GetSecret(Secrets.GoogleSecretsKeys.azure_endpoint)), 
            new AzureKeyCredential(_secrets.GetSecret(Secrets.GoogleSecretsKeys.azure_key)));
        
        ConversationService = new ConversationService(_client);
    }
    
    public OpenAIClient GetClient()
    {
        return _client;
    }

}