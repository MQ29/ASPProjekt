using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData.Entities
{

    [Table("Books")]
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required] public string Author { get; set; }
        public string? ISBN { get; set; }
        [Range(0, 2023)]
        public int? PublicationDate { get; set; }
        public int BookType { get; set; }
        public PublisherEntity? Publisher { get; set; }
        public int? PublisherId { get; set; }
    }
}
