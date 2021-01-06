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
        public void GenerateRandomNumberForEachSequence()
        {
            int[] numberSequence = Program.GenerateRandomNumberForEachSequence(15, Program.Sequence.Length);
            Assert.IsInstanceOf<int[]>(numberSequence);
        }
    }
}