using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Tongfang.DAU
{
    public class ModbusAcquireProvider : IAcquireProvider<ModbusAcquireOptions>
    {
        private ILogger _logger;

        public ModbusAcquireProvider(ILogger<ModbusAcquireService> logger)
        {
            _logger = logger;
        }

        public IAcquireService Create(ModbusAcquireOptions options)
        {
            return new ModbusAcquireService(options.Equipment, options.Channel, _logger);
        }
    }
}
