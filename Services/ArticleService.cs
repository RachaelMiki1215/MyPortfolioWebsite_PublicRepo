using MyPortfolioWebsite.Models;
using Npgsql;
using NPoco;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Services
{
    public class ArticleService
    {
        public async Task<List<Article>> GetArticlesAsync(int offset = 0, int limit = 0)
        {
            List<Article> articles;
            string queryStr = string.Format("SELECT {0} FROM {1} OFFSET {2}{3};",
                "id, title, updated_date, keywords, favs", "articles",
                offset, limit > 0 ? " LIMIT " + limit : "");

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    articles = await db.FetchAsync<Article>(queryStr);
                    await db.Connection.CloseAsync();
                }
            }

            return articles;
        }

        public async Task<Article> GetArticleAsync(long id)
        {
            Article article;

            using (NpgsqlConnection conn = new CockroachDB().conn)
            {
                using (Database db = new Database(conn))
                {
                    await db.Connection.OpenAsync();
                    article = await db.SingleOrDefaultByIdAsync<Article>(id);
                    await db.Connection.CloseAsync();
                }
            }

            return article;
        }

        public async Task<int> GetArticleCountAsync()
        {
            int count;

            string queryStr = "SELECT COUNT(*) FROM articles;";

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
                    Article article = await db.SingleOrDefaultByIdAsync<Article>(id);
                    article.Favs ++;
                    await db.UpdateAsync("articles", "id", article, Convert.ToInt64(article.Id), new List<string>() { "favs" });
                    await db.Connection.CloseAsync();
                }
            }
        }
    }
}
