using System;
using System.Collections.Generic;
using System.Text;

namespace Tongfang.DAU
{
    public class ModbusEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Modbus现场设备1";
    }

    public class ModbusAcquireChannel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Modbus采集通道01";
    }

    public class ModbusAcquireOptions: AcquireOptions
    {
        public ModbusEquipment Equipment { get; set; }
        public ModbusAcquireChannel Channel { get; set; }
    }
}
