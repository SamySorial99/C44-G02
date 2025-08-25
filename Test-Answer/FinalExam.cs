using Test_Answer.Questions;
using Proxy.Models;
using System;

namespace Test_Answer.Exams
{
    internal class FinalExam : Exam
    {
        private Question[]? questions;

        public FinalExam(int time, int numQuestions) : base(time, numQuestions)
        {
            questions = new Question[numQuestions];
            CreateQuestions();
        }

        public void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Creating Question {i + 1}");
                Console.Write("Enter question type (1: MCQ, 2: True/False): ");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2))
                {
                    Console.WriteLine("Invalid input. Enter 1 for MCQ or 2 for True/False.");
                }

                if (type == 1)
                {
                    questions![i] = new MCQQuestion("", "", 0);
                }
                else
                {
                    questions![i] = new TFQuestion("", "", 0);
                }

                questions![i].CreateQuestion();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($" Final Exam (Time: {Time} mins)");

            int score = 0;

            foreach (var q in questions!)
            {
                q.DisplayQuestion();
                int answer = q.ReadAnswerFromUser(); // from Question.cs
                if (q.CorrectAnswer.HasValue && answer == q.CorrectAnswer.Value)
                {
                    score += q.Mark;
                }
            }

            Console.WriteLine($" Exam Finished. Your total grade: {score}");

            Console.WriteLine("Answer Summary:");
            foreach (var q in questions!)
            {
                // Safe lookups
                string correctText = (q.CorrectAnswer.HasValue && q.AnswersList != null &&
                                      q.CorrectAnswer.Value >= 1 && q.CorrectAnswer.Value <= q.AnswersList.Length)
                    ? q.AnswersList[q.CorrectAnswer.Value - 1].AnswerText
                    : "N/A";

                string yourText = (q.UserAnswer.HasValue && q.AnswersList != null &&
                                   q.UserAnswer.Value >= 1 && q.UserAnswer.Value <= q.AnswersList.Length)
                    ? q.AnswersList[q.UserAnswer.Value - 1].AnswerText
                    : "—";

                Console.WriteLine($"- {q.Body} | Correct: {correctText} | Your answer: {yourText}");
            }
        }
    }
}
