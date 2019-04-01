using System;
using System.Collections.Generic;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    public class ServersFile
    {
        public readonly string PathToFile;
        public readonly ServersFileType FileType;
        public List<Server> Services;
        private readonly ServersReader _serversReader;

        public ServersFile(string pathToFile, ServersFileType fileType)
        {
            _serversReader = new ServersReader(pathToFile);
            PathToFile = pathToFile;
            FileType = fileType;
            Services = new List<Server>();
            foreach (ServerType serverType in (ServerType[])Enum.GetValues(typeof(ServerType)))
            {
                Services.Add(new Server(serverType, _serversReader));
            }
        }
    }
}