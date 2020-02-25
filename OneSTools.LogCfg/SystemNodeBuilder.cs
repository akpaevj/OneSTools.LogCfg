using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class SystemNodeBuilder : NodeBuilder
    {
        internal override string TAG => "system";
        public string Level { get; set; }
        public string Component { get; set; }
        public string Class { get; set; }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("level", Level));
            elem.Add(new XAttribute("component", Component));
            elem.Add(new XAttribute("class", Class));

            return elem;
        }
    }
}
