using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public partial class KingVocabularyContext : DbContext
{
    public KingVocabularyContext()
    {
    }

    public KingVocabularyContext(DbContextOptions<KingVocabularyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vocabulary> Vocabularies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Folder__3213E83F47DDC8C1");

            entity.ToTable("Folder");

            entity.HasIndex(e => e.Id, "UQ__Folder__3213E83ECBD97735").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FolderName)
                .HasMaxLength(255)
                .HasColumnName("folder_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Folders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Folder__user_id__571DF1D5");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Module__3213E83F7BD1F722");

            entity.ToTable("Module");

            entity.HasIndex(e => e.Id, "UQ__Module__3213E83E5E7BC957").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(255)
                .HasColumnName("module_name");

            entity.HasOne(d => d.Folder).WithMany(p => p.Modules)
                .HasForeignKey(d => d.FolderId)
                .HasConstraintName("FK__Module__folder_i__5629CD9C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F075A45D3");

            entity.ToTable("User");

            entity.HasIndex(e => e.Id, "UQ__User__3213E83E0411A529").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__AB6E616445BF1676").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("avatar_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HashPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hash_password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Vocabulary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vocabula__3213E83FFE914C27");

            entity.ToTable("Vocabulary");

            entity.HasIndex(e => e.Id, "UQ__Vocabula__3213E83E8688078F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Definition)
                .HasMaxLength(255)
                .HasColumnName("definition");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Terminology)
                .HasMaxLength(255)
                .HasColumnName("terminology");

            entity.HasOne(d => d.Module).WithMany(p => p.Vocabularies)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Vocabular__modul__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
