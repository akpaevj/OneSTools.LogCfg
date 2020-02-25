using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public abstract class NodeBuilder
    {
        private XElement element;

        internal XElement Element
        {
            get
            {
                if (element is null)
                    Build();
                
                return element;
            }
            set
            {
                element = value;
            }
        }
        internal abstract string TAG { get; }

        internal virtual XElement Build()
        {
            Element = new XElement(TAG);

            return Element;
        }
    }
}
