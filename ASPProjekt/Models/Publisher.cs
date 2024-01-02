using BookData.Entities;
using BookData.Models;

namespace ASPProjekt.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address? Address { get; set; }
        public ISet<BookEntity>? Books { get; set; }
    }
}
