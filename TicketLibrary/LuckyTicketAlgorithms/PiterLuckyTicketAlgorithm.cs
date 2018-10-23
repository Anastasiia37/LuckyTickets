// <copyright file="PiterLuckyTicketAlgorithm.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace TicketLibrary
{
    /// <summary>
    /// Used for determining whether the specified ticket is lucky using Piter algorithm
    /// </summary>
    /// <seealso cref="TicketLibrary.ILuckyTicketAlgorithm" />
    public class PiterLuckyTicketAlgorithm : ILuckyTicketAlgorithm
    {
        /// <summary>
        /// Determines whether the specified ticket is lucky using Piter algorithm
        /// </summary>
        /// <param name="ticket">The ticket that is the instance of Ticket type</param>
        /// <returns>
        ///   <c>true</c> if the specified ticket is lucky; otherwise, <c>false</c>
        /// </returns>
        public bool IsLucky(Ticket ticket)
        {
            if ((ticket.NumberOfDigits & 1) == 1)
            {
                return false;
            }

            int rightSum = 0;
            int leftSum = 0;
            for (int i = 0; i < ticket.NumberOfDigits; i++)
            {
                rightSum += ticket[i];
                leftSum += ticket[++i];
            }

            if (rightSum == leftSum)
            {
                return true;
            }

            return false;
        }
    }
}