using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.Entities
{
    public class Author 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BookId { get; set; }
        public ICollection<Book> Books { get; set; }
        public DateTime BirthDate { get; set; }
    }
}