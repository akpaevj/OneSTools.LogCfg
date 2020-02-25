using System;
using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class LeaksNodeBuilder : NodeBuilder
    {
        internal override string TAG => "leaks";

        public bool Collect { get; set; }

        /// <summary>
        /// Adds "point" node with "call" attribute
        /// </summary>
        /// <param name="call">"server" or "client"</param>
        /// <returns></returns>
        public LeaksNodeBuilder PointCall(string call)
        {
            var node = new PointCallNodeBuilder(call);
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "point" node with "proc" attribute
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public LeaksNodeBuilder PointProc(string proc)
        {
            var node = new PointProcNodeBuilder(proc);
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "point" node with "on" and "off" attributes
        /// </summary>
        /// <param name="on"></param>
        /// <param name="off"></param>
        /// <returns></returns>
        public LeaksNodeBuilder PointOnOff(string on, string off)
        {
            var node = new PointOnOffNodeBuilder(on, off);
            Element.Add(node.Element);

            return this;
        }

        internal override XElement Build()
        {
            var elem = base.Build();
            elem.Add(new XAttribute("collect", Collect));

            return elem;
        }
    }
}
