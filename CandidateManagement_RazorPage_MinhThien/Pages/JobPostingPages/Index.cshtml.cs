using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.JobPostingPages
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public IndexModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IList<JobPosting> JobPosting { get; set; } = default!;

        public void OnGet()
        {
            JobPosting = _jobPostingService.GetJobPostings();
        }
    }
}
