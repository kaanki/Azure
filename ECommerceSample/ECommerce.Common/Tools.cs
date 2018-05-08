using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;

namespace ECommerce.Common
{
    public class Tools
    {
        public static MyECommerceDBEntities db = null;
        public static MyECommerceDBEntities GetConnection()
        {
            if (db == null)
                db = new MyECommerceDBEntities();

            return db;
        }
    }
}
