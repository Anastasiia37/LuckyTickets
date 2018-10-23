// <copyright file="LuckyTicketsApplication.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Text;
using TicketLibrary;

namespace LuckyTickets
{
    /// <summary>
    /// Class of application for getting the number of lucky tickets
    /// </summary>
    public class LuckyTicketsApplication
    {
        /// <summary>
        /// The null arguments count in command line
        /// </summary>
        private const int NULL_ARGUMENTS_COUNT = 0;

        /// <summary>
        /// The not enough arguments count in command line
        /// </summary>
        private const int NOT_ENOUGH_ARGUMENTS_COUNT = 1;

        /// <summary>
        /// The minimum arguments count  in command line
        /// </summary>
        private const int MIN_ARGUMENTS_COUNT = 2;

        /// <summary>
        /// The maximum arguments count  in command line
        /// </summary>
        private const int MAX_ARGUMENTS_COUNT = 3;

        /// <summary>
        /// The using lucky ticket algorithm
        /// </summary>
        private ILuckyTicketAlgorithm luckyTicketAlgorithm;

        /// <summary>
        /// The start ticket for lucky tickets counting 
        /// </summary>
        private Ticket startTicket;

        /// <summary>
        /// The last ticket for lucky tickets counting
        /// </summary>
        private Ticket boundaryTicket;

        /// <summary>
        /// The number of digits
        /// </summary>
        private byte numberOfDigits;
       
        /// <summary>
        /// The count of lucky tickets
        /// </summary>
        private int countOfLuckyTickets;

        /// <summary>
        /// The starting point of application for getting the number of lucky tickets
        /// </summary>
        /// <param name="args">The arguments from command line</param>
        /// <returns>Return Code</returns>
        /// <exception cref="ArgumentException">
        /// You don't have enough arguments!
        /// or
        /// You have too many arguments!
        /// </exception>
        public int Run(string[] args)
        {
            Logger.InitLogger();
            try
            {
                LuckyTicketsArgumentParser parser = new LuckyTicketsArgumentParser();
                LuckyTicketCounter counter = new LuckyTicketCounter();
                this.countOfLuckyTickets = 0;
                switch (args.Length)
                { 
                    case NULL_ARGUMENTS_COUNT:
                        this.ShowAbout();
                        Console.ReadKey();
                        Logger.Log.Info("The program started with null parameters, showed Instructions "
                            + "and ended with return code: Success.");
                        return (int)ReturnCode.Success;
                    case NOT_ENOUGH_ARGUMENTS_COUNT:
                        throw new ArgumentException("You don't have enough arguments!");
                    case MIN_ARGUMENTS_COUNT:
                        parser.Parse(args, out this.luckyTicketAlgorithm, out this.numberOfDigits);
                        countOfLuckyTickets = counter.Count(this.luckyTicketAlgorithm, this.numberOfDigits);
                        break;
                    case MAX_ARGUMENTS_COUNT:
                        parser.Parse(args, out this.luckyTicketAlgorithm, out this.startTicket, out this.boundaryTicket);
                        countOfLuckyTickets = counter.Count(this.luckyTicketAlgorithm, this.startTicket, this.boundaryTicket);
                        break;
                    default:
                        if (args.Length > MAX_ARGUMENTS_COUNT)
                        {
                            throw new ArgumentException("You have too many arguments!");
                        }

                        break;
                }

                Console.WriteLine($"There are {countOfLuckyTickets} lucky tickets in your diapason.");
            }
            catch (ArgumentException exception)
            {
                string logMessage = exception + Environment.NewLine +
                    "The command line arguments: " + this.GetArgumentsAsString(args) + Environment.NewLine;
                Logger.Log.Error(logMessage);
                Console.WriteLine(exception.Message);
                return (int)ReturnCode.Error;
            }

            Logger.Log.Info("The program ended with return code: Success. "
                + "The command line arguments: " + this.GetArgumentsAsString(args));
            return (int)ReturnCode.Success;
        }

        /// <summary>
        /// Allows to convert an array of strings to a single string
        /// </summary>
        /// <param name="args">Array of strings</param>
        /// <returns>A string that consists of an array of input strings</returns>
        private string GetArgumentsAsString(string[] args)
        {
            StringBuilder stringArgs = new StringBuilder();
            foreach (string argument in args)
            {
                stringArgs.Append(argument).Append(" ");
            }

            return stringArgs.ToString();
        }

        /// <summary>
        /// Shows the information about the application
        /// </summary>
        private void ShowAbout()
        {
            Console.WriteLine(LuckyTickets.Properties.Resources.ReadMe);
        }

        /// <summary>
        /// Shows the instructions how to use the application
        /// </summary>
        private void ShowInstructions()
        {
            Console.WriteLine(Environment.NewLine + "The program starts from the command line." + Environment.NewLine
                + "Input parameters: <File> <RangeOfTickets>" + Environment.NewLine
                + "OR" + Environment.NewLine + "Input parameters: <File> <StartTicket> <BoundaryTicket>" + Environment.NewLine
                + Environment.NewLine + "where" 
                + Environment.NewLine + "\t<File> is the file with lucky ticket counting algorithm,"
                + Environment.NewLine + "\t<RangeOfTickets> is a number of ticket`s digits (must be from 1 to 18),"
                + Environment.NewLine + "\t<StartTicket> is a ticket from which to start counting,"
                + Environment.NewLine + "\t<BoundaryTicket> is a ticket from which to stop counting.");
        }
    }
}