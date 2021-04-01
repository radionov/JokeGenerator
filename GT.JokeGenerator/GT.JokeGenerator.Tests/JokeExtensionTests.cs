using GT.JokeGenerator.Extensions;
using GT.JokeGenerator.Models;
using NUnit.Framework;
using System;

namespace GT.JokeGenerator.Tests
{
    [TestFixture]
    public class JokeExtensionTests
    {
        [Test]
        public void ReplaceWith_JokeIsNull_ArgumentNullException()
        {
            // Setup Fake Data
            Joke joke = null;
            var userName = new UserName { Name = "John", Surname = "Doe" };

            // Execute & Verify mocks and assertions
            Assert.Throws<ArgumentNullException>(() => joke.ReplaceWith(userName));
        }

        [Test]
        public void ReplaceWith_ArgumentsNull_ArgumentNullException()
        {
            // Setup Fake Data
            var joke = new Joke { Value = "Some joke" };

            // Execute & Verify mocks and assertions
            Assert.Throws<ArgumentNullException>(() => joke.ReplaceWith(null));
        }

        [Test]
        public void ReplaceWith_DoesNotMatch_DoesNotReplace()
        {
            // Setup Fake Data
            var joke = new Joke { Value = "Some joke" };
            var userName = new UserName { Name = "John", Surname = "Doe" };

            // Execute Test
            var result = joke.ReplaceWith(userName);

            // Verify mocks and assertions
            Assert.IsNotNull(result);
            Assert.AreEqual(joke.Value, result.Value);
        }

        [Test]
        public void ReplaceWith_Match_Replace()
        {
            // Setup Fake Data
            var chuck = "Chuck";
            var norris = "Norris";
            var value = $"Some joke with {chuck} {norris}";
            var joke = new Joke { Value = value };
            var userName = new UserName { Name = "John", Surname = "Doe" };

            // Execute Test
            var result = joke.ReplaceWith(userName);

            // Verify mocks and assertions
            Assert.IsNotNull(result);
            Assert.AreNotEqual(value, result.Value);
            Assert.IsTrue(result.Value.Contains(userName.Name));
            Assert.IsTrue(result.Value.Contains(userName.Surname));
            Assert.IsFalse(result.Value.Contains(chuck));
            Assert.IsFalse(result.Value.Contains(norris));
        }
    }
}
