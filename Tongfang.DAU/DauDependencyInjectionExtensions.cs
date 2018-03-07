using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tongfang.DAU;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 依赖注入扩展
    /// </summary>
    /*public static class DauDependencyInjectionExtensions
    {
        /// <summary>
        /// 添加DAU(Data Acquisition Unit)
        /// </summary>
        /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
        public static IDauBuilder AddDAU(this IServiceCollection serviceCollection)
        {
            AddCoreServices(serviceCollection);
            return new DauBuilder(serviceCollection);
        }

        public static IDauBuilder AddDAU2<TOptions>(this IServiceCollection serviceCollection,
            Action<IServiceProvider, IAcquireOptionsCollectionBuiler<TOptions>> optionsAction) where TOptions : AcquireOptions
        {
            AddCoreServices(serviceCollection);
            return new DauBuilder(serviceCollection);
        }

        private static void AddCoreServices(IServiceCollection serviceCollection)
        {
            ModbusAcquireOptions mopt1 = new ModbusAcquireOptions()
            {
                ProviderName = typeof(ModbusAcquireProvider).AssemblyQualifiedName,
                Equipment = new FieldEquipment(),
                Channel = new AcquireChannel()
            };
            ModbusAcquireOptions mopt2 = new ModbusAcquireOptions()
            {
                ProviderName = typeof(ModbusAcquireProvider).AssemblyQualifiedName,
                Equipment = new FieldEquipment(),
                Channel = new AcquireChannel()
            };
            OpcAcquireOptions oopt = new OpcAcquireOptions()
            {
                ProviderName = typeof(OpcAcquireProvider).AssemblyQualifiedName,
                Equipment = new FieldEquipment(),
                Channel = new AcquireChannel()
            };

            //IAcquireOptionsCollection<AcquireOptions> sopts = new AcquireOptionsCollection<AcquireOptions>() { mopt1, mopt2, oopt };
            IAcquireOptionsCollection<ModbusAcquireOptions> modbusList = new AcquireOptionsCollection<ModbusAcquireOptions>() { mopt1, mopt2 };
            IAcquireOptionsCollection<OpcAcquireOptions> opcList = new AcquireOptionsCollection<OpcAcquireOptions>() { oopt };

            //AcquireOptionsListBuiler<ModbusAcquireOptions> b1 = new AcquireOptionsListBuiler<ModbusAcquireOptions>();
            //b1.AddRange(modbusList);

            //AcquireOptionsListBuiler<OpcAcquireOptions> b2 = new AcquireOptionsListBuiler<OpcAcquireOptions>();
            //b2.AddRange(opcList);

            serviceCollection.TryAddSingleton(modbusList);
            serviceCollection.TryAddSingleton(opcList);

            foreach (TypeInfo t in AcquireProviderTypeDiscoverer.AcquireProviderDic.Values)
            {
                serviceCollection.AddTransient(t);
            }

            var dd = serviceCollection.Where(x => x.ServiceType.FullName.StartsWith("Tongfang"));

            serviceCollection.AddSingleton<IList<A>>(new List<A> { new A { Value = 1 }, new A { Value = 2 } });

            serviceCollection.AddSingleton<AcquireServiceCollection>((p) =>
            {
                AcquireServiceCollection asc = new AcquireServiceCollection();
                var opts = p.GetRequiredService<IAcquireOptionsCollection<AcquireOptions>>();
                foreach (var opt in opts)
                {
                    if (AcquireProviderTypeDiscoverer.AcquireProviderDic.TryGetValue(opt.ProviderName, out TypeInfo t))
                    {
                        var ap = (IAcquireProvider)p.GetRequiredService(t);
                        asc.Add(ap.Create(opt));
                    }
                }
                return asc;
            });
            serviceCollection.AddSingleton<IDauCore, DauCore>();
        }
    }

    public class A
    {
        public int Value { get; set; }
    }*/
}