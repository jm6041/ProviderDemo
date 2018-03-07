using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    internal class CollectionBuilder<T>
    {
        private List<T> _services;

        public CollectionBuilder()
        {
            _services = new List<T>();
        }

        public void Add(T service)
        {
            _services.Add(service);
        }

        public void AddRange(IEnumerable<T> services)
        {
            _services.AddRange(services);
        }

        public ICollection<T> Collection
        {
            get { return _services; }
        }
    }
}
