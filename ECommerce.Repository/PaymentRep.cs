using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;
using ECommerce.Common;

namespace ECommerce.Repository
{
    public class PaymentRep
    {
        private static MyECommerceDBEntities1 db = Tools.GetConection();
        public static List<Payment> list()
            {
            return db.Payments.ToList();
            }

    }

}
