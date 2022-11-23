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
    public class GroupService
    {
        //__________________Get__________________
        public static List<GroupDTO> GetGroups()
        {
            var data = DataAccessFactory.GroupDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
            });
            var mapper = new Mapper(config);
            var groups = mapper.Map<List<GroupDTO>>(data);
            return groups;
        }

        //__________________Get by id__________________
        public static GroupDTO GetGroup(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<GroupDTO>(data);
            return group;
        }

        //__________________Add__________________
        public static GroupDTO Add(GroupDTO groupDTO)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
                cfg.CreateMap<GroupDTO, Group>();
            });
            var mapper = new Mapper(config);
            var groups = mapper.Map<Group>(groupDTO);

            var data = DataAccessFactory.GroupDataAccess().Add(groups);

            var groupdto = mapper.Map<GroupDTO>(groups);
            return groupdto;
        }


        //__________________Delete__________________

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Delete(id);
            return data;

        }

        //__________________Update__________________

        public static GroupDTO Update(GroupDTO groupDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
                cfg.CreateMap<GroupDTO, Group>();
            });
            var mapper = new Mapper(config);
            var groups = mapper.Map<Group>(groupDTO);

            var data = DataAccessFactory.GroupDataAccess().Update(groups);

            var grpdto = mapper.Map<GroupDTO>(groups);
            return grpdto;

        }
    }
}
