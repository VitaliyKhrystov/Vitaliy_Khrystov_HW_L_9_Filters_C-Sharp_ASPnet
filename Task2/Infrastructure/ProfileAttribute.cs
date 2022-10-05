
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Task2.Controllers;
using Task2.Models;

namespace Task2.Infrastructure
{
    public class ProfileAttribute: ActionFilterAttribute
    {
        private List<Person> persons { get; set; }
        private Person person { get; set; }
        public string path = "JSON/person.json";



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!File.Exists(path))
            {
               FileStream file = new FileStream(path, FileMode.Create);
               file.Close();
            }

            if (HomeController.cookieKey != null && context.HttpContext.Request.Cookies[HomeController.cookieKey] != null)
            {
                person = System.Text.Json.JsonSerializer.Deserialize<Person>(context.HttpContext.Request.Cookies[HomeController.cookieKey]);

                persons = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(path)) == null ? new List<Person>() : JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(path));


                if (!persons.Exists(p => p.Email == person.Email))
                    {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    persons.Add(person);
                    using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        System.Text.Json.JsonSerializer.Serialize<List<Person>>(file, persons);
                    }    
                }

                
            }

        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //var viewdata = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            //viewdata["NumberOfIndividualClient"] = persons == null ? 0 : persons.Count;

            //context.Result = new ViewResult()
            //{
            //   // ViewName = "Index",
            //    ViewData = viewdata
            //};
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }

    }
}
