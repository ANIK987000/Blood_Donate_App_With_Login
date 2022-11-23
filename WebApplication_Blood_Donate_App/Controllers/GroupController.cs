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
    public class GroupController : ApiController
    {

        //______________________________Get_____________________________
        [Route("api/groups")]
        [HttpGet]

        public HttpResponseMessage Get()
        {
            var data = GroupService.GetGroups();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_____________________________Get By ID__________________________

        [Route("api/groups/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = GroupService.GetGroup(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //____________________________________Add ______________________

        [Route("api/groups/add")]
        [HttpPost]

        public HttpResponseMessage Add(GroupDTO groupDTO)
        {
            var data = GroupService.Add(groupDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        //_________________________________Delete__________________________

        [Route("api/groups/delete/{id}")]
        [HttpPost]

        public HttpResponseMessage Delete(int id)
        {
            var data = GroupService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //_________________________________Update__________________________

        [Route("api/groups/update")]
        [HttpPost]

        public HttpResponseMessage Update(GroupDTO groupDTO)
        {
            var data = GroupService.Update(groupDTO);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
