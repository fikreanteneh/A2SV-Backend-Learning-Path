using Microsoft.EntityFrameworkCore;
using BlogApp.Entities;

namespace  BlogApp.Data;
public class ApiDbContext : DbContext {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { 

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        //     optionsBuilder.UseNpgsql("Host=localhost:5432;Database=blog;Username=postgres;Password=241128");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Comment>(
                entity => {
                    entity.HasOne(e => e.Post)
                        .WithMany(e => e.Comments)
                        .HasForeignKey(e => e.PostId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Comment_Post");
                }
            );

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            modelBuilder.Entity<Comment>()
                .Property(p => p.Id)
                .UseIdentityColumn();


            // modelBuilder.Entity<Post>(entity => {
            //     entity.HasMany(e => e.Comments)
            //         .WithOne(e => e.Post)
            //         .OnDelete(DeleteBehavior.Cascade)
            //         .HasConstraintName("FK_Comment_Post");
            // });
            
            modelBuilder.Entity<Post>()
                .Property(p => p.Id)
                .UseIdentityColumn();
                
            modelBuilder.Entity<Post>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            
        }
    }