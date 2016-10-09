//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.Configuration;

//namespace mp3ehb.core1.Models
//{
//    public partial class Mp3EhbContext : DbContext
//    {
//        private static int _instanceCount = 0;
//        private string _connectionString; // = @"Server=localhost;Database=mp3-ehb;Trusted_Connection=True;";
//        //public Mp3EhbContext(DbContextOptions<Mp3EhbContext> options) : base(options)
//        //{
//        //}

//        public Mp3EhbContext(IConfigurationRoot configuration)
//        {
//            _instanceCount += 1;
//            _connectionString = configuration.GetConnectionString("DataAccessMySqlProvider");
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//            optionsBuilder.UseSqlServer(_connectionString);
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Folder>(entity =>
//            {
//                entity.ToTable("folders");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.Level).HasColumnName("level");

//                entity.Property(e => e.Lft)
//                    .HasColumnName("lft")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasColumnName("name")
//                    .HasColumnType("varchar(50)");

//                entity.Property(e => e.ParentId).HasColumnName("parent_id");

//                entity.Property(e => e.Rgt)
//                    .HasColumnName("rgt")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Rules)
//                    .IsRequired()
//                    .HasColumnName("rules")
//                    .HasColumnType("varchar(5120)");

//                entity.Property(e => e.Title)
//                    .IsRequired()
//                    .HasColumnName("title")
//                    .HasColumnType("varchar(100)");

//                entity.HasOne(d => d.Parent)
//                    .WithMany(p => p.Children)
//                    .HasForeignKey(d => d.ParentId)
//                    .HasConstraintName("FK_assets_assets");
//            });

//            modelBuilder.Entity<Category>(entity =>
//            {
//                entity.ToTable("categories");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.Access)
//                    .HasColumnName("access")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Alias)
//                    .IsRequired()
//                    .HasColumnName("alias")
//                    .HasMaxLength(255)
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.AssetId).HasColumnName("asset_id");

//                entity.Property(e => e.CheckedOut)
//                    .HasColumnName("checked_out")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CheckedOutTime)
//                    .IsRequired()
//                    .HasColumnName("checked_out_time")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.CreatedTime)
//                    .IsRequired()
//                    .HasColumnName("created_time")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.CreatedUserId)
//                    .HasColumnName("created_user_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasColumnName("description")
//                    .HasColumnType("text");

//                entity.Property(e => e.Extension)
//                    .IsRequired()
//                    .HasColumnName("extension")
//                    .HasColumnType("varchar(50)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Hits)
//                    .HasColumnName("hits")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Language)
//                    .IsRequired()
//                    .HasColumnName("language")
//                    .HasColumnType("char(7)");

//                entity.Property(e => e.Level)
//                    .HasColumnName("level")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Lft)
//                    .HasColumnName("lft")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Metadata)
//                    .IsRequired()
//                    .HasColumnName("metadata")
//                    .HasColumnType("varchar(2048)");

//                entity.Property(e => e.Metadesc)
//                    .IsRequired()
//                    .HasColumnName("metadesc")
//                    .HasColumnType("varchar(1024)");

//                entity.Property(e => e.Metakey)
//                    .IsRequired()
//                    .HasColumnName("metakey")
//                    .HasColumnType("varchar(1024)");

//                entity.Property(e => e.ModifiedTime)
//                    .IsRequired()
//                    .HasColumnName("modified_time")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.ModifiedUserId)
//                    .HasColumnName("modified_user_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Note)
//                    .IsRequired()
//                    .HasColumnName("note")
//                    .HasColumnType("varchar(255)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Params)
//                    .IsRequired()
//                    .HasColumnName("params")
//                    .HasColumnType("text");

//                entity.Property(e => e.ParentId).HasColumnName("parent_id");

//                entity.Property(e => e.Path)
//                    .IsRequired()
//                    .HasColumnName("path")
//                    .HasColumnType("varchar(255)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Published)
//                    .HasColumnName("published")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Rgt)
//                    .HasColumnName("rgt")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Title)
//                    .IsRequired()
//                    .HasColumnName("title")
//                    .HasColumnType("varchar(255)");

//                entity.HasOne(d => d.Asset)
//                    .WithMany(p => p.Categories)
//                    .HasForeignKey(d => d.AssetId)
//                    .HasConstraintName("FK_categories_assets");

//                entity.HasOne(d => d.Parent)
//                    .WithMany(p => p.Children)
//                    .HasForeignKey(d => d.ParentId)
//                    .HasConstraintName("FK_categories_categories");
//            });

//            modelBuilder.Entity<Content>(entity =>
//            {
//                entity.ToTable("content");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.Access)
//                    .HasColumnName("access")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Alias)
//                    .IsRequired()
//                    .HasColumnName("alias")
//                    .HasMaxLength(255)
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.AssetId)
//                    .HasColumnName("asset_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Attribs)
//                    .IsRequired()
//                    .HasColumnName("attribs")
//                    .HasColumnType("varchar(5120)");

//                entity.Property(e => e.CatId)
//                    .HasColumnName("catid")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CheckedOut)
//                    .HasColumnName("checked_out")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CheckedOutTime)
//                    .IsRequired()
//                    .HasColumnName("checked_out_time")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.Created)
//                    .IsRequired()
//                    .HasColumnName("created")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.CreatedBy)
//                    .HasColumnName("created_by")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CreatedByAlias)
//                    .IsRequired()
//                    .HasColumnName("created_by_alias")
//                    .HasColumnType("varchar(255)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Featured)
//                    .HasColumnName("featured")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.FullText)
//                    .IsRequired()
//                    .HasColumnName("fulltext")
//                    .HasColumnType("text");

//                entity.Property(e => e.Hits)
//                    .HasColumnName("hits")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Images)
//                    .IsRequired()
//                    .HasColumnName("images")
//                    .HasColumnType("text");

//                entity.Property(e => e.IntroText)
//                    .IsRequired()
//                    .HasColumnName("introtext")
//                    .HasColumnType("text");

//                entity.Property(e => e.Language)
//                    .IsRequired()
//                    .HasColumnName("language")
//                    .HasColumnType("char(7)");

//                entity.Property(e => e.Mask)
//                    .HasColumnName("mask")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.MetaData)
//                    .IsRequired()
//                    .HasColumnName("metadata")
//                    .HasColumnType("text");

//                entity.Property(e => e.MetaDesc)
//                    .IsRequired()
//                    .HasColumnName("metadesc")
//                    .HasColumnType("text");

//                entity.Property(e => e.MetaKey)
//                    .IsRequired()
//                    .HasColumnName("metakey")
//                    .HasColumnType("text");

//                entity.Property(e => e.Modified)
//                    .IsRequired()
//                    .HasColumnName("modified")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.ModifiedBy)
//                    .HasColumnName("modified_by")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Ordering)
//                    .HasColumnName("ordering")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.ParentId).HasColumnName("parentid");

//                entity.Property(e => e.PublishDown)
//                    .IsRequired()
//                    .HasColumnName("publish_down")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.PublishUp)
//                    .IsRequired()
//                    .HasColumnName("publish_up")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.SectionId)
//                    .HasColumnName("sectionid")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.State)
//                    .HasColumnName("state")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Title)
//                    .IsRequired()
//                    .HasColumnName("title")
//                    .HasColumnType("varchar(255)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.TitleAlias)
//                    .IsRequired()
//                    .HasColumnName("title_alias")
//                    .HasMaxLength(255)
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Urls)
//                    .IsRequired()
//                    .HasColumnName("urls")
//                    .HasColumnType("text");

//                entity.Property(e => e.Version)
//                    .HasColumnName("version")
//                    .HasDefaultValueSql("'1'");

//                entity.Property(e => e.XReference)
//                    .IsRequired()
//                    .HasColumnName("xreference")
//                    .HasColumnType("varchar(50)");

//                entity.HasOne(d => d.Asset)
//                    .WithMany(p => p.Contents)
//                    .HasForeignKey(d => d.AssetId)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasConstraintName("FK_content_assets");

//                entity.HasOne(d => d.Category)
//                    .WithMany(p => p.Contents)
//                    .HasForeignKey(d => d.CatId)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasConstraintName("FK_content_categories");

//                entity.HasOne(d => d.Parent)
//                    .WithMany(p => p.Children)
//                    .HasForeignKey(d => d.ParentId)
//                    .HasConstraintName("FK_content_content");
//            });

//            modelBuilder.Entity<Menu>(entity =>
//            {
//                entity.ToTable("menu");

//                entity.Property(e => e.Id)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.Access)
//                    .HasColumnName("access")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Alias)
//                    .IsRequired()
//                    .HasColumnName("alias")
//                    .HasMaxLength(255);

//                entity.Property(e => e.BrowserNav)
//                    .HasColumnName("browserNav")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CheckedOut)
//                    .HasColumnName("checked_out")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.CheckedOutTime)
//                    .IsRequired()
//                    .HasColumnName("checked_out_time")
//                    .HasColumnType("varchar(20)")
//                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

//                entity.Property(e => e.ClientId)
//                    .HasColumnName("client_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.ComponentId)
//                    .HasColumnName("component_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Home)
//                    .HasColumnName("home")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Img)
//                    .IsRequired()
//                    .HasColumnName("img")
//                    .HasColumnType("varchar(255)");

//                entity.Property(e => e.Language)
//                    .IsRequired()
//                    .HasColumnName("language")
//                    .HasColumnType("char(7)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Level)
//                    .HasColumnName("level")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Lft)
//                    .HasColumnName("lft")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Link)
//                    .IsRequired()
//                    .HasColumnName("link")
//                    .HasColumnType("varchar(1024)");

//                entity.Property(e => e.Menutype)
//                    .IsRequired()
//                    .HasColumnName("menutype")
//                    .HasColumnType("varchar(24)");

//                entity.Property(e => e.Note)
//                    .IsRequired()
//                    .HasColumnName("note")
//                    .HasColumnType("varchar(255)")
//                    .HasDefaultValueSql("''");

//                entity.Property(e => e.Ordering)
//                    .HasColumnName("ordering")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Params)
//                    .IsRequired()
//                    .HasColumnName("params")
//                    .HasColumnType("text");

//                entity.Property(e => e.ParentId)
//                    .HasColumnName("parent_id")
//                    .HasDefaultValueSql("'1'");

//                entity.Property(e => e.Path)
//                    .IsRequired()
//                    .HasColumnName("path")
//                    .HasColumnType("varchar(1024)");

//                entity.Property(e => e.Published)
//                    .HasColumnName("published")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Rgt)
//                    .HasColumnName("rgt")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.TemplateStyleId)
//                    .HasColumnName("template_style_id")
//                    .HasDefaultValueSql("'0'");

//                entity.Property(e => e.Title)
//                    .IsRequired()
//                    .HasColumnName("title")
//                    .HasColumnType("varchar(255)");

//                entity.Property(e => e.Type)
//                    .IsRequired()
//                    .HasColumnName("type")
//                    .HasColumnType("varchar(16)");
//            });
//        }

//        public virtual DbSet<Asset> Assets { get; set; }
//        public virtual DbSet<Category> Categories { get; set; }
//        public virtual DbSet<Content> Content { get; set; }
//        public virtual DbSet<Menu> Menu { get; set; }

//        // Unable to generate entity type for table 'dbo.content_frontpage'. Please see the warning messages.

//        public override void Dispose()
//        {
//            base.Dispose();
//            _instanceCount = -1;
//        }

//        //~Mp3EhbContext()
//        //{
//        //    Dispose();
//        //}
//    }
//}