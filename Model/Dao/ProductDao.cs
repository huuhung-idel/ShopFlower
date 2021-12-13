using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDBContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDBContext();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public IEnumerable<Product> ListAll(string search, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Name.Contains(search));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

    
        public bool Update(Product enti)
        {
            try
            {
                var product = db.Products.Find(enti.ID);
                product.Name = enti.Name;
                product.Code = enti.Code;
                product.MetaTitle = enti.MetaTitle;
                product.Price = enti.Price;
                product.IncludeVAT = enti.IncludeVAT;
                product.Quantity = enti.Quantity;
                product.ModifiedBy = enti.ModifiedBy;
                product.ModifiedDate = DateTime.Now;
                product.Status = enti.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Product GetById(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {

                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        public List<Product> ListRelateProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        public List<Product> ListByCategoryId(long categoryId)
        {
            return db.Products.Where(x => x.CategoryID == categoryId).ToList();
        }

        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        }

        public List<Product> ListSearch(string search)
        {
            return db.Products.Where(x => x.Name == search ).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
