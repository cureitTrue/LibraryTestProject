using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class GenreData
    {
        [Key]
        public int Id { get; set; }
        public string GenreStr { get; set; }

        public override string ToString()
        {
            return GenreStr;
        }
    }
}