using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Models;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface ITournamentRepository
    {
        Task<Tournament> Create (CreateTournamentDto createTournamentDto);
        Task<bool> RemoveFromActive (int tournamentId);
        Task<List<Tournament>> RetrieveAllActive();
        Task<List<JoinTournamentDto>> GetActiveTournamentsData();
        Task<TournamentUser> AddUser(AddUserToTournamentDto addUser);
        Task<List<GetAllUsersInTournamentDto>> GetAllUsersInTournament(TournamentIdDto tournamentId);

    }
}