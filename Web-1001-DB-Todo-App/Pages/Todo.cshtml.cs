using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web_1001_DB_Todo_Context;

namespace Web_1001_DB_Todo_App.Pages
{
    public class TodoModel : PageModel
    {
        private readonly ILogger<TodoModel> _logger;
        private readonly TodoContext _db;

        public TodoModel(ILogger<TodoModel> logger, TodoContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            ViewData["NumTodos"] = _db.Todos.Count();
        }
    }
}
