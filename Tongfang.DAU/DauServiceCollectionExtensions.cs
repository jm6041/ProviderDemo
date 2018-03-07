using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Tongfang.DAU
{
    public static class DauServiceCollectionExtensions
    {
        public static IServiceCollection AddDAU<TOptions>(this IServiceCollection serviceCollection,
            Action<IServiceProvider, IAcquireOptionsCollectionBuiler<TOptions>> optionsAction)
            where TOptions : AcquireOptions
        {
            AddCoreServices<TOptions>(serviceCollection, optionsAction);
            return serviceCollection;
        }

        private static void AddCoreServices<TOptions>(IServiceCollection serviceCollection,
            Action<IServiceProvider, IAcquireOptionsCollectionBuiler<TOptions>> optionsAction) 
            where TOptions : AcquireOptions
        {
            serviceCollection.TryAddSingleton<IAcquireOptionsCollectionBuiler<TOptions>, AcquireOptionsCollectionBuilder<TOptions>>();

            serviceCollection.TryAddSingleton(p =>
            {
                var b = p.GetRequiredService<IAcquireOptionsCollectionBuiler<TOptions>>();
                optionsAction?.Invoke(p, b);
                return b.OptionsCollection;
            });

            serviceCollection.TryAddSingleton<IAcquireProviderTypeDiscoverer<TOptions>, AcquireProviderTypeDiscoverer<TOptions>>();

            foreach (TypeInfo t in AcquireProviderTypeDiscoverer<TOptions>.AcquireProviderDic.Values)
            {
                serviceCollection.AddTransient(t);
            }

            serviceCollection.TryAddSingleton<AcquireServiceCollectionBuilder>();
            serviceCollection.AddSingleton<ICollection<IAcquireService>>((p)=> 
            {
                var b = p.GetRequiredService<AcquireServiceCollectionBuilder>();
                var opts = p.GetRequiredService<IAcquireOptionsCollection<TOptions>>();
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

        public static IDauBuilder AddDAUCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDauCore, DauCore>();
            return new DauBuilder(serviceCollection);
        }
    }
}
