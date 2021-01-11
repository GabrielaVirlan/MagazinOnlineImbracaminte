using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MagazinOnlineImbracaminte.Models.Validator
{
    public class ValidatorEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            var emailAddress = new System.Net.Mail.MailAddress(user.Email);
            MailAddress isEmailAdress = new MailAddress(emailAddress.ToString());
            if (isEmailAdress != null)
                return ValidationResult.Success;
            return new ValidationResult("Adresa de email nu este valida!");
        }
    }
}
