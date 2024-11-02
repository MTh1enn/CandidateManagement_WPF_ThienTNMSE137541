using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.JobPostingPages
{
    public class DeleteModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public DeleteModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
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

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = _jobPostingService.GetJobPostingById(id);
            if (jobposting != null)
            {
                JobPosting = jobposting;
                _jobPostingService.DeleteJobPosting(jobposting);
            }

            return RedirectToPage("./Index");
        }
    }
}
