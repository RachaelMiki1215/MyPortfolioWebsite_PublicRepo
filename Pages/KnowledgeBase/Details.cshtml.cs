using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Models;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Pages.KnowledgeBase
{
    public class DetailsModel : PageModel
    {
        private readonly ArticleService _articleService;

        public DetailsModel(ArticleService articleService)
        {
            _articleService = articleService;
        }

        public Article Article { get; set; } = new Article();

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _articleService == null)
            {
                return NotFound();
            }

            Article = await _articleService.GetArticleAsync((long)id);

            if (Article == null)
            {
                return NotFound();
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAddFav([FromRoute]long id)
        {
            await _articleService.AddFavAsync(id);
            Article.Favs = Article.Favs + 1;
            return new JsonResult(Article.Favs);
        }
        
    }
}
