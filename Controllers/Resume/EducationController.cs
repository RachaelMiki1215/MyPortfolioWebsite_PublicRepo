using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyPortfolioWebsite.Models.Resume;
using MyPortfolioWebsite.Services.Resume;

namespace MyPortfolioWebsite.Controllers.Resume
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        public EducationController(EducationService educationService)
        {
            EducationService = educationService;
        }

        EducationService EducationService { get; }

        [HttpGet]
        public async Task<IEnumerable<Education>> GetAsync()
        {
            return await EducationService.GetEducationsAsync();
        }
    }
}
