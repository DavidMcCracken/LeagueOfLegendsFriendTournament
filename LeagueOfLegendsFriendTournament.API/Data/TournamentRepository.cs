using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeagueOfLegendsFriendTournament.API.Models;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFriendTournament.API.Dtos;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;
        public TournamentRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Tournament> Create(CreateTournamentDto createTournamentDto)
        {
            var isMadeAlready = await _context.Tournaments.FirstOrDefaultAsync(x => x.TournamentName == createTournamentDto.TournamentName && x.CreatorOfTournament == createTournamentDto.CreaterOfTournament);
            if (isMadeAlready != null)
            {
                return null;
            }
            var TournamentToCreate = new Tournament
            {

                TournamentName = createTournamentDto.TournamentName,
                CreatorOfTournament = createTournamentDto.CreaterOfTournament,
                StartTime = createTournamentDto.StartTime,
                EndTime = createTournamentDto.EndTime,
                GameType = createTournamentDto.GameType,
                Active = 1,
                PlayerCount = 1
            };
            await _context.Tournaments.AddAsync(TournamentToCreate);
            await _context.SaveChangesAsync();

            return TournamentToCreate;
        }
        public async Task<TournamentUser> AddUser(AddUserToTournamentDto addUser)
        {
            var Tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.TournamentId == addUser.TournamentId);

            if (Tournament.PlayerCount < 5)
            {
                var checkTournamentUser = await _context.TournamentUsers.FirstOrDefaultAsync(x => x.UserID == addUser.PersonJoiningTournament && x.TournamentID == addUser.TournamentId);
                if (checkTournamentUser == null)
                {
                    var TournamentUser = new TournamentUser
                    {
                        UserID = addUser.PersonJoiningTournament,
                        TournamentID = Tournament.TournamentId
                    };
                    await _context.TournamentUsers.AddAsync(TournamentUser);
                    await _context.SaveChangesAsync();
                    return TournamentUser;
                }
            }
            return null;
        }
        public async Task<List<GetAllUsersInTournamentDto>> GetAllUsersInTournament(TournamentIdDto tournamentId)
        {
            var players = await (from ep in _context.TournamentUsers
                                 join e in _context.Users on ep.UserID equals e.UserId
                                 where ep.TournamentID == tournamentId.TournamentId
                                 select new GetAllUsersInTournamentDto
                                 {
                                     TournamentId = ep.TournamentID,
                                     UserId = e.UserId,
                                     Username = e.Username,
                                 }).ToListAsync();
            if (players == null)
            {
                return null;
            }
            return players;

        }

        public async Task<bool> RemoveFromActive(int tournamentId)
        {
            var Tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.TournamentId == tournamentId);
            if (Tournament == null)
            {
                return false;
            }
            _context.Tournaments.Remove(Tournament);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tournament>> RetrieveAllActive()
        {
            var tournaments = await _context.Tournaments.Where(x => x.Active == 1 && x.PlayerCount < 5).ToListAsync();
            return tournaments;
        }

        public async Task<List<JoinTournamentDto>> GetActiveTournamentsData()
        {
            var values = await (from ep in _context.Users
                                join e in _context.Tournaments on ep.UserId equals e.CreatorOfTournament
                                where e.Active == 1
                                select new JoinTournamentDto
                                {
                                    TournamentId = e.TournamentId,
                                    UserId = ep.UserId,
                                    TournamentName = e.TournamentName,
                                    Username = ep.Username,
                                    GameType = e.GameType
                                }).ToListAsync();
            return values;
        }
        public async Task<List<Tournament>> GetActiveTournamentsForUsers(GetActiveTournamentsForUserDto activeTournaments)
        {
            var tournaments = await (from tu in _context.TournamentUsers
                                     join t in _context.Tournaments on tu.TournamentID equals t.TournamentId
                                     where tu.UserID == activeTournaments.UserId && t.Active == 1
                                     select t).ToListAsync();
            return tournaments;
        }
    }
}