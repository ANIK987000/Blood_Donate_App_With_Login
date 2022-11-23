using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication_Blood_Donate_App.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/authenticate")]
        [HttpPost]
        public HttpResponseMessage Get(UserDTO userDTO)
        {
            if(userDTO==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "username and password not supplied");
            }
            var data = AuthService.Authentic(userDTO.Username, userDTO.Password);
            if (data!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No valid user");

        }


        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage login(LoginDTO loginDTO)
        {
            if (loginDTO==null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "username and password not supplied");
            }
            if (ModelState.IsValid)
            {
                var token = TokenService.Authenticate(loginDTO.Username, loginDTO.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "username and password not valid");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
        }
    }
}
