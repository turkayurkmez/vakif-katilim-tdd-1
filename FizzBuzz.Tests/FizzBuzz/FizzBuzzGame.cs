using System.Security.AccessControl;

namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public FizzBuzzGame()
        {
        }

        public string GetWord(int value)
        {
            if (value % 15 == 0)
            {
                return "FizzBuzz";
            }
            else if (value % 5 == 0)
            {
                return "Buzz";
            }
            else if (value % 3==0)
            {
                return "Fizz";
            }

            return value.ToString();
          


           
        }
    }
}