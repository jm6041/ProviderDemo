using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tongfang.DAU
{
    public interface IAcquireProviderTypeDiscoverer<T> where T : AcquireOptions
    {
        IList<TypeInfo> AcquireProviderList { get; }
    }

    /// <summary>
    /// 服务实现类型发现
    /// </summary>
    public class AcquireProviderTypeDiscoverer<T> : IAcquireProviderTypeDiscoverer<T> where T : AcquireOptions
    {
        private static readonly Dictionary<string, TypeInfo> _dic;

        static AcquireProviderTypeDiscoverer()
        {
            _dic = new Dictionary<string, TypeInfo>();
            ICollection<Assembly> assemblys = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ab in assemblys)
            {
                var ts = ab.DefinedTypes.Where(x => x.IsPublic && !x.IsInterface && !x.IsAbstract && x.ImplementedInterfaces.Contains(typeof(IAcquireProvider<T>)));
                foreach (TypeInfo t in ts)
                {
                    string key = t.AssemblyQualifiedName;
                    if (!_dic.TryGetValue(key, out var val))
                    {
                        _dic.Add(key, t);
                    }
                }
            }
        }

        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="filter">类型实现的接口</param>
        /// <returns>实现了指定接口的类型集合</returns>
        public static Dictionary<string, TypeInfo> AcquireProviderDic
        {
            get
            {
                return _dic;
            }
        }

        public IList<TypeInfo> AcquireProviderList
        {
            get { return _dic.Values.ToArray(); }
        }
    }
}
