using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }


        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4-8 characters")]
        public string Password { get; set; }
    }
}