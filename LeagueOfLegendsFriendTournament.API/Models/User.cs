using System.Collections.Generic;

namespace LeagueOfLegendsFriendTournament.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalted { get; set; }
        public int TournamentsWon { get; set; }
        public int TournamentsLost { get; set; }

        //tells EF TournamentUser is referencing UserId key
        public ICollection<TournamentUser> TournamentUser { get; set; }
        public ICollection<GameData> GameData { get; set; }


    }
}