using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IJobPostingService
    {
        public JobPosting GetJobPostingById(string jobId);
        public List<JobPosting> GetJobPostings();

        bool AddJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(JobPosting jobPosting);
        bool UpdateJobPosting(JobPosting jobPosting);

    }
}
