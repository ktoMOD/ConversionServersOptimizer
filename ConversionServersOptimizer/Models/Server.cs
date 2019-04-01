using System.Collections.Generic;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class Server
    {
        public readonly ServerType ServerType;
        public readonly List<ServerItem> Items;

        public Server(ServerType serverType, ServersReader serversReader)
        {
            ServerType = serverType;
            Items = serversReader.GetItems(serverType);
        }
    }
}