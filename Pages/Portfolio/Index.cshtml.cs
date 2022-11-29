using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Models;
using MyPortfolioWebsite.Services;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Pages.Portfolio
{
    public class IndexModel : PageModel
    {
        private readonly ProjectService _projectService;

        public IndexModel(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public IList<Project> Projects { get; set; } = new List<Project>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int ProjectCount { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageCount => (int)Math.Ceiling(decimal.Divide(ProjectCount, PageSize));

        public async Task OnGetAsync()
        {
            ProjectCount = await _projectService.GetProjectCountAsync("personal");

            Projects = await _projectService.GetProjectsBasicInfoAsync(
                (CurrentPage - 1)*10, 10, "personal");
        }
    }
}
