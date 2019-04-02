using System.Collections.Generic;
using System.IO;
using System.Xml;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Models;

namespace ConversionServersOptimizer.Services
{
    public class ServerItemsReader
    {
        private readonly XmlDocument _xmlDoc;

        public ServerItemsReader(string uri)
        {
            using (var xmlFile = new FileStream(uri, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                _xmlDoc = new XmlDocument();
                _xmlDoc.Load(xmlFile);
            }
        }

        public List<ServerItem> GetItems(ServerType serverType)
        {
            var result = new List<ServerItem>();
            var xmlNode = _xmlDoc.GetElementsByTagName(serverType.ToString());
            if (xmlNode.Count == 0)
            {
                return result;
            }
            var childNodes = xmlNode[0].ChildNodes;
            for (var i = 0; i <= childNodes.Count - 1; i++)
            {
                var xmlAttributeCollection = childNodes[i].Attributes;
                if (xmlAttributeCollection == null) continue;

                var id = xmlAttributeCollection["id"].Value;
                var file = xmlAttributeCollection["file"]?.Value;
                result.Add(new ServerItem(id, file));
            }
            return result;
        }
    }
}