using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.Models;
using MyPortfolioWebsite.Services;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        public ArticlesController(ArticleService articleService)
        {
            ArticleService = articleService;
        }

        public ArticleService ArticleService { get; }

        [HttpGet]
        [Route("{id:long?}")]
        public async Task<IEnumerable<Article>> GetAsync([FromRoute] long? id)
        {
            if (id == null)
            {
                return await ArticleService.GetArticlesAsync();
            }

            Article article = await ArticleService.GetArticleAsync((long)id);
            return new List<Article>() { article };
        }

        [HttpPost]
        [Route("{id:long?}/like")]
        public async Task<IActionResult> PostLikeAsync([FromRoute] long? id)
        {
            if (id == null)
                return new JsonResult("You didn't select any article.");

            await ArticleService.AddFavAsync((long)id);
            return new JsonResult(string.Format("Thanks for liking article ID: {0} !!", id));
        }
    }
}
