using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;
        private readonly IJobPostingService _jobPostingService;

        public EditModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            _candidateProfileService = candidateProfileService;
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null || _candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(_jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = _candidateProfileService.UpdateCandidateProfile(CandidateProfile);
            //Lỗi dưới DAO à , đợi chút xíu nhé

            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
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

        private bool CandidateProfileExists(string id)
        {
            return _candidateProfileService.GetCandidateProfileById(id) != null;
        }
    }
}
