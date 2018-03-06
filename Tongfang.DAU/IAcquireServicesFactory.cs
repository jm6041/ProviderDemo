using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tongfang.DAU
{
    public class AcquireServiceCollection : List<IAcquireService>
    {

    }

    public interface IAcquireServiceCollectionFactory
    {
        AcquireServiceCollection Create();
    }

    public class AcquireServiceCollectionFactory : IAcquireServiceCollectionFactory
    {
        private AcquireServicesOptions _options;
        //private Dictionary<string, TypeInfo> _providerDic;

        public AcquireServiceCollectionFactory(AcquireServicesOptions options)
        {
            _options = options;
            //_providerDic = discoverer.AcquireProviderDic;
        }

        public AcquireServiceCollection Create()
        {
            AcquireServiceCollection asc = new AcquireServiceCollection();
            foreach (AcquireOptions opt in _options)
            {
                //string implTypeName = opt.ProviderName;
                //if (_providerDic.TryGetValue(opt.ProviderName, out TypeInfo type))
                //{
                    
                //}
            }
            return asc;
        }
    }
}
