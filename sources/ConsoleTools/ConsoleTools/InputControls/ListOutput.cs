﻿// ConsoleTools
// Copyright (C) 2017-2018 Dust in the Wind
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

// --------------------------------------------------------------------------------
// Bugs or feature requests
// --------------------------------------------------------------------------------
// Note: For any bug or feature request please add a new issue on GitHub: https://github.com/lastunicorn/ConsoleTools/issues/new

using System;
using System.Collections.Generic;
using System.Text;

namespace DustInTheWind.ConsoleTools.InputControls
{
    /// <summary>
    /// Displays a list of values to the console.
    /// </summary>
    public class ListOutput<T> : Control
    {
        private readonly Label labelControl = new Label
        {
            ForegroundColor = CustomConsole.EmphasiesColor
        };

        /// <summary>
        /// Gets or sets the label text to be displayed before the list of values.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the list of values that needs to be displayed to the user.
        /// </summary>
        public IEnumerable<T> Values { get; set; }

        /// <summary>
        /// Gets or sets the foreground color used to display the label.
        /// </summary>
        public ConsoleColor? LabelForegroundColor
        {
            get { return labelControl.ForegroundColor; }
            set { labelControl.ForegroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the background color used to display the label.
        /// </summary>
        public ConsoleColor? LabelBackgroundColor
        {
            get { return labelControl.BackgroundColor; }
            set { labelControl.BackgroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the number of spaces by which the items are indented.
        /// </summary>
        public int ItemsIndentation { get; set; } = 1;

        /// <summary>
        /// Gets or sets the bullet character displayed in front of each item that is read.
        /// </summary>
        public string Bullet { get; set; } = "-";

        /// <summary>
        /// Gets or sets the number of spaced displayed after the bullet, before the user types the value.
        /// </summary>
        public int SpaceAfterBullet { get; set; } = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListOutput{T}"/> class.
        /// </summary>
        public ListOutput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListOutput{T}"/> class with
        /// the label text to be displayed before the list of values.
        /// </summary>
        /// <param name="label">The label text to be displayed before the list of values.</param>
        public ListOutput(string label)
        {
            Label = label;
        }

        /// <summary>
        /// Writes the label and the list of values to the console.
        /// </summary>
        protected override void OnDisplayContent()
        {
            if (Label != null)
            {
                labelControl.Text = Label;
                labelControl.Display();
                CustomConsole.WriteLine();
            }

            string leftpart = BuildItemLeftPart();

            foreach (T value in Values)
            {
                CustomConsole.Write(leftpart);
                CustomConsole.WriteLine(value);
            }
        }

        private string BuildItemLeftPart()
        {
            StringBuilder sb = new StringBuilder();

            if (ItemsIndentation > 0)
            {
                string indentation = new string(' ', ItemsIndentation);
                sb.Append(indentation);
            }

            if (Bullet != null)
            {
                sb.Append(Bullet);

                if (SpaceAfterBullet > 0)
                {
                    string bulletSpace = new string(' ', SpaceAfterBullet);
                    sb.Append(bulletSpace);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Reads a list of values from the console using a <see cref="ListOutput{T}"/> with default configuration.
        /// </summary>
        /// <param name="label">The label text to be displayed.</param>
        /// <param name="values">The list of values to be displayed.</param>
        /// <returns>The value read from the console.</returns>
        public static void QuickDisplay(string label, IEnumerable<T> values)
        {
            ListOutput<T> listOutput = new ListOutput<T>
            {
                Label = label,
                Values = values
            };
            listOutput.Display();
        }
    }
}