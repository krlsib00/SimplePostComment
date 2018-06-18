using VerifiedLay.Models;

namespace VerifiedLay.Services
{
    public interface IPostsService
    {
        int Create(PostCreateRequest req);
    }
}