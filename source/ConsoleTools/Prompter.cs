﻿// ConsoleTools
// Copyright (C) 2017 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DustInTheWind.ConsoleTools
{
    public class Prompter
    {
        /// <summary>
        /// Gets the text displayed as a prompter.
        /// </summary>
        public static string PrompterText { get; } = "> ";

        /// <summary>
        /// Event raised when the user writes a new command at the console.
        /// </summary>
        public static event EventHandler<NewCommandEventArgs> NewCommand;

        /// <summary>
        /// Raises the NewCommand event.
        /// </summary>
        /// <param name="e">An NewCommandEventArgs that contains the event data.</param>
        public static void OnNewCommand(NewCommandEventArgs e)
        {
            NewCommand?.Invoke(null, e);
        }

        /// <summary>
        /// Continously read from the console new commands.
        /// After a command is obtained from the console, the NewCommand event is raised.
        /// The infinite loop that reads commands can be stopped only by setting the Exit property
        /// of the NewCommandEventArgs object received in the callback method of the NewCommand event.
        /// </summary>
        public static void WaitForUserCommand()
        {
            bool exitloop = false;

            do
            {
                UserCommand command = GetUserCommand();

                NewCommandEventArgs eva = new NewCommandEventArgs(command);

                try
                {
                    OnNewCommand(eva);

                    if (eva.Exit)
                        exitloop = true;
                }
                catch { }
            }
            while (!exitloop);
        }

        /// <summary>
        /// Displays a prompter and invites the user to type a command.
        /// The command is finished with an Enter.
        /// Observation! The current thread is blocked until the user finishes to type the command.
        /// </summary>
        /// <returns>The command typed by the user.</returns>
        public static UserCommand GetUserCommand()
        {
            // Check if the cursor is at the begining of the line.
            if (Console.CursorLeft != 0)
                Console.WriteLine();

            // Display the prompter.
            Console.Write(PrompterText);

            // Read the command typed by the user.
            string commandText = Console.ReadLine();
            Console.WriteLine();

            // Parse the command typed by the user.
            UserCommand command = UserCommand.Parse(commandText);

            // Return the command typed by the user.
            return command;
        }
    }
}