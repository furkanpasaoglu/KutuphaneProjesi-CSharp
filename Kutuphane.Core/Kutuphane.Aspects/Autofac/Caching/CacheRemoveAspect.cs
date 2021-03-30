using Castle.DynamicProxy;
using Kutuphane.Core.Kutuphane.CrossCuttingConcerns.Caching;
using Kutuphane.Core.Kutuphane.Utilities.Interceptors;
using Kutuphane.Core.Kutuphane.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Core.Kutuphane.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly string _pattern;
        private readonly ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}