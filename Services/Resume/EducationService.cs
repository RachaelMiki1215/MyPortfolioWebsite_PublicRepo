using MyPortfolioWebsite.Models.Resume;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services.Resume
{
    public class EducationService
    {
        public async Task<List<Education>> GetEducationsAsync()
        {
            List<Education> educations;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    educations = await db.FetchAsync<Education>("SELECT * FROM education;");
                    await db.Connection.CloseAsync();
                }
            }

            return educations;
        }
    }
}
