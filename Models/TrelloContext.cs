using Microsoft.EntityFrameworkCore;

namespace trello;

public partial class TrelloContext : DbContext
{

    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<List> Lists { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public TrelloContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=trello;User=root;Password=;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>()
            .HasOne(c => c.List)
            .WithMany(o => o.CardList);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(c => c.Card).WithMany(o => o.CommentList);
            entity.HasOne(c => c.User).WithMany(o => o.CommentList);
        });

        modelBuilder.Entity<List>()
            .HasOne(c => c.Project)
            .WithMany(o => o.ListList);

        modelBuilder.Entity<Tag>()
            .HasOne(c => c.Card)
            .WithMany(o => o.TagList);

        modelBuilder.Entity<ProjectUser>(entity =>
        {
            entity.HasKey(e => new { e.ProjectID, e.UserID }).HasName("PRIMARY");

            entity.HasOne(c => c.Project).WithMany(o => o.ProjectUserList);
            entity.HasOne(c => c.User).WithMany(o => o.ProjectUserList);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
