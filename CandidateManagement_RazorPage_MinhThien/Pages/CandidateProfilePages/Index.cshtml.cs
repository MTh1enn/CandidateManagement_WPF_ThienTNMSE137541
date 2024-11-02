using Candidate_BusinessObjects;
using Candidate_Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public IndexModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public void OnGet(int pageNumber = 1, int pageSize = 20)
        {
            var (items, totalItems, totalPages) = _candidateProfileService.GetCandidateProfiles(pageNumber, pageSize);

            CandidateProfile = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
