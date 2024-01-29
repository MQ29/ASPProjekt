using BookData.Entities;
using BookData;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekt.Models
{
    public class EFBookService : IBookService
    {
        private readonly AppDbContext _context;
        public EFBookService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public int Add(Book book)
        {
            var e = _context.Books.Add(BookMapper.ToEntity(book));
            _context.SaveChanges();
            int id = e.Entity.BookId;
            return id;
        }

        public int AddPublisher(Publisher publisher)
        {
            var p = _context.Publishers.Add(PublisherMapper.ToEntity(publisher));
            _context.SaveChanges();
            int id = p.Entity.Id;
            return id;
        }

        public void Delete(int id)
        {
            BookEntity? find = _context.Books.Find(id);
            if (find != null)
            {
                _context.Books.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.Select(e => BookMapper.FromEntity(e)).ToList();
        }

        public List<PublisherEntity> FindAllPublishers()
        {
            return _context.Publishers.ToList();
        }

        public Book? FindById(int id)
        {
            BookEntity? find = _context.Books.Find(id);
            return find != null ? BookMapper.FromEntity(find) : null;
        }

        public PagingList<Book> FindPage(int page, int size)
        {
            var p = PagingList<Book>.Create(null, _context.Books.Count(), page, size);
            var data = _context.Books.OrderBy(o => o.Title)
                              .Skip((p.Number - 1) * p.Size)
                              .Take(p.Size)
                              .Select(BookMapper.FromEntity)
                              .ToList();
            p.Data = data;
            return p;
        }

        public void Update(Book contact)
        {
            _context.Books.Update(BookMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
