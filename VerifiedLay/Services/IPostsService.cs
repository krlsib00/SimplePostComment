using System.Collections.Generic;
using VerifiedLay.Models;

namespace VerifiedLay.Services
{
    public interface IPostsService
    {
        int Create(PostCreateRequest req);
        List<Post> GetAll();
        void Delete(int id);
        void Update(PostUpdateRequest req);
    }
}