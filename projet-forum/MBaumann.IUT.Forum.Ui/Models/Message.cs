using System.ComponentModel.DataAnnotations;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid SujetId { get; set; }
        public Sujet Sujet { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public string Contenu { get; set; }
        public bool Supression {  get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; }

    }
}
