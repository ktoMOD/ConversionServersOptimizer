using System;
using System.Collections.Generic;
using System.Linq;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Models;

namespace ConversionServersOptimizer.Services
{
    public class ServersFileService
    {
        public void RemoveDuplicationsFromRegularServersFiles(ServersFile commonServersFile, List<ServersFile> regularServersFiles)
        {
            foreach (var regularServersFile in regularServersFiles)
            {
                foreach (var commonServer in commonServersFile.Servers)
                {
                    var fileNameArray = regularServersFile.PathToFile.Split('\\');
                    var fileName = fileNameArray[fileNameArray.Length - 2];
                    var regularFileServer = regularServersFile.Servers.First(x => x.ServerType == commonServer.ServerType);

                    Console.WriteLine(fileName);
                    Console.WriteLine($"{fileName}-{commonServer.ServerType} items count {regularFileServer.Items.Count}");

                    var duplicatedItems = commonServer.Items.Intersect(regularFileServer.Items).ToList();
                    if (duplicatedItems.Count > 0)
                    {
                        Console.WriteLine($"{fileName}-{commonServer.ServerType} duplicated items count {duplicatedItems.Count}");
                    }

                    regularFileServer.Items = regularFileServer.Items.Except(duplicatedItems).ToList();
                    Console.WriteLine($"{fileName}-{commonServer.ServerType} unique items count {regularFileServer.Items.Count}");
                    Console.WriteLine();
                }
            }
        }

        public void MoveCommonItemsToCommonServersFiles(ServersFile commonServersFile, List<ServersFile> regularServersFiles)
        {
            foreach (var serverType in (ServerType[])Enum.GetValues(typeof(ServerType)))
            {
                var listOfLists = new List<List<ServerItem>>();
                foreach (var regularServersFile in regularServersFiles)
                {
                    listOfLists.Add(regularServersFile.Servers.First(x => x.ServerType == serverType).Items);
                }
                var intersection = listOfLists
                    .Skip(1)
                    .Aggregate((previousList, nextList) => previousList.Intersect(nextList).ToList());

                if (intersection.Count <= 0)
                {
                    continue;
                }

                foreach (var regularServersFile in regularServersFiles)
                {
                    var regularServer = regularServersFile.Servers.First(x => x.ServerType == serverType);
                        regularServer.Items = regularServer.Items.Except(intersection).ToList();
                }

                var commonServer = commonServersFile.Servers.First(x => x.ServerType == serverType);
                commonServer.Items = commonServer.Items.Concat(intersection).ToList();
            }
        }
    }
}