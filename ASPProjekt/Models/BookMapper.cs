using BookData.Entities;

namespace ASPProjekt.Models
{
    public class BookMapper
    {
        public static BookEntity ToEntity(Book model)
        {
            return new BookEntity()
            {
                BookId = model.Id,
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                BookType = (int)model.BookType,
                PublicationDate = model.PublicationDate,
                PublisherId = model.PublisherId,
            };
        }

        public static Book FromEntity(BookEntity entity)
        {
            return new Book()
            {
                Id = entity.BookId,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                BookType = (BookType)entity.BookType,
                PublicationDate = entity.PublicationDate,
                PublisherId = entity.PublisherId,
            };
        }
    }
}
