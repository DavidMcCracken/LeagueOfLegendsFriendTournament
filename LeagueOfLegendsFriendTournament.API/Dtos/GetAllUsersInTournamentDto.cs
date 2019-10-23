namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class GetAllUsersInTournamentDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int TournamentId { get; set; }
    }
}