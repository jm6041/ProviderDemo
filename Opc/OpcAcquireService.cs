using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Tongfang.DAU
{
    public class OpcAcquireService : IAcquireService
    {
        private OpcEquipment equipment;
        private OpcAcquireChannel channel;
        private ILogger logger;
        public OpcAcquireService(OpcEquipment equipment, OpcAcquireChannel channel, ILogger logger)
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
