using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorldEntity
{
   public class MyWorldDbContent:DbContext
    {
        public MyWorldDbContent():base("name=MyWorldDbContent")
        {

        }


        public DbSet<User> Users { get; set; }
    }
}
