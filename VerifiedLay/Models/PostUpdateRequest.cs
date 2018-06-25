using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerifiedLay.Models
{
    public class PostUpdateRequest : PostCreateRequest
    {
        [Required]
        public int? Id { get; set; }
    }
}