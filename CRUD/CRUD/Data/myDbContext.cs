using CRUD.Models;
using CRUD.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> AllUsers { get; set; }
        public DbSet<Contact> Contacts { get;set; }
    }
}
