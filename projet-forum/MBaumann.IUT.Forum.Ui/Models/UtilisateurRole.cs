using Microsoft.AspNetCore.Identity;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class UtilisateurRole : IdentityUserRole<int>
    {
        public virtual Utilisateur User { get; set; }
        public virtual Role Role { get; set; }
    }
}
