using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize()
        {
            //migrations if they are not applied

            //create roles if they are not created

            //if roles are not created, then we will create admin user as well
            
        }
    }
}
