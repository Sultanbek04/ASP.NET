namespace TinyAsp.App
{
    public static class ActionResultFactory
    {
        public static ActionResult GetActionResult(
            string acceptHeader, object content)
        {
            return acceptHeader switch
            {
                "application/json" => new JsonResult(content),
                "application/xml" => new XmlResult(content),
                "application/yaml" => new YamlResult(content),
                _ => new JsonResult(content),
            };
        }
    }
}
