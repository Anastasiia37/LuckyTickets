// <copyright file="ILuckyTicketAlgorithm company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace TicketLibrary
{
    /// <summary>
    /// Used for determining whether the specified ticket is lucky using Moscow algorithm
    /// </summary>
    public interface ILuckyTicketAlgorithm
    {
        /// <summary>
        /// Determines whether the specified ticket is lucky
        /// </summary>
        /// <param name="ticket">The ticket that is the instance of Ticket type</param>
        /// <returns>
        ///   <c>true</c> if the specified ticket is lucky; otherwise, <c>false</c>.
        /// </returns>
        bool IsLucky(Ticket ticket);
    }
}