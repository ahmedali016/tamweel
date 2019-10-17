using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noteData.Model;
namespace noteLogic
{
    public class department
    {
        note n = new note();

        public bool AddDepartment(string depart)
        {
            
            if (depart != string.Empty)
            {
                var exist = n.departments.FirstOrDefault(c => c.departmentName == depart);
                if (exist == null)
                {
                    n.departments.Add(new noteData.Model.department { departmentName = depart });
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
        public bool EditDepartment(int id,string depart)
        {
            if (depart != string.Empty && id>0)
            {
                var exist = n.departments.FirstOrDefault(c => c.departmentName == depart);
                if (exist == null)
                {
                    var editdepart = n.departments.FirstOrDefault(c => c.ID == id);
                    editdepart.departmentName = depart;
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

        public bool DeleteDepartment(int id)
        {
            if (id > 0)
            {
                var deletedepart = n.departments.FirstOrDefault(c => c.ID == id);
                n.departments.Remove(deletedepart);
                n.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<ViewModel.DepartmentView> displayDepartments()
        {
            var list = n.departments.Select(c => new ViewModel.DepartmentView { departmentName = c.departmentName, depaId = c.ID });
            return list.ToList();
        }
    }
}
