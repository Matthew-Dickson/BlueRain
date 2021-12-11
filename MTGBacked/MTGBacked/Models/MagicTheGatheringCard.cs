using System.ComponentModel.DataAnnotations;

namespace MTGBacked.Models
{
    //Model showing the structure of a Magic the gathering card
    public class MagicTheGatheringCard
    {
        [Key]
        public int Id { get; set; }

    
        [Required]
        public string CardName { get; set; }

        [Required]
        public string CardType { get; set; }

        [Required]
        public string CardDiscription { get; set; }

    }
}
