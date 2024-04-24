using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Model;

namespace ToDoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<ToDo> toDo = new List<ToDo>()
        {
            new ToDo(),
            new ToDo("Hello")
        };
        public readonly string[] AddTable;
        public string hello { get; set; } = "Hello";
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
