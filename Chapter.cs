

using System;
using System.Collections;
using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public class Chapter : IEnumerable<QuestionNumber>
    {
        public IEnumerable<QuestionNumber> Questions { get; private set; }

        public Chapter(int chapterNumber, int numQuestions)
        {
            if (chapterNumber < 1)
            {
                throw new IndexOutOfRangeException("chapter number should be a number larger than 0");
            }

            var questions = new QuestionNumber[numQuestions];
            for(var i = 0; i < questions.Length; i++)
            {
                questions[i] = new QuestionNumber(chapterNumber, i+1);
            }

            Questions = questions;
        }

        public int Count<QuestionNumber>()
        {
            ICollection<QuestionNumber> is2 = this as ICollection<QuestionNumber>;
            if (is2 != null)
            {
                return is2.Count;
            }
            int num = 0;
            using (IEnumerator<object> enumerator = this.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    num++;
                }
            }
            return num;
        }

        public IEnumerator<QuestionNumber> GetEnumerator()
        {
            return Questions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Questions.GetEnumerator();
        }
    }
}