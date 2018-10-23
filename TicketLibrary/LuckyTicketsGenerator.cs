// <copyright file="LuckyTicketSequenceGenerator.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace TicketLibrary
{
    /// <summary>
    /// The generator of lucky tickets sequence
    /// </summary>
    /// <seealso cref="TicketLibrary.ITicketGenerator" />
    public class LuckyTicketsGenerator : ITicketGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LuckyTicketsGenerator"/> class
        /// </summary>
        /// <param name="startValue">The start value of ticket from which generator wil be searching for tickets</param>
        /// <param name="boundaryValue">The boundary value of ticket until which generator wil be searching for tickets</param>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm of <see cref="ILuckyTicketAlgorithm"/> type</param>
        private LuckyTicketsGenerator(Ticket startValue, Ticket boundaryValue, ILuckyTicketAlgorithm luckyTicketAlgorithm)
        {
            this.StartValue = startValue;
            this.BoundaryValue = boundaryValue;
            this.LuckyTicketAlgorithm = luckyTicketAlgorithm;
        }

        /// <summary>
        /// Gets the start value from which generator wil be searching for tickets
        /// </summary>
        /// <value>
        /// The start value
        /// </value>
        public Ticket StartValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the boundary value until which generator wil be searching for tickets
        /// </summary>
        /// <value>
        /// The boundary value
        /// </value>
        public Ticket BoundaryValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the lucky ticket algorithm of <see cref="ILuckyTicketAlgorithm"/> type
        /// </summary>
        /// <value>
        /// The lucky ticket algorithm
        /// </value>
        public ILuckyTicketAlgorithm LuckyTicketAlgorithm
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the generator of lucky tickets
        /// <param name="startValue">The start value from which generator wil be searching for tickets</param>
        /// <param name="boundaryValue">The boundary value until which generator wil be searching for tickets</param>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm</param>
        /// <returns>The instance of LuckyTicketsSequenceGenerator type</returns>
        /// <exception cref="ArgumentException">
        /// Start ticket and last ticket can not have different number of digits!
        /// or
        /// The value of the last ticket can not be less than the value of the start ticket!
        /// </exception>
        public static LuckyTicketsGenerator Initialize(Ticket startValue, Ticket boundaryValue, ILuckyTicketAlgorithm luckyTicketAlgorithm)
        {
            if (startValue.NumberOfDigits != boundaryValue.NumberOfDigits)
            {
                throw new ArgumentException("Start ticket and last ticket can not have different number of digits!");
            }

            if (boundaryValue.Value < startValue.Value)
            {
                throw new ArgumentException("The value of the last ticket can not be less than "
                    + "the value of the start ticket!");
            }

            return new LuckyTicketsGenerator(startValue, boundaryValue, luckyTicketAlgorithm);
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>Next lucky ticket</returns>
        public IEnumerator<Ticket> GetEnumerator()
        {
            Ticket elementOfSequence = Ticket.Initialize(this.StartValue.Value, this.StartValue.NumberOfDigits);
            for (; (uint)elementOfSequence <= (uint)this.BoundaryValue; elementOfSequence++)
            {
                if (this.LuckyTicketAlgorithm.IsLucky(elementOfSequence))
                {
                    yield return elementOfSequence;
                }
            }
        }
    }
}