namespace ConversionServersOptimizer.Models
{
    public class ServerItem
    {
        public readonly string Id;
        public readonly string File;

        public ServerItem(string id, string file)
        {
            Id = id;
            File = file;
        }
    }
}