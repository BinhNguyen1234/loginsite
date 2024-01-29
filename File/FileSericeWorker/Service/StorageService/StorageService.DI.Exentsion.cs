namespace FileSericeWorker.Service.StorageService
{
    public static class DiExtension
    {
        public static IServiceCollection AddFileStorageService(this IServiceCollection services, string initialPath)
        {
            services.AddScoped<IStorageService>((x) => {
                return new StorageService(initialPath);
            });
            return services;
        }
    }
}
