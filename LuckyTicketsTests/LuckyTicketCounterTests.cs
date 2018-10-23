// <copyright file="LuckyTicketCounterTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TicketLibrary.Tests
{
    [TestClass]
    public class LuckyTicketCounterTests
    {
        [TestMethod]
        [DataRow("1001", "1010", 10)]
        [DataRow("00", "99", 100)]
        [DataRow("000", "999", 0)]
        public void CountTest_CorrectInputForStringInputStartValueAndInputBoundaryValue(
            string inputStartValue, string inputBoundaryValue, int expectedCount)
        {     
            // Arrange
            Mock<ILuckyTicketAlgorithm> luckyTicketAlgorithm = new Mock<ILuckyTicketAlgorithm>();
            luckyTicketAlgorithm.Setup((obj) => obj.IsLucky(It.Is<Ticket>(
                ticket => (ticket.NumberOfDigits & 1) == 0))).Returns(true);            
            Ticket startValue = Ticket.Initialize(inputStartValue);
            Ticket boundaryValue = Ticket.Initialize(inputBoundaryValue);
            LuckyTicketCounter counter = new LuckyTicketCounter();
            int actualLuckyTicketCount;

            // Act
            actualLuckyTicketCount = counter.Count(luckyTicketAlgorithm.Object, startValue, boundaryValue);

            // Assert
            Assert.AreEqual(expectedCount, actualLuckyTicketCount);
        }

        [TestMethod]
        [DataRow((byte)2, 100)]
        [DataRow((byte)3, 0)]
        [DataRow((byte)4, 10000)]
        public void CountTest_CorrectInputForDigitsOfTicketInputValue(byte digitsOfTicket, int expectedCount)
        {
            // Arrange
            Mock<ILuckyTicketAlgorithm> luckyTicketAlgorithm = new Mock<ILuckyTicketAlgorithm>();
            luckyTicketAlgorithm.Setup((obj) => obj.IsLucky(It.Is<Ticket>(
        ticket => (ticket.NumberOfDigits & 1) == 0))).Returns(true);
            LuckyTicketCounter counter = new LuckyTicketCounter();
            int actualLuckyTicketCount;

            // Act
            actualLuckyTicketCount = counter.Count(luckyTicketAlgorithm.Object, digitsOfTicket);

            // Assert
            Assert.AreEqual(expectedCount, actualLuckyTicketCount);
        }
    }
} 