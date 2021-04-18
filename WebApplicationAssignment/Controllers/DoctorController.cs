using Microsoft.AspNetCore.Mvc;
using WebApplicationAssignment.Models;



namespace WebApplicationAssignment.Controllers
{
    public class DoctorController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string theTemp)
        {

            // Skicka med data här!!
            ViewBag.tempMsg = TempCheck.CheckTemp(theTemp);
            return View();
        }

        [HttpGet]
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(string theTemp) // Didn't get (float theTemp) from <form> to work; so what the point of type="number"
        {
            float temp;
            if (float.TryParse(theTemp, out temp))      // TryParse does not work with "xx.y", only "xx,y"
            {
                ViewBag.tempMsg = TempCheck.CheckTemp(temp);  // Overloaded function for string input.
            }
            else
            {
                ViewBag.tempMsg = "Noo. Temp!";
            }
            return View();
        }
    }
}
