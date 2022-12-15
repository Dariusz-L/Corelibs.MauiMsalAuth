using Microsoft.AspNetCore.Components;

namespace Common.Infrastructure.MauiMsalAuth.Client
{
    public class MsalNativeSignInRedirector
    {
        private readonly ISignInManager _signInManager;
        private readonly NavigationManager _navigation;

        public MsalNativeSignInRedirector(ISignInManager signInManager, NavigationManager navigation)
        {
            _signInManager = signInManager;
            _navigation = navigation;
        }

        public async void Redirect(Exception exception)
        {
            if (exception is NoAccessTokenAvailableException)
            {
                await _signInManager.SignIn();
                _navigation.NavigateTo(_navigation.Uri, forceLoad: true);
            }
        }
    }
}
