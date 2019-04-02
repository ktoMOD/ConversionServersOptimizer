using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer.Models
{
    [XmlRoot("Servers")]
    public class ServersFile
    {
        public readonly string PathToFile;
        public readonly ServersFileType FileType;
        [XmlElement("AnimatedModelsServer", typeof(AnimatedModelsServer))]
        [XmlElement("DecalsServer", typeof(DecalsServer))]
        [XmlElement("LightsServer", typeof(LightsServer))]
        [XmlElement("MusicServer", typeof(MusicServer))]
        [XmlElement("ParticlesServer", typeof(ParticlesServer))]
        [XmlElement("ProjectorsServer", typeof(ProjectorsServer))]
        [XmlElement("SoundsServer", typeof(SoundsServer))]
        [XmlElement("SpritesServer", typeof(SpritesServer))]
        public List<Server> Servers;

        public ServersFile(){}

        public ServersFile(string pathToFile, ServersFileType fileType)
        {
            var serverItemsReader = new ServerItemsReader(pathToFile);
            PathToFile = pathToFile;
            FileType = fileType;
            Servers = new List<Server>();
            foreach (ServerType serverType in (ServerType[])Enum.GetValues(typeof(ServerType)))
            {
                switch (serverType)
                {
                    case ServerType.AnimatedModelsServer:
                        Servers.Add(new AnimatedModelsServer(serverType, serverItemsReader));
                        break;
                    case ServerType.DecalsServer:
                        Servers.Add(new DecalsServer(serverType, serverItemsReader));
                        break;
                    case ServerType.LightsServer:
                        Servers.Add(new LightsServer(serverType, serverItemsReader));
                        break;
                    case ServerType.MusicServer:
                        Servers.Add(new MusicServer(serverType, serverItemsReader));
                        break;
                    case ServerType.ParticlesServer:
                        Servers.Add(new ParticlesServer(serverType, serverItemsReader));
                        break;
                    case ServerType.ProjectorsServer:
                        Servers.Add(new ProjectorsServer(serverType, serverItemsReader));
                        break;
                    case ServerType.SoundsServer:
                        Servers.Add(new SoundsServer(serverType, serverItemsReader));
                        break;
                    case ServerType.SpritesServer:
                        Servers.Add(new SpritesServer(serverType, serverItemsReader));
                        break;
                }
            }
        }
    }
}