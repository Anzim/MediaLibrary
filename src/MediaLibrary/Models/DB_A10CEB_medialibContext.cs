using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediaLibrary.Models
{
    public partial class DB_A10CEB_medialibContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"server=sql5031.myasp.net;user=DB_A10CEB_medialib_admin;password=Seattle-2016;database=DB_A10CEB_medialib;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("folder");

                entity.Property(e => e.FolderId)
                    .HasColumnName("folderId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddDate)
                    .HasColumnName("addDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Downloadable)
                    .HasColumnName("downloadable")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FolderName)
                    .IsRequired()
                    .HasColumnName("folderName")
                    .HasMaxLength(512);

                entity.Property(e => e.HasMp3)
                    .HasColumnName("hasMP3")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsCategory)
                    .HasColumnName("isCategory")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Privacy)
                    .IsRequired()
                    .HasColumnName("privacy")
                    .HasColumnType("varchar(7)")
                    .HasDefaultValueSql("'private'");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZipFile)
                    .HasColumnName("zip_file")
                    .HasMaxLength(255);
            });
        }

        public virtual DbSet<Folder> Folder { get; set; }
    }
}