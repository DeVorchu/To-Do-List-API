using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToDoApp.Models.Domains
{
    public partial class db_e337Context : DbContext
    {
        public db_e337Context()
        {
        }

        public db_e337Context(DbContextOptions<db_e337Context> options)
            : base(options)
        {
        }

       
        public virtual DbSet<ShopList> ShopLists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersTask> UsersTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseMySQL("server=mysql.mikr.us;User Id=e337;Password=09BE_04f3df;database=db_e337; SslMode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ShopList>(entity =>
            {
                entity.ToTable("ShopList");

                entity.HasIndex(e => e.TaskId, "TaskId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Items).IsRequired();

                entity.Property(e => e.TaskId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("ShopList_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ShopList_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "Id");

                entity.Property(e => e.Id).HasColumnType("int(8)");

                entity.Property(e => e.Bdate)
                    .HasColumnType("date")
                    .HasColumnName("BDate");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.SecretCode)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UsersTask>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ReminderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReminderTime).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShopListId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.UserId).HasColumnType("int(8)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersTasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsersTasks_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
