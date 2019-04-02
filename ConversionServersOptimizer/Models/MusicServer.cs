using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class MusicServer : Server
    {
        public MusicServer() : base() { }
        public MusicServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}