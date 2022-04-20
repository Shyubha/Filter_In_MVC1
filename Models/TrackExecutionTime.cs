using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Filter_In_MVC1.Models
{
    public class TrackExecutionTime :Attribute, IActionFilter,IResultFilter
    {
        public void GetMesage(string msg)
        {
            File.AppendAllText(Path.GetFullPath(@"C:\Users\HP\source\repos\Filter_In_MVC1\Test\test.txt"), msg);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string msg="\nOn action executed ->"+DateTime.Now.ToString()+"\n";
            GetMesage(msg);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string msg = "\n On action executing->" + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
           string msg="On result executed-> "+ context.RouteData.Values["controller"].ToString() +
                "->" + context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string msg = "On result executing ->" + context.RouteData.Values["controller"].ToString() +
                "->" + context.RouteData.Values["action"].ToString() + " " + DateTime.Now.ToString() + "\n";
            GetMesage(msg);
        }
    }
}
