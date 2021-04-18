using System;
using System.IO;
using System.Collections.Generic;


namespace WebApplicationAssignment.Models
{
    public class FIleMessengerService : IMessageService
    {
        public bool Save(float temp)
        {
            try
            {
                using (var writer = new StreamWriter("message.txt", true))
                {
                    writer.WriteLine(temp.ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<float> GetAll()
        {
            float tempValue = 0;
            List<float> myList = new List<float>();
            try
            {
                using (StreamReader reader = new StreamReader("message.txt"))
                {
                    while (true)
                    {
                        string input = reader.ReadLine();
                        if (input == null) break;
                        tempValue = float.Parse(input);
                        myList.Add(tempValue);

                    }
                }
                return myList;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
