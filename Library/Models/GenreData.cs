using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class GenreData
    {
        [Key]
        public int Id { get; set; }
        public string Genre { get; set; }
    }
}