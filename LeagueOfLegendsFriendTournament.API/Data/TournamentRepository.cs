using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeagueOfLegendsFriendTournament.API.Models;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFriendTournament.API.Dtos;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;
        public TournamentRepository(DataContext context){
            this._context = context;
        }

        public async Task<Tournament> Create(CreateTournamentDto createTournamentDto)
        {
            var TournamentToCreate = new Tournament {

                TournamentName = createTournamentDto.TournamentName,
                CreatorOfTournament = createTournamentDto.CreaterOfTournament,
                StartTime = createTournamentDto.StartTime,
                EndTime = createTournamentDto.EndTime,
                GameType = createTournamentDto.GameType,
                Active = 1
            };
            await _context.Tournaments.AddAsync(TournamentToCreate);
            await _context.SaveChangesAsync();

            return TournamentToCreate;
        }
        public async Task<TournamentUser> AddUser(AddUserToTournamentDto addUser)
        {
            var Tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.TournamentName == addUser.TournamentName && x.CreatorOfTournament ==addUser.CreaterOfTournament);
            if(Tournament == null) {
                return null;
            }
            var TournamentUser = new TournamentUser
            {
                UserID = addUser.CreaterOfTournament,
                TournamentID = Tournament.TournamentId
            };
            await _context.TournamentUsers.AddAsync(TournamentUser);
            await _context.SaveChangesAsync();
            return TournamentUser;
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

        public async Task<List<Tournament>> RetrieveAllActive(){
            var tournaments = await _context.Tournaments.Where(x => x.Active ==1).ToListAsync();
            return tournaments;
        }

        public async Task<List<JoinTournamentDto>> JoinTournamentData(){
            var values = await (from ep in _context.Users
            join e in _context.Tournaments on ep.UserId equals e.CreatorOfTournament
            where e.Active == 1
            select new JoinTournamentDto {
                TournamentId = e.TournamentId,
                UserId = ep.UserId,
                TournamentName = e.TournamentName,
                Username = ep.Username,
                Active = e.Active
            }).ToListAsync();
            return values;
        }
    }
}