using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        Blood_Donate_DBEntities db;
        internal TokenRepo()
        {
            db = new Blood_Donate_DBEntities();
        }
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if(db.SaveChanges()>0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string id)
        {
            var tk=db.Tokens.FirstOrDefault(x=>x.TKey.Equals(id)); //Find()= only when primary key
            return tk;
        }

        public Token Update(Token obj)
        {
            var tk=Get(obj.TKey); //var data = db.Tokens.Find(obj.TKey);
            db.Entry(tk).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0)
            {
                return tk;
            }
            return null;

        }
    }
}
