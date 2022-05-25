using MBaumann.IUT.Migrations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MBaumann.IUT.Migrations.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IutDbContext _context;

        public IEnumerable<Salle> Salles { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IutDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Salles = _context.Salle.AsEnumerable();
        }
    }
}