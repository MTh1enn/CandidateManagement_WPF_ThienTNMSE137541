using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public DetailsModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

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
    }
}
