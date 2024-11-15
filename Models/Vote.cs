using System.ComponentModel.DataAnnotations;

namespace OVS.Database
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NationalParty { get; set; }

        [Required]
        public string ProvincialParty { get; set; }

        [Required]
        public string LocalParty { get; set; }

        public string ElectionType { get; set; } // Optional
    }
}
