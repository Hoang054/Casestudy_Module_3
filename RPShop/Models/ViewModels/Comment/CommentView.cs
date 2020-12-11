﻿using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models.ViewModels.Comment
{
    public class CommentView
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Vote { get; set; }
    }
}
