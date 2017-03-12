using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Models
{
    public class MediaLibraryContext : DbContext
    {
        public MediaLibraryContext() { }

        public MediaLibraryContext(DbContextOptions<MediaLibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("folder");

                entity.Property(e => e.FolderId)
                    .HasColumnName("folderId")
                    .ValueGeneratedOnAdd();

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
                    .HasDefaultValueSql("private");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZipFile)
                    .HasColumnName("zip_file")
                    .HasMaxLength(255);

                entity.HasOne(e => e.Parent)
                    .WithMany(e => e.Children)
                    .HasForeignKey(e => e.ParentId);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.TrackId);
                    //.HasName("PK__tracks__55B5F952DD13098D");

                entity.ToTable("tracks");

                entity.Property(e => e.TrackId)
                    .HasColumnName("trackId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddDate)
                    .HasColumnName("addDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Album)
                    .HasColumnName("album")
                    .HasColumnType("ntext");

                entity.Property(e => e.Artist)
                    .HasColumnName("artist")
                    .HasColumnType("ntext");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(100);

                entity.Property(e => e.Downloadable)
                    .HasColumnName("downloadable")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnName("duration")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FileSize)
                    .IsRequired()
                    .HasColumnName("file_size")
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FolderId)
                    .HasColumnName("folderId")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(100);

                entity.Property(e => e.Height)
                    .HasColumnName("height");

                entity.Property(e => e.MusicFile)
                    .HasColumnName("music_file")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Privacy)
                    .IsRequired()
                    .HasColumnName("privacy")
                    .HasColumnType("varchar(7)")
                    .HasDefaultValueSql("private");

                entity.Property(e => e.TrackDisplayOption)
                    .HasColumnName("track_display_option")
                    .HasMaxLength(255);

                entity.Property(e => e.TrackFile)
                    .IsRequired()
                    .HasColumnName("trackFile")
                    .HasMaxLength(255);

                entity.Property(e => e.TrackNumber).HasColumnName("track_number");

                entity.Property(e => e.TrackTitle)
                    .IsRequired()
                    .HasColumnName("trackTitle")
                    .HasColumnType("ntext");

                entity.Property(e => e.TrackYear)
                    .HasColumnName("track_year")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Width).HasColumnName("width");
            });
        }

        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    
    }



    //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        {
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
    //            optionsBuilder.UseSqlServer(@"server=sql5031.myasp.net;user=DB_A10CEB_medialib_admin;password=Seattle-2016;database=DB_A10CEB_medialib;");
    //        }


    //modelBuilder.Entity<Folder>(entity =>
    //{
    //    entity.ToTable("folder");

    //    entity.Property(e => e.FolderId)
    //        .HasColumnName("folderId")
    //        .ValueGeneratedNever();

    //    entity.Property(e => e.AddDate)
    //        .HasColumnName("addDate")
    //        .HasColumnType("datetime");

    //    entity.Property(e => e.Downloadable)
    //        .HasColumnName("downloadable")
    //        .HasDefaultValueSql("1");

    //    entity.Property(e => e.FolderName)
    //        .IsRequired()
    //        .HasColumnName("folderName")
    //        .HasMaxLength(512);

    //    entity.Property(e => e.HasMp3)
    //        .HasColumnName("hasMP3")
    //        .HasDefaultValueSql("0");

    //    entity.Property(e => e.IsCategory)
    //        .HasColumnName("isCategory")
    //        .HasDefaultValueSql("0");

    //    entity.Property(e => e.ParentId)
    //        .HasColumnName("parentId")
    //        .HasDefaultValueSql("0");

    //    entity.Property(e => e.Privacy)
    //        .IsRequired()
    //        .HasColumnName("privacy")
    //        .HasColumnType("varchar(7)")
    //        .HasDefaultValue("private");

    //    entity.Property(e => e.UpdateDate)
    //        .HasColumnName("updateDate")
    //        .HasColumnType("datetime");

    //    entity.Property(e => e.ZipFile)
    //        .HasColumnName("zip_file")
    //        .HasMaxLength(255);
    //});


}