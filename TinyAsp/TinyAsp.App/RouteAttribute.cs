using System;

namespace TinyAsp.App
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RouteAttribute : Attribute
    {
        public string Route { get; private set; }
        public RouteAttribute(string route)
        {
            Route = route;
        }
    }
}
