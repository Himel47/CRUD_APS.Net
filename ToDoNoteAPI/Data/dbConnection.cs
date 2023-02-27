using Microsoft.EntityFrameworkCore;
using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Data
{
    public class dbConnection : DbContext
    {
        public dbConnection(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
