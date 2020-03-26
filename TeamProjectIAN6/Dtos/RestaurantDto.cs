using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Dtos
{
    public class RestaurantDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public string Category { get; set; }


    }
}