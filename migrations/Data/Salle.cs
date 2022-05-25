using System.ComponentModel.DataAnnotations;

namespace MBaumann.IUT.Migrations.Data
{
    public class Salle
    {
        public int Id { get; set; }

        [StringLength(5, MinimumLength = 5)]
        public string Nom { get; set; }
    }
}
