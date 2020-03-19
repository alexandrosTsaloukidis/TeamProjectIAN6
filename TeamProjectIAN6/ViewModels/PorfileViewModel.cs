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
      
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age 
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            } 
        }

        [Display(Name = "Education")]
        public int EducationId { get; set; }

        public IEnumerable<Education> Educations { get; set; }

        

        public string Occupation { get; set; }
       
        public int? Id { get; set; }


    }
}