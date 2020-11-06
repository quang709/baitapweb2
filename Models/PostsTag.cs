using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baitapweb2.Models
{
    public class PostsTag
    {
        public int PostsId { get; set; }
        public int TagId { get; set; }

        public Posts Posts { get; set; }
        public Tag Tag { get; set; }
    }
}
