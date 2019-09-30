using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Data;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LeagueOfLegendsFriendTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository _repo;
        private readonly IConfiguration _config;

        
        public TournamentController(ITournamentRepository repo, IConfiguration config){
            this._repo = repo;
            this._config = config;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTournamentDto createTournamentDto){
            var TournamentToCreate = new Tournament {

                TournamentName = createTournamentDto.TournamentName,
                CreatorOfTournament = createTournamentDto.CreaterOfTournament,
                StartTime = createTournamentDto.StartTime,
                EndTime = createTournamentDto.EndTime,
                GameType = createTournamentDto.GameType,
                Active = 1
            };
            var createdTournament = await _repo.Create(TournamentToCreate);
            return Ok(TournamentToCreate);
        }
        
    }
}