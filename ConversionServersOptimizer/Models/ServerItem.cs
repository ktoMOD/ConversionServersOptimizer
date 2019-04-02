using System.Xml.Serialization;

namespace ConversionServersOptimizer.Models
{
    public class ServerItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttributeAttribute("file")]
        public string File { get; set; }

        public ServerItem(){}

        public ServerItem(string id, string file)
        {
            Id = id;
            File = file;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ServerItem;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}