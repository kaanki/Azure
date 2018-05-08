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
        public static MyECommerceDBEntities1 db = null;
        public static MyECommerceDBEntities1 GetConection()
        {
            if (db==null)
            {
                db = new MyECommerceDBEntities1();
            }

            return db;
        }

    }
}
