using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Należy podać tytuł książki")]
        [MaxLength(50, ErrorMessage = "Długość tytułu nie może przekraczać 50 znaków")]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Należy podać autora książki")]
        [MaxLength(50, ErrorMessage = "Długość nie może przekraczać 50 znaków")]
        [DisplayName("Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Należy podać rok publikacji")]
        [DisplayName("Year of Publish")]
        public int PublishYear { get; set; }
        [DisplayName("Genre")]
        public Genre Genre { get; set; }
        [DisplayName("Genre Id")]
        public int GenreId { get; set; }
    }
}
