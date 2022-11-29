using MyPortfolioWebsite.Models.Resume;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services.Resume
{
    public class HobbyInterestService
    {
        public async Task<List<HobbyInterest>> GetHobbiesInterestsAsync()
        {
            List<HobbyInterest> hobbiesInterests;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    hobbiesInterests = await db.FetchAsync<HobbyInterest>("SELECT * FROM hobbies_interests");
                    await db.Connection.CloseAsync();
                }
                    
            }

            return hobbiesInterests;
        }
    }
}
