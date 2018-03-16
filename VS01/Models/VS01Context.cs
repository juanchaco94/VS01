using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VS01.Models
{
    public class VS01Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VS01Context() : base("name=VS01Context")
        {
        }

        public System.Data.Entity.DbSet<VS01.Models.documentType> documentTypes { get; set; }

        public System.Data.Entity.DbSet<VS01.Models.rol> rols { get; set; }

        public System.Data.Entity.DbSet<VS01.Models.gender> genders { get; set; }

        public System.Data.Entity.DbSet<VS01.Models.person> people { get; set; }
    }
}
