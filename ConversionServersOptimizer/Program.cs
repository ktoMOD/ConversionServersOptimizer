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

            var configValues = new ConfigReader($@"{PathToMainDirectory}\ConversionServersOptimizer.config").GetConfig();
            var files = new List<ServersFile>();
            foreach (var config in configValues)
            {
                files.Add(new ServersFile($@"{PathToMainDirectory}{config.Key}", config.Value));
            }

            var regularFiles = files.Where(x => x.FileType == ServersFileType.Regular).ToList();
            var commonFile = files.First(x => x.FileType == ServersFileType.Common);
            var regularMapsFiles = files.Where(x => x.FileType == ServersFileType.RegularMaps).ToList();
            var commonMapsFile = files.First(x => x.FileType == ServersFileType.CommonMaps);
            var regularMultiplayerFiles = files.Where(x => x.FileType == ServersFileType.RegularMultiplayer).ToList();
            var commonMultiplayerFile = files.First(x => x.FileType == ServersFileType.CommonMultiplayer);

            var serversFileService = new ServersFileService();
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonFile, regularFiles);
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonMapsFile, regularMapsFiles);
            serversFileService.RemoveDuplicationsFromRegularServersFiles(commonMultiplayerFile, regularMultiplayerFiles);

            serversFileService.MoveCommonItemsToCommonServersFiles(commonFile, regularFiles);
            serversFileService.MoveCommonItemsToCommonServersFiles(commonMapsFile, regularMapsFiles);
            serversFileService.MoveCommonItemsToCommonServersFiles(commonMultiplayerFile, regularMultiplayerFiles);

            var serializer = new XmlSerializer(typeof(ServersFile));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var xmlWriterSettings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                Indent = true,
                NewLineOnAttributes = true,
                NewLineHandling = NewLineHandling.None,
                CheckCharacters = false
            };
            using (var xmlWriter = XmlWriter.Create(@"c:\temp\garage.xml", xmlWriterSettings))
            {
                xmlWriter.WriteRaw("<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"yes\"?>\r\n");
                serializer.Serialize(xmlWriter, commonFile, ns);
            }
        }
    }
}
