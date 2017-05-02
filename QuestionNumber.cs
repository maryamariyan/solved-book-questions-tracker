using System;

namespace solvedQuestionsTracker {

    public class QuestionNumber : System.IEquatable<QuestionNumber>
    {
        public int Chapter { get; set; }
        public int Question { get; set; }

        public bool Solved {get; set;}

        public QuestionNumber(int chapter, int question)
        {
            Chapter = chapter;
            Question = question;
            Solved = false;
        }

        public override string ToString()
        {
            return $"Q{Chapter}.{Question}";
        }

        public bool Equals(QuestionNumber other)
        {
            if (other == null)
            {
                return false;
            }
            return StringComparer.Ordinal.Equals(ToString(), other.ToString());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuestionNumber);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}