using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tongfang.DAU
{
    public interface IDauCore
    {
        void Start();
    }

    public class DauCore : IDauCore
    {
        private ICollection<IAcquireService> services;
        public DauCore(AcquireServiceCollection services)
        {
            this.services = services;
        }

        public void Start()
        {
            foreach (IAcquireService service in services)
            {
                service.Start();
            }
        }
    }
}
