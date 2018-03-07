using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    //public interface IAcquireProvider
    //{
    //    IAcquireService Create(AcquireOptions options);
    //}

    public interface IAcquireProvider<T> where T : AcquireOptions
    {
        IAcquireService Create(T options);
    }
}
