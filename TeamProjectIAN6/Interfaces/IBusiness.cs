using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectIAN6.Interfaces
{
    interface IBusiness
    {
        int ID { get; set; }
        string Name { get; set; }

        int Capacity { get; set; }

        string Category { get; set; }

        int LocationID { get; set; }

        string StreetName { get; set; }

        string StreetNumber { get; set; }

        double Lattitude { get; set; }
        double Longitude { get; set; }

        double PostalCode { get; set; }
    }
}
