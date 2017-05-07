using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp
{
    public class FileRecords
    {
        private LinkedList<DateTime> time;
        private LinkedList<byte> temperature;
        private LinkedList<byte> humidity;
        private LinkedList<byte> light;

        public LinkedList<DateTime> Time { get => time; }
        public LinkedList<byte> Temperature { get => temperature; }
        public LinkedList<byte> Humidity { get => humidity; }
        public LinkedList<byte> Light { get => light; }

        public FileRecords(LinkedList<Record> records)
        {
            FormatRecords(records);
        }

        private void FormatRecords(LinkedList<Record> records)
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
            //foreach (Record record in records)
            //{
            //    time.AddLast(record.Time);
            //    temperature.AddLast(record.Temperature);
            //    humidity.AddLast(record.Humidity);
            //    light.AddLast(record.Light);
            //}
        }
    }
}
