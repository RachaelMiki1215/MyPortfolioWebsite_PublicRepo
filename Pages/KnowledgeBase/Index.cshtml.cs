using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Models;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Pages.KnowledgeBase
{
    public class IndexModel : PageModel
    {
        private readonly ArticleService _articleService;

        public IndexModel(ArticleService articleService)
        {
            _articleService = articleService;
        }

        public IList<Article> Articles { get; set; } = new List<Article>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ArticleCount { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageCount => (int)Math.Ceiling(decimal.Divide(ArticleCount, PageSize));

        public async Task OnGetAsync()
        {
            Articles = await _articleService.GetArticlesAsync();

            ArticleCount = await _articleService.GetArticleCountAsync();

            Articles = await _articleService.GetArticlesAsync((CurrentPage - 1) * 10, 10);
        }
    }
}
