﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class UserList
    {
        [Key]
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ItemCategory { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public bool UserIsComplete { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser UserName { get; set; }
        
        [ForeignKey("ListCategories")]
        public int ListCategoryId { get; set; }
        public virtual ListCategory ListCategories { get; set; }

    }
}