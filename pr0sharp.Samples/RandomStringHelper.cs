using System.Text;

namespace pr0sharp.Samples
{
    public static class RandomStringHelper
    {
        private static readonly string _defaultCharset = "abcdefghijklmnopqrstuvwxyz0123456789";

        public static string CreateString(int length) => CreateString(length, _defaultCharset);

        public static string CreateString(int length, string allowedCharset)
        {
            if (length <= 0)
            {
                throw new ArgumentException("String length must be greater than zero!");
            }

            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(allowedCharset[Random.Shared.Next(allowedCharset.Length)]);
            }

            return sb.ToString();
        }
    }
}
