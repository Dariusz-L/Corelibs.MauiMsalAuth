using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Common.Infrastructure.MauiMsalAuth
{
    public static class MauiMsalAuthExtensions
    {
        public static IServiceCollection AddMsalAuthentication(
            this IServiceCollection services, 
            ConfigurationManager configurationManager)
        {
            var executingAssembly = Assembly.GetCallingAssembly();
            var assemblyName = executingAssembly.GetName().Name;

            using var stream = executingAssembly.GetManifestResourceStream($"{assemblyName}.appsettings.json");
            configurationManager.AddConfiguration(
                new ConfigurationBuilder().AddJsonStream(stream).Build());

            services.AddSingleton(SecureStorage.Default);
            services.AddSingleton<IPCAWrapper, PCAWrapper>();
            services.AddSingleton<ISignInManager, PCASignInManager>();
            services.AddTransient<AuthorizationMessageHandler>();

            return services;
        }

        public static IServiceCollection AddAuthorizedHttpService<TInterface, TImplementation>(this IServiceCollection services, string baseAdress)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddHttpClient<TInterface, TImplementation>(
                client => client.BaseAddress = new Uri(baseAdress))
                .AddHttpMessageHandler<AuthorizationMessageHandler>();

            return services;
        }
    }
}
