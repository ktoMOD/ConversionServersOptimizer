using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Models;
using ConversionServersOptimizer.Services;

namespace ConversionServersOptimizer
{
    class Program
    {
        public static string PathToMainDirectory { get; set; } = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            for (var i = 0; i != args.Length; ++i)
            {
                if (!args[i].Contains("-path=")) continue;

                var param = args[i].Substring(6).Trim('"');
                if (!string.IsNullOrEmpty(param))
                {
                    PathToMainDirectory += $@"\{param}";
                }
            }

            var configValues = new ConfigReader($@"{PathToMainDirectory}\ConversionServersOptimizer.cfg").GetConfig();
            var files = new List<ServersFile>();
            foreach (var config in configValues)
            {
                files.Add(new ServersFile($@"{PathToMainDirectory}{config.Key}", config.Value));
            }

            var regularFiles = files.Where(x => x.FileType == ServersFileType.Regular).ToList();
            var commonFile = files.FirstOrDefault(x => x.FileType == ServersFileType.Common);
            var regularArcadeFiles = files.Where(x => x.FileType == ServersFileType.RegularArcade).ToList();
            var commonArcadeFile = files.FirstOrDefault(x => x.FileType == ServersFileType.CommonArcade);
            var regularEm1Files = files.Where(x => x.FileType == ServersFileType.RegularEm1).ToList();
            var commonEm1File = files.FirstOrDefault(x => x.FileType == ServersFileType.CommonEm1);
            var regularMultiplayerFiles = files.Where(x => x.FileType == ServersFileType.RegularMultiplayer).ToList();
            var commonMultiplayerFile = files.FirstOrDefault(x => x.FileType == ServersFileType.CommonMultiplayer);

            var serversFileService = new ServersFileService();
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonFile, regularFiles);
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonArcadeFile, regularArcadeFiles);
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonEm1File, regularEm1Files);
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonMultiplayerFile, regularMultiplayerFiles);

            serversFileService.MoveCommonItemsToCommonServersFiles(commonFile, regularFiles);
            serversFileService.MoveCommonItemsToCommonServersFiles(commonArcadeFile, regularArcadeFiles);
            serversFileService.MoveCommonItemsToCommonServersFiles(commonEm1File, regularEm1Files);
            serversFileService.MoveCommonItemsToCommonServersFiles(commonMultiplayerFile, regularMultiplayerFiles);

            var allServersFiles = regularFiles.Concat(regularArcadeFiles).Concat(regularEm1Files).Concat(regularMultiplayerFiles).Concat(new List<ServersFile>{ commonFile, commonArcadeFile, commonEm1File, commonMultiplayerFile });
            var serversFileWriter = new ServersFileWriter();
            foreach (var serversFile in allServersFiles)
            {
                if (serversFile == null) continue;
                serversFileWriter.Save(serversFile);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
