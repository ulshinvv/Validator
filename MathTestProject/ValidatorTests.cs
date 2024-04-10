using ValidatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorTest
{
    [TestClass]
    public class ValidatorTests
    {

        
        [DataRow("username", true)]
        [DataRow("user123", false)]
        [DataRow("username123", false)]
        [DataRow("user", false)]
        [DataRow(null, false)]
        [TestMethod]
        public void TestLoginValidator(string username, bool expected)
        {
            var validator = new LoginValidator();
            Assert.AreEqual(expected, validator.Validate(username));
        }

        
        
        [DynamicData(nameof(DynamicDataMethod), DynamicDataSourceType.Method)]
        [TestMethod]
        public void TestPasswordValidator(string password, bool expected)
        {
            var validator = new PasswordValidator();
            Assert.AreEqual(expected, validator.Validate(password));
        }

        public static object[][] DynamicDataMethod()
        {
            return new object[][]
            {
                new object[] { "password", false },
                new object[] { "Password1", false },
                new object[] { "Password123!", true },
                new object[] { "short", false },
                new object[] { null, false }
            };
        }
    }
}
