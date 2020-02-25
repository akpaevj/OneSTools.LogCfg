using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class PointOnOffNodeBuilder : NodeBuilder
    {
        internal override string TAG => "point";

        public string On { get; set; }
        public string Off { get; set; }

        public PointOnOffNodeBuilder(string on, string off)
        {
            On = on;
            Off = off;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("on", On));
            elem.Add(new XAttribute("off", Off));

            return elem;
        }
    }
}