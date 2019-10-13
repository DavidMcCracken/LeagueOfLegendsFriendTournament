using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Models;
using Microsoft.EntityFrameworkCore;


namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<User>> RetrieveAllUsers()
        {
            var values = await _context.Users.ToListAsync();
            return values;
        }

        public async Task<object> RetrieveUser(int id)
        {
            var value = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            var obj = new {username = value.Username};

            return obj;
        }
    }
}