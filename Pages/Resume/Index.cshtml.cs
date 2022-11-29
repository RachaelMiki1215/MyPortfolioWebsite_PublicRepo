using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolioWebsite.Models;
using MyPortfolioWebsite.Models.Resume;
using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Services.Resume;
using System.Threading.Tasks;

namespace MyPortfolioWebsite.Pages.Resume
{
    public class IndexModel : PageModel
    {
        private readonly EducationService _educationService;
        private readonly HobbyInterestService _hobbyInterestService;
        private readonly SkillService _skillService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly ProjectService _projectService;

        public IndexModel(EducationService educationService, 
            HobbyInterestService hobbyInterestService, SkillService skillService,
            WorkExperienceService workExperienceService, ProjectService projectService)
        {
            _educationService = educationService;
            _hobbyInterestService = hobbyInterestService;
            _skillService = skillService;
            _workExperienceService = workExperienceService;
            _projectService = projectService;
        }

        public IList<Education> EducationList { get; set; }
        public IList<HobbyInterest> HobbyInterestList { get; set; }
        public IList<Skill> SkillList { get; set; }
        public IList<WorkExperience> WorkExperienceList { get; set; }
        private IList<Project> _ProjectList { get; set; }
        public IList<Project> WorkProjectList { get; set; }
        public IList<Project> PersonalProjectList { get; set; }

        public async Task OnGetAsync()
        {
            EducationList = await _educationService.GetEducationsAsync();
            HobbyInterestList = await _hobbyInterestService.GetHobbiesInterestsAsync();
            SkillList = await _skillService.GetSkillsAsync();
            WorkExperienceList = await _workExperienceService.GetWorkExperiencesAsync();

            _ProjectList = await _projectService.GetProjectsResumeInfoAsync();
            WorkProjectList = _ProjectList.Where(p => p.ProjectCategory == "work").ToList();
            PersonalProjectList = _ProjectList.Where(p => p.ProjectCategory == "personal").ToList();
        }
    }
}
