using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Data;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Dtos.RiotGames;
using LeagueOfLegendsFriendTournament.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RiotGamesController: ControllerBase
    {
        private readonly IRiotGamesRepository _repo;
        private readonly IConfiguration _config;


        public RiotGamesController(IRiotGamesRepository repo, IConfiguration config)
        {
            this._repo = repo;
            this._config = config;
        }

        
        [HttpGet("getSummonerData")]
        public async Task<IActionResult> GetSummonerData(GetSummonerDataDto getSummonerDataDto)
        {
            var json = await _repo.GetSummonerData(getSummonerDataDto);
            return Ok(json);
        }

        [HttpGet("getMatchesBasedOffDateTime")]
        public async Task<IActionResult> GetMatchesBasedOffDateTime(GetMatchesBasedOffDateTimeDto getMatchesDto)
        {
            var json = await _repo.GetMatchesBasedOffDateTime(getMatchesDto);
            return Ok(json);

        }
        
        [HttpGet("getMatchDetails")]
        public async Task<IActionResult> GetMatchDetails(GetMatchFromMatchIdDto getMatch)
        {
            var json = await _repo.GetMatchDetails(getMatch);
            return Ok(json);
        }

        [HttpGet("GetSummonerDataMultiple")]
        public async Task<IActionResult> GetSummonerDataMultiple()
        {
            var json = await _repo.GetSummonerDataMultiple();
            return Ok(json);
        }

    }
}
