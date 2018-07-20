using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class UserDao
    {
        OnlineQLVBDbContext db = null;

        public UserDao()
        {
            db = new OnlineQLVBDbContext();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string password)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == password);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
