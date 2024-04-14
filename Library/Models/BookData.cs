using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookData
    {
        [Key]
        public int Id { get; set; }
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Desc { get; set; }
        public string Genre { get; set; }
    }
}