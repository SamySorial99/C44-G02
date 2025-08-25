using Test_Answer.Questions;
using System;

namespace Test_Answer.Exams
{
    internal class PracticalExam : Exam
    {
        private MCQQuestion[]? mcqQuestions;

        public PracticalExam(int time, int numQuestions) : base(time, numQuestions)
        {
            mcqQuestions = new MCQQuestion[numQuestions];
            CreateQuestions();
        }

        private void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Creating Question {i + 1} (MCQ)");
                mcqQuestions![i] = new MCQQuestion("", "", 0);
                mcqQuestions[i].CreateQuestion();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($" Practical Exam (Time: {Time} mins)");

            int score = 0;
            int[] userAnswers = new int[NumberOfQuestions];

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                var q = mcqQuestions![i];
                q.DisplayQuestion();

                int answer;
                while (true)
                {
                    Console.Write("Enter your answer: ");
                    var line = Console.ReadLine();

                    // Validate numeric input and bounds vs available options
                    if (int.TryParse(line, out answer) &&
                        q.AnswersList != null &&
                        answer >= 1 && answer <= q.AnswersList.Length)
                    {
                        break;
                    }

                    Console.WriteLine(" Invalid answer. Try again.");
                }

                userAnswers[i] = answer;

                if (q.CorrectAnswer.HasValue && answer == q.CorrectAnswer.Value)
                {
                    score += q.Mark;
                }
            }

            Console.WriteLine($" Exam Finished. Your score: {score}");
            Console.WriteLine("Answer Summary:");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                var q = mcqQuestions![i];

                string correctText =
                    (q.CorrectAnswer.HasValue && q.AnswersList != null &&
                     q.CorrectAnswer.Value >= 1 && q.CorrectAnswer.Value <= q.AnswersList.Length)
                        ? q.AnswersList[q.CorrectAnswer.Value - 1].AnswerText
                        : "N/A";

                string yourText =
                    (q.AnswersList != null &&
                     userAnswers[i] >= 1 && userAnswers[i] <= q.AnswersList.Length)
                        ? q.AnswersList[userAnswers[i] - 1].AnswerText
                        : "—";

                Console.WriteLine($"- {q.Body} | Correct: {correctText} | Your answer: {yourText}");
            }
        }
    }
}
