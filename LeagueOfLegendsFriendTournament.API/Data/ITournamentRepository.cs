using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Dtos;
using LeagueOfLegendsFriendTournament.API.Models;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface ITournamentRepository
    {
        Task<Tournament> Create (CreateTournamentDto createTournamentDto);
        Task<bool> RemoveFromActive (int tournamentId);
        Task<List<Tournament>> RetrieveAllActive();
        Task<List<JoinTournamentDto>> JoinTournamentData();
        Task<TournamentUser> AddUser(AddUserToTournamentDto addUser);

    }
}