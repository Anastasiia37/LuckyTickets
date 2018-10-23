// <copyright file="Program.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace LuckyTickets
{
    /// <summary>
    /// Contains the Main function from where the program starts its execution
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main function from where the program starts its execution
        /// </summary>
        /// <param name="args">The arguments from command line</param>
        /// <returns>Program termination code: 0 if succes, 1 if error occured</returns>
        public static int Main(string[] args)
        {
            LuckyTicketsApplication myApplication = new LuckyTicketsApplication();
            return myApplication.Run(args);
        }
    }
}