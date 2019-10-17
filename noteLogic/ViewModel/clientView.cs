using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteLogic.ViewModel
{
    public class clientView
    {
        public int clientId { set; get; }
        public string clientName { set; get; }
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public string mail { get; set; }
        public string birthdate { set; get; }
        public int job { set; get; }
        public string jobTitle { get; set; }
        public List<phone> clientPhone { set; get; }
        public List<address> clientAddress { set; get; }
        public int age { set; get; }
        public string photo { get; set; }
        public string password { get; set; }
    }

    public class phone
    {
        public int clientId { set; get; }
        public string phones { set; get; }
    }

    public class address
    {
        public int clientId { set; get; }
        public string addres { set; get; }
    }
}
