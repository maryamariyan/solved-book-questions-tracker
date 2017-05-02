
using System;
using System.Collections.Generic;
using System.Linq;

namespace solvedQuestionsTracker
{
    public class CourseBook : IBook
    {
        private readonly Chapter[] _chapters;

        private readonly string _name;

        public CourseBook(string name, int numChapters)
        {
            _chapters = new Chapter[numChapters];
            _name = name;
        }

        public int NumChapters => _chapters.Length;
        
        public int NumQuestions => 
            Chapters.Sum((chapter) => chapter == null ? 0 : chapter.Count<QuestionNumber>()); 

        public int NumSolved =>
            Chapters.Sum((chapter) => chapter == null ? 0 : chapter.Questions.Sum(q => q.Solved ? 1 : 0));
            
        public IEnumerable<Chapter> Chapters => _chapters;

        public string Name => _name;

        public void AddChapter(int chapterNumber, int numQuestions)
        {
            if (chapterNumber == 0 || chapterNumber > NumChapters + 1)
            {
                throw new IndexOutOfRangeException("chapter number not within range");
            }

            _chapters[chapterNumber - 1] = new Chapter(chapterNumber, numQuestions);
        }

        public void AddChapter(Chapter chapter)
        {
            AddChapter(chapter.ChapterNumber, chapter.Count<QuestionNumber>());
            foreach (var questionNumber in chapter.Questions)
            {
                if (questionNumber.Solved)
                {
                    _chapters[questionNumber.Chapter - 1].Questions = chapter.Questions;
                }
            }
        }

        public void SolveQuestion(QuestionNumber questionNumber)
        {
            _chapters[questionNumber.Chapter - 1].SolveQuestion(questionNumber);
        }
    }
}