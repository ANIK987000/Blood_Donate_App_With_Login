using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication_Blood_Donate_App.Auth;

namespace WebApplication_Blood_Donate_App.Controllers
{
    [Logged]
    public class DonorController : ApiController
    {

        //______________________________Get_____________________________
        [Route("api/donors")]
        [HttpGet]

        public HttpResponseMessage Get()
        {
            var data = DonorService.GetDonors();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_____________________________Get By ID__________________________

        [Route("api/donors/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = DonorService.GetDonor(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //____________________________________Add ______________________

        [Route("api/donors/add")]
        [HttpPost]

        public HttpResponseMessage Add(DonorDTO donorDTO)
        {
            var data = DonorService.Add(donorDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

     
        //_________________________________Delete__________________________

        [Route("api/donors/delete/{id}")]
        [HttpPost]

        public HttpResponseMessage Delete(int id)
        {
            var data = DonorService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_________________________________Update__________________________

        [Route("api/donors/update")]
        [HttpPost]

        public HttpResponseMessage Update(DonorDTO donorDTO)
        {
            var data = DonorService.Update(donorDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
