using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Test_Data_extraction
{
    public class FreelancerDb : DbContext
    {
        public FreelancerDb()
            : base("DBConnection")
        {

        }

        public DbSet<Freelancer> Freelancers { get; set; }
    }
}
