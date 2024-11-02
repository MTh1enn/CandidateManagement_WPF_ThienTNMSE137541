using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public JobPosting GetJobPostingById(string jobId) => JobPostingDAO.Instance.GetJobPostingByID(jobId);

        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPosting();
        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.DeleteJobPosting(jobPosting);
    }
}
