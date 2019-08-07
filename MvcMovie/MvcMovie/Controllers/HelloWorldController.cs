using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        //GET: /HelloWorld/Welcome/
        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["numTimes"] = numTimes;

            return View();

            //return "This is the Welcome method...";
            //HtmlEncoder.Default.Encode($"Hello {name}, ID is: {ID}");
        }


        //GET: /HelloWorld/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
    }
}