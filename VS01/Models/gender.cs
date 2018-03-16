using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS01.Models
{
    public class gender
    {
        [Key]
        public int IdGender { get; set; }

        public string description { get; set; }

        public bool status { get; set; }

        public virtual ICollection<person> person { get; set; }
    }
}