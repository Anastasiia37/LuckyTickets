// <copyright file="LuckyTicketSequenceGeneratorTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace TicketLibrary.Tests
{
    [TestClass]
    public class LuckyTicketsSequenceGeneratorTests
    {
        [DataTestMethod()]
        [DataRow("0030", "0032")]
        public void InitializeTest_ReturnNewLuckyTicketGeneratorWithCorrectProperties(
            string stringStartTicket, string stringBoundaryTicket)
        {
            // Arrange
            Ticket startTicket = Ticket.Initialize(stringStartTicket);
            Ticket boundaryTicket = Ticket.Initialize(stringBoundaryTicket);

            Mock<ILuckyTicketAlgorithm> luckyTicketAlgorithm = new Mock<ILuckyTicketAlgorithm>();
            luckyTicketAlgorithm.Setup((obj) => obj.IsLucky(It.IsAny<Ticket>())).Returns(true);

            // Act
            LuckyTicketsGenerator generator = LuckyTicketsGenerator.Initialize(startTicket,
                boundaryTicket, luckyTicketAlgorithm.Object);

            // Assert
            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(LuckyTicketsGenerator));
            Assert.AreEqual(startTicket, generator.StartValue);
            Assert.AreEqual(boundaryTicket, generator.BoundaryValue);
            Assert.AreEqual(luckyTicketAlgorithm.Object, generator.LuckyTicketAlgorithm);
        }

        [TestMethod()]
        [DataRow(0030u, (byte)4)]
        public void GetEnumeratorTest_TrueLuckyTicketAlgorithm_ReturnThreeTickets(uint startTicketValue, byte startTicketDigitsNumber)
        {
            // Arrange
            List<Ticket> ticketList = new List<Ticket>();
            ticketList.Add(Ticket.Initialize(startTicketValue, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 1, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 2, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 3, startTicketDigitsNumber));
            Mock<ILuckyTicketAlgorithm> luckyTicketAlgorithm = new Mock<ILuckyTicketAlgorithm>();
            luckyTicketAlgorithm.Setup((obj) => obj.IsLucky(It.IsAny<Ticket>())).Returns(true);
            LuckyTicketsGenerator generator = LuckyTicketsGenerator.Initialize(
                Ticket.Initialize(startTicketValue, startTicketDigitsNumber),
                Ticket.Initialize(startTicketValue + 3, startTicketDigitsNumber), 
                luckyTicketAlgorithm.Object);

            // Act and Assert
            int i = 0;

            foreach(Ticket ticket in generator)
            {
                Assert.IsTrue(ticketList[i].Equals(ticket));
                i++;
            }
        }

        [TestMethod()]
        [DataRow(0030u, (byte)4)]
        public void GetEnumeratorTest__FalseLuckyTicketAlgorithm_ReturnZeroTickets(uint startTicketValue, byte startTicketDigitsNumber)
        {
            // Arrange
            List<Ticket> ticketList = new List<Ticket>();
            ticketList.Add(Ticket.Initialize(startTicketValue, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 1, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 2, startTicketDigitsNumber));
            ticketList.Add(Ticket.Initialize(startTicketValue + 3, startTicketDigitsNumber));
            Mock<ILuckyTicketAlgorithm> luckyTicketAlgorithm = new Mock<ILuckyTicketAlgorithm>();
            luckyTicketAlgorithm.Setup((obj) => obj.IsLucky(It.IsAny<Ticket>())).Returns(false);
            LuckyTicketsGenerator generator = LuckyTicketsGenerator.Initialize(
                Ticket.Initialize(startTicketValue, startTicketDigitsNumber),
                Ticket.Initialize(startTicketValue + 3, startTicketDigitsNumber),
                luckyTicketAlgorithm.Object);

            // Act and Assert
            int i = 0;
            foreach (Ticket ticket in generator)
            {
                Assert.IsTrue(ticketList[i].Equals(ticket));
                i++;
            }
        }
    }
}