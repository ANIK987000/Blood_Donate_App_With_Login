using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepo<User, string, User>,IAuth
    {



        Blood_Donate_DBEntities db;
        internal UserRepo()
        {
            db = new Blood_Donate_DBEntities();
        }



        public User Authenticate(string uname, string pass)
        {
            var obj = db.Users.FirstOrDefault(x => x.Username.Equals(uname) && x.Password.Equals(pass));
            return obj;
        }
        public User Add(User obj)
        {
            //var db = new Blood_Donate_DBEntities();
            db.Users.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string username)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Users.Find(username);
            db.Users.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {

            //var db = new Blood_Donate_DBEntities();
            return db.Users.ToList();
        }

        public User Get(string username)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Users.Find(username);
            return data;
        }

        public User Update(User obj)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Users.Find(obj.Username);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
    }
}
