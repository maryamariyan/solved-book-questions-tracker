
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
            Chapters.Sum((chapter) => chapter == null ? 0 : chapter.Count<QuestionNumber>()); /* expected 189 */ 
            
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
    }
}