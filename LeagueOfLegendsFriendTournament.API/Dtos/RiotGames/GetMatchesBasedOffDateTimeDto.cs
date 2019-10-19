namespace LeagueOfLegendsFriendTournament.API.Dtos
{
    public class GetMatchesBasedOffDateTimeDto
    {
        public string AccountId { get; set; }
        public int[] MatchId { get; set; }
        public long BeginTime { get; set; }
        public long EndTime { get; set; }
        
    }
}