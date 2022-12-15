using Microsoft.Identity.Client;

namespace Common.Infrastructure.MauiMsalAuth
{
	internal interface IPCAWrapper
	{
		string[] Scopes { get; set; }
		Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes);
		Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes);
		Task SignOutAsync();
	}
}
