// <copyright file="LuckyTicketAlgorithmsTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketLibrary.Tests
{
    [TestClass]
    public class LuckyTicketAlgorithmsTests
    {
        [DataTestMethod]
        [DataRow("633633", true)]
        [DataRow("635716", true)]
        [DataRow("635717", false)]
        [DataRow("000111", false)]
        public void MoscowLuckyTicketAlgorithm_IsLucky(string input, bool expected)
        {
            // Arrange
            MoscowLuckyTicketAlgorithm algorithm = new MoscowLuckyTicketAlgorithm();
            Ticket ticket = Ticket.Initialize(input);
            bool actual;

            // Act
            actual = algorithm.IsLucky(ticket);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("633633", true)]
        [DataRow("605616", true)]
        [DataRow("635717", false)]
        [DataRow("000111", false)]
        public void PiterLuckyTicketAlgorithm_IsLucky(string input, bool expected)
        {
            // Arrange
            PiterLuckyTicketAlgorithm algorithm = new PiterLuckyTicketAlgorithm();
            Ticket ticket = Ticket.Initialize(input);
            bool actual;

            // Act
            actual = algorithm.IsLucky(ticket);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}