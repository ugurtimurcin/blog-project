using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BlogProject.Core.Utilities.Helpers
{
    public static class StringHelper
    {
        public static string TitleToPascalCase(string text)
        {
            text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return text;
        }
        public static string FriendlyUrl(string url)
        {
            url.ToLower();
            url = url.Trim();
            url = Regex.Replace(url, @"<(.|\n)*?>", string.Empty);
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");
            url = url.Replace("Ğ", "g");
            url = url.Replace("ğ", "g");
            url = url.Replace("Ö", "o");
            url = url.Replace("ö", "o");
            url = url.Replace("Ü", "u");
            url = url.Replace("ü", "u");
            url = url.Replace("Ş", "s");
            url = url.Replace("ş", "s");
            url = url.Replace("Ç", "c");
            url = url.Replace("ç", "c");

            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (url.Contains(strChr))
                {
                    url = url.Replace(strChr, string.Empty);
                }
            }
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            url = r.Replace(url, "-");
            while (url.IndexOf("--") > -1)
                url = url.Replace("--", "-");

            return url;
        }
    }
}
