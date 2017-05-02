

using System;
using System.Collections;
using System.Collections.Generic;

namespace solvedQuestionsTracker
{
    public class Chapter : IChapter
    {
        private QuestionNumber[] _questions;

        public int ChapterNumber => _questions[0].Chapter; // chapter has at least one question

        public QuestionNumber[] Questions { get => _questions; set { _questions = value;}} 

        public Chapter(int chapterNumber, int numQuestions)
        {
            if (chapterNumber < 1)
            {
                throw new IndexOutOfRangeException("chapter number should be a number larger than 0");
            }

            if (numQuestions < 1)
            {
                throw new IndexOutOfRangeException("chapter should have at least 1 question");                
            }

            _questions = new QuestionNumber[numQuestions];
            for(var i = 0; i < _questions.Length; i++)
            {
                _questions[i] = new QuestionNumber(chapterNumber, i+1);
            }
        }

        public void SolveQuestion(QuestionNumber qestionNumber)
        {
            _questions[qestionNumber.Question - 1].Solved = true;
        }

        public int Count<QuestionNumber>()
        {
            return _questions.Length;
        }
    }
}