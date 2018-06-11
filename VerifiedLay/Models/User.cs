using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerifiedLay.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}