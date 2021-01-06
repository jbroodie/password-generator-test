using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGenerator
{
    public class Program
    {
        private const string Chars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly char[] LowercaseChars = Chars.ToCharArray();
        private static readonly char[] UppercaseChars = Chars.ToUpper().ToCharArray();
        private static readonly char[] Digits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private static readonly char[] Specials = {'!', '@', '#', '$', '%', '^', '&', '*'};
        public static readonly char[][] Sequence = {LowercaseChars, UppercaseChars, Digits, Specials};

        public static void Main(string[] args) =>
            Console.WriteLine(GenerateRandomPassword(new Random().Next(6, 30), Sequence));

        public static string GenerateRandomPassword(
            int total, IReadOnlyCollection<char[]> sequences)
        {
            int[] r = GenerateRandomNumberForEachSequence(total, sequences.Count);

            var password = new List<char>();
            foreach ((char[] population, int k) in sequences.Zip(r))
            {
                var n = 0;
                while (n < k)
                {
                    int position = new Random().Next(0, population.Length - 1);
                    password.Add(population[position]);
                    n++;
                }
            }
            Shuffle(password);

            while (IsRepeating(password))
                Shuffle(password);

            return string.Join("", password);
        }

        /// <summary>
        /// Generate random sequence with numbers (greater than 0).
        /// The number of items equals to 'sequence_number' and
        /// the total number of items equals to 'total'
        /// </summary>
        public static int[] GenerateRandomNumberForEachSequence(int total, int sequenceNumber)
        {
            var currentTotal = 0;
            var r = new List<int>();
            for (int n = sequenceNumber - 1; n > 0; n--)
            {
                int current = new Random().Next(1, (total - currentTotal - n));
                currentTotal += current;
                r.Add(current);
            }
            r.Add(total - r.Sum());
            return Shuffle(r).ToArray();
        }

        /// <summary>
        /// Check if there is any 2 characters repeating consecutively
        /// </summary>
        public static bool IsRepeating(IReadOnlyList<char> password)
        {
            var n = 1;
            while (n > password.Count)
            {
                if (password[n] == password[n - 1])
                    return true;

                n++;
            }

            return false;
        }

        /// <summary>
        /// Shuffle the order of elements
        /// </summary>
        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
