using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class DeleteModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public DeleteModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
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
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null || _candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }
            var candidateprofile = _candidateProfileService.GetCandidateProfileById(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateProfileService.DeleteCandidateProfile(candidateprofile);
            }

            return RedirectToPage("./Index");
        }
    }
}
