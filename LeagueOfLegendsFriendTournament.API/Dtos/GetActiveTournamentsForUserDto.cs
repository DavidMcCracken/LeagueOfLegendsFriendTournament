using System;

namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class GetActiveTournamentsForUserDto
    {
        public int UserId { get; set; }
        public int tournamentId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string tournamentName { get; set; }
        public string gameType { get; set; }
        public int creatorOfTournament { get; set; }
        public int active { get; set; }
        public int playerCount { get; set; }
        public string CreatorUsername { get; set; }
    }
}