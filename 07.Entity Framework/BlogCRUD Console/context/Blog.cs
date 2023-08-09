using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=blog;Username=postgres;Password=241128");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            modelBuilder.Entity<Post>()
                .Property(p => p.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Comment>()
                .Property(p => p.Id)
                .UseIdentityColumn();
                
            modelBuilder.Entity<Post>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
        }
    }