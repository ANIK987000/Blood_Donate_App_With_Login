using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class DonorService
    {
        //__________________Get__________________
        public static List<DonorDTO> GetDonors()
        {
            var data = DataAccessFactory.DonorDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
            });
            var mapper = new Mapper(config);
            var donors = mapper.Map<List<DonorDTO>>(data);
            return donors;
        }

        //__________________Get by id__________________
        public static DonorDTO GetDonor(int id)
        {
            var data = DataAccessFactory.DonorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
            });
            var mapper = new Mapper(config);
            var donor = mapper.Map<DonorDTO>(data);
            return donor;
        }

        //__________________Add__________________
        public static DonorDTO Add(DonorDTO donordto)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
                cfg.CreateMap<DonorDTO, Donor>();
            });
            var mapper = new Mapper(config);
            var donors = mapper.Map<Donor>(donordto);

            var data = DataAccessFactory.DonorDataAccess().Add(donors);

            var donordTo = mapper.Map<DonorDTO>(donors);
            return donordTo;
        }

        //__________________Delete__________________

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DonorDataAccess().Delete(id);
            return data;

        }

        //__________________Update__________________

        public static DonorDTO Update(DonorDTO donorDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
                cfg.CreateMap<DonorDTO, Donor>();
            });
            var mapper = new Mapper(config);
            var donors = mapper.Map<Donor>(donorDTO);

            var data = DataAccessFactory.DonorDataAccess().Update(donors);

            var donordTo = mapper.Map<DonorDTO>(donors);
            return donordTo;

        }
    }
}
