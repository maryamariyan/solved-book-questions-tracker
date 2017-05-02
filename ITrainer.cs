using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public interface ITrainer<IBook>
    {
        IEnumerable<QuestionNumber> MakeExamExcludingLastChapters(int countLastChaptersToExclude);
    }
}