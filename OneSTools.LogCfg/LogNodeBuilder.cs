using System;
using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class LogNodeBuilder : NodeBuilder
    {
        internal override string TAG => "log";
        public string Location { get; set; }
        public int History { get; set; }
        
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public LogNodeBuilder ForEvent(string eventName)
        {
            return ForEvent(eventName, null);
        }
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public LogNodeBuilder ForEvent(Action<EventNodeBuilder> builder)
        {
            return ForEvent(null, builder);
        }
        /// <summary>
        /// Adds "Event" node
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public LogNodeBuilder ForEvent(string eventName, Action<EventNodeBuilder> builder)
        {
            var node = new EventNodeBuilder();
            builder?.Invoke(node);
            var elem = node.Build();
            if (eventName != null)
                node.Equal("name", eventName);
            Element.Add(elem);

            return this;
        }
        /// <summary>
        /// Adds "Property" node
        /// </summary>
        /// <param name="name">Property name</param>
        /// <returns></returns>
        public LogNodeBuilder CollectProperty(string name)
        {
            return CollectProperty(name, null);
        }
        /// <summary>
        /// Adds "Property" node
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public LogNodeBuilder CollectProperty(string name, Action<PropertyNodeBuilder> builder)
        {
            var node = new PropertyNodeBuilder(name);
            builder?.Invoke(node);
            Element.Add(node.Element);

            return this;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("location", Location));
            elem.Add(new XAttribute("history", History));

            return elem;
        }
    }
}
