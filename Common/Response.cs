using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]

    public class Response
    {
        public bool BadRequest { get; set; } = false;

        public bool IsCorrect { get; set; }

        public List<int> Positions { get; set; }= new List<int>();  

        public int NumberOfCorrectGuesses { get; set; }

        public int NumberOfAttempts{ get; set; } = 0;
    }
}
