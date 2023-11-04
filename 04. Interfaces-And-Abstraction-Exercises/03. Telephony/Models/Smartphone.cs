using System.Linq;

using E03.Telephony.Constraints;
using E03.Telephony.Exceptions;

namespace E03.Telephony.Models
{
    public class Smartphone : ICal, IBrowse
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        public string Cal(string phoneNumber)
        {
            if (!phoneNumber.All(n => char.IsDigit(n)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
