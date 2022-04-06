using Microsoft.AspNetCore.Identity;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Role : IdentityRole<int>
    {
        public string? Description { get; set; }

        public ICollection<UtilisateurRole> UserRoles { get; set; }
    }
}
