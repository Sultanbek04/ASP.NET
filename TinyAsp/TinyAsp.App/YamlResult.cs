using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TinyAsp.App
{
    public class YamlResult : ActionResult
    {
        private readonly object _content;
        public YamlResult(object content)
        {
            _content = content;
        }
        public override string ExecuteResult()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(_content);
            return yaml;
        }
    }
}
