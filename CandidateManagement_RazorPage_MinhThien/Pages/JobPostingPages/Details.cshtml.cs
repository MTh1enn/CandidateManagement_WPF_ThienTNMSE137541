using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.JobPostingPages
{
    public class DetailsModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public DetailsModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingService.GetJobPostingById(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            else
            {
                JobPosting = jobposting;
            }
            return Page();
        }
    }
}
