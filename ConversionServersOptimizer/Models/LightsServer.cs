using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class LightsServer : Server
    {
        public LightsServer() : base() { }
        public LightsServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}