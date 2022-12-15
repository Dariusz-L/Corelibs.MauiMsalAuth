namespace Common.Infrastructure.MauiMsalAuth
{
    public class NoAccessTokenAvailableException : Exception
    {
        public string RedirectURL { get; }

        public NoAccessTokenAvailableException(string message, string redirectUrl) : base(message) 
        {
            RedirectURL = redirectUrl;
        }
    }
}
