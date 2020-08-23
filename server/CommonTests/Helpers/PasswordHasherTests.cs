using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers.Tests
{
    [TestClass()]
    public class PasswordHasherTests
    {
        [TestMethod()]
        public void Hashed_Password_Matches()
        {
            var pw = "thisispassword123";
            var salt = PasswordHasher.CreateSalt();
            var hash = PasswordHasher.CreateHashedPassword(pw, salt);

            var validateResult = PasswordHasher.Validate(pw, salt, hash);

            Assert.IsTrue(validateResult);
        }

        [TestMethod()]
        public void Wrong_Hash_Should_Not_Match()
        {
            var pw = "thisispassword123";
            var salt = PasswordHasher.CreateSalt();
            var hash = "randomWrongHash";

            var validateResult = PasswordHasher.Validate(pw, salt, hash);

            Assert.IsFalse(validateResult);
        }

        [TestMethod()]
        public void Hashes_Should_Be_Unique()
        {
            var pw1 = "thisispassword123";
            var pw2 = "thisispassword12";

            var salt = PasswordHasher.CreateSalt();
            var hash1 = PasswordHasher.CreateHashedPassword(pw1, salt);
            var hash2 = PasswordHasher.CreateHashedPassword(pw2, salt);

            Assert.AreNotEqual(hash1, hash2);
        }
    }
}