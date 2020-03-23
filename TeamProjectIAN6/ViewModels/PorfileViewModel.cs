using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.ViewModels
{
    public class PorfileViewModel
    {
        public string Firstname { get; set; }
      
      

        public string Education { get; set; }

        public IEnumerable<Education> Educations { get; set; }



    }
}