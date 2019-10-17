using noteData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteLogic
{
    public class jobtitle
    {
        note n = new note();

        public bool AddJobTitle(string job)
        {
            if (job != string.Empty)
            {
                var exist = n.jobTitles.FirstOrDefault(c => c.jobTitleName == job);
                if (exist == null)
                {
                    n.jobTitles.Add(new noteData.Model.jobTitle { jobTitleName = job });
                    n.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
        public bool EditJob(int id, string job)
        {
            if (job != string.Empty && id > 0)
            {
                var exist = n.jobTitles.FirstOrDefault(c => c.jobTitleName == job);
                if (exist == null)
                {
                    var editdepart = n.jobTitles.FirstOrDefault(c => c.ID == id);
                    editdepart.jobTitleName = job;
                    n.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteJob(int id)
        {
            if (id > 0)
            {
                var deletedepart = n.jobTitles.FirstOrDefault(c => c.ID == id);
                n.jobTitles.Remove(deletedepart);
                n.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<ViewModel.jobTitleView> displayjobTitles()
        {
            var list = n.jobTitles.Select(c => new ViewModel.jobTitleView { jobTitle = c.jobTitleName, jobId = c.ID });
            return list.ToList();
        }
    }
}
