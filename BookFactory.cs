namespace solvedQuestionsTracker
{
    public class BookFactory : IBookFactory
    {
        public IBook CrackingTheCodingInterview()
        {
            var book = new CourseBook(nameof(CrackingTheCodingInterview), 17);

            book.AddChapter(1, 9);
            book.AddChapter(2, 8);
            book.AddChapter(3, 6);
            book.AddChapter(4, 12);
            book.AddChapter(5, 8);
            book.AddChapter(6, 10);
            book.AddChapter(7, 12);
            book.AddChapter(8, 14);
            book.AddChapter(9, 8);
            book.AddChapter(10, 11);
            book.AddChapter(11,6);
            book.AddChapter(12,11);
            book.AddChapter(13,8);
            book.AddChapter(14,7);
            book.AddChapter(15,7);
            book.AddChapter(16,26);
            book.AddChapter(17,26);
  
            return book;
        }
    }
}