using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tongfang.DAU
{
    internal class AcquireOptionsCollection<T> : List<T>, IAcquireOptionsCollection<T> where T : AcquireOptions
    {

    }
    public class AcquireOptionsCollectionBuilder<T> : IAcquireOptionsCollectionBuiler<T> where T : AcquireOptions
    {
        private AcquireOptionsCollection<T> _opts;

        public AcquireOptionsCollectionBuilder()
        {
            _opts = new AcquireOptionsCollection<T>();
        }

        public void Add(T opt)
        {
            _opts.Add(opt);
        }

        public void AddRange(IEnumerable<T> opts)
        {
            _opts.AddRange(opts);
        }

        public IAcquireOptionsCollection<T> OptionsCollection
        {
            get { return _opts; }
        }
    }
}
