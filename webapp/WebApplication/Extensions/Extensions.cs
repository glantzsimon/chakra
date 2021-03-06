using K9.WebApplication.Enums;
using System.Linq;
using System.Text.RegularExpressions;

namespace K9.WebApplication.Extensions
{
    public static partial class Extensions
    {
        public static string ToSeoFriendlyString(this string value)
        {
            var regex = new Regex("[^a-zA-Z0-9 -]");
            var alphaNumericString = regex.Replace(value, "");

            return string.Join("-", alphaNumericString.ToLower().Split(' '));
        }

        public static string ToPreviewText(this string value, int length = 100)
        {
            var valueLength = value.Length;
            var canBeAbbreviated = valueLength > length;
            var substring = value.Substring(0, canBeAbbreviated ? length : valueLength);
            var abbrevationSuffix = canBeAbbreviated ? "..." : string.Empty;
            return $"{substring}{abbrevationSuffix}";
        }

        public static string EncaseInParantheses(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return $"({value})";
            }

            return value;
        }

        public static EChakraCode Increment(this EChakraCode code, int value = 1)
        {
            return (EChakraCode)((int)code).Increment(value);
        }

        public static EChakraCode Decrement(this EChakraCode code, int value = 1)
        {
            return (EChakraCode)((int)code).Decrement(value);
        }

        public static int Increment(this int code, int value = 1)
        {
            for (int i = 0; i < value; i++)
            {
                code = code == 9 ? 1 : code + 1;
            }
            return code;
        }

        public static int Decrement(this int code, int value = 1)
        {
            for (int i = 0; i < value; i++)
            {
                code = code == 1 ? 9 : code - 1;
            }
            return code;
        }

        public static int ToNumerology(this int value)
        {
            if (value < 0)
            {
                value = value + 9;
            }

            if (value == 0)
            {
                return 0;
            }

            var result = 0;
            while (result >= 10 || result == 0)
            {
                if (result == 0)
                {
                    result = value;
                }

                result = result.ToString().Select(e => int.Parse(e.ToString())).Sum();
            }

            return result;
        }
    }
}
