using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Concrete;
using Infrastructure.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentRequest> CommentRequests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.ApplyConfiguration(new UserConfig());
            base.OnModelCreating(builder);

			builder.Entity<IdentityRole>(entity =>
			{
				entity.Property(m => m.Name).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.NormalizedName).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
			});

			builder.Entity<IdentityUser>(entity =>
			{
				entity.Property(m => m.UserName).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.NormalizedUserName).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.Email).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.NormalizedEmail).HasMaxLength(256).HasColumnType("varchar(256)");
				entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
				entity.Property(m => m.PasswordHash).HasColumnType("longtext");
				entity.Property(m => m.SecurityStamp).HasColumnType("longtext");
				entity.Property(m => m.PhoneNumber).HasColumnType("longtext");
				entity.Property(m => m.LockoutEnd).HasColumnType("datetime").IsRequired(false); // datetime(6) yerine datetime kullanımı
			});

			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.HasKey(m => new { m.UserId, m.RoleId });
			});

			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.Property(m => m.ClaimType).HasColumnType("longtext");
				entity.Property(m => m.ClaimValue).HasColumnType("longtext");
			});

			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.HasKey(m => new { m.LoginProvider, m.ProviderKey });
				entity.Property(m => m.ProviderDisplayName).HasColumnType("longtext");
			});

			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.Property(m => m.ClaimType).HasColumnType("longtext");
				entity.Property(m => m.ClaimValue).HasColumnType("longtext");
			});

			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.HasKey(m => new { m.UserId, m.LoginProvider, m.Name });
				entity.Property(m => m.Value).HasColumnType("longtext");
			});

			builder.Entity<Message>(entity =>
			{
				entity.Property(m => m.PostedDate).HasColumnType("datetime"); 
			});

			// Comment entity'si için ayarlar
			builder.Entity<Comment>(entity =>
			{
				entity.Property(m => m.PostedDate).HasColumnType("datetime");
				entity.HasOne(m => m.Post)
					  .WithMany(p => p.Comments)
					  .HasForeignKey(m => m.PostId);
			});

			builder.Entity<CommentRequest>(entity =>
			{
				entity.Property(m => m.PostedDate).HasColumnType("datetime");
				entity.HasOne(m => m.Post)
					  .WithMany(p => p.CommentRequests) // Eğer CommentRequest ile Post arasında bire çok ilişki varsa bu satır geçerli
					  .HasForeignKey(m => m.PostId);
			});

			builder.Entity<Post>(entity =>
			{
				entity.Property(m => m.PostedDate).HasColumnType("datetime");
				entity.Property(m => m.UserId).HasMaxLength(450);
				entity.HasOne(m => m.AppUser)
					  .WithMany(u => u.Posts)
					  .HasForeignKey(m => m.UserId);
			});
		}


    }
}
