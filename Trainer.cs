using System;
using System.Collections.Generic;
using System.Linq;

namespace solvedQuestionsTracker
{
    public class Trainer : ITrainer<IBook>
    {
        private readonly IBook _book;
        private readonly Random _rand;

        public Trainer(IBook book)
        {
            _book = book;
            _rand = new Random(837);
        }

        public Trainer(string filename)
        {
            _book = new BookFactory().CrackingTheCodingInterview(filename);
            _rand = new Random(837);
        }

        public IEnumerable<QuestionNumber> MakeExam(int numQuestions, List<int> chaptersExcluded)
        {
            if (chaptersExcluded == null || !chaptersExcluded.Any())
            {
                return MakeExam(numQuestions);
            }

            var tempBook = new CourseBook("tempBook", _book.NumChapters - chaptersExcluded.Count);
            foreach (var chapter in _book.Chapters)
            {
                if (!chaptersExcluded.Contains(chapter.ChapterNumber))
                {
                    tempBook.AddChapter(chapter);
                }   
            }

            return new Trainer(tempBook).MakeExam(numQuestions);
        }

        public IEnumerable<QuestionNumber> MakeExam(int numQuestions)
        {
            if (numQuestions > _book.NumQuestions)
            {
                throw new InvalidOperationException("number of requested questions in an exam should be less that number of questions that exist in the book.");
            }

            var questions = new HashSet<QuestionNumber>();

            while (questions.Count < numQuestions)
            {
                var q = PickRandomQuestionNumber();
                if (!questions.Contains(q) && !q.Solved)
                {
                    questions.Add(q);
                    yield return q;
                }
            }
            
            yield break;
        }

        private QuestionNumber PickRandomQuestionNumber()
        {
            var randomChapterNumber = _rand.Next(1, _book.NumChapters + 1);
            var randomChapter = _book.Chapters.Where(c => c.ChapterNumber == randomChapterNumber).FirstOrDefault();
            var randomQuestionInChapter = _rand.Next(1, randomChapter.Count<QuestionNumber>() + 1);
            return randomChapter.Questions.Where(x => x.Question == randomQuestionInChapter).FirstOrDefault();
        }
    }
}