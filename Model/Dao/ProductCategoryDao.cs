using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineStoreDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineStoreDbContext();
        }
        public List<LoaiSach> ListAll()
        {
            return db.LoaiSaches.Where(x => x.TrangThai == true).ToList();
        }
        public LoaiSach ViewDetail(string id)
        {
            return db.LoaiSaches.Find(id);
        }
        public TacGia ViewDetailAuthor(string id)
        {
            return db.TacGias.Find(id);
        }
        public IEnumerable<LoaiSach> ListAllPaging(int page, int pageSize)
        {
            return db.LoaiSaches.OrderByDescending(x => x.MaLoaiSach).ToPagedList(page, pageSize);
        }
        public string Insert(LoaiSach cate)
        {
            {
                db.LoaiSaches.Add(cate);
                db.SaveChanges();
                return cate.MaLoaiSach;
            }
        }
        public bool Update(LoaiSach cate)
        {
            try
            {
                var category = db.LoaiSaches.Find(cate.MaLoaiSach);
                category.MaLoaiSach = cate.MaLoaiSach;
                category.TenLoaiSach = cate.TenLoaiSach;
                category.TrangThai = cate.TrangThai;
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
                var cate = db.LoaiSaches.Find(id.Trim());
                db.LoaiSaches.Remove(cate);
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
