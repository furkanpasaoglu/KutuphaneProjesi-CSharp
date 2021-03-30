using Microsoft.Extensions.DependencyInjection;

namespace Kutuphane.Core.Kutuphane.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}