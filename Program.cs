using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace solvedQuestionsTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"A sample question number is {new QuestionNumber(2,11)}");
            IBookFactory bookFactory = new BookFactory();
            var book = bookFactory.CrackingTheCodingInterview();

            Console.WriteLine($"created book {book.Name}");
            Console.WriteLine($"book {book.Name} has {book.NumChapters} chapters and {book.NumQuestions} questions in total.");

            var savedBook = bookFactory.CrackingTheCodingInterview("question-numbers.txt");
            Console.WriteLine($"saved book {savedBook.Name} has {savedBook.NumSolved} questions solved.");
            var questionsToChooseFrom = new Trainer(savedBook).MakeExamExcludingLastChapters(7);

            foreach (var question in questionsToChooseFrom)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                Console.WriteLine($"{DateTime.Now}: Now solve {question}.");
                var k = Console.ReadKey();
       
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Runtime: " + elapsedTime);

                Console.WriteLine($" Note: update the txt file if you finished {question}.");

                if (k.KeyChar.Equals('q'))
                {
                    break;
                }
            }
        }
    }
}
