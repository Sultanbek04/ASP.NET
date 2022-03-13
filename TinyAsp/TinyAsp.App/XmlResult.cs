using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TinyAsp.App
{
    internal static class XmlSerializerWrapper
    {
        public static string Serialize(object value)
        {
            using var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(stringwriter, value);
            return stringwriter.ToString();
        }
    }

    public class XmlResult : ActionResult
    {
        private readonly object _content;
        public XmlResult(object content)
        {
            _content = content;
        }

        public override string ExecuteResult()
        {
            return XmlSerializerWrapper.Serialize(_content);
        }
    }
}
