using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class RestaurantOwnership
    {
        [Key]
        [Column(Order = 1)]
        public int ApplicationUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RestaurantId { get; set; }
        public DateTime StartOwnershipDateTime { get; set; }
        public DateTime? QuitOwnershipDateTime { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}