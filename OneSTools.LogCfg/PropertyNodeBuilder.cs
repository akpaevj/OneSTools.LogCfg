using System;
using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class PropertyNodeBuilder : NodeBuilder
    {
        internal override string TAG => "property";

        public string Name { get; set; }

        internal PropertyNodeBuilder(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public PropertyNodeBuilder Event(Action<EventNodeBuilder> builder)
        {
            return Event(null, builder);
        }
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public PropertyNodeBuilder Event(string eventName)
        {
            return Event(eventName, null);
        }
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public PropertyNodeBuilder Event(string eventName, Action<EventNodeBuilder> builder)
        {
            var node = new EventNodeBuilder();
            builder?.Invoke(node);
            if (eventName != null)
                node.Equal("name", eventName);
            Element.Add(node.Element);

            return this;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("name", Name));

            return elem;
        }
    }
}
