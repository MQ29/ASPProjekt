using BookData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookData.Entities
{
    [Table("Publishers")]
    public class PublisherEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address? Address { get; set; }
        public ISet<BookEntity>? Books { get; set; }
    }
}
