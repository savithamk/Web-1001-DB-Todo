using System;
using Microsoft.EntityFrameworkCore;
using Web_1001_DB_Todo_Models;

//This is the Todo context page to interact with database
namespace Web_1001_DB_Todo_Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }
    }
}
