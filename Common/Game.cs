using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Game
    {
        public string Answer { get; set; }

        public int NumberOfAttempts { get; set; } = 0;

        public int NumberOfCorrectGuesses { get; set; }

        public bool IsOver { get; set; } = false;

        public bool Guessed { get; set; } = false;

        public List<char> AttemptedLetters { get; set; } = new List<char>();

        public Response checkGuess(Request request)
        {
            Response response = new Response();
            if (AttemptedLetters.Contains(request.Guess))
            {
                response.BadRequest = true;
                return response;
            }
            response.BadRequest = false;
            AttemptedLetters.Add(request.Guess);
            for (int i = 0; i < Answer.Length; i++)
            {
                if (Answer[i] == request.Guess)
                {
                    response.Positions.Add(i);
                    NumberOfCorrectGuesses++;
                }
            }
            if(response.Positions.Count==0)
            {
                response.IsCorrect = false;
            }
            else
            {
                response.IsCorrect=true;
            }

            NumberOfAttempts++;
            response.NumberOfCorrectGuesses = NumberOfCorrectGuesses;
            response.NumberOfAttempts = NumberOfAttempts;

            if(NumberOfCorrectGuesses==Answer.Length)
            {
                IsOver = true;
                Guessed= true;
            }

            if(NumberOfAttempts==10)
            {
                IsOver = true;
            }

            return response;
        }

    }

}
