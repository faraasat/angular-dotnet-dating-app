using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // It is convention to pluralize the name of entities like here we pluralize value as values
        public DbSet<Value> Values {get; set;}
        public DbSet<User> Users {get; set;}

    }
}