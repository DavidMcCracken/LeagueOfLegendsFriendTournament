using System;
using System.Collections.Generic;

namespace LeagueOfLegendsFriendTournament.API.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        //tells EF TournamentUser is referencing TournamentId
        public ICollection<TournamentUser> TournamentUser { get; set; }
    }
}