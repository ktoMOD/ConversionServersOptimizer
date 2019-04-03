using System.Xml;
using System.Xml.Serialization;
using ConversionServersOptimizer.Models;

namespace ConversionServersOptimizer.Services
{
    public class ServersFileWriter
    {
        public void Save(ServersFile file)
        {
            var serializer = new XmlSerializer(typeof(ServersFile));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var xmlWriterSettings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                Indent = true,
                NewLineOnAttributes = true,
                NewLineHandling = NewLineHandling.None,
                CheckCharacters = false
            };
            using (var xmlWriter = XmlWriter.Create(file.PathToFile, xmlWriterSettings))
            {
                xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"yes\"?>\r\n");
                serializer.Serialize(xmlWriter, file, ns);
            }
        }
    }
}