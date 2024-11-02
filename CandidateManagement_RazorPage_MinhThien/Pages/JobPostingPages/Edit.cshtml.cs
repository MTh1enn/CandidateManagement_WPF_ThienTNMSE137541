using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement_GUI.Pages.JobPostingPages
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public EditModel(IJobPostingService jobPostingService)
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
            JobPosting = jobposting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = _jobPostingService.UpdateJobPosting(JobPosting);
            //Lỗi dưới DAO à , đợi chút xíu nhé

            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!JobPostingExists(JobPosting.PostingId))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
            return _jobPostingService.GetJobPostingById(id) != null;
        }
    }
}
