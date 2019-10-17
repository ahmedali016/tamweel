using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteData.Model
{
   public class clientAddress
    {
        public int ID { set; get; }
        public int clientId { set; get; }
        [Required]
        [StringLength(150)]
        public string address { set; get; }

        public virtual clients Clients { set; get; }
        

    }
}
