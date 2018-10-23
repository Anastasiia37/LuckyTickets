// <copyright file="TicketTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketLibrary.Tests
{
    /// <summary>
    /// Summary description for TicketTests
    /// </summary>
    [TestClass]
    public class TicketTests 
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        /// <summary>
        /// Tests static method Initialize of class Ticket with string input value of ticket number.
        /// Checks return value for being typeOf(Ticket), being instance of typeOf(Ticket),
        /// having expected value, number of digits, array of ticket digits
        /// </summary>
        /// <param name="input">String input value of ticket number</param>
        /// <param name="expectedValue">The expected value of ticket number</param>
        /// <param name="expectedNumberOfDigits">The expected number of digits</param>
        /// <param name="expectedDigitsOfTicket">The expected array of digits of ticket</param>
        [DataTestMethod]
        [DataRow("633633", 633633ul, (byte)6, new byte[] { 6, 3, 3, 6, 3, 3 })]
        [DataRow("605616", 605616ul, (byte)6, new byte[] { 6, 0, 5, 6, 1, 6 })]
        [DataRow("000111", 111ul, (byte)6, new byte[] { 0, 0, 0, 1, 1, 1 })]
        [DataRow("00301110", 301110ul, (byte)8, new byte[] { 0, 0, 3, 0, 1, 1, 1, 0 })]
        [DataRow("0000", 0ul, (byte)4, new byte[] { 0, 0, 0, 0 })]
        public void Ticket_InitializeTest_StringInputValue_ReturnNewTicketWithCorrectProperties(string input,
            ulong expectedValue, byte expectedNumberOfDigits, byte[] expectedDigitsOfTicket)
        {
            // Arrange
            Ticket actualTicket;

            // Act
            actualTicket = Ticket.Initialize(input);

            // Assert
            Assert.IsNotNull(actualTicket);
            Assert.IsInstanceOfType(actualTicket, typeof(Ticket));
            Assert.AreEqual(expectedValue, actualTicket.Value);
            Assert.AreEqual(expectedNumberOfDigits, actualTicket.NumberOfDigits);
            for (int i = 0; i < actualTicket.NumberOfDigits; i++)
            {
                Assert.AreEqual(expectedDigitsOfTicket[i], actualTicket[i]);
            }
        }

        /// <summary>
        /// Tests static method Initialize of class Ticket with UInt input value of ticket number and byte input value of number of ticket digits.
        /// Checks return value for being typeOf(Ticket), being instance of typeOf(Ticket),
        /// having expected value, number of digits, array of ticket digits
        /// </summary>
        /// <param name="inputValue">UInt input value of ticket number</param>
        /// <param name="inputNumberOfDigits">Byte input value of number of ticket digits</param>
        /// <param name="expectedValue">The expected value of ticket number</param>
        /// <param name="expectedNumberOfDigits">The expected number of digits</param>
        /// <param name="expectedDigitsOfTicket">The expected array of digits of ticket</param>
        [DataTestMethod]
        [DataRow(633633ul, (byte)6, 633633ul, (byte)6, new byte[] { 6, 3, 3, 6, 3, 3 })]
        [DataRow(605616ul, (byte)6, 605616ul, (byte)6, new byte[] { 6, 0, 5, 6, 1, 6 })]
        [DataRow(111ul, (byte)6, 111ul, (byte)6, new byte[] { 0, 0, 0, 1, 1, 1 })]
        [DataRow(301110ul, (byte)8, 301110ul, (byte)8, new byte[] { 0, 0, 3, 0, 1, 1, 1, 0 })]
        public void Ticket_InitializeTest_InputUIntValueAndByteNumberOfDigits_ReturnNewTicketWithCorrectProperties
            (ulong inputValue, byte inputNumberOfDigits, ulong expectedValue, byte expectedNumberOfDigits, byte[] expectedDigitsOfTicket)
        {
            // Arrange
            Ticket actualTicket;

            // Act
            actualTicket = Ticket.Initialize(inputValue, inputNumberOfDigits);

            // Assert
            Assert.IsNotNull(actualTicket);
            Assert.IsInstanceOfType(actualTicket, typeof(Ticket));
            Assert.AreEqual(expectedValue, actualTicket.Value);
            Assert.AreEqual(expectedNumberOfDigits, actualTicket.NumberOfDigits);
            for (int i = 0; i < actualTicket.NumberOfDigits; i++)
            {
                Assert.AreEqual(expectedDigitsOfTicket[i], actualTicket[i]);
            }
        }

        /// <summary>
        /// Tests static method Initialize of class Ticket with UInt input value of ticket number and byte input value of number of ticket digits.
        /// Checks for throwing ArgumentException
        /// </summary>
        /// <param name="inputValue">UInt input value of ticket number</param>
        /// <param name="inputNumberOfDigits">Byte input value of number of ticket digits</param>
        [DataTestMethod]
        [DataRow(633633ul, (byte)4)]
        [DataRow(0ul, (byte)0)]
        [ExpectedException(typeof(ArgumentException))]
        public void Ticket_InitializeTest_InputUIntValueAndByteNumberOfDigits_ThrowArgumentException
            (ulong inputValue, byte inputNumberOfDigits)
        {
            // Arrange
            Ticket actualTicket;

            // Act
            actualTicket = Ticket.Initialize(inputValue, inputNumberOfDigits);
        }

        /// <summary>
        /// Tests static method Initialize of class Ticket with string input value of ticket number.
        /// Checks for throwing ArgumentException
        /// </summary>
        /// <param name="input">String input value of ticket number</param>
        [DataTestMethod]
        [DataRow("633h33")]
        [DataRow("6056166528951215865954513256852")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Ticket_InitializeTest_StringInputValue_ThrowArgumentException(string input)
        {
            // Arrange
            Ticket actualTicket;

            // Act
            actualTicket = Ticket.Initialize(input);
        }
        
        [TestMethod()]
        public void EqualsTest_ReturnTrue()
        {
            //Arrange
            Ticket startTicket = Ticket.Initialize("253");
            Ticket startTicket1 = Ticket.Initialize("253");

            //Act and Assert
            Assert.IsTrue(startTicket.Equals(startTicket1));
        }

        [TestMethod()]
        public void EqualsTest_ReturnFalse()
        {
            // Arrange
            Ticket startTicket = Ticket.Initialize("253");
            Ticket startTicket1 = Ticket.Initialize("254");

            // Act and assert
            Assert.IsFalse(startTicket.Equals(startTicket1));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            Ticket ticket = Ticket.Initialize(12, 6);
            string expected = "000012";
            string actual;

            // Act
            actual = ticket.ToString();

            // Assert
            StringAssert.Equals(expected, actual);
        }
    }
}