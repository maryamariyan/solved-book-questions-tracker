using System;
using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"A sample question number is {new QuestionNumber(2,11)}");
            var bookFactory = new BookFactory() as IBookFactory;
            var book = bookFactory.CrackingTheCodingInterview();

            Console.WriteLine($"created book {book.Name}");

            Console.WriteLine($"book {book.Name} has {book.NumChapters} chapters and {book.NumQuestions} questions in total.");
        }
    }
}
