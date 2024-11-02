using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance = null;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public JobPosting GetJobPostingByID(string jobID)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(jobID));
        }
        public List<JobPosting> GetJobPosting()
        {
            return dbContext.JobPostings.ToList();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPostingByID(jobPosting.PostingId);
            try
            {
                if (job == null)
                {
                    dbContext.JobPostings.Add(jobPosting);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? job = GetJobPostingByID(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    dbContext.JobPostings.Remove(jobPosting);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? job = GetJobPostingByID(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    dbContext.Entry(job).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    dbContext.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
