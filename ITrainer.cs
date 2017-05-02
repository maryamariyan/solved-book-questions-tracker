using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public interface ITrainer<IBook>
    {
        IEnumerable<QuestionNumber> MakeExam(int numQuestions, List<int> chaptersExcluded);

        IEnumerable<QuestionNumber> MakeExam(int numQuestions);
    }
}