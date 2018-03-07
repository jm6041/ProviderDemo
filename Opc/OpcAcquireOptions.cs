using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public class OpcEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Opc现场设备1";
    }

    public class OpcAcquireChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Opc采集通道01";
    }

    public class OpcAcquireOptions: AcquireOptions
    {
        public OpcEquipment Equipment { get; set; }
        public OpcAcquireChannel Channel { get; set; }
    }
}
