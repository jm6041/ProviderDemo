using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public interface IAcquireOptionsCollection<T> : ICollection<T> where T : AcquireOptions
    {
    }
}
