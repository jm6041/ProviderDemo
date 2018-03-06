using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Tongfang.DAU
{
    public interface IAcquireService
    {
        void Start();
    }

    public class ModbusAcquireService : IAcquireService
    {
        private FieldEquipment equipment;
        private AcquireChannel channel;
        private ILogger logger;
        public ModbusAcquireService(FieldEquipment equipment, AcquireChannel channel, ILogger logger)
        {
            this.equipment = equipment;
            this.channel = channel;
            this.logger = logger;
        }

        public void Start()
        {
            logger.LogInformation("{0:yyyy-MM-dd HH:mm:ss.ffff} Started!", DateTimeOffset.Now);
        }
    }

    public class OpcAcquireService : IAcquireService
    {
        private FieldEquipment equipment;
        private AcquireChannel channel;
        private ILogger logger;
        public OpcAcquireService(FieldEquipment equipment, AcquireChannel channel, ILogger logger)
        {
            this.equipment = equipment;
            this.channel = channel;
            this.logger = logger;
        }

        public void Start()
        {
            logger.LogInformation("{0:yyyy-MM-dd HH:mm:ss.ffff} Started!", DateTimeOffset.Now);
        }
    }
}
