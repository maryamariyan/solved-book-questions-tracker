using System;
using System.Collections.Generic;

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

            ITrainer<IBook> trainer = new Trainer("question-numbers.txt");

            var savedBook = bookFactory.CrackingTheCodingInterview("question-numbers.txt");
            Console.WriteLine($"saved book {book.Name} has {savedBook.NumSolved} questions solved.");
            var allExcludingLastThreeChapters = trainer.MakeExam(130 - savedBook.NumSolved, new List<int> {book.NumChapters, book.NumChapters - 1, book.NumChapters - 2});

            foreach (var question in allExcludingLastThreeChapters)
            {
                Console.WriteLine($" Now solve {question}.");
                var k = Console.ReadKey();
                Console.WriteLine($" Note: update the txt file if you finished {question}.");

                if (k.KeyChar.Equals('q'))
                {
                    break;
                }
            }
        }
    }
}
