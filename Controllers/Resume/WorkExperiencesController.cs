using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyPortfolioWebsite.Models.Resume;
using MyPortfolioWebsite.Services.Resume;

namespace MyPortfolioWebsite.Controllers.Resume
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        public WorkExperiencesController(WorkExperienceService workExperienceService)
        {
            WorkExperienceService = workExperienceService;
        }

        public WorkExperienceService WorkExperienceService { get; }

        [HttpGet]
        public async Task<IEnumerable<WorkExperience>> GetAsync()
        {
            return await WorkExperienceService.GetWorkExperiencesAsync();
        }
    }
}
