using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp
{
    /// <summary>
    /// FileRecords class converts a List of Record objects to four Lists, each containing 
    /// one of the measurements: Time, Temperature, Humidity and Light. All four are public properties with getters.
    /// FilesRecords class is used for getting data to the Chart control which plots it.
    /// </summary>
    public class FileRecords
    {
        /// <summary>
        /// Returns LinkedList of DateTime objects.
        /// </summary>
        public readonly List<DateTime> Time;
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public readonly List<byte> Temperature;
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public readonly List<byte> Humidity;
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public readonly List<byte> Light;

        /// <summary>
        /// Constructor, converts List of Record objects to four Lists of measurements. Each has public getter.
        /// </summary>
        /// <param name="records">File records to be converted to separate lists of measurements.</param>
        public FileRecords(List<Record> records)
        {
            Time = new List<DateTime>();
            Temperature = new List<byte>();
            Humidity = new List<byte>();
            Light = new List<byte>();

            for (int i = 0; i < records.Count; ++i)
            {
                Time.Add(records[i].Time);
                Temperature.Add(records[i].Temperature);
                Humidity.Add(records[i].Humidity);
                Light.Add(records[i].Light);
            }
        }
    }
}
