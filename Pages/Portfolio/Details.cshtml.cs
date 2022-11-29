using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Models;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Pages.Portfolio
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectService _projectService;

        public DetailsModel(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public Project Project { get; set; } = new Project();

        public async Task<IActionResult> OnGetAsync(long? id)
        {

            if (id == null || _projectService == null)
            {
                return NotFound();
            }

            Project = await _projectService.GetProjectAsync((long)id);

            if (Project == null)
            {
                return NotFound();
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAddFav([FromRoute] long id)
        {
            await _projectService.AddFavAsync(id);
            Project.Favs = Project.Favs + 1;
            return new JsonResult(Project.Favs);
        }
    }
}
