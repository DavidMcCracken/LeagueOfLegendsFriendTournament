using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LeagueOfLegendsFriendTournament.API.Helpers
{
    public class Riot
    {
        public string RiotToken { get; set; }
        public string RiotChampionsData { get; set; }

        public Riot()
    {
        using(StreamReader r = new StreamReader("champion.json"))
        {
            RiotChampionsData = r.ReadToEnd();
        }
        
    }
    }

    
}