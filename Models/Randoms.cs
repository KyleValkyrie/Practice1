using System.ComponentModel.DataAnnotations;

namespace Practice1.Models
{
    public class Randoms
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public decimal Number { get; set; }
    }
}
