using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggings"
            };
            string expected = "Baggings, Bilbo";

            string actual = customer.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            Customer customer = new Customer
            {
                LastName = "Baggings"
            };
            string expected = "Baggings";

            string actual = customer.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            Customer customer = new Customer
            {
                FirstName = "Bilbo"
            };
            string expected = "Bilbo";

            string actual = customer.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            var c1 = new Customer();
            c1.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Rosie";
            Customer.InstanceCount += 1;

            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            // Arrange
            var customer = new Customer
            {
                LastName = "White",
                Email = "bobwhite@email.com"
            };

            // Act

            var validateResult = customer.Validate();

            //Asset

           Assert.AreEqual(true, validateResult);
        }

        [TestMethod]
        public void ValidateInvalid()
        {
            var customer = new Customer
            {
                Email = "bobwhite@email.com"
            };

            var expected = false;

            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);
        }
    }
}
