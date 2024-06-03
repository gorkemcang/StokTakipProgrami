using System.ComponentModel.DataAnnotations;

namespace StokTakipProgrami.Entity
{
	public class User
	{
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public string? UserSurname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
