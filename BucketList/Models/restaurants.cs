﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class restaurants
    {
        [Key]

        public int RestaurantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RestaurantType { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public bool RestaurantsIsComplete { get; set; }
        public virtual ApplicationUser User { get; set; }   //This SHOULD be the fk
       

    }
}