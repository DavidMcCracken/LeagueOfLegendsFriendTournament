namespace LeagueOfLegendsFriendTournament.API.Models
{
    public class GameData
    {
        public int GameDataId { get; set; }


        //Foreign key for USER
        public int UserID { get; set; }
        public User User { get; set; }

        //Foreign key for Tournament
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }

        //Data about the specific matches that are sent to database
        public bool Win { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public float Assists { get; set; }
        public int LongestTimeSpentLiving { get; set; }
        public int KillingSprees { get; set; }
        public int GoldEarned { get; set; }
        public int totalDamageDealt { get; set; }
        public int VisionScore { get; set; }
        public string Champion { get; set; }
        public string Role { get; set; }

    }
}