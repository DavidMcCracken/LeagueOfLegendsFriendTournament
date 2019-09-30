using System;
using System.ComponentModel.DataAnnotations;
using LeagueOfLegendsFriendTournament.API.Helpers;

namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class CreateTournamentDto
    {
        [Required]
        public string TournamentName { get; set; }
        [Required]
        public int CreaterOfTournament { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required]
        public string GameType { get; set; }

    }
}