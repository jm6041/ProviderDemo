using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public class OpcAcquireProvider : IAcquireProvider<OpcAcquireOptions>
    {
        private ILogger _logger;

        public OpcAcquireProvider(ILogger<OpcAcquireService> logger)
        {
            _logger = logger;
        }

        public IAcquireService Create(OpcAcquireOptions options)
        {
            return new OpcAcquireService(options.Equipment, options.Channel, _logger);
        }
    }
}
