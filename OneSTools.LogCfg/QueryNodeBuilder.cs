using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class QueryNodeBuilder : NodeBuilder
    {
        internal override string TAG => "query";

        public bool CheckActualNullable { get; set; }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("checkActualNullable", CheckActualNullable));

            return elem;
        }
    }
}
