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
    public class DepartmentController : ApiController
    {
        department op = new department();

        public IEnumerable<DepartmentView> GetDepartments()
        {
            var list = op.displayDepartments();
            return list;
        }

        public DepartmentView GetDepartment(int id)
        {
            var list = op.displayDepartments().FirstOrDefault(c => c.depaId == id);
            return list;
        }

        public IEnumerable<DepartmentView> PostDepartment(DepartmentView depart)
        {
            var result = op.AddDepartment(depart.departmentName);

            var list = op.displayDepartments();
            return list;
        }

        public IEnumerable<DepartmentView> PutDepartment(DepartmentView depart)
        {
            var result = op.EditDepartment(depart.depaId, depart.departmentName);
            var list = op.displayDepartments();
            return list;
        }

        public IEnumerable<DepartmentView> DeleteDepartment(int id)
        {
            var result = op.DeleteDepartment(id);
            var list = op.displayDepartments();
            return list;
        }

        
    }
    
}
