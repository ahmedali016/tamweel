using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteData.Model
{
    public class clientPhone
    {
        public int ID { set; get; }
        public int clientId { set; get; }
        [Required]
        [StringLength(50)]
        public string phone { set; get; }

        public virtual clients Clients { set; get; }
    }
}
