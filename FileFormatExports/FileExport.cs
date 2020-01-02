using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileFormatExports
{
    public class FileExport
    {
        public static Task CSV<T>(List<T> input)
        {
            string filepath = DateTime.UtcNow.ToFileTimeUtc() + ".csv";

            using (var writer = new StreamWriter(filepath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(input);
            }

            return Task.CompletedTask;
        }

        public static Task JSON<T>(List<T> input)
        {
            string filepath = DateTime.UtcNow.ToFileTimeUtc() + ".json";
            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, input);
            }

            return Task.CompletedTask;
        }

        public static Task XML<T>(List<T> input)
        {
            string filePath = DateTime.UtcNow.ToFileTimeUtc() + ".xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, input);
                writer.Close();
            }

            return Task.CompletedTask;
        }
    }
}