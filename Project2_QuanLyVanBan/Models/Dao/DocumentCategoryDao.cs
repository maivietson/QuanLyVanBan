using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class DocumentCategoryDao
    {
        private OnlineQLVBDbContext db = null;

        public DocumentCategoryDao()
        {
            db = new OnlineQLVBDbContext();
        }

        public List<DocumentCategory> ListAll()
        {
            return db.DocumentCategories.Where(x => x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public IEnumerable<DocumentCategory> ListAllPaging(int page, int pageSize)
        {
            IQueryable<DocumentCategory> model = db.DocumentCategories.OrderByDescending(x => x.ID);
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public DocumentCategory ViewDetail(long id)
        {
            return db.DocumentCategories.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var doc = new DocumentDao().ListAll(id);
                foreach(var item in doc)
                {
                    new DocumentDao().Delete(item.ID);
                }
                var cate = db.DocumentCategories.Find(id);
                db.DocumentCategories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(DocumentCategory docCate)
        {
            try
            {
                var model = db.DocumentCategories.Find(docCate.ID);
                model = docCate;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public long Insert(DocumentCategory entity)
        {
            db.DocumentCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
    }
}
