using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tongfang.DAU
{
    //internal class AcquireServiceCollection : List<IAcquireService>, IServiceCollection
    //{

    //}

    //public interface ICollectionBuilder<T>
    //{
    //    void Add(T service);
    //    void AddRange(IEnumerable<T> services);
    //    ICollection<T> Collection { get; }
    //}

    public class AcquireServiceCollectionBuilder : CollectionBuilder<IAcquireService>
    {
        public DateTime V = DateTime.Now;
    }

    public abstract class CollectionBuilder<T>
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
