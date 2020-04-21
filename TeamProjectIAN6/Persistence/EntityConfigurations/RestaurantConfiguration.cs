using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.EntityConfigurations
{
    public class RestaurantConfiguration : EntityTypeConfiguration<Restaurant>
    {

        public RestaurantConfiguration()
        {

            HasOptional(r => r.Parking)
            .WithRequired(p => p.Restaurant);

        }

    }
}