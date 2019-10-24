using LeagueOfLegendsFriendTournament.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfLegendsFriendTournament.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TournamentUser> TournamentUsers { get; set; }
        public DbSet<GameData> GameDatas { get; set; }
    }
}