using System.Collections.Generic;
using VerifiedLay.Models;

namespace VerifiedLay.Services
{
    public interface IUsersService
    {
        List<User> GetAll();
    }
}