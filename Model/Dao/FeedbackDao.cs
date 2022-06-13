using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedbackDao
    {
        OnlineStoreDbContext db = null;
        public FeedbackDao()
        {
            db = new OnlineStoreDbContext();
        }
        public IEnumerable<GopY_KH> ListAllPaging(int page, int pageSize)
        {
            return db.GopY_KH.OrderByDescending(x => x.NgayTao).ToPagedList(page, pageSize);
        }
    }
}
