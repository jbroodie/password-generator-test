using System.Linq;
using NUnit.Framework;
using PasswordGenerator;

namespace PasswordGeneratorTests
{
    public class Tests
    {
        [Test]
        public void IsRepeating_RepeatedCharacters_ReturnsTrue()
        {
            char[] repeatedPassword = "abccdefgh".ToCharArray();
            Assert.That(Program.IsRepeating(repeatedPassword), Is.EqualTo(true));
        }

        [Test]
        public void IsRepeating_UniqueCharacters_ReturnsFalse()
        {
            char[] repeatedPassword = "abcdefghi".ToCharArray();
            Assert.That(Program.IsRepeating(repeatedPassword), Is.EqualTo(false));
        }

        [Test]
        public void GenerateRandomNumberForEachSequence_ReturnsExpectedSumAndLength()
        {
            const int total = 15;

            int[] numberSequence = Program.GenerateRandomNumberForEachSequence(total, Program.Sequence);

            Assert.That(numberSequence.Sum(), Is.EqualTo(total));
            Assert.That(numberSequence.Length, Is.EqualTo(Program.Sequence));
        }
    }
}