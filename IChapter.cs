using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public interface IChapter
    {
        void SolveQuestion(QuestionNumber qestionNumber);

        int Count<QuestionNumber>();

        int ChapterNumber {get;}

        QuestionNumber[] Questions {get; set;}
    }
}