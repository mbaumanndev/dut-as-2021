using Microsoft.AspNetCore.Mvc;

namespace Iut.Demo.Web.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET /HelloWorld/
        public IActionResult Index()
        {
            ViewData["Hello"] = "Bienvenue du controller";
            ViewData["Count"] = 1;
            return View();
        }

        // GET /HelloWorld/Bienvenue/?nom=Maxime
        // GET /HelloWorld/Bienvenue/12?nom=Maxime
        public IActionResult Bienvenue(string nom, int id = 1)
        {
            ViewData["Hello"] = $"Bienvenue {nom}";
            ViewData["Count"] = id;
            return View("Index");
        }
    }
}
