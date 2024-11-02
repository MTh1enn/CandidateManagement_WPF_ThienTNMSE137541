using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;
        private readonly IJobPostingService _jobPostingService;

        public CreateModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            _candidateProfileService = candidateProfileService;
            _jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _candidateProfileService.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                return Page();
            }

            _candidateProfileService.AddCandidateProfile(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
