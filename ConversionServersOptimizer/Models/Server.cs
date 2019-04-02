using System.Collections.Generic;
using System.Xml.Serialization;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public abstract class Server
    {
        public readonly ServerType ServerType;
        [XmlElement("Item")]
        public List<ServerItem> Items;

        public Server(){}

        public Server(ServerType serverType, ServerItemsReader serversReader)
        {
            ServerType = serverType;
            Items = serversReader.GetItems(serverType);
        }
    }
}