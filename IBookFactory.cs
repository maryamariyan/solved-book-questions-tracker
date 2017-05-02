namespace solvedQuestionsTracker
{
    public interface IBookFactory
    {
        IBook CrackingTheCodingInterview();

        IBook CrackingTheCodingInterview(string fileName);
    }
}