﻿using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommunityClasses
{
    public class BlogComment
    {
        public int BlogCommentId { get; set; }
        public string Comment { get; set; }
        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}
