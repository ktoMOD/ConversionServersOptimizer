using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class AnimatedModelsServer : Server
    {
        public AnimatedModelsServer() : base(){ }
        public AnimatedModelsServer(ServerType serverType, ServerItemsReader serversReader)
            : base(serverType, serversReader) { }

    }
}