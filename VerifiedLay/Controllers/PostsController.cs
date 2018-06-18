using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VerifiedLay.Models;
using VerifiedLay.Services;

namespace VerifiedLay.Controllers
{
    [AllowAnonymous]
    public class PostsController : ApiController
    {
        readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Route("api/posts"), HttpPost]
        public HttpResponseMessage Create(PostCreateRequest model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "You did not send any body data!");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    ModelState
                    );
            }

            IPostsService postsService = new PostsService();

            int id = postsService.Create(model);

            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}
