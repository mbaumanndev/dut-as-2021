using MBaumann.IUT.Migrations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MBaumann.IUT.Migrations.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IutDbContext _context;

        public PrivacyModel(ILogger<PrivacyModel> logger, IutDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            if (_context.Salle.Count() == 0)
            {
                _context.Salle.Add(new Salle { Nom = "TP-01" });
                _context.Salle.Add(new Salle { Nom = "TP-02" });
                _context.Salle.Add(new Salle { Nom = "TP-03" });
                _context.Salle.Add(new Salle { Nom = "TP-04" });
                _context.Salle.Add(new Salle { Nom = "TD-01" });
                _context.Salle.Add(new Salle { Nom = "TD-02" });
                _context.Salle.Add(new Salle { Nom = "TD-03" });
                _context.Salle.Add(new Salle { Nom = "TD-04" });

                _context.SaveChanges();
            }
        }
    }
}