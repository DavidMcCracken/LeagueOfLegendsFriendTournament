using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Models;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}