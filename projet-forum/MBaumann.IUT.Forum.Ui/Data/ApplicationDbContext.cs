using MBaumann.IUT.Forum.Ui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MBaumann.IUT.Forum.Ui.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<Utilisateur, Role, int,
            IdentityUserClaim<int>, UtilisateurRole, IdentityUserLogin<int>,
            IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Utilisateur>(b =>
            {
                // Chaque utilisateur peut avoir plusieurs UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Chaque utilisateur peut avoir plusieurs UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Chaque utilisateur peut avoir plusieurs UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Chaque utilisateur peut avoir plusieurs UtilisateurRole
                b.HasMany(e => e.UserRoles)
                    .WithOne(u => u.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                // Chaque utilisateur peut avoir plusieurs messages
                b.HasMany(e => e.Messages)
                    .WithOne(u => u.Utilisateur)
                    .HasForeignKey(m => m.UtilisateurId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                // Chaque role peut avoir plusieurs UtilisateurRole
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.Property(e => e.Description).HasMaxLength(255);
            });

            builder.Entity<Message>(b => {
                b.HasKey(e => e.Id);

                b.HasOne(e => e.Sujet)
                    .WithMany(s => s.Messages)
                    .HasForeignKey(m => m.SujetId)
                    .IsRequired();

                b.Property(e => e.Contenu)
                    .IsRequired();

                b.Property(e => e.Supression)
                    .HasDefaultValue(false);

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAddOrUpdate()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            });

            builder.Entity<Sujet>(b => {
                b.HasKey(b => b.Id);

                b.HasOne(e => e.Topic)
                    .WithMany(t => t.Sujets)
                    .HasForeignKey(s => s.TopicId)
                    .IsRequired();

                b.Property(e => e.Nom)
                    .HasMaxLength(255)
                    .IsRequired();

                b.Property(e => e.Suppression);

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            });

            builder.Entity<Topic>(b =>
            {
                b.HasKey(b => b.Id);

                b.HasOne(e => e.Categorie)
                    .WithMany(c => c.Topics)
                    .HasForeignKey(t => t.CategorieId)
                    .IsRequired();

                b.Property(e => e.Nom)
                    .HasMaxLength(255)
                    .IsRequired();

                b.Property(e => e.Description)
                    .HasMaxLength(2000);

                b.Property(e => e.Cle)
                    .IsRequired();

                b.Property(e => e.Ordre)
                    .IsRequired();

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            });

            builder.Entity<Categorie>(b => {
                b.HasKey(e => e.Id);

                b.Property(e => e.Nom)
                    .HasMaxLength(255)
                    .IsRequired();

                b.Property(e => e.Description)
                    .HasMaxLength(2000);

                b.Property(e => e.Cle)
                    .IsRequired();

                b.Property(e => e.Ordre)
                    .IsRequired();

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .IsRequired();

                b.Property(e => e.Modification)
                    .IsRequired()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            });
        }

        public DbSet<MBaumann.IUT.Forum.Ui.Models.Categorie> Categorie { get; set; }

        public DbSet<MBaumann.IUT.Forum.Ui.Models.Topic> Topic { get; set; }

        public DbSet<MBaumann.IUT.Forum.Ui.Models.Sujet> Sujet { get; set; }

        public DbSet<Message> Message { get; set; }
    }
}