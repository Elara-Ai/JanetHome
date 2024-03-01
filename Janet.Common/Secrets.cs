using System.Text.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Janet.Common;

public class Secrets
{
    private Dictionary<string,string> SecretsDictionary { get; set; }
    public Secrets()
    {
        var json = File.ReadAllText(Constants.Files.GoogleSecrets);
        SecretsDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
        var t = GetSecret(GoogleSecretsKeys.client_id);
    }

    public string GetSecret(GoogleSecretsKeys p_key)
    {
        return SecretsDictionary[p_key.ToString().ToLower()];
    }
    

    public enum GoogleSecretsKeys
    {
        type,
        project_id,
        private_key_id,
        client_email,
        client_id,
        auth_uri,
        token_uri,
        auth_provider_x509_cert_url,
        client_x509_cert_url,
        universe_domain,
        janet_core_api_key,
        open_ai_key,
        azure_key,
        azure_endpoint,
    }
    
    
    
    
    
}