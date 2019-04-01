using ConversionServersOptimizer.Enums;
using ConversionServersOptimizer.Models;

namespace ConversionServersOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serversFile = new ServersFile(@"D:\ConversionServersOptimizer\TestData\data\models\commonservers.xml", ServersFileType.Common);
        }
    }
}
