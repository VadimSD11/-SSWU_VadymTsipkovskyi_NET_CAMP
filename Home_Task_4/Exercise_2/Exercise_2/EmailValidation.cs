using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public static class EmailValidation
    {
        public static bool IsEmailReal(string email)
        {
            if (string.IsNullOrEmpty(email)) {

                return false;
            }
            if (!(email.Contains('.'))) {
                return false;
            }

            int atIndex = email.IndexOf('@');
            
            if (atIndex <= 0 || atIndex == email.Length - 1)
            {
                return false;
            }
            string beforeAt = email.Substring(0, atIndex);
            string afterAt = email.Substring(atIndex + 1);

            if (beforeAt.Contains("..") || afterAt.Contains(".."))
            { 
                return false;
            }
            // Перевірка частини до @
            for (int i = 0; i < beforeAt.Length; i++)
            {
                char c = beforeAt[i];
                if (!char.IsLetterOrDigit(c) && c != '!' && c != '#' && c != '$' && c != '%' && c != '&'
                    && c != '\'' && c != '*' && c != '+' && c != '-' && c != '/' && c != '=' && c != '?' && c != '^'
                    && c != '_' && c != '`' && c != '{' && c != '|' && c != '}' && c != '~' && c != '.')
                { 
                    return false; 
                }
            }

            // Перевірка частини після @
            if (afterAt.StartsWith(".") || afterAt.EndsWith("."))
            {
                return false;
            }
                string[] domainParts = afterAt.Split('.');
            foreach (string part in domainParts)
            {
                if (part.Length == 0)
                {
                    return false;
                }
                foreach (char c in part)
                {
                    if (!char.IsLetter(c))
                    { 
                        return false;
                    }
                }
            }

            return true;
        }
        public static string[] GetRealEmails(string str) {

            List<string> realEmails = new List<string>();
            
          

            string[] words = str.Split(' ', ',', ';', ':', '\t', '\n');//розділення строки на слова
           
            foreach (string word in words)//пошук правильних електроних адрес
            {
                if (word.Contains("@"))
                {
                    if (IsEmailReal(word))
                    {
                        realEmails.Add(word);
                    }
                }
            }
            return realEmails.ToArray();

        }
        public static string[] GetWrongEmails(string str) {
            List<string> wrongInputEmails = new List<string>();



            string[] words = str.Split(' ', ',', ';', ':', '\t', '\n');//розділення строки на слова

            foreach (string word in words)//пошук неправильних електроних адрес
            {
                if (word.Contains("@"))
                {
                    if (!IsEmailReal(word))
                    {
                        wrongInputEmails.Add(word);
                    }
                }
            }
            return wrongInputEmails.ToArray();


        }

    }
}
