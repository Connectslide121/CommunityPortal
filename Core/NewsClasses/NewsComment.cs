﻿using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewsClasses
{
    public class NewsComment
    {
        public int NewsCommentId { get; set; }
        public string Comment { get; set; }
        public News News { get; set; }
        public User User { get; set; }
    }
}
