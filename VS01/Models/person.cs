using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS01.Models
{
    public class person
    {
        [Key]
        public int IdPerson { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int IdDocumentType { get; set; }

        public string identityNumber { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public DateTime birthDate { get; set; }

        public int IdRol { get; set; }

        public string address { get; set; }

        public int IdGender { get; set; }

        public bool status { get; set; }


        public virtual documentType documentType { get; set; }

        public virtual rol rol { get; set; }

        public virtual gender genders { get; set; }


    }
}