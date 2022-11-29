using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Models;

namespace MyPortfolioWebsite.Pages
{
    public class sitemapModel : PageModel
    {
        public readonly ProjectService _projectService;
        public readonly ArticleService _articleService;

        public sitemapModel(ProjectService projectService,
            ArticleService articleService)
        {
            _projectService = projectService;
            _articleService = articleService;
        }

        public IList<Project> Projects { get; set; } = new List<Project>();
        public IList<Article> Articles { get; set; } = new List<Article>();

        public async Task OnGetAsync()
        {
            Projects = await _projectService.GetProjectsAsync();
            Articles = await _articleService.GetArticlesAsync();
        }
    }
}
