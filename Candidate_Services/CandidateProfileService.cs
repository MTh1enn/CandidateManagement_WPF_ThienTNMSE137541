using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo profileRepo;
        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.DeleteCandidateProfile(candidateProfile);
        }

        public CandidateProfile GetCandidateProfileById(string id)
        {
            return profileRepo.GetCandidateProfileById(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return profileRepo.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(candidateProfile);
        }
        public (List<CandidateProfile> Items, int TotalItems, int TotalPages) GetCandidateProfiles(int pageNumber, int pageSize)
        {
            var allProfiles = profileRepo.GetCandidateProfiles();
            var totalItems = allProfiles.Count();

            var pagedProfiles = allProfiles
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return (pagedProfiles, totalItems, totalPages);
        }
    }
}
