using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<TodoItem> Items { get; set; }
    }
}