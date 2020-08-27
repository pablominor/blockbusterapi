using System;
using System.Text;

namespace UnitTest.Shared.Helper
{
    public static class StringHelper
    {
        private static string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random Random = new Random();
        private static int RandomChar => Random.Next(0, chars.Length - 1);

        public static string GenerateRandomStringOfSetLength(int length)
        {
            return GenerateRandomString(length);
        }

        private static string GenerateRandomString(int length)
        {
            var stringBuilder = new StringBuilder();

            while (stringBuilder.Length - 1 <= length)
            {
                var character = chars[RandomChar];
                if (!char.IsControl(character))
                {
                    stringBuilder.Append(character);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
