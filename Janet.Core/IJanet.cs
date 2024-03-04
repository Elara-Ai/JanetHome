using Azure.AI.OpenAI;

namespace Janet.Core;

public interface IJanet
{
    public OpenAIClient GetClient();
}