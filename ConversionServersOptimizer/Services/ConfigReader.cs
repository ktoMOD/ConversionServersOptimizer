using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ConversionServersOptimizer.Enums;

namespace ConversionServersOptimizer.Services
{
    public class ConfigReader
    {
        private readonly XmlDocument _xmlDoc;

        public ConfigReader(string uri)
        {
            using (var xmlFile = new FileStream(uri, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                _xmlDoc = new XmlDocument();
                _xmlDoc.Load(xmlFile);
            }
        }

        public Dictionary<string, ServersFileType> GetConfig()
        {
            var result = new Dictionary<string, ServersFileType>();
            var xmlNodes = _xmlDoc.GetElementsByTagName("Value");
            for (var i = 0; i <= xmlNodes.Count - 1; i++)
            {
                var xmlAttributeCollection = xmlNodes[i].Attributes;
                if (xmlAttributeCollection == null) continue;

                var path = xmlAttributeCollection["path"].Value;
                var type = (ServersFileType) Enum.Parse(typeof(ServersFileType),
                    xmlAttributeCollection["type"]?.Value, true);
                result.Add(path, type);
            }
            return result;
        }
    }
}