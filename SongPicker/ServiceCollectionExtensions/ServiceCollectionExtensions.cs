namespace SongPicker.ServiceCollectionExtensions
{
    using Microsoft.Extensions.DependencyInjection;
    using SongPicker.Services.Interfaces;
    using SongPicker.Services.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISongService, SongService>();

            return serviceCollection;
        }
    }
}
