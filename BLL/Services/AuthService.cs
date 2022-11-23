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
    public class AuthService
    {
        public static UserDTO Authentic(string uname,string pass)
        {
            var obj = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDTO>(obj);
           
            if (user != null)
            { 
                return user; 
            }
            return null;
        }
    }
}
