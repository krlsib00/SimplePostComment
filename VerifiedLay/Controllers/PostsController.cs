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

        [Route("api/posts"), HttpGet]
        public HttpResponseMessage GetAll()
        {
            var results = postsService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/posts/{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            postsService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/posts/{id:int}"), HttpPut]
        public HttpResponseMessage Update(int id, PostUpdateRequest req)
        {            
            if (req == null)
            {
                ModelState.AddModelError("", "You did not send any body data!");
            }
            if (req.Id != id)
            {
                ModelState.AddModelError("Id", "ID in the URL does not match the ID in the body");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    ModelState
                    );
            }
            IPostsService postsService = new PostsService();

            postsService.Update(req);

            return Request.CreateResponse(HttpStatusCode.Created, id);
        }
    }
}
