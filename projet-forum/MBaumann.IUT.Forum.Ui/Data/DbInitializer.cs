using MBaumann.IUT.Forum.Ui.Models;

namespace MBaumann.IUT.Forum.Ui.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // 1. On s'assure que la base est créée
            context.Database.EnsureCreated();

            // 2. On s'assure qu'on n'a pas déjà inséré de données
            if (context.Categorie.Any())
            {
                return;
            }

            // 3. On fait nos insertions
            var transaction = context.Database.BeginTransaction();
            try
            {
                var roleAdmin = new Role
                {
                    Name = "Admin",
                    NormalizedName = "admin",
                    Description = "Administrateur du forum"
                };
                var roleModo = new Role
                {
                    Name = "Modo",
                    NormalizedName = "modo",
                    Description = "Modérateur du forum"
                };
                var roleMembre = new Role
                {
                    Name = "Membre",
                    NormalizedName="membre",
                    Description = "Membre du forum"
                };

                context.Roles.Add(roleAdmin);
                context.Roles.Add(roleModo);
                context.Roles.Add(roleMembre);

                context.SaveChanges();

                var utilAdmin = new Utilisateur
                {
                    Email = "admin@forum.fr",
                    EmailConfirmed = true,
                    UserName = "admin",
                    NormalizedEmail = "admin@forum.fr",
                    NormalizedUserName = "admin",
                };
                var user1 = new Utilisateur
                {
                    Email = "user1@forum.fr",
                    EmailConfirmed = true,
                    UserName = "user1",
                    NormalizedEmail = "user1@forum.fr",
                    NormalizedUserName = "user1",
                };

                context.Users.Add(utilAdmin);
                context.Users.Add(user1);

                context.SaveChanges();

                context.UserRoles.Add(new UtilisateurRole
                {
                    RoleId = roleAdmin.Id,
                    UserId = utilAdmin.Id,
                });
                context.UserRoles.Add(new UtilisateurRole
                {
                    RoleId = roleMembre.Id,
                    UserId = user1.Id,
                });

                context.SaveChanges();

                var categorie1 = new Categorie
                {
                    Nom = "Général",
                    Cle = "general",
                    Description = "La vie du forum",
                    Ordre = 0
                };
                var categorie2 = new Categorie
                {
                    Nom = "Gaming",
                    Cle = "gaming",
                    Description = "Discussions gaming",
                    Ordre = 1
                };

                context.Categorie.Add(categorie1);
                context.Categorie.Add(categorie2);

                context.SaveChanges();

                var topic1 = new Topic
                {
                    Nom = "Vie du forum",
                    Cle = "vie-du-forum",
                    CategorieId = categorie1.Id,
                    Description = "Tout sur la vie du forum, charte, ...",
                    Ordre = 0,
                };
                var topic2 = new Topic {
                    Nom = "Discussions générales",
                    Cle = "discussions-generales",
                    CategorieId = categorie1.Id,
                    Description = "Ici on parle de tout et de rien",
                    Ordre = 1
                };
                var topic3 = new Topic {
                    Nom = "Minecraft",
                    Cle = "minecraft",
                    CategorieId = categorie2.Id,
                    Description = "Mods, ...",
                    Ordre = 0
                };

                context.Topic.Add(topic1);
                context.Topic.Add(topic2);
                context.Topic.Add(topic3);

                context.SaveChanges();

                var sujet1 = new Sujet {
                    Nom = "Règlement",
                    TopicId = topic1.Id,
                };
                var sujet2 = new Sujet
                {
                    Nom = "Idées d'améliorations",
                    TopicId = topic1.Id
                };
                var sujet3 = new Sujet
                {
                    Nom = "Cadavre exquis",
                    TopicId = topic2.Id,
                };

                context.Sujet.Add(sujet1);
                context.Sujet.Add(sujet2);
                context.Sujet.Add(sujet3);

                context.SaveChanges();

                var message1 = new Message
                {
                    SujetId = sujet1.Id,
                    UtilisateurId = utilAdmin.Id,
                    Contenu = "Règlement du forum",
                };
                var message2 = new Message
                {
                    SujetId = sujet2.Id,
                    UtilisateurId = utilAdmin.Id,
                    Contenu = "Partagez vos idées ici"
                };
                var message3 = new Message
                {
                    SujetId = sujet3.Id,
                    UtilisateurId = user1.Id,
                    Contenu = "Et si on faisait un cadavre exquis ?\n\nQui se lance ?"
                };

                context.Message.Add(message1);
                context.Message.Add(message2);
                context.Message.Add(message3);

                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }
    }
}
