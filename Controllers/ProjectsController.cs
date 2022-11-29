using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Models;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(ProjectService projectService)
        {
            this.ProjectService = projectService;
        }

        public ProjectService ProjectService { get; }

        [HttpGet]
        [Route("{id:long?}")]
        public async Task<IEnumerable<Project>> GetAsync([FromRoute] long? id)
        {
            if (id == null)
            {
                return await ProjectService.GetProjectsAsync();
            }

            Project project = await ProjectService.GetProjectAsync((long)id);
            return new List<Project>() { project };
        }

        [HttpPost]
        [Route("{id:long?}/like")]
        public async Task<IActionResult> PostLikeAsync([FromRoute] long? id)
        {
            if (id == null)
                return new JsonResult("You didn't select any project.");

            await ProjectService.AddFavAsync((long)id);
            return new JsonResult(string.Format("Thanks for liking project ID: {0} !!", id));
        }
    }
}
