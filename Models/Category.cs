using System.ComponentModel.DataAnnotations;

namespace Aspnetserver2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int StateId { get; set; }
        public int ColorId { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }
    }
}
