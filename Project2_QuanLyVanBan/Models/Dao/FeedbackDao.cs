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

        public int Insert(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public List<Feedback> GetFeedback()
        {
            return db.Feedbacks.OrderBy(x => x.CreatedDate).Take(10).ToList();
        }
    }
}
