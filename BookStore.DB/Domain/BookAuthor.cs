
namespace BookStore.DB.Domain
{
    public class BookAuthor
    {
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }

        public BookAuthor(int? bookId, int? authorId)
        {
            BookId = bookId;
            AuthorId = authorId;
        }
    }
}
