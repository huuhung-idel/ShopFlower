using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Model.Dao
{
    public class ContentDao
    {
        [Required(ErrorMessage = "Mời nhập Name...")]
        public string Name { set; get; }

       

        OnlineShopDBContext db = null;
        public ContentDao()
        {
            db = new OnlineShopDBContext();
        }
        

        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public Content GetById(string name)
        {
            return db.Contents.SingleOrDefault(x => x.Name == name);
        }

        public Content ViewDetail(int id)
        {
            return db.Contents.Find(id); 
        }

        public bool Update(Content entity)
        {
            try
            {
                var content = db.Contents.Find(entity.ID);
                content.Detail = entity.Detail;
                content.MetaTitle = entity.MetaTitle;
                content.Descriptions = entity.Descriptions;
                content.Image = entity.Image;
                content.ViewCount = entity.ViewCount;
                content.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {

                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

    }
}
