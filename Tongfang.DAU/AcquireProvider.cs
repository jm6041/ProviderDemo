using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tongfang.DAU
{
    public interface IAcquireProvider
    {
        IAcquireService Create(AcquireOptions options);
    }

    public class ModbusAcquireProvider : IAcquireProvider
    {
        private ILogger _logger;
        public ModbusAcquireProvider(ILogger<ModbusAcquireService> logger)
        {
            _logger = logger;
        }

        public IAcquireService Create(AcquireOptions options)
        {
            return new ModbusAcquireService(options.Equipment, options.Channel, _logger);
        }
    }

    public class OpcAcquireProvider : IAcquireProvider
    {
        private ILogger _logger;
        public OpcAcquireProvider(ILogger<OpcAcquireService> logger)
        {
            _logger = logger;
        }

        public IAcquireService Create(AcquireOptions options)
        {
            return new OpcAcquireService(options.Equipment, options.Channel, _logger);
        }
    }
}
