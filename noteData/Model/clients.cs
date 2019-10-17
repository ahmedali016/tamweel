using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteData.Model
{
    public class clients
    {
        public int ID { set; get; }
        [Required]
        [StringLength(200)]
        public string name { set; get; }
        [Required]
        [StringLength(100)]
        public string mail { set; get; }
        [Required]
        [StringLength(200)]
        public string password { set; get; }
        public string photo { set; get; }
       
        public DateTime birthDate { set; get; }
        public int? age { set; get; }
        public int jobId { set; get; }
        public int departmentId { set; get; }

        public virtual ICollection<clientPhone> clientPhone { get; set; }
        public virtual ICollection<clientAddress> clientAddress { get; set; }

        public virtual department Department { set; get; }
        public virtual jobTitle JobTitle { set; get; }
    }
}
