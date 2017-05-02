using System;
using System.Collections.Generic;
using System.IO;

namespace solvedQuestionsTracker
{
    public class BookFactory : IBookFactory
    {
        public IBook CrackingTheCodingInterview()
        {
            var book = new CourseBook(nameof(CrackingTheCodingInterview), 17);

            book.AddChapter(1, 9);
            book.AddChapter(2, 8);
            book.AddChapter(3, 6);
            book.AddChapter(4, 12);
            book.AddChapter(5, 8);
            book.AddChapter(6, 10);
            book.AddChapter(7, 12);
            book.AddChapter(8, 14);
            book.AddChapter(9, 8);
            book.AddChapter(10, 11);
            book.AddChapter(11,6);
            book.AddChapter(12,11);
            book.AddChapter(13,8);
            book.AddChapter(14,7);
            book.AddChapter(15,7);
            book.AddChapter(16,26);
            book.AddChapter(17,26);
  
            return book;
        }


        public IBook CrackingTheCodingInterview(string filename)
        {
            // 1.1,3.2,14.1
            var biggestChapterNumberSoFar = 0;
            var solvedQuestions = new HashSet<QuestionNumber>();
            using (TextReader reader = File.OpenText(filename))
            {
                var questions = reader.ReadLine().Split(',');

                foreach (var q in questions)
                {
                    string[] question = q.Split('.');

                    var qn = new QuestionNumber(int.Parse(question[0]), int.Parse(question[1]));
                    qn.Solved = true;

                    if (!solvedQuestions.Contains(qn))
                    {
                        solvedQuestions.Add(qn);
                        biggestChapterNumberSoFar = Math.Max(biggestChapterNumberSoFar, qn.Chapter);
                    }
                }
            }

            if (biggestChapterNumberSoFar < 1)
            {
                throw new InvalidOperationException("no questions were saved in file.");
            }

            IBook book = new BookFactory().CrackingTheCodingInterview();

            foreach (var solvedQuestion in solvedQuestions)
            {
                book.SolveQuestion(solvedQuestion);
            }

            return book;
        }
    }
}