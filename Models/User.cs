using System.ComponentModel.DataAnnotations;

namespace OVS.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        public bool IsRegistered { get; set; }
    }
}
