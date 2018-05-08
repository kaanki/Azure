using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Common;
using ECommerce.Entity;


namespace ECommerce.Repository
{
    public class MemberRepository : DataRepository<Member, int>
    {
        MyECommerceDBEntities1 db = Tools.GetConection();
        ResultProcess<Member> result = new ResultProcess<Member>();
        public override Result<int> Delete(int id)
        {
            Member c = db.Members.SingleOrDefault(t => t.UserId == id);
            db.Members.Remove(c);
            return result.GetResult(db);
        }

        public override Result<List<Member>> GetLatestObj(int Quantity)
        {
            return result.GetListResult(db.Members.OrderByDescending(t => t.UserId).Take(Quantity).ToList());
        }

        public override Result<Member> GetObjById(int id)
        {
            Member c = db.Members.SingleOrDefault(t => t.UserId == id);
            return result.GetT(c);
        }

        public override Result<int> Insert(Member item)
        {
            db.Members.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Member>> List()
        {
            List<Member> MemList = db.Members.ToList();
            return result.GetListResult(MemList);
        }

        public override Result<int> Update(Member item)
        {
            Member c = db.Members.SingleOrDefault(t => t.UserId == item.UserId);
            c.FirstName = item.FirstName;
            c.LastName = item.LastName;
            c.Password = item.Password;
            c.Orders = item.Orders;
            c.RoleId = item.RoleId;
            c.Email = item.Email;
            c.Address = item.Address;
            return result.GetResult(db);
        }
    }
}
