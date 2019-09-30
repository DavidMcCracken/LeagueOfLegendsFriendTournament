using System;
using System.Threading.Tasks;
using LeagueOfLegendsFriendTournament.API.Models;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public interface ITournamentRepository
    {
        Task<Tournament> Create (Tournament tournament);
        Task<bool> RemoveFromActive (int tournamentId);

    }
}