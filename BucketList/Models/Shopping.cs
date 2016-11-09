using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class Shopping
    {
        [Key]
        public int ShoppingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShoppingType { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public virtual ApplicationUser Id { get; set; }
        public bool IsComplete { get; set; }
        
        //Random comment for testing git purposes
    }
}