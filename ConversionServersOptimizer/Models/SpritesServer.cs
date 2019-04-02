using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class SpritesServer : Server
    {
        public SpritesServer() : base() { }
        public SpritesServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}