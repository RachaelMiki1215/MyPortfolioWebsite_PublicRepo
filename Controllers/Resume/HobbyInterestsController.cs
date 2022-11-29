using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyPortfolioWebsite.Models.Resume;
using MyPortfolioWebsite.Services.Resume;

namespace MyPortfolioWebsite.Controllers.Resume
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyInterestsController : ControllerBase
    {
        public HobbyInterestsController(HobbyInterestService hobbyInterestService)
        {
            HobbyInterestService = hobbyInterestService;
        }

        public HobbyInterestService HobbyInterestService { get; }

        [HttpGet]
        public async Task<IEnumerable<HobbyInterest>> GetAsync()
        {
            return await HobbyInterestService.GetHobbiesInterestsAsync();
        }
    }
}
