using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class PointProcNodeBuilder : NodeBuilder
    {
        internal override string TAG => "point";

        public string Proc { get; set; }

        public PointProcNodeBuilder(string proc)
        {
            Proc = proc;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("proc", Proc));

            return elem;
        }
    }
}