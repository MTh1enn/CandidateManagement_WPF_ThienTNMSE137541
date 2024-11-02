using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
            => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) 
            => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);
        
        public CandidateProfile GetCandidateProfileById(string id)
            => CandidateProfileDAO.Instance.GetCandidateProfileById(id);
        

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();
        
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)=> CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
        
    }
}
