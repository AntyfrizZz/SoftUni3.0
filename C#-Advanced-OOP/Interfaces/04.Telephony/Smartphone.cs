namespace _04.Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public string CallPhone(string number)
        {
            foreach (var character in number)
            {
                if (!char.IsDigit(character))
                {
                    return "Invalid number!";
                }
            }

            return $"Calling... {number}";
        }

        public string BrowseWebsite(string website)
        {
            foreach (var character in website)
            {
                if (char.IsDigit(character))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {website}!";
        }
    }
}
