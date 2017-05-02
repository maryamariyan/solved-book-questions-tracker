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
            _rand = new Random(7);
        }

        public IEnumerable<QuestionNumber> MakeExamExcludingLastChapters(int countLastChaptersToExclude)
        {
            var excludedChapters = new List<int>();
            var numExcludedQuestions = 0;
            for (int i = 0; i < countLastChaptersToExclude; i++)
            {
                excludedChapters.Add(_book.NumChapters - i);
                numExcludedQuestions += _book.Chapters[_book.NumChapters - i - 1].Questions.Length;
            }
            return MakeExam(189 - numExcludedQuestions - _book.NumSolved, excludedChapters);
        }

        private IEnumerable<QuestionNumber> MakeExam(int numQuestions, List<int> chaptersExcluded)
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

        private IEnumerable<QuestionNumber> MakeExam(int numQuestions)
        {
            if (numQuestions > _book.NumQuestions - _book.NumSolved)
            {
                throw new InvalidOperationException(
                    $"cannot allow requesting {numQuestions} while book has {_book.NumSolved} questions solved and {_book.NumQuestions} available to choose from.");
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