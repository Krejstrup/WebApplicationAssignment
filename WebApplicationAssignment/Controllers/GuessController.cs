using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAssignment.Models;

namespace WebApplicationAssignment.Controllers
{
    public class GuessController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // First time and every new reentery: Clear data and create a new guessing number.

            ViewBag.NumbGuess = 0.ToString();       // This is a renemy of understanding how the ViewBag works, and not works.
            //int slask = (int)ViewBag.NumbGuess;   // Couldn't get the ViewBag to work with integers, though it should!

            HttpContext.Session.SetInt32("Secret", MathThings.GetNumber());
            MathThings.Clear();     // Resetting the Loop-turn-value that keeps tracks of how many tries
            return View();
        }

        [HttpPost]
        public IActionResult Index(string guess)
        {
            // If post Index and Post: Al the setups are clear, the number has allready been created.

            int guessInt = MathThings.TestGuess(guess);
            ViewBag.guess = guess;

            if (guessInt != 0)
            {
                MathThings.Add(1);
                ViewBag.NumbGuess = MathThings.Get().ToString(); // = MathThings.Turns;
                ViewBag.guessOK = "ok";

                int secret = (int)HttpContext.Session.GetInt32("Secret");
                if (guessInt == secret) // winner winner chicken dinner! Load a new View for that presentation.
                {
                    return View("GameWon");
                }
                else if (guessInt > secret)
                {
                    ViewBag.status = "to big.";         // Tell the user that the guess was wrong.
                }
                else if (guessInt < secret)
                {
                    ViewBag.status = "to small.";       // Tell the user that the guess was wrong.
                }
            }
            else
            {
                ViewBag.guessOK = "no";                 // We are not expected to ever see this, but failsafe anyways.
            }
            return View();
        }
    }
}
