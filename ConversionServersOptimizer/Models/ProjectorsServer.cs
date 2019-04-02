using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class ProjectorsServer : Server
    {
        public ProjectorsServer() : base() { }
        public ProjectorsServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}