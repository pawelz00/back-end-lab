namespace todo_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }
        public DbSet<ToDo> Todos { get; set; }
    }
}
