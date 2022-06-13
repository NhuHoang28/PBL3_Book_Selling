using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AuthorDao
    {
        OnlineStoreDbContext db = null;
        public AuthorDao()
        {
            db = new OnlineStoreDbContext();
        }
        public List<TacGia> ListAll()
        {
            return db.TacGias.ToList();
        }
        public IEnumerable<TacGia> ListAllPaging(int page, int pageSize)
        {
            return db.TacGias.OrderByDescending(x => x.MaTacGia).ToPagedList(page, pageSize);
        }
        public TacGia ViewDetail(string id)
        {
            return db.TacGias.Find(id); // tra ve 1 phan tu duy nhat theo primary key
        }
        public string Insert(TacGia author)
        {
            {
                db.TacGias.Add(author);
                db.SaveChanges();
                return author.MaTacGia;
            }
        }
        public bool Update(TacGia aut)
        {
            try
            {
                var author = db.TacGias.Find(aut.MaTacGia);
                author.MaTacGia = aut.MaTacGia;
                author.TenTacGia = aut.TenTacGia;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var author = db.TacGias.Find(id.Trim());
                db.TacGias.Remove(author);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
