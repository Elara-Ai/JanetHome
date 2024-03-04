using Azure;
using Azure.AI.OpenAI;
using Janet.Common;
using Janet.Core;
using Janet.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var user = new UserProfile()
{
    Username = "Arthur",
    Nickname = "Arthur"
};

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((p_context, p_services) =>
    {
        p_services.AddSingleton<IJanet, Janet.Core.Janet>();
    });

using var host = builder.Build();

var janet = host.Services.GetRequiredService<IJanet>();

var client = janet.GetClient();

var conversation = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage($"You are a helpful assistant."),
    new ChatRequestSystemMessage($"Your name is Janet."),
    new ChatRequestSystemMessage($"The user's name is {user.Nickname}")
};

var chat = new ChatCompletionsOptions()
{
    DeploymentName = "janet-35", //This must match the custom deployment name you chose for your model
    MaxTokens = 100
};
foreach (var message in conversation)
{
    chat.Messages.Add(message);
}

Response<ChatCompletions> response = client.GetChatCompletions(chat);
Console.WriteLine(response.Value.Choices[0].Message.Content);

while (true)
{
    var input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }
    chat.Messages.Add(new ChatRequestUserMessage(input));
    response = client.GetChatCompletions(chat);
    Console.WriteLine(response.Value.Choices[0].Message.Content);
    
}