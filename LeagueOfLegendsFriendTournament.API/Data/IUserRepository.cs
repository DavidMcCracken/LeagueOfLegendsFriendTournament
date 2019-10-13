using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Models;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface IUserRepository
    {
        Task<object> RetrieveUser(int id);
        Task<List<User>> RetrieveAllUsers();
        
    }
}