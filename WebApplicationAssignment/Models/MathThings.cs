using System;

// This Class is just for handeling the data for the Guessing Controller.
//

namespace WebApplicationAssignment.Models
{
    public static class MathThings
    {
        private static int _turns = 0;

        /// <summary>
        /// GetNumber creates a Random object.
        /// </summary>
        /// <returns>Returns a new random value between 1 and 100.</returns>
        public static int GetNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 101);
        }


        /// <summary>
        /// Test Guess tries to convert a string (from a <form>) to an integer.
        /// </summary>
        /// <param name="guess">The string to convert from.</param>
        /// <returns>Returns the integer of the string or 0 if fail.</returns>
        public static int TestGuess(string guess)
        {
            int anIntValue = 0;

            if (Int32.TryParse(guess, out anIntValue))
            {
                return anIntValue;
            }
            return 0;
        }


        /// <summary>
        /// Adds a number to a private attribute to keep track of a value.
        /// </summary>
        /// <param name="i">The size of increment.</param>
        public static void Add(int i)
        {
            _turns += i;
        }

        /// <summary>
        /// Get the value of the track keeping member.
        /// </summary>
        /// <returns>Returns the actual value.</returns>
        public static int Get()
        {
            return _turns;
        }

        /// <summary>
        /// Clears and Resets the value to Zero.
        /// </summary>
        public static void Clear()
        {
            _turns = 0;
        }

    }

}
