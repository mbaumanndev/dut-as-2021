using System.ComponentModel.DataAnnotations;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public short CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Nom { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-z][a-z\-]{2,}$", ErrorMessage = "La clé doit commencer par une lettre et ne comporte que des minuscules non acecntuées et des traits d'union")]
        public string Cle { get; set; }

        [Required]
        public int Ordre { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; }

        public ICollection<Sujet> Sujets { get; set; }
    }
}
