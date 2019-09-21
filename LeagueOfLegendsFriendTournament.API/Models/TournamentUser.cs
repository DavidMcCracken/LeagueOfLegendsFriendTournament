using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LeagueOfLegendsFriendTournament.API.Models
{
    public class TournamentUser
    {
        public int TournamentUserId { get; set; }
        public int Wins { get; set; }

        //Foreign key for USER
        public int UserID { get; set; }
        public User User{ get; set; }

        //Foreign key for Tournament
        public int TournamentID { get; set; }
        public Tournament Tournament{ get; set; }

    }
}