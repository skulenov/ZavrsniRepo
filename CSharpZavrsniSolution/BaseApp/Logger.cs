using System;
using System.Collections.Generic;
using System.IO;

namespace BaseApp
{
    static class Logger
    {
        /// <summary>
        /// Writes a line of text composed of current time ("@HH:mm:ss # ") string to which the supplied <paramref name="text"/> is concatenated.
        /// Composed string is written to the file given by the <paramref name="path"/> parameter.
        /// </summary>
        /// <param name="path">A path (including a file name) where to write text string. If file of directory do not exist they are created.</param>
        /// <param name="text">A text to be written to the specified path.</param>
        public static void Log(string path, string text)
        {
            try
            {
                /// Create directory if it does not exist, do nothing otherwise
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("@HH:mm:ss # ") + text);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message);
                }
            }
        }

        /// <summary>
        /// Writes a single record of data bytes. 
        /// </summary>
        /// <param name="path">A path (including a file name) where to write data bytes. If file or directory do not exist they are created.</param>
        /// <param name="data">A byte array holding data to be written to the specified path.</param>
        public static void Log(string path, Record record)
        {
            try
            {
                // Create directory if it does not exist, do nothing otherwise
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                // Create or append to given file, open it for writing, 
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    fs.Write(record.GetBytes(), 0, record.GetBytes().Length);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLineAsync(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message);
                }
            }
        }

        /// <summary>
        /// Returns FileRecords object filled with data from given LinkedList of Records.
        /// </summary>
        /// <param name="records">A List of Record objects that hold data.</param>
        /// <returns>A FileRecords object containing data.</returns>
        public static FileRecords Parse(List<Record> records)
        {
            return new FileRecords(records);
        }

        /// <summary>
        /// Parses file given by path and extracts Records in a List.
        /// </summary>
        /// <param name="path">String holding path and filename of the file that is to be parsed.</param>
        /// <returns>A List of Records from given file.</returns>
        public static List<Record> Parse(string path)
        {
            List<Record> fileData = new List<Record>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    while (fs.Position < fs.Length)
                    {
                        byte[] data = new byte[14];
                        // Read in 14 bytes at a time
                        fs.Read(data, 0, 14);
                        // Check data integrity
                        if (!CheckData(data))
                        {
                            break;
                        }
                        fileData.Add(new Record(data));
                    }
                }
                return fileData;
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLineAsync(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message + e.StackTrace);
                }
                fileData.Clear();
                return fileData;
            }
        }

        /// <summary>
        /// Checks data integrity in received byte array.
        /// </summary>
        /// <param name="data">Byte array holding received data that is to be checked.</param>
        /// <returns>True if data passes the check, false otherwise.</returns>
        private static bool CheckData(byte[] data)
        {
            return (data[8] == 204 && data[data.Length-1] == 185);
        }
    }
}