using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePostComment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Sex { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public bool Verified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}