// <copyright file="Ticket.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;

namespace TicketLibrary
{
    /// <summary>
    /// Ticket class
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The digits of ticket
        /// </summary>
        private byte[] digitsOfTicket;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class
        /// </summary>
        /// <param name="value">The string value</param>
        private Ticket(string value)
        {
            this.Value = Convert.ToUInt32(value);
            this.NumberOfDigits = Convert.ToByte(value.Length);
            this.digitsOfTicket = new byte[this.NumberOfDigits];
            for (int i = 0; i < this.NumberOfDigits; i++)
            {
                this.digitsOfTicket[i] = byte.Parse(value[i].ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class.
        /// </summary>
        /// <param name="value">The vint alue.</param>
        /// <param name="numberOfDigits">The number of ticket digits</param>
        private Ticket(ulong value, byte numberOfDigits)
        {
            const int TEN = 10;
            this.Value = value;
            this.NumberOfDigits = numberOfDigits;
            this.digitsOfTicket = new byte[this.NumberOfDigits];
            for (int i = (int)this.NumberOfDigits - 1; i >= 0; i--)
            {
                this.digitsOfTicket[i] = (byte)(value % TEN);
                value -= this.digitsOfTicket[i];
                value /= TEN;
            }
        }

        /// <summary>
        /// Gets the value of the ticket
        /// </summary>
        /// <value>
        /// The value
        /// </value>
        public ulong Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of digits of the ticket
        /// </summary>
        /// <value>
        /// The number of digits
        /// </value>
        public byte NumberOfDigits
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Int32"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>the value of ticket digit with given index</returns>
        public byte this [int index]
        {
            get
            {
                return this.digitsOfTicket[index];
            }
        }

        /// <summary>
        /// Initializes the ticket to the specified value
        /// </summary>
        /// <param name="value">The value of the ticket</param>
        /// <returns>The instance of Ticket type</returns>
        /// <exception cref="ArgumentException">
        /// The value of the ticket is not a number!
        /// or
        /// Ticket can`t have such number!
        /// or
        /// The ticket must have its number!
        /// </exception>
        public static Ticket Initialize (string value)
        {
            try
            {
                return new Ticket(value);
            }
            catch (FormatException)
            {
                throw new ArgumentException("The value of the ticket is not a number!");
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Ticket can`t have such number!");
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentException("The ticket must have its number!");
            }
        }

        /// <summary>
        /// Initializes the ticket to the specified unsigned integer value  with specified number of digits
        /// </summary>
        /// <param name="value">The value of ticket</param>
        /// <param name="numberOfDigits">The number of digits in ticket</param>
        /// <returns>The instance of Ticket type</returns>
        public static Ticket Initialize(ulong value, byte numberOfDigits)
        {
            if (value.ToString().Length > numberOfDigits)
            {
                throw new ArgumentException("The number of ticket digits can`t be less than number of digits in its value!");
            }

            if (numberOfDigits == 0)
            {
                throw new ArgumentException("The number of ticket digits can not be equal to zero!");
            }

            return new Ticket((uint)value, (byte)numberOfDigits);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.String"/> to <see cref="Ticket"/>
        /// </summary>
        /// <param name="value">The string number</param>
        /// <returns>
        /// The result of the conversion
        /// </returns>
        public static explicit operator Ticket(string value)
        {
            return Ticket.Initialize(value);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Ticket"/> to <see cref="System.Int32"/>
        /// </summary>
        /// <param name="ticket">The Ticket type</param>
        /// <returns>
        /// The integer ticket value
        /// </returns>
        public static explicit operator ulong(Ticket ticket)
        {
            return ticket.Value;
        }

        /// <summary>
        /// Implements the operator ++.
        /// </summary>
        /// <param name="ticket">The Ticket type</param>
        /// <returns>
        /// The ticket which value is one more than input ticket value
        /// </returns>
        public static Ticket operator ++(Ticket ticket)
        {
            if ((ticket.Value + 1).ToString().Length > ticket.NumberOfDigits)
            {
                return Ticket.Initialize(ticket.Value + 1, (byte)(ticket.NumberOfDigits + 1));
            }

            return Ticket.Initialize(ticket.Value + 1, ticket.NumberOfDigits);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the Ticket type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />
        /// </returns>
        public bool Equals(Ticket otherTicket)
        {
            if (this.Value == otherTicket.Value & this.NumberOfDigits == otherTicket.NumberOfDigits)
            {
                return true;
            }

            return false;
        }
       
        /// <summary>
        /// Performs an implicit conversion from <see cref="Ticket"/> to <see cref="System.String"/>
        /// </summary>
        /// <returns>
        /// The string ticket value
        /// </returns>
        public override string ToString ()
        {
            return string.Format("{0:D" + this.NumberOfDigits + "}", this.Value);
        }
    }
}