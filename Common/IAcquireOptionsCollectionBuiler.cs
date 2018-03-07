using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public interface IAcquireOptionsCollectionBuiler<T> where T : AcquireOptions
    {
        void Add(T opt);

        void AddRange(IEnumerable<T> opts);

        IAcquireOptionsCollection<T> OptionsCollection { get; }
    }
}
