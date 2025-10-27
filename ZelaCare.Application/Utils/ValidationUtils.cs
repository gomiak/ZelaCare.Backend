using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ZelaCare.Application.Utils
{
    public static class ValidationUtils
        {
            public static bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    var addr = new MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

        public static bool IsValidCpf(string? cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], 11) == cpf)
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * mult1[i];

            int rem = sum % 11;
            int dig1 = rem < 2 ? 0 : 11 - rem;


            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * mult2[i];

            rem = sum % 11;
            int dig2 = rem < 2 ? 0 : 11 - rem;

            return cpf[9].ToString() == dig1.ToString() && cpf[10].ToString() == dig2.ToString();
        }

        public static bool IsValidPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            var digits = Regex.Replace(phone, @"[^\d]", "");
            return digits.Length == 10 || digits.Length == 11;
        }
    }
}
