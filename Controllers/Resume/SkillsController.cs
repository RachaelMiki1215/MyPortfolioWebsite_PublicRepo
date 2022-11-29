using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyPortfolioWebsite.Models.Resume;
using MyPortfolioWebsite.Services.Resume;

namespace MyPortfolioWebsite.Controllers.Resume
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        public SkillsController(SkillService skillService)
        {
            SkillService = skillService;
        }

        public SkillService SkillService { get; }

        [HttpGet]
        public async Task<IEnumerable<Skill>> GetAsync()
        {
            return await SkillService.GetSkillsAsync();
        }
    }
}
