using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Kutuphane.Core.Kutuphane.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();

            if (classAttributes.Count > 0)
            {
                var methodAttributes = type.GetMethod(method.Name)
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}