using System;
using System.Xml.Linq;

namespace OneSTools.LogCfg
{
    public class LogCfgBuilder
    {
        private XNamespace _ns;
        private XDocument _document;

        public LogCfgBuilder()
        {
            _document = new XDocument();
        }
        /// <summary>
        /// Forces using the standard "xmlns" of the LogCfg file
        /// </summary>
        /// <returns></returns>
        public LogCfgBuilder UseStandartNamespace()
        {
            _ns = "http://v8.1c.ru/v8/tech-log";

            return this;
        }
        /// <summary>
        /// Sets "xmlns"
        /// </summary>
        /// <param name="ns">Namespace string</param>
        /// <returns></returns>
        public LogCfgBuilder SetNamespace(string ns)
        {
            _ns = ns;

            return this;
        }
        /// <summary>
        /// Adds "config" node
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public LogCfgBuilder Config(Action<ConfigNodeBuilder> builder)
        {
            var node = new ConfigNodeBuilder();
            builder(node);
            _document.Add(node.Element);

            return this;
        }
        public void Save(string fileName)
        {
            SetNamespace();

            _document.Save(fileName);
        }
        public string Build()
        {
            SetNamespace();

            return _document.ToString();
        }

        internal void SetNamespace(XElement element = null)
        {
            var elem = element ?? _document.Root;

            elem.Name = _ns + elem.Name.LocalName;

            foreach (var e in elem.Elements())
            {
                SetNamespace(e);
            }
        }
    }
}
