using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;
using ECommerce.Common;

namespace ECommerce.Repository
{
    public class CommentRep:DataRepository<Comment,int>
    {
        MyECommerceDBEntities1 db = Tools.GetConection();
        ResultProcess<Comment> result = new ResultProcess<Comment>();

        public override Result<int> Delete(int id)
        {
            Comment com = db.Comments.SingleOrDefault(x => x.CommentID == id);
            db.Comments.Remove(com);
            return result.GetResult(db);
        }

        public override Result<List<Comment>> GetLatestObj(int Quantity)
        {
            throw new NotImplementedException();
        }

        public override Result<Comment> GetObjById(int id)
        {
            Comment com = db.Comments.SingleOrDefault(x => x.CommentID == id);
            return result.GetT(com);
        }

        public override Result<int> Insert(Comment item)
        {
            db.Comments.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Comment>> List()
        {
            List<Comment> ComList = db.Comments.ToList();
            return result.GetListResult(ComList);
        }

        public override Result<int> Update(Comment item)
        {
            throw new NotImplementedException();
        }
        public Result<List<Comment>> GetListByComId(int Id)
        {
            return result.GetListResult(db.Comments.Where(t => t.ProductId == Id).ToList());

        }
    }
}
