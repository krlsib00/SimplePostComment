using System.Collections.Generic;
using SimplePostComment.Models;

namespace SimplePostComment.Services
{
    public interface IPostsService
    {
        int Create(PostCreateRequest req);
        List<Post> GetAll();
        void Delete(int id);
        void Update(PostUpdateRequest req);
    }
}