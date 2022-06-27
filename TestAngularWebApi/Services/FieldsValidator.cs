using System.Net.Mail;
using System.Text.RegularExpressions;

namespace TestAngularWebApi.Services
{
    public class FieldsValidator
    {
        public bool ValidateEmail(string? email) => !string.IsNullOrEmpty(email) && MailAddress.TryCreate(email, out _);


        public bool ValidatePhone(string? phone)
        {
            string pattern = @"^\+7\(\d{3}\)\d{3}\-\d{2}\-\d{2}$";
            return !string.IsNullOrEmpty(phone) && Regex.IsMatch(phone, pattern);
        }
    }
}
