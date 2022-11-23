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
    public class UserController : ApiController
    {

        //______________________________Get_____________________________
        [Route("api/users")]
        [HttpGet]

        public HttpResponseMessage Get()
        {
            var data = UserService.GetUsers();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_____________________________Get By ID__________________________

        [Route("api/users/{username}")]
        [HttpGet]

        public HttpResponseMessage Get(string username)
        {
            var data = UserService.GetUser(username);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //____________________________________Add ______________________

        [Route("api/users/add")]
        [HttpPost]

        public HttpResponseMessage Add(UserDTO userDTO)
        {
            var data = UserService.Add(userDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        //_________________________________Delete__________________________

        [Route("api/users/delete/{username}")]
        [HttpPost]

        public HttpResponseMessage Delete(string username)
        {
            var data = UserService.Delete(username);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_________________________________Update__________________________

        [Route("api/users/update")]
        [HttpPost]

        public HttpResponseMessage Update(UserDTO userDTO)
        {
            var data = UserService.Update(userDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
