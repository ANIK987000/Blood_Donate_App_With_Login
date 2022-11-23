using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {

        //__________________Get__________________
        public static List<UserDTO> GetUsers()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UserDTO>>(data);
            return users;
        }

        //__________________Get by id__________________
        public static UserDTO GetUser(string username)
        {
            var data = DataAccessFactory.UserDataAccess().Get(username);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDTO>(data);
            return user;
        }

        //__________________Add__________________
        public static UserDTO Add(UserDTO userDTO)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<User>(userDTO);

            var data = DataAccessFactory.UserDataAccess().Add(users);

            var userdTo = mapper.Map<UserDTO>(users);
            return userdTo;
        }

        //__________________Delete__________________

        public static bool Delete(string username)
        {
            var data = DataAccessFactory.UserDataAccess().Delete(username);
            return data;

        }

        //__________________Update__________________

        public static UserDTO Update(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<User>(userDTO);

            var data = DataAccessFactory.UserDataAccess().Update(users);

            var userdTo = mapper.Map<UserDTO>(users);
            return userdTo;

        }
    }
}
