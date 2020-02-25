using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class EventNodeBuilder : NodeBuilder
    {
        internal override string TAG => "event";

        /// <summary>
        /// Adds the "Equal" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder Equal(string property, string value)
        {
            return AddFilter("eq", property, value);
        }
        /// <summary>
        /// Adds the "Not equal" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder NotEqual(string property, string value)
        {
            return AddFilter("ne", property, value);
        }
        /// <summary>
        /// Adds the "Like" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder Like(string property, string value)
        {
            return AddFilter("like", property, value);
        }
        /// <summary>
        /// Adds the "Greater than or equal" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder GreaterOrEqual(string property, string value)
        {
            return AddFilter("ge", property, value);
        }
        /// <summary>
        /// Adds the "Greater than" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder Greater(string property, string value)
        {
            return AddFilter("gt", property, value);
        }
        /// <summary>
        /// Adds the "Less than or equal" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder LessOrEqual(string property, string value)
        {
            return AddFilter("le", property, value);
        }
        /// <summary>
        /// Adds the "Less than" filter
        /// </summary>
        /// <param name="property">Name of the filtered property</param>
        /// <param name="value">Value of the filtered property</param>
        public EventNodeBuilder Less(string property, string value)
        {
            return AddFilter("lt", property, value);
        }

        private EventNodeBuilder AddFilter(string tag, string property, string value)
        {
            var elem = new XElement(tag);
            elem.Add(new XAttribute("property", property));
            elem.Add(new XAttribute("value", value));

            Element.Add(elem);

            return this;
        }
    }
}
