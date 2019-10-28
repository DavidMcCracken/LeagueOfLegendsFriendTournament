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
        private readonly IUserRepository _user;

        public TournamentController(ITournamentRepository repo, IConfiguration config, IUserRepository user)
        {
            this._repo = repo;
            this._config = config;
            this._user = user;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTournamentDto createTournamentDto)
        {

            var createdTournament = await _repo.Create(createTournamentDto);
            return Ok(createdTournament);
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(AddUserToTournamentDto addUser)
        {
            var addingUser = await _repo.AddUser(addUser);
            return Ok(addingUser);
        }

        [HttpGet("retrieve-all-active")]
        public async Task<IActionResult> RetrieveAllActive()
        {
            var tournaments = await _repo.RetrieveAllActive();
            return Ok(tournaments);
        }

        [HttpGet("GetActiveTournamentsData")]
        public async Task<IActionResult> GetActiveTournamentsData()
        {
            var tournaments = await _repo.GetActiveTournamentsData();
            return Ok(tournaments);
        }
        [HttpPost("GetAllUsersInTournament")]
        public async Task<IActionResult> GetAllUsersInTournament(TournamentIdDto tournamentId)
        {
            var players = await _repo.GetAllUsersInTournament(tournamentId);
            return Ok(players);
        }

        [HttpPost("GetActiveTournamentsForUsers")]
        public async Task<IActionResult> GetActiveTournamentsForUsers(GetActiveTournamentsForUserDto activeTournaments)
        {
            var tournaments = await _repo.GetActiveTournamentsForUsers(activeTournaments);
            return Ok(tournaments);
        }

    }
}