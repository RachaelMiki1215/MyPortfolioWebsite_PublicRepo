using MyPortfolioWebsite.Models;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services
{
    public class ProjectService
    {
        public async Task<List<Project>> GetProjectsAsync(int offset = 0, int limit = 0)
        {
            List<Project> projects;

            string queryStr = string.Format("SELECT {0} FROM {1} OFFSET {2}{3};",
                "id, name, updated_date, languages, keywords, category, status, platform, short_desc_html, favs",
                "projects", offset, limit > 0 ? " LIMIT " + limit : "");

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    projects = await db.FetchAsync<Project>(queryStr);
                    await db.Connection.CloseAsync();
                }
            }

            return projects;
        }

        public async Task<IList<Project>> GetProjectsBasicInfoAsync(int offset = 0, int limit = 0, string? category = null)
        {
            IList<Project> projects;

            string queryStr = string.Format("SELECT {0} FROM {1}{2} OFFSET {3}{4};",
                "id, name, updated_date, languages, keywords, category, status, platform",
                "projects", category == null ? "" : string.Format(" WHERE category='{0}'", category),
                offset, limit > 0 ? " LIMIT " + limit : "");

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    projects = await db.FetchAsync<Project>(queryStr);
                    await db.Connection.CloseAsync();
                }
            }

            return projects;
        }

        public async Task<IList<Project>> GetProjectsResumeInfoAsync()
        {
            IList<Project> projects;

            string queryStr = "SELECT id, name, languages, keywords, category, short_desc_html, src_code_link, demo_link, summary_bullets FROM projects WHERE put_on_resume = true;";

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    projects = await db.FetchAsync<Project>(queryStr);
                    await db.Connection.CloseAsync();
                }
            }

            return projects;
        }

        public async Task<Project> GetProjectAsync(long id)
        {
            Project project;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    project = await db.SingleOrDefaultByIdAsync<Project>(id);
                    await db.Connection.CloseAsync();
                }
            }

            return project;
        }

        public async Task<int> GetProjectCountAsync(string? category = null)
        {
            int count;

            string queryStr = string.Format("SELECT COUNT(*) FROM projects{0};",
                category == null ? "" : string.Format(" WHERE category='{0}'", category));

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    count = (await db.FetchAsync<int>(queryStr))[0];
                    await db.Connection.CloseAsync();
                }
            }

            return count;
        }

        public async Task AddFavAsync(long id)
        {
            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    Project project = await db.SingleOrDefaultByIdAsync<Project>(id);
                    project.Favs++;
                    await db.UpdateAsync("projects", "id", project, Convert.ToInt64(project.Id), new List<string>() { "favs" });
                    await db.Connection.CloseAsync();
                }
            }
        }
    }
}
