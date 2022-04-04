using System;
using System.Collections;
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

        //To get list of todos to display in html page
        public void OnGet()
        {
            var todoQuery = _db.Todos.Select(todo => todo);
            Todos = todoQuery.ToList();

        }

        //This method is responsible to add a new Todo
        public RedirectToPageResult OnPost()
        {
            todo.Status = "Incomplete";
            _db.Add<Todo>(todo);
            _db.SaveChangesAsync();
            return RedirectToPage();
        }

        //This method is responsible to update an existing item by marking the status as complete and a completion date
        public RedirectToPageResult OnPostEdit(int Id)
        {
            var todoToUpdate = _db.Todos.First(a => a.Id == Id);
            todoToUpdate.Status = "Complete";
            todoToUpdate.CompletionDate = DateTime.Now;
            _db.SaveChangesAsync();
            return RedirectToPage();
        }

        //This method is used to delete a record from the database
        public RedirectToPageResult OnPostDelete(int Id)
        {
            _db.Remove(_db.Todos.Single(a => a.Id == Id));
            _db.SaveChangesAsync();
            return RedirectToPage();

        }

    }
}
