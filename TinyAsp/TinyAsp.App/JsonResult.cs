using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyAsp.App
{
    public class JsonResult : ActionResult
    {
        public object bodyContent;
        public JsonResult(object content)
        {
            bodyContent = content;
        }

        public override string ExecuteResult()
        {
            return JsonConvert.SerializeObject(bodyContent, Formatting.Indented);
        }
    }
}
