using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfile GetCandidateProfileById(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = this.GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " Inner Exception: " + ex.InnerException.Message;
                }
                throw new Exception(errorMessage);
            }
            return isSuccess;
        }

        public bool DeleteCandidateProfile(string profileID)
        {
            bool isSuccess = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileById(profileID);
            try
            {
                if (profileID != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            try
            {
                var existingCandidate = GetCandidateProfileById(candidate.CandidateId);

                if (existingCandidate != null)
                {
                    context.Entry(existingCandidate).State = EntityState.Detached;
                    context.CandidateProfiles.Attach(candidate);
                    context.Entry(candidate).State = EntityState.Modified;
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
