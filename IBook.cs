using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public interface IBook
    {
        string Name { get; }
        int NumChapters { get; }
        int NumQuestions { get; }
        IEnumerable<Chapter> Chapters { get; }
        void AddChapter(int chapterNumber, int numQuestions);


    }
}