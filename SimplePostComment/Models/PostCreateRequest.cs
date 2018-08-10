using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplePostComment.Models
{
    public class PostCreateRequest
    {
        public int? UserId { get; set; }

        public string PostText { get; set; }

        public string Location { get; set; }

        public int? Latitude { get; set; }

        public int? Longitude { get; set; }

        public string PostContentsJSON { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}