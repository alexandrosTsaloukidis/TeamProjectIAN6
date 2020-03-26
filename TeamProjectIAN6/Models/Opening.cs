using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class Opening
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime? DateTimeOpen { get; set; }

        public string UserCloserId { get; set; }

        public DateTime? DateTimeClose { get; private set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser UserCloser { get; set; }

        public void SetDateTimeClose(DateTime dateTime, string userCloserId)
        {
            DateTimeClose = dateTime;
            UserCloserId = userCloserId;
        }

        public Restaurant Restaurant { get; set; }
    }
}