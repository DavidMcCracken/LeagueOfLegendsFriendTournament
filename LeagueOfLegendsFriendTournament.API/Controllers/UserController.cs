using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Data;
using LeagueOfLegendsFriendTournament.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LeagueOfLegendsFriendTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UserController(IUserRepository repo, IConfiguration config)
        {
            this._config = config;
            this._repo = repo;
        }

        [HttpGet("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var values = await _repo.RetrieveAllUsers();
            return Ok(values);
        }
        [HttpGet("user")]
        public async Task<IActionResult> RetrieveUsername(UserIdDto userIdDto)
        {
            var value = await _repo.RetrieveUser(userIdDto.UserId);
            return Ok(value);
        }
    }
}