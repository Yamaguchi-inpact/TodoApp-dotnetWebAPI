using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aspnetserver2.Models
{
    public class TodoCategoryModel
    {
        public List<TodoItem>? TodoItems { get; set; }
        public SelectList? Categories { get; set; }
        public int? TodoCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
