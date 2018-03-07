using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Tongfang.DAU
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProvider<TOptions, TProvider>(this IServiceCollection serviceCollection,
            Action<IServiceProvider, IAcquireOptionsCollectionBuilder<TOptions>> optionsAction)
            where TOptions : AcquireOptions where TProvider : IAcquireProvider<TOptions>
        {
            AddCoreServices<TOptions, TProvider>(serviceCollection, optionsAction);
            return serviceCollection;
        }

        private static void AddCoreServices<TOptions,TProvider>(IServiceCollection serviceCollection,
            Action<IServiceProvider, IAcquireOptionsCollectionBuilder<TOptions>> optionsAction)
            where TOptions : AcquireOptions where TProvider : IAcquireProvider<TOptions>
        {
            serviceCollection.TryAddSingleton<IAcquireOptionsCollectionBuilder<TOptions>, AcquireOptionsCollectionBuilder<TOptions>>();

            serviceCollection.TryAddSingleton(p =>
            {
                var b = p.GetRequiredService<IAcquireOptionsCollectionBuilder<TOptions>>();
                optionsAction?.Invoke(p, b);
                return b.Collection;
            });

            serviceCollection.TryAddSingleton<IAcquireProviderTypeDiscoverer<TOptions>, AcquireProviderTypeDiscoverer<TOptions>>();

            foreach (TypeInfo t in AcquireProviderTypeDiscoverer<TOptions>.AcquireProviderDic.Values)
            {
                serviceCollection.AddTransient(t);
            }

            serviceCollection.TryAddSingleton(new AcquireServiceCollectionBuilder());
            
            serviceCollection.AddSingleton<ICollection<IAcquireService>>((p) =>
            {
                var b = p.GetRequiredService<AcquireServiceCollectionBuilder>();
                var opts = p.GetRequiredService<ICollection<TOptions>>();
                foreach (var opt in opts)
                {
                    if (AcquireProviderTypeDiscoverer<TOptions>.AcquireProviderDic.TryGetValue(opt.ProviderName, out TypeInfo t))
                    {
                        var ap = (IAcquireProvider<TOptions>)p.GetRequiredService(t);
                        b.Add(ap.Create(opt));
                    }
                }
                return b.Collection;
            });
        }
    }
}
