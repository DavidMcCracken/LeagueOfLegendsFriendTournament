using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Dtos.RiotGames;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface IRiotGamesRepository
    {
        Task<JObject> GetSummonerData(GetSummonerDataDto getSummonerDataDto);
        Task<JObject> GetMatchesBasedOffDateTime(GetMatchesBasedOffDateTimeDto getMatches);
        Task<JObject> GetMatchDetails(GetMatchFromMatchIdDto getMatch);
        Task<JArray> GetSummonerDataMultiple(GetSummonersDataDto summoners);
        Task<JArray> GetMatchesBasedOffDateTimeMultiple(JArray matches);
        Task<JArray> GetMatchDetailsMultiple(JArray match);
    }
}