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

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        public int? RestaurantId { get; set; }
        public DateTime StartOwnershipDateTime { get; set; }
        public DateTime? QuitOwnershipDateTime { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}