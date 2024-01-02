using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPProjekt.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string? ISBN { get; set; }
        [Range(0, 2023)]
        [Display(Name = "Publication Date")]
        public int? PublicationDate { get; set; }
        [DisplayName("Literary type")]
        public BookType BookType { get; set; }
        [HiddenInput]
        public int? PublisherId { get; set; }
        [ValidateNever]
        public List<SelectListItem>? PublisherList { get; set; }

    }
}
