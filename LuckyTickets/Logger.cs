// <copyright file="Logger.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using log4net;
using log4net.Config;

namespace TicketLibrary
{
    /// <summary>
    /// Logger class
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The logger name
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        /// <summary>
        /// Gets the logger name
        /// </summary>
        /// <value>
        /// The logger name
        /// </value>
        public static ILog Log
        {
            get { return log; }
        }

        /// <summary>
        /// Initializes the logger
        /// </summary>
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}