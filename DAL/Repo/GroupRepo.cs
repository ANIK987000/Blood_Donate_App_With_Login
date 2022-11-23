using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class GroupRepo : IRepo<Group, int, bool>
    {
        Blood_Donate_DBEntities db;
        internal GroupRepo()
        {
            db = new Blood_Donate_DBEntities();
        }
        public bool Add(Group obj)
        {
            //var db = new Blood_Donate_DBEntities();
            db.Groups.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            // var db = new Blood_Donate_DBEntities();
            var data = db.Groups.Find(id);
            db.Groups.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Group> Get()
        {
            // var db = new Blood_Donate_DBEntities();
            return db.Groups.ToList();
        }

        public Group Get(int id)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Groups.Find(id);
            return data;
        }

        public bool Update(Group obj)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Groups.Find(obj.ID);
            db.Entry(data).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
