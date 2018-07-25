using Models.EF;
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
    }
}
