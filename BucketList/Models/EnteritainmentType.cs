using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucketList.Models
{
    public class EnteritainmentType
    {
        [Key]
        public int EntertainmentTypeId { get; set; }
        public string EnterainmentType { get; set; }

    }
}