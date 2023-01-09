﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity;
using ECommerce.Common;
namespace ECommerce.Repository
{
    public class BrandRep : DataRepository<Brand, int>
    {
        public static MyECommerceDBEntities1 db = Tools.GetConection();
        ResultProcess<Brand> result = new ResultProcess<Brand>();

        public override Result<int> Delete(int id)
        {
            Brand silinecek = db.Brands.SingleOrDefault(t => t.BrandId == id);
            db.Brands.Remove(silinecek);
            return result.GetResult(db);
        }

        public override Result<List<Brand>> GetLatestObj(int Quantity)
        {
            return result.GetListResult(db.Brands.OrderByDescending(t => t.BrandId).Take(Quantity).ToList());
        }

        public override Result<Brand> GetObjById(int id)
        {
            Brand b = db.Brands.SingleOrDefault(t => t.BrandId == id);
            return result.GetT(b);
        }

        public override Result<int> Insert(Brand item)
        {
            db.Brands.Add(item);
            return result.GetResult(db);
        }

        public override Result<List<Brand>> List()
        {
            return result.GetListResult(db.Brands.ToList());
        }

        public override Result<int> Update(Brand item)
        {
            Brand Guncellenecek = db.Brands.SingleOrDefault(t => t.BrandId == item.BrandId);
            Guncellenecek.BrandName = item.BrandName;
            Guncellenecek.Description = item.Description;
            Guncellenecek.Photo = item.Photo;
            return result.GetResult(db);
        }
    }
}
