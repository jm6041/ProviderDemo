using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tongfang.DAU
{
    public class AcquireOptions
    {
        public string ProviderName { get; set; }

        /// <summary>
        /// <see cref="FieldEquipment"/>
        /// </summary>
        public FieldEquipment Equipment { get; set; }
        /// <summary>
        /// <see cref="AcquireChannel"/>
        /// </summary>
        public AcquireChannel Channel { get; set; }
    }

    public class ModbusAcquireOptions : AcquireOptions
    {

    }

    public class OpcAcquireOptions : AcquireOptions
    {

    }
}
