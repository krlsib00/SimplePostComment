using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VerifiedLay.Services;

namespace VerifiedLay.Controllers
{
    [AllowAnonymous]
    public class UsersController : ApiController
    {
        readonly UsersService usersService = new UsersService();

        [Route("api/users"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            var results = usersService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}
