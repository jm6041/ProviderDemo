using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public interface IAcquireOptionsCollectionBuilder<T> : ICollectionBuilder<T> where T : AcquireOptions
    {
    }
}
