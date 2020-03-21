using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.ViewModels
{

    public class ValidVat : ValidationAttribute
    {
        protected override ValidationResult IsValid(object vatNumber, ValidationContext validationContext)
        {
            bool isValid = false;
            try
            {

                using (var client = new TaxService.checkVatPortTypeClient())
                {
                    string name;
                    string address;

                    string countryCode = "EL";
                    string vatNumberStr = Convert.ToString(vatNumber);

                    var result = client.checkVat(ref countryCode, ref vatNumberStr, out isValid, out name, out address);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return (isValid)? ValidationResult.Success: new ValidationResult("Invalid Vat");
        }
    }
}
