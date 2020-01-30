using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Findhorn;
using R5T.Lombardy;
using R5T.Zografou;


namespace R5T.Glenrothes.Findhorn
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DataDirectoryTestingDataDirectoryPathProvider"/> implementation of <see cref="ITestingDataDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDataDirectoryTestingDataDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IDataDirectoryPathProvider> addDataDirectoryPathProvider,
            ServiceAction<ITestingDataDirectoryNameConvention> addTestingDataDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            services
                .AddSingleton<ITestingDataDirectoryPathProvider, DataDirectoryTestingDataDirectoryPathProvider>()
                .RunServiceAction(addDataDirectoryPathProvider)
                .RunServiceAction(addTestingDataDirectoryNameConvention)
                .RunServiceAction(addStringlyTypedPathOperator)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DataDirectoryTestingDataDirectoryPathProvider"/> implementation of <see cref="ITestingDataDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<ITestingDataDirectoryPathProvider> AddDataDirectoryTestingDataDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IDataDirectoryPathProvider> addDataDirectoryPathProvider,
            ServiceAction<ITestingDataDirectoryNameConvention> addTestingDataDirectoryNameConvention,
            ServiceAction<IStringlyTypedPathOperator> addStringlyTypedPathOperator)
        {
            var serviceAction = new ServiceAction<ITestingDataDirectoryPathProvider>(() => services.AddDataDirectoryTestingDataDirectoryPathProvider(
                addDataDirectoryPathProvider,
                addTestingDataDirectoryNameConvention,
                addStringlyTypedPathOperator));
            return serviceAction;
        }
    }
}
