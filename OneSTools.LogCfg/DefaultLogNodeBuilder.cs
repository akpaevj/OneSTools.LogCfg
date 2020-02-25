using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class DefaultLogNodeBuilder : NodeBuilder
    {
        internal override string TAG => "defaultlog";
        public string Location { get; set; }
        public int History { get; set; }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("location", Location));
            elem.Add(new XAttribute("history", History));

            return elem;
        }
    }
}
