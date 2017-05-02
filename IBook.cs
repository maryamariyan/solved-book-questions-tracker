using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public interface IBook
    {
        string Name { get; }
        int NumChapters { get; }
        int NumQuestions { get; }
        int NumSolved {get;}
        Chapter[] Chapters { get; }
        void AddChapter(int chapterNumber, int numQuestions);
        void AddChapter(Chapter chapter);
        void SolveQuestion(QuestionNumber questionNumber);
    }
}