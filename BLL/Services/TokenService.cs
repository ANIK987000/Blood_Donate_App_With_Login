using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService
    {
        public static TokenDTO Authenticate(string uname,string pass)
        {
            var obj = DataAccessFactory.AuthDataAccess().Authenticate(uname,pass);
            if(obj != null)
            {
                var tk = new Token();
                tk.Username = obj.Username;
                tk.CreationTime = DateTime.Now;
                tk.ExpirationTime = null;
                tk.TKey=Guid.NewGuid().ToString();
                var rttk=DataAccessFactory.TokenDataAccess().Add(tk);
                if(rttk!=null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token,TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
               
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().Get(token);
            if(tk!=null && tk.ExpirationTime==null)
            {
                return true;
            }
            return false;
            
        }
    }
}
