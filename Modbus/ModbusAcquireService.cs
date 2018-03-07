using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Tongfang.DAU
{
    public class ModbusAcquireService : IAcquireService
    {
        private ModbusEquipment equipment;
        private ModbusAcquireChannel channel;
        private ILogger logger;
        public ModbusAcquireService(ModbusEquipment equipment, ModbusAcquireChannel channel, ILogger logger)
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
