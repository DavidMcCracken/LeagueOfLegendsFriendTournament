using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Dtos.RiotGames;
using LeagueOfLegendsFriendTournament.API.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class RiotGamesRepository : IRiotGamesRepository
    {
        private readonly DataContext _context;
        private readonly string _riotToken;
        private readonly string _champData;

        public RiotGamesRepository(DataContext context, Riot token)
        {
            this._context = context;
            this._riotToken = token.RiotToken;
            this._champData = token.RiotChampionsData;
        }


        public async Task<JObject> GetSummonerData(GetSummonerDataDto getMatch)
        {
            string username = getMatch.Username;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + username;
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotToken);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(body);
            return json;
        }

        public async Task<JObject> GetMatchesBasedOffDateTime(GetMatchesBasedOffDateTimeDto getMatches)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "https://na1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + getMatches.AccountId +
            "?queue=" + 400 +
            "&queue=" + 410 +
            "&queue=" + 420 +
            "&queue=" + 430 +
            "&queue=" + 440 +
            "&endTime=" + getMatches.EndTime +
            "&beginTime=" + getMatches.BeginTime;
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotToken);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(body);
            JArray arjson = new JArray(json);
            foreach (JObject obj in arjson)
            {
                obj.Add(getMatches.AccountId, obj.GetValue("matches"));
                obj.Property("matches").Remove();
            }
            return json;
        }
        public async Task<JObject> GetMatchDetails(GetMatchFromMatchIdDto getMatch)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "https://na1.api.riotgames.com/lol/match/v4/matches/" + getMatch.MatchId;
            client.DefaultRequestHeaders.Add("X-Riot-Token", _riotToken);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(body);
            JArray arjson = new JArray(json);

            return json;
        }
        public async Task<JArray> GetSummonerDataMultiple(GetSummonersDataDto summoners)
        {

            JArray SummonersData = new JArray();
            foreach (var player in summoners.Username)
            {
                var user = await GetSummonerData(new GetSummonerDataDto { Username = player });
                if (user != null)
                {
                    SummonersData.Add(user);
                }
            }
            return SummonersData;
        }

        public async Task<JArray> GetMatchesBasedOffDateTimeMultiple(JArray matches)
        {
            JArray MatchesData = new JArray();
            foreach (var match in matches)
            {
                var matchData = await GetMatchesBasedOffDateTime(
                    new GetMatchesBasedOffDateTimeDto
                    {
                        AccountId = match.Value<string>("accountid"),
                        BeginTime = match.Value<long>("begintime"),
                        EndTime = match.Value<long>("endtime")
                    });
                if (matchData != null)
                {
                    MatchesData.Add(matchData);
                }
            }
            return MatchesData;

        }
    }
}

