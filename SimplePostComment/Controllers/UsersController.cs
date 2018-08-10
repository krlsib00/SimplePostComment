using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimplePostComment.Services;

namespace SimplePostComment.Controllers
{
    [AllowAnonymous]
    public class UsersController : ApiController
    {
        readonly IUsersService usersService; // this was pre-Unity = new UsersService();

        public UsersController(IUsersService usersService)
        {
            // store the parameter "usersService" into the filed "usersService"
            this.usersService = usersService;
        }

        [Route("api/users"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            var results = usersService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}
