using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMvc.Models;

namespace TestMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public async Task<string> SendSale()
        {
            string json = "";

            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                Console.WriteLine(Request);
                Console.WriteLine(Request.Body);
                Console.WriteLine(reader);
                json = await reader.ReadToEndAsync();

            }
            Console.WriteLine(json);
            dynamic stuff = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            Console.WriteLine(stuff.subscription);
            //ViewData["Message"] = json;

            //return View();
            return json;

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
