using System.ComponentModel.DataAnnotations;

namespace Aspnetserver2.Models
{
    public class TodoItem
    {
        public long TodoItemId { get; set; }
        public string? TodoTitle { get; set; }
        public string? TodoText { get; set; }
        public bool IsComplete { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
    }
}
