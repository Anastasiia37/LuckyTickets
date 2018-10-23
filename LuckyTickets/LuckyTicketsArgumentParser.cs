// <copyright file="LuckyTicketsArgumentParser.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.IO;
using TicketLibrary;

namespace LuckyTickets
{
    /// <summary>
    /// Using for parsing and validating command line arguments
    /// </summary>
    public class LuckyTicketsArgumentParser
    {
        /// <summary>
        /// The lucky ticket counting algorithm
        /// </summary>
        private ILuckyTicketAlgorithm luckyTicketAlgorithm;        

        /// <summary>
        /// Parses the arguments of command line (if the number of command line arguments equals to 2)
        /// </summary>
        /// <param name="args">The arguments of command line</param>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm</param>
        /// <param name="numberOfDigits">The number of digits in tickets</param>
        /// <exception cref="ArgumentException">
        /// Invalid path to the file!
        /// or
        /// Can`t find valid algorithm in the file!
        /// or
        /// Your second argument is not a number!
        /// or
        /// Number of digits can`t be less or equal zero!
        /// </exception>
        public void Parse(string[] args, out ILuckyTicketAlgorithm luckyTicketAlgorithm,
                          out byte numberOfDigits)
        {            
            if (!File.Exists(args[0]))
            {
                throw new ArgumentException("Invalid path to the file!");
            }

            if (!this.IsValidAlgorithm(args[0]))
            {
                throw new ArgumentException("Can`t find valid algorithm in the file!");
            }

            luckyTicketAlgorithm = this.luckyTicketAlgorithm;

            if (!byte.TryParse(args[1], out numberOfDigits))
            {
                throw new ArgumentException("Your second argument is not a number from 0 to 18!");
            }

            if (numberOfDigits <= 0)
            {
                throw new ArgumentException("The number of ticket digits can`t be less or equal zero!");
            }
        }

        /// <summary>
        /// Parses the arguments of command line (if the number of command line arguments equals to 3)
        /// </summary>
        /// <param name="args">The arguments of command line</param>
        /// <param name="luckyTicketAlgorithm">The lucky ticket algorithm</param>
        /// <param name="startTicket">The start ticket</param>
        /// <param name="boundaryTicket">The last ticket</param>
        /// <exception cref="ArgumentException">
        /// Invalid path to the file!
        /// or
        /// Can`t find valid algorithm in the file!
        /// or
        /// Your second argument is not a number!
        /// </exception>
        public void Parse(string[] args, out ILuckyTicketAlgorithm luckyTicketAlgorithm,
                          out Ticket startTicket, out Ticket boundaryTicket)
        {            
            if (!File.Exists(args[0]))
            {
                throw new ArgumentException("Invalid path to the file!");
            }

            if (!this.IsValidAlgorithm(args[0]))
            {
                throw new ArgumentException("Can`t find valid algorithm in the file!");
            }

            luckyTicketAlgorithm = this.luckyTicketAlgorithm;
            startTicket = (Ticket)args[1];
            boundaryTicket = (Ticket)args[2];
        }

        /// <summary>
        /// Determines whether lucky ticket counting algorithm is valid
        /// </summary>
        /// <param name="path">The path to the file with algorithm</param>
        /// <returns>
        ///   <c>true</c> if algorithm is valid; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidAlgorithm(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string stringFromFile;
                    stringFromFile = streamReader.ReadLine();
                    if (stringFromFile == null)
                    {
                        return false;
                    }

                    stringFromFile = stringFromFile.ToLower();
                                        
                    if (stringFromFile.Equals(LuckyTicketsAlgorithms.moscow.ToString()))
                    {
                        this.luckyTicketAlgorithm = new MoscowLuckyTicketAlgorithm();
                        return true;
                    }

                    if (stringFromFile.Equals(LuckyTicketsAlgorithms.piter.ToString()))
                    {
                        this.luckyTicketAlgorithm = new PiterLuckyTicketAlgorithm();
                        return true;
                    }

                    return false;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}