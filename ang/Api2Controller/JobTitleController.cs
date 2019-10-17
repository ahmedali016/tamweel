using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using noteLogic;
using noteLogic.ViewModel;

namespace ang.Api2Controller
{
    public class JobTitleController : ApiController
    {
        jobtitle op = new jobtitle();
        public IEnumerable<jobTitleView> GetJobTitles()
        {
            var list=op.displayjobTitles();
            return list;
        }

        public jobTitleView GetJobTitle(int id)
        {
            var list = op.displayjobTitles().FirstOrDefault(c=>c.jobId==id);
            return list;
        }

        public IEnumerable<jobTitleView> PostJobTitle(jobTitleView job)
        {
            var result = op.AddJobTitle(job.jobTitle);
            var list = op.displayjobTitles();
            return list;
        }

        public IEnumerable<jobTitleView> PutjobTitle(jobTitleView job)
        {
            var result = op.EditJob(job.jobId, job.jobTitle);
            var list = op.displayjobTitles();
            return list;
        }

        public IEnumerable<jobTitleView> DeleteJob(int id)
        {
            var result = op.DeleteJob(id);
            var list = op.displayjobTitles();
            return list;
        }
    }
}
