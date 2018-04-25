using System;
using System.IO;
using System.Xml.Serialization;
using BoxExpress;

namespace BoxExpress
{
    public static class Kekus
    {
        private static readonly XmlSerializer Xml = new XmlSerializer(typeof(FormSample));
        public static void WriteToFile(string fileName, FormSample data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xml.Serialize(fileStream, data);
            }
        }

        public static FormSample LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (FormSample)Xml.Deserialize(fileStream);
            }
        }

        public static void WriteToFile(string fileName, object mem)
        {
            throw new NotImplementedException();
        }
    }
}