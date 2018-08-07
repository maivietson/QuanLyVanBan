using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class DocumentDao
    {
        private OnlineQLVBDbContext db = null;

        public DocumentDao()
        {
            db = new OnlineQLVBDbContext();
        }

        public Document GetById(long id)
        {
            return db.Documents.Find(id);
        }

        public List<Document> ListAll(long catagoryID)
        {
            return db.Documents.Where(x => x.CategotyID == catagoryID).OrderByDescending(x => x.ReleasedDate).ToList();
        }

        public int GetTotalDocument()
        {
            return db.Documents.Count();
        }

        public long Insert(Document entity)
        {
            db.Documents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Document entity)
        {
            try
            {
                var model = db.Documents.Find(entity.ID);
                model = entity;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var model = db.Documents.Find(id);
                db.Documents.Remove(model);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Document> ListDocSearch(string searchString, ref int total, int pageIndex = 1, int pageSize = 1)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var model = db.Documents.Where(x => x.Name.Contains(searchString) || x.Number.Contains(searchString) || x.Symbol.Contains(searchString) || x.Description.Contains(searchString) || x.Signer.Contains(searchString) || x.Type.Contains(searchString));
                total = model.Count();
                return model.OrderByDescending(x => x.ReleasedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return null;
        }

        public List<Document> ListAllToPage(long categoryId, ref int total, int pageIndex, int pageSize)
        {
            total = db.Documents.Where(x => x.CategotyID == categoryId).Count();
            int takeRecord = (pageIndex * pageSize) < total ? pageSize : (pageIndex * pageSize) - total;
            return db.Documents.Where(x => x.CategotyID == categoryId).OrderByDescending(x => x.ReleasedDate).Skip((pageIndex - 1) * pageSize).Take(takeRecord).ToList();
        }

        public IEnumerable<Document> ListAllPaging(string searchString, long id, int page, int pageSize)
        {
            IQueryable<Document> model = db.Documents.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = db.Documents.Where(x => (x.CategotyID == id) && (x.Name.Contains(searchString) || x.Number.Contains(searchString) || x.Symbol.Contains(searchString) || x.Description.Contains(searchString) || x.Signer.Contains(searchString) || x.Type.Contains(searchString)));
            }
            else
            {
                model = model.Where(x => x.CategotyID == id);
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public IEnumerable<Document> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Document> model = db.Documents.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = db.Documents.Where(x => (x.Name.Contains(searchString) || x.Number.Contains(searchString) || x.Symbol.Contains(searchString) || x.Description.Contains(searchString) || x.Signer.Contains(searchString) || x.Type.Contains(searchString)));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public long GetTotalView()
        {
            long totalView = 0;
            List<Document> documents = db.Documents.ToList();
            foreach (var item in documents)
            {
                totalView += item.ViewCount.Value;
            }
            return totalView;
        }

        public List<Document> ListDocumentNew(int top)
        {
            return db.Documents.OrderByDescending(x => x.ReleasedDate).Take(top).ToList();
        }

        public List<Document> ListDocument(long? idCategory, int top)
        {
            return db.Documents.Where(x => x.CategotyID == idCategory).Take(top).ToList();
        }

        public Document ViewDetail(long id)
        {
            return db.Documents.Find(id);
        }
    }
}
