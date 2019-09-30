using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeagueOfLegendsFriendTournament.API.Models;


namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;
        public TournamentRepository(DataContext context){
            this._context = context;
        }

        public async Task<Tournament> Create(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;

        }

        public async Task<bool> RemoveFromActive(int tournamentId)
        {
            var Tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.TournamentId == tournamentId);
            if(Tournament == null){
                return false;
            }
            _context.Tournaments.Remove(Tournament);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}