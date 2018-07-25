using Models.EF;
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
            return db.DocumentCategories.Where(x => x.Status == true).ToList();
        }
    }
}
