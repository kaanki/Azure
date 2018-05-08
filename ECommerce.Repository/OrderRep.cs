using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;
using ECommerce.Common;

namespace ECommerce.Repository
{
    public class OrderRep : DataRepository<Order, int>
    {
        private static MyECommerceDBEntities1 db = Tools.GetConection();
        ResultProcess<Order> result = new ResultProcess<Order>();
        public override Result<int> Delete(int id)
        {
            Order deleted = db.Orders.SingleOrDefault(t => t.OrderId == id);
            db.Orders.Remove(deleted);
            return result.GetResult(db);
        }

        public override Result<List<Order>> GetLatestObj(int Quantity)
        {
            return result.GetListResult(db.Orders.OrderByDescending(t => t.OrderId).Take(Quantity).Take(Quantity).ToList());
        }

        public override Result<Order> GetObjById(int id)
        {
            Order obj = db.Orders.SingleOrDefault(t => t.OrderId == id);
            return result.GetT(obj);
        }

        public override Result<int> Insert(Order item)
        {
            db.Orders.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Order>> List()
        {
            List<Order> OrdList = db.Orders.ToList();
            return result.GetListResult(OrdList);
        }

        public override Result<int> Update(Order item)
        {
            Order Updated = db.Orders.SingleOrDefault(t => t.OrderId == item.OrderId);
            Updated.IsPay = item.IsPay;
            Updated.TotalPrice = item.TotalPrice;
            return result.GetResult(db);
        }
    }
}
