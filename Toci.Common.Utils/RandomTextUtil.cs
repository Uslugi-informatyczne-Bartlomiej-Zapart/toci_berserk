using System;

namespace Toci.Common.Utils
{
    public class RandomTextUtil
    {
        protected string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string GenerateRandomText(int minLenght, int maxLength)
        {
            Random r = new Random();

            int length = r.Next(minLenght, maxLength);

            string result = string.Empty;

            int index = 0;

            for (int i = 0; i < length; i++)
            {
                index = r.Next(0, alphabet.Length - 1);
                result += alphabet[index];
            }

            return result;
        }

    }
}
