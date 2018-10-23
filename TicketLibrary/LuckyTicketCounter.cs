// <copyright file="LuckyTicketCounter.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace TicketLibrary
{
    /// <summary>
    /// Used to count lucky tickets
    /// </summary>
    public class LuckyTicketCounter
    {
        /// <summary>
        /// Counts lucky tickets in specified range using specified algorithm 
        /// </summary>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm</param>
        /// <param name="startValue">The start value from which generator wil be searching for tickets</param>
        /// <param name="boundaryValue">The boundary value until which generator wil be searching for tickets</param>
        /// <returns></returns>
        public int Count(ILuckyTicketAlgorithm luckyTicketAlgorithm, Ticket startValue, Ticket boundaryValue)
        {
            LuckyTicketsGenerator generator = LuckyTicketsGenerator.Initialize(startValue, boundaryValue, luckyTicketAlgorithm);
            int luckyTicketsCount = 0;
            foreach (Ticket luckyTicket in generator)
            {
                luckyTicketsCount++;
            }

            return luckyTicketsCount;
        }

        /// <summary>
        /// Counts lucky tickets with specefied digits using specified algorithm
        /// </summary>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm.</param>
        /// <param name="digitsOfTicket">The digits of ticket.</param>
        /// <returns></returns>
        public int Count(ILuckyTicketAlgorithm luckyTicketAlgorithm, byte digitsOfTicket)
        {
            Ticket startValue = (Ticket)"0".PadLeft((int)digitsOfTicket, '0');
            Ticket boundaryValue = (Ticket)"9".PadLeft((int)digitsOfTicket, '9');
            return this.Count(luckyTicketAlgorithm, startValue, boundaryValue);
        }
    }
}