using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Entities.Identity;
using System.Reflection.Emit;

namespace PawRescue.DataAccess.Contexts;

public class PawRescueContext : IdentityDbContext<AppUser>
{
    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Shelter> Shelters { get; set; }

    public virtual DbSet<UsefulLink> UsefulLinks { get; set; }

    public virtual DbSet<Verification> Verifications { get; set; }

    public PawRescueContext(DbContextOptions<PawRescueContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3214EC076CA3C47F");

            entity.Property(e => e.AdoptionStatus).HasMaxLength(50);
            entity.Property(e => e.ArrivalDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Size).HasMaxLength(10);
            entity.Property(e => e.Species).HasMaxLength(50);

            entity.HasOne(d => d.Shelter).WithMany(p => p.Animals)
                .HasForeignKey(d => d.ShelterId)
                .HasConstraintName("FK_Shelters_To_Animals");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07F7121547");

            entity.Property(e => e.AuthorId).HasMaxLength(450);
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_To_Users");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_To_Posts");
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Complain__3214EC0795BE87B7");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.ComplainantId).HasMaxLength(450);
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Comment).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_Complaints_To_Comments");

            entity.HasOne(d => d.Complainant).WithMany(p => p.ComplaintComplainants)
                .HasForeignKey(d => d.ComplainantId)
                .HasConstraintName("FK_Complaints_To_Complainants");

            entity.HasOne(d => d.Post).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Complaints_To_Posts");

            entity.HasOne(d => d.User).WithMany(p => p.ComplaintUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Complaints_To_Users");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B7404CF9");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.RecipientId).HasMaxLength(450);
            entity.Property(e => e.ReviewDate).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ReviewerId).HasMaxLength(450);

            entity.HasOne(d => d.Recipient).WithMany(p => p.PointRecipients)
                .HasForeignKey(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Points_To_Users_Recipient");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.PointReviewers)
                .HasForeignKey(d => d.ReviewerId)
                .HasConstraintName("FK_Points_To_Users_Reviewer");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07B98D951D");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.PostType).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Posts_To_Users");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reports__3214EC071181C61E");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Text).HasColumnType("text");

            entity.HasOne(d => d.Post).WithMany(p => p.Reports)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Reports_To_Posts");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC07799BA2AC");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Shelter).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ShelterId)
                .HasConstraintName("FK_Resources_To_Shelters");
        });

        modelBuilder.Entity<Shelter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shelters__3214EC075045688B");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OwnerId).HasMaxLength(450);

            entity.HasOne(d => d.Owner).WithMany(p => p.Shelters)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Shelters_To_Users");
        });

        modelBuilder.Entity<UsefulLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsefulLi__3214EC075F2AE727");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Verification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Verifica__3214EC079C08C94B");

            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.Documents);

            entity.HasOne(d => d.User).WithMany(p => p.Verifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Verifications_To_Users");
        });
    }
}
