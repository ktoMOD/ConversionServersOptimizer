using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class SoundsServer : Server
    {
        public SoundsServer() : base() { }
        public SoundsServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}