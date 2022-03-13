namespace TinyAsp.App.Core.Models
{
    public class RouteToActionMapping
    {
        public string AssociatedController { get; set; } // Class
        public string AssociatedAction { get; set; } // Method
        public string AssociatedHttpMethod { get; set; }
    }

    // RouteToActionMapping[]
    // Class => Method (AssociatedAction) => Reflection => 
    // есть ли у этого метода аттрибут [FromBody] =>
    // если такой аттрибут существует, то есть ли в текущем HTTP-запросе ТЕЛО запроса
    // Попытаться десериализовать тело в тот тип, который указан в аргументе метода

}
