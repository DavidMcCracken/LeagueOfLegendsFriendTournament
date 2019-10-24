using System;
using System.Collections.Generic;
using LeagueOfLegendsFriendTournament.API.Helpers;

namespace LeagueOfLegendsFriendTournament.API.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TournamentName { get; set; }
        public string GameType {get; set; }
        public int CreatorOfTournament { get; set; }
        public int Active { get; set; }
        public int PlayerCount { get; set; }
        
        //tells EF TournamentUser is referencing TournamentId
        public ICollection<TournamentUser> TournamentUser { get; set; }
        public ICollection<GameData> GameData { get; set; }

    }
}