namespace todo_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }
        public DbSet<ToDo> Todos { get; set; }
        public DbSet<Priority> Priorities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasData(
                 new Priority
                 {
                     PriorityId = 1,
                     Name = "Important"
                 },
                 new Priority
                 {
                     PriorityId = 2,
                     Name = "Medium important"
                 },
                 new Priority
                 {
                     PriorityId = 3,
                     Name = "Not very important"
                 }
            );

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    Name = "Odkurzyć",
                    Description = "Łazienka, sypialnia, kuchnia, salon",
                    Created = DateTime.UtcNow,
                    PriorityId = 2,
                    IsCompleted = false
                },
                new ToDo
                {
                    Id = 2,
                    Name = "Zrobić zadanie",
                    Description = "Matematyka - planimetria",
                    Created = DateTime.UtcNow,
                    PriorityId = 1,
                    IsCompleted = false
                }
            );
        }



        //public DbSet<Group> Groups { get; set; }
        //public DbSet<User> Users { get; set; }

    }
}
