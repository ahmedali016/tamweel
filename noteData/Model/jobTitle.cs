using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteData.Model
{
   public class jobTitle
    {
        public int ID { set; get; }
        [Required]
        [StringLength(100)]
        public string jobTitleName { set; get; }

    }
}
