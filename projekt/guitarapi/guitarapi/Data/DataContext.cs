using guitarapi.Models;
using Microsoft.EntityFrameworkCore;

namespace guitarapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<GuitarType> GuitarTypes { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Strings> Strings { get; set; }
        public DbSet<Guitar> Guitars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ToDo many to many relationship (Guitars <=> Guitarist)

            modelBuilder.Entity<Strings>().HasData(
                new Strings
                {
                    Id = 1,
                    Name = "Nylon"
                },
                new Strings
                {
                    Id = 2,
                    Name = "Carbon"
                },
                new Strings
                {
                    Id = 3,
                    Name = "Pro steel"
                },
                new Strings
                {
                    Id = 4,
                    Name = "Pure nickel"
                }
            );
            modelBuilder.Entity<Producer>().HasData(
                new Producer
                {
                    Id = 1,
                    Name = "Fender"
                },
                new Producer
                {
                    Id = 2,
                    Name = "Gibson"
                },
                new Producer
                {
                    Id = 3,
                    Name = "Taylor"
                },
                new Producer
                {
                    Id = 4,
                    Name = "Martin"
                },
                new Producer
                {
                    Id = 5,
                    Name = "PRS"
                },
                new Producer
                {
                    Id = 6,
                    Name = "Ibanez"
                },
                new Producer
                {
                    Id = 7,
                    Name = "Yamaha"
                },
                new Producer
                {
                    Id = 8,
                    Name = "Epiphone"
                },
                new Producer
                {
                    Id = 9,
                    Name = "Suhr"
                },
                new Producer
                {
                    Id = 10,
                    Name = "Rickenbacker"
                }
            );
            modelBuilder.Entity<GuitarType>().HasData(
                new GuitarType
                {
                    Id = 1,
                    Name = "Electric"
                },
                new GuitarType
                {
                    Id = 2,
                    Name = "Acoustic"
                },
                new GuitarType
                {
                    Id = 3,
                    Name = "Classical"
                },
                new GuitarType
                {
                    Id = 4,
                    Name = "Electro acoustic"
                },
                new GuitarType
                {
                    Id = 5,
                    Name = "Classical Acoustic-Electric"
                }
            );
        }
    }
}
