using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    internal class AcquireOptionsCollectionBuilder<T> : CollectionBuilder<T>, IAcquireOptionsCollectionBuilder<T> where T : AcquireOptions
    {
    }
}
