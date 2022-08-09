
using IdentityModel.Client;

var client = new HttpClient();
 
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:8001");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
}

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "client_id_mvc",
    ClientSecret = "client_secret_mvc",
    Scope = "WebAPI"
});
if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.Json);