using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class FeedbackDao
    {
        OnlineQLVBDbContext db = null;

        public FeedbackDao()
        {
            db = new OnlineQLVBDbContext();
        }

        public int GetCountFeedback()
        {
            return db.Feedbacks.Count();
        }
    }
}
