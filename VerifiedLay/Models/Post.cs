using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerifiedLay.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PostText { get; set; }
        public string Location { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}