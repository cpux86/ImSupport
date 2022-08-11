
using IdentityModel.Client;

var client = new HttpClient();
 
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:8001");

if (disco.IsError)
{
    Console.WriteLine(disco.Error);
}

var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
{
    Address = disco.TokenEndpoint,
    UserName = "admin",
    Password = "LaMp368&",
    ClientId = "client",
    ClientSecret = "client_secret_mvc",
    Scope = "Api"
});

//var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
//{
//    Address = disco.TokenEndpoint,
//    ClientId = "client",
//    ClientSecret = "client_secret_mvc",
//    Scope = "Api"
//});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}
var accessToken = tokenResponse.AccessToken;
Console.WriteLine(tokenResponse.Json);