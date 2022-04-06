using MBaumann.IUT.Forum.Ui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MBaumann.IUT.Forum.Ui.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<Utilisateur, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}