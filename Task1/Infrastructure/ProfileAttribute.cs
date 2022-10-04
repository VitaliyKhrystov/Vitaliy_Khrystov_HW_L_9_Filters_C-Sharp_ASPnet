using Microsoft.AspNetCore.Mvc.Filters;

namespace Task1.Infrastructure
{
    public class ProfileAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StreamWriter stream = new StreamWriter("Logs/log.txt", true);
            stream.WriteLine(new String('-', 100));
            stream.WriteLine($"Action: {context.ActionDescriptor.DisplayName}; Time: {DateTime.Now}");
            stream.WriteLine();
            stream.Close();
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
