using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class ListCategory
    {
        public int ListCategoryId { get; set; }
        public string ListCategories { get; set; }
        public virtual ICollection<UserList> UserList { get; set; }
    }
}