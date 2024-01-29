using BookData.Entities;

namespace ASPProjekt.Models
{
    public interface IBookService
    {
        int Add(Book book);
        void Delete(int id);
        void Update(Book book);
        List<Book> FindAll();
        Book? FindById(int id);
        List<PublisherEntity> FindAllPublishers();
        int AddPublisher(Publisher publisher);
        PagingList<Book> FindPage(int page, int size);
    }
}
