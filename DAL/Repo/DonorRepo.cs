using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DonorRepo : IRepo<Donor, int, Donor>
    {
        Blood_Donate_DBEntities db;
        internal DonorRepo()
        {
            db = new Blood_Donate_DBEntities();
        }

        public Donor Add(Donor obj)
        {
            //var db = new Blood_Donate_DBEntities();
            db.Donors.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Donors.Find(id);
            db.Donors.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Donor> Get()
        {
            //var db= new Blood_Donate_DBEntities();
            return db.Donors.ToList();
        }

        public Donor Get(int id)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Donors.Find(id);
            return data;
        }

        public Donor Update(Donor obj)
        {
            //var db = new Blood_Donate_DBEntities();
            var data = db.Donors.Find(obj.ID);  //var data=Get(obj.ID);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }
    }
}
