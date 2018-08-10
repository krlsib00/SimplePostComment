using System.Collections.Generic;
using SimplePostComment.Models;

namespace SimplePostComment.Services
{
    public interface IUsersService
    {
        List<User> GetAll();
    }
}