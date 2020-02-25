using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class DumpNodeBuilder : NodeBuilder
    {
        internal override string TAG => "dump";

        public string Location { get; set; } = null;
        public bool? Create { get; set; } = null;
        public int? Type { get; set; } = null;
        public bool? Prntscrn { get; set; } = null;
        public bool? Externaldump { get; set; } = null;

        internal override XElement Build()
        {
            var elem = base.Build();

            if (Location != null)
                elem.Add(new XAttribute("location", Location));

            if (Create != null)
                elem.Add(new XAttribute("create", Create));

            if (Type != null)
                elem.Add(new XAttribute("type", Type));

            if (Prntscrn != null)
                elem.Add(new XAttribute("prntscrn", Prntscrn));

            if (Externaldump != null)
                elem.Add(new XAttribute("externaldump", Externaldump));

            return elem;
        }
    }
}
