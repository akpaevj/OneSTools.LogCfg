using System;
using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class ConfigNodeBuilder : NodeBuilder
    {
        internal override string TAG => "config";

        /// <summary>
        /// Adds "Log" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder Log(string location, int history, Action<LogNodeBuilder> builder)
        {
            var node = new LogNodeBuilder
            {
                Location = location,
                History = history
            };
            builder(node);
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "dump" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder Dump(Action<DumpNodeBuilder> builder)
        {
            var node = new DumpNodeBuilder();
            builder(node);
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "mem" node
        /// </summary>
        /// <returns></returns>
        public ConfigNodeBuilder Mem()
        {
            Element.Add(new XElement("mem"));

            return this;
        }
        /// <summary>
        /// Adds "plansql" node
        /// </summary>
        /// <returns></returns>
        public ConfigNodeBuilder PlanSql()
        {
            Element.Add(new XElement("plansql"));

            return this;
        }
        /// <summary>
        /// Adds "DefaultLog" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder DefaultLog(string location, int history)
        {
            var node = new DefaultLogNodeBuilder
            {
                Location = location,
                History = history
            };
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "Ftextupd" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder Ftextupd(bool logFiles)
        {
            var node = new FtextupdNodeBuilder
            {
                Logfiles = logFiles
            };
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "Query" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder Query(bool checkActualNullable)
        {
            var node = new QueryNodeBuilder();
            node.CheckActualNullable = checkActualNullable;
            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "dbmslocks" node
        /// </summary>
        /// <returns></returns>
        public ConfigNodeBuilder Dbmslocks()
        {
            Element.Add(new XElement("dbmslocks"));

            return this;
        }
        /// <summary>
        /// Adds "scriptcircrefs" node
        /// </summary>
        /// <returns></returns>
        public ConfigNodeBuilder Scriptcircrefs()
        {
            Element.Add(new XElement("scriptcircrefs"));

            return this;
        }
        /// <summary>
        /// Adds "System" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder System(string level, string component, string _class)
        {
            var node = new SystemNodeBuilder
            {
                Level = level,
                Component = component,
                Class = _class
            };

            Element.Add(node.Element);

            return this;
        }
        /// <summary>
        /// Adds "Leaks" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public ConfigNodeBuilder Leaks(bool collect, Action<LeaksNodeBuilder> builder)
        {
            var node = new LeaksNodeBuilder
            {
                Collect = collect
            };

            builder(node);
            Element.Add(node.Element);

            return this;
        }
    }
}