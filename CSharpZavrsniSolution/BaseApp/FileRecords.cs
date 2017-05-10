using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp
{
    /// <summary>
    /// FileRecords class converts a LinkedList of Record objects to four Linked Lists, each containing 
    /// one of the measurements: Time, Temperature, Humidity and Light. All four are public properties with getters.
    /// FilesRecords class is used for getting data to the Chart control which plots it.
    /// </summary>
    public class FileRecords
    {
        private LinkedList<DateTime> time;
        private LinkedList<byte> temperature;
        private LinkedList<byte> humidity;
        private LinkedList<byte> light;

        /// <summary>
        /// Returns LinkedList of DateTime objects.
        /// </summary>
        public LinkedList<DateTime> Time { get => time; }
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public LinkedList<byte> Temperature { get => temperature; }
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public LinkedList<byte> Humidity { get => humidity; }
        /// <summary>
        /// Returns LinkedList of bytes.
        /// </summary>
        public LinkedList<byte> Light { get => light; }

        /// <summary>
        /// Constructor, converts Linked List of Record objects to four Linked Lists of measurements. Each has public getter.
        /// </summary>
        /// <param name="records">File records to be converted to separate lists of measurements.</param>
        public FileRecords(LinkedList<Record> records)
        {
            time = new LinkedList<DateTime>();
            temperature = new LinkedList<byte>();
            humidity = new LinkedList<byte>();
            light = new LinkedList<byte>();

            for (LinkedListNode<Record> node = records.First; node != null; node = node.Next)
            {
                time.AddLast(node.Value.Time);
                temperature.AddLast(node.Value.Temperature);
                humidity.AddLast(node.Value.Humidity);
                light.AddLast(node.Value.Light);
            }
        }
    }
}
