using System.ComponentModel.DataAnnotations;

namespace MBaumann.IUT.Forum.Ui.Models
{
    public class Sujet
    {
        public Guid Id { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Nom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Suppression { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Creation { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Modification { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
