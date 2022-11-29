using MyPortfolioWebsite.Models.Resume;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services.Resume
{
    public class WorkExperienceService
    {
        public async Task<List<WorkExperience>> GetWorkExperiencesAsync()
        {
            List<WorkExperience> workExperiences;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    workExperiences = await db.FetchAsync<WorkExperience>("SELECT * FROM work_experience");
                    await db.Connection.CloseAsync();
                }
            }

            return workExperiences;
        }
    }
}
