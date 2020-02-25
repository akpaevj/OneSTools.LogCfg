using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class FtextupdNodeBuilder : NodeBuilder
    {
        internal override string TAG => "ftextupd";

        public bool Logfiles { get; set; }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("logfiles", Logfiles));

            return elem;
        }
    }
}
