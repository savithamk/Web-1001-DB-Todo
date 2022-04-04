using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web_1001_DB_Todo_Context;
using Web_1001_DB_Todo_Models;

namespace Web_1001_DB_Todo_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TodoContext _db;

        [FromForm]
        public Todo todo { get; set; }
        public List<Todo> Todos { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, TodoContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            var todoQuery = _db.Todos.Select(todo => todo);
            Todos = todoQuery.ToList();
        }

        public RedirectToPageResult OnPost()
        {
            todo.Status = "Incomplete";
            _db.Add<Todo>(todo);
            _db.SaveChangesAsync();
            return RedirectToPage();
        }

    }
}
