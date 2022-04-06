using Microsoft.AspNetCore.Identity;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Utilisateur : IdentityUser<int>
    {
        public ICollection<Message> Messages { get; set; }
        public virtual ICollection<UtilisateurRole> UserRoles {  get; set; }
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins {  get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
    }
}
