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
        public override bool IsValid(object vatNumber)
        {
            bool isValid = false; 
            try
            {

                using (var client = new TaxService.checkVatPortTypeClient())
                {
                    string name;
                    bool valid;
                    string address;

                    string countryCode = "EL";
                    string vatNumberStr = Convert.ToString(vatNumber);

                    var result = client.checkVat(ref countryCode, ref vatNumberStr, out valid, out name, out address);

                    Console.WriteLine(result);
                    Console.WriteLine(valid ? "VALID" : "NOT VALID");
                    Console.WriteLine(name);
                    Console.WriteLine(address);
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return (isValid);
        }
    }
}
