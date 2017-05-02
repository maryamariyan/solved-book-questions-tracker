namespace solvedQuestionsTracker {

    public class QuestionNumber
    {
        public int Chapter { get; set; }
        public int Question { get; set; }

        public QuestionNumber(int chapter, int question)
        {
            Chapter = chapter;
            Question = question;
        }

        public override string ToString()
        {
            return $"Q{Chapter}.{Question}";
        }
    }
}