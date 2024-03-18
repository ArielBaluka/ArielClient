using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfClient
{
    public class ValidBirthDate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                DateTime date = DateTime.Parse(value.ToString());

                if (date.Day > 31 || date.Day < 1)
                    return new ValidationResult(false, "impossible day");
                if (date.Year > DateTime.Today.Year || date.Year < 1900)
                    return new ValidationResult(false, "impossible year");
                if (date.Month > 12 || date.Month < 0)
                    return new ValidationResult(false, "impossible month");
                if (date.Year == DateTime.Today.Year && date.Month > DateTime.Today.Month)
                    return new ValidationResult(false, "future date");
                if (date.Year == DateTime.Today.Year && date.Month == DateTime.Today.Month && date.Day > DateTime.Today.Day)
                    return new ValidationResult(false, "future date");
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class ValidName : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string firstName = value.ToString();

                if (firstName.Length < Min)
                    return new ValidationResult(false, "First Name is too short");
                if (firstName.Length > Max)
                    return new ValidationResult(false, "First Name is too long");
                if (!Char.IsUpper(firstName[0]))
                    return new ValidationResult(false, "First character MUST be a capital letter!");
                if (!Char.IsLetter(firstName[firstName.Length - 1]))
                    return new ValidationResult(false, "Last character MUST be a letter!");
                if (firstName.IndexOf("  ") != -1)
                    return new ValidationResult(false, "First name shouldn't include more than one space in a row");

                for (int i = 0; i < firstName.Length; i++)
                {
                    if (!(Char.IsLetter(firstName[i]) || Char.IsWhiteSpace(firstName[i])))
                        return new ValidationResult(false, "Illegal characters!");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class ValidUserName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string UserName = value.ToString();
                string specialChars = "_#$?!~-";

                if (UserName.Length < 6)
                    return new ValidationResult(false, "User Name is too short");
                if (UserName.Length > 12)
                    return new ValidationResult(false, "User Name is too long");

                if (UserName.IndexOf(" ") != -1)
                    return new ValidationResult(false, "User name shouldn't include spaces");

                for (int i = 0; i < UserName.Length; i++)
                {
                    if (!(Char.IsLetterOrDigit(UserName[i]) || (specialChars.IndexOf(UserName[i])) != -1))
                        return new ValidationResult(false, "Illegal characters!");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class ValidPhoneNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string PhoneNumber = value.ToString();

                if (PhoneNumber.Length != 10)
                    return new ValidationResult(false, "Phone number must have 10 digits");

                if (PhoneNumber[0] != '0' || PhoneNumber[1] != '5')
                    return new ValidationResult(false, "Illegal beginning");

                if (PhoneNumber.IndexOf(" ") != -1)
                    return new ValidationResult(false, "Phone number shouldn't include spaces");

                for (int i = 0; i < PhoneNumber.Length; i++)
                {
                    if (!(Char.IsDigit(PhoneNumber[i])))
                        return new ValidationResult(false, "Numbers only!");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }



    public class ValidEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string Email = value.ToString();

                if (Email.IndexOf(" ") != -1)
                    return new ValidationResult(false, "Email shouldn't include spaces");
                if (Email.IndexOf("@") == -1)
                    return new ValidationResult(false, "Email must include @");
                if (Email.IndexOf(".") == -1)
                    return new ValidationResult(false, "Email must include .");
                if (Email.Length < 12)
                    return new ValidationResult(false, "Email too short");
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }



    public class ValidPassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string Password = value.ToString();
                string specialChars = "_#$?!~-";

                if (Password.Length < 6)
                    return new ValidationResult(false, "Password is too short");
                if (Password.Length > 12)
                    return new ValidationResult(false, "Password is too long");

                if (Password.IndexOf(" ") != -1)
                    return new ValidationResult(false, "Password shouldn't spaces");

                bool UpperFound = false, LowerFound = false, NumberFound = false, SymbolFound = false;

                for (int i = 0; i < Password.Length; i++)
                {
                    if (!(Char.IsLetterOrDigit(Password[i]) || (specialChars.IndexOf(Password[i])) != -1))
                        return new ValidationResult(false, "Illegal characters!");

                    if (specialChars.IndexOf(Password[i]) != -1) SymbolFound = true;
                    if (Char.IsUpper(Password[i])) UpperFound = true;
                    if (Char.IsLower(Password[i])) LowerFound = true;
                    if (Char.IsDigit(Password[i])) NumberFound = true;
                }

                if (!(UpperFound && LowerFound && NumberFound && SymbolFound))
                    throw new Exception("Not strong enough");
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class ValidNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                int Number = int.Parse(value.ToString());
                if (Number < 1 || Number > 99)
                    return new ValidationResult(false, "Number is not between 1 and 99"); 
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }
}
