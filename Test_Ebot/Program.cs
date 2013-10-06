using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NUnit.Core;
using NUnit.ConsoleRunner;

namespace Test_Ebot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int returnCode = Runner.Main(args);

            if (returnCode != 0)
            {
                Console.Beep();
            }
        }
    }
}
