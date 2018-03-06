using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tongfang.DataAcquisition;
using Tongfang.DAU;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 依赖注入扩展
    /// </summary>
    public static class DauDependencyInjectionExtensions
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

            AcquireServicesOptions sopts = new AcquireServicesOptions() { mopt1, mopt2, oopt };

            serviceCollection.TryAddSingleton<AcquireServicesOptions>(sopts);

            foreach (TypeInfo t in AcquireProviderTypeDiscoverer.AcquireProviderDic.Values)
            {
                serviceCollection.AddTransient(t);
            }

            serviceCollection.AddSingleton<IList<A>>(new List<A> { new A { Value = 1 }, new A { Value = 2 } });

            serviceCollection.AddSingleton<AcquireServiceCollection>((p) =>
            {
                AcquireServiceCollection asc = new AcquireServiceCollection();
                var opts = p.GetRequiredService<AcquireServicesOptions>();
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

            var dd = serviceCollection.Where(x => x.ServiceType.FullName.StartsWith("Tongfang"));

            serviceCollection.AddSingleton<IDauCore, DauCore>();
        }
    }

    public class A
    {
        public int Value { get; set; }
    }
}