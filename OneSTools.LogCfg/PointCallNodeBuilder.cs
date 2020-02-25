using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class PointCallNodeBuilder : NodeBuilder
    {
        internal override string TAG => "point";

        public string Call { get; set; }

        public PointCallNodeBuilder(string call)
        {
            Call = call;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("call", Call));

            return elem;
        }
    }
}