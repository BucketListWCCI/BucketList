using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class Shopping
    {

        public int ShoppingId { get; set; }
        public int MyProperty { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShoppingType { get; set; }
        public string Location { get; set; }
        public ApplicationUser Id { get; set; }
        public bool IsComplete { get; set; }
        

    }
}