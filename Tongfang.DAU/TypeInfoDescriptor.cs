using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Tongfang.DAU
{
    /// <summary>
    /// <see cref="TypeInfo"/>描述
    /// </summary>
    public class TypeInfoDescriptor
    {
        private TypeInfo _info;
        private string _displayName;
        private string _assemblyQualifiedName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info"><see cref="TypeInfo"/></param>
        public TypeInfoDescriptor(TypeInfo info)
        {
            _info = info;
            _displayName = GetDisplayName(_info.AsType());
            _assemblyQualifiedName = _info.AssemblyQualifiedName;
        }

        private static string GetDisplayName(Type type)
        {
            DisplayNameAttribute attr = type.GetCustomAttribute<DisplayNameAttribute>();
            return attr == null ? type.FullName : attr.DisplayName;
        }
        /// <summary>
        /// <see cref="System.Reflection.TypeInfo"/>
        /// </summary>
        public TypeInfo TypeInfo { get { return _info; } }
        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get { return _displayName; } }
        /// <summary>
        /// 完整名字，包括类型名，程序集名<see cref="Type.AssemblyQualifiedName"/>
        /// </summary>
        public string AssemblyQualifiedName { get { return _assemblyQualifiedName; } }

        /// <summary>
        /// 过滤指定实现类的类型
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="implTypeName">类名</param>
        /// <returns>过滤后的值</returns>
        public static IEnumerable<TypeInfoDescriptor> Filter(IEnumerable<TypeInfoDescriptor> source, string implTypeName)
        {
            if (string.IsNullOrWhiteSpace(implTypeName))
            {
                return Enumerable.Empty<TypeInfoDescriptor>();
            }
            var daqn = source.Where(t => t.TypeInfo.AssemblyQualifiedName == implTypeName);

            // 使用“,”分离类型名，程序集名
            string[] arr = implTypeName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            // 类名
            string tn = arr[0];
            var dtn = source.Where(t => t.TypeInfo.FullName == tn || t.TypeInfo.Name == tn);
            if (arr.Length >= 2)
            {
                // 程序集名
                string an = arr[1];
                dtn = dtn.Where(x => x.TypeInfo.Assembly.GetName().FullName == an || x.TypeInfo.Assembly.GetName().Name == an);
            }
            return daqn.Concat(dtn).Distinct();
        }
    }
}
