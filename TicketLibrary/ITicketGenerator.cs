// <copyright file="ITicketGenerator.cs" company="Peretiatko Anastasiia" library="TicketLibrary">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace TicketLibrary
{
    /// <summary>
    /// Interface of ticket sequence generator
    /// </summary>
    public interface ITicketGenerator
    {
        /// <summary>
        /// Gets the start value from which generator wil be searching for tickets
        /// </summary>
        /// <value>
        /// The start value
        /// </value>
        Ticket StartValue
        {
            get;
        }

        /// <summary>
        /// Gets the boundary value until which generator wil be searching for tickets
        /// </summary>
        /// <value>
        /// The boundary value
        /// </value>
        Ticket BoundaryValue
        {
            get;
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>Next ticket</returns>
        IEnumerator<Ticket> GetEnumerator();
    }
}