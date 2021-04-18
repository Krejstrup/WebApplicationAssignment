using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAssignment.Views.Shared
{
    public class HomeController : Controller    // Controller hanterar HTTP requests
    {
        [HttpGet]
        public IActionResult Index()    // Det ska alltid finnas en Hem-Index
        {
            return View();  // Detta hämtas normalt från filen Views/Home/index
        }

        // Här lägger vi alla funktioner för vad som ska hända när en HTTP-request kommer in.
        // Controllern använder en Model för att få fram data och en View för att visa resultatet.
        // Metoder i en Controller är olika typer av Actions.
        // Controllern skapar alla Cookies, ViewBags och Session Cookies. Både Controllern och View använder dem.
        // Cookies fungerar som en dictionary med key/value samt har en expiry time.
        // För ViewBag kan vi behöva använda IS/AS-metoder och !=null när vi läser dem.
        // ViewBag kan ju innehålla vad som helst och skickas bara från Controllern till en View.
        // Vill vi använda data för en längre period så använder vi hellre Session Cookie som ligger på Servern.
        // Standard expiery tid för Session är 20 minuter.


        /*
         [HttpPost] // Filter!
         public IActionResult Create(Course course)
         {
            return View();  // Om inget är specificerat så letar den efter standard, annars skicka in strängen på EXAKT rätt namn
         }
         */

        [HttpGet]
        public IActionResult About()    // Right klick/ new Enpty Razor View
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Projects() // exact same name as in Form
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string message)
        {
            // ViewBag.??
            return View("ContactList"); // open the page showing this data
        }
    }
}
