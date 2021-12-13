using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsDao
    {
        OnlineShopDBContext db = null;
        public NewsDao()
        {
            db = new OnlineShopDBContext();
        }
        public List<News> ListAll()
        {
            return db.News.Where(x => x.Status == true).OrderBy(x => x.CreateDate).ToList();
        }
    }
}
