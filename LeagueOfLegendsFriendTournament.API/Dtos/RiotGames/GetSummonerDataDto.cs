using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class GetSummonerDataDto
    {
        [Required]
        public string username { get; set; }
    }
}