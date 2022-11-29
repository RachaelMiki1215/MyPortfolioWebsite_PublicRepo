using MyPortfolioWebsite.Models.Resume;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services.Resume
{
    public class SkillService
    {
        public async Task<List<Skill>> GetSkillsAsync()
        {
            List<Skill> skills;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    skills = await db.FetchAsync<Skill>("SELECT * FROM skills ORDER BY level ASC, name ASC;");
                    await db.Connection.CloseAsync();
                }
            }

            return skills;
        }
    }
}
