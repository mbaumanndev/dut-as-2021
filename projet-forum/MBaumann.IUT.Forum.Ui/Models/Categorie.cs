using System.ComponentModel.DataAnnotations;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Categorie
    {
        public short Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Nom { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-z][a-z\-]{2,}$", ErrorMessage = "La clé doit commencer par une lettre et ne comporte que des minuscules non acecntuées et des traits d'union")]
        public string Cle { get; set; }

        [Required]
        public short Ordre { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
