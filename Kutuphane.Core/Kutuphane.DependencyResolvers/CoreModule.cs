using System.Diagnostics;
using Kutuphane.Core.Kutuphane.CrossCuttingConcerns.Caching;
using Kutuphane.Core.Kutuphane.CrossCuttingConcerns.Caching.Microsoft;
using Kutuphane.Core.Kutuphane.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Core.Kutuphane.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}