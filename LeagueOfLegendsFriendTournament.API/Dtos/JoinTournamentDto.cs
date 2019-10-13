namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class JoinTournamentDto
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Active { get; set; }
    }
}