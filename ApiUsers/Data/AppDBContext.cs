using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];

            for (int i = 1; i <= 6; i++)
            {
                postsToSeed[i - 1] = new Post
                {
                    id = i,
                    Title = $"Post {i}",
                    Content = $"Este es el post {i} con contenido muy divertido."
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
    }
}
