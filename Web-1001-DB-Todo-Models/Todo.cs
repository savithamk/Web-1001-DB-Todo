using System;
using System.Data;

//This is the definition for Todo class to store the data.
namespace Web_1001_DB_Todo_Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> CompletionDate { get; set; }

    }
}
