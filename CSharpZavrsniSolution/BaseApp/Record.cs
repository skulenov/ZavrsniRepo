using System;
using System.Collections.Generic;

namespace BaseApp
{
    /// <summary>
    /// The Record class represents a single record, when it is first recorded or received by Server. It consists of public properties 
    /// Time, Temperature, Humidity and Light, and a simple serialization method that returns a byte array that represents a Record
    /// instance that it has been called upon. The bytes are ordered in the following order:
    /// =========================================
    /// [0-7]   - 8 bytes = Time (Ticks)
    /// [8]     - 1 byte  = Start Data Mark (DEC 204)
    /// [9]     - 1 byte  = ID byte ('@')
    /// [10]    - 1 byte  = Temperature
    /// [11]    - 1 byte  = Humidity
    /// [12]    - 1 byte  = Light
    /// [13]    - 1 byte  = End Data Mark (DEC 185)
    /// -----------------------------------------
    /// [0-13]  - 14 bytes = Total Record Length
    /// =========================================
    /// </summary>
    public class Record
    {
        public DateTime Time { get => time; }
        public byte Temperature { get => temperature; }
        public byte Humidity { get => humidity; }
        public byte Light { get => light; }

        private DateTime time;
        private byte temperature;
        private byte humidity;
        private byte light;

        public Record(byte[] data)
        {
            time = (data.Length == 14) ? DateTime.FromBinary(BitConverter.ToInt64(data, 0)) :  DateTime.Now;
            temperature = data[data.Length - 4];
            humidity = data[data.Length - 3];
            light = data[data.Length - 2];
        }

        /// <summary>
        /// Creates a byte array that holds this Record's data.
        /// </summary>
        /// <returns>A byte array holding this Record's data.</returns>
        public byte[] GetBytes()
        {
            //byte[] datetime = BitConverter.GetBytes(Time.Ticks);
            byte[] bytes = new byte[14];

            BitConverter.GetBytes(Time.Ticks).CopyTo(bytes, 0);
            bytes[8] = 204;
            bytes[9] = Convert.ToByte('@');
            bytes[10] = Temperature;
            bytes[11] = Humidity;
            bytes[12] = Light;
            bytes[13] = 185;

            return bytes;
        }
    }
}