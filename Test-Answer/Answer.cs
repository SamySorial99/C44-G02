using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Answer
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        // Constructors
        public Answer() { AnswerId = 0; AnswerText = ""; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        // For easy display
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }
}
