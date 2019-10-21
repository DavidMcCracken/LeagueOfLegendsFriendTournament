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
            
            var createdTournament = await _repo.Create(createTournamentDto);
            return Ok(createdTournament);
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(AddUserToTournamentDto addUser){
            var addingUser = await _repo.AddUser(addUser);
            return Ok(addingUser);
        }

        [HttpGet("retrieve-all-active")]
        public async Task<IActionResult> RetrieveAllActive(){
            var tournaments = await _repo.RetrieveAllActive();
            return Ok(tournaments);
        }

        [HttpGet("JoinTournamentList")]
        public async Task<IActionResult> JoinTournamentData(){
            var tournaments = await _repo.JoinTournamentData();
            return Ok(tournaments);
        }
        
    }
}