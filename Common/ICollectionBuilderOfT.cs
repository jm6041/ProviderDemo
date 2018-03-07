using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public interface ICollectionBuilder<T>
    {
        void Add(T service);
        void AddRange(IEnumerable<T> services);
        ICollection<T> Collection { get; }
    }
}
