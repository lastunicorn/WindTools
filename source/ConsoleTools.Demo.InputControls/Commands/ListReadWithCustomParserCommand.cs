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

using System;
using System.Collections.Generic;
using DustInTheWind.ConsoleTools.InputControls;
using DustInTheWind.ConsoleTools.MenuControl;

namespace DustInTheWind.ConsoleTools.Demo.InputControls.Commands
{
    internal class ListReadWithCustomParserCommand : ICommand
    {
        public bool IsActive => true;

        public void Execute()
        {
            List<ConsoleColor> colors = ReadColors();
            CustomConsole.WriteLine();

            DisplayColors(colors);
        }

        private static void DisplayColors(List<ConsoleColor> colors)
        {
            CustomConsole.Write("Your prefered colors: ");

            for (int i = 0; i < colors.Count; i++)
            {
                CustomConsole.Write(colors[i], colors[i].ToString());

                if (i < colors.Count - 1)
                    CustomConsole.Write(", ");
            }

            CustomConsole.WriteLine();
        }

        private static List<ConsoleColor> ReadColors()
        {
            ListInput<ConsoleColor> colorsInput = new ListInput<ConsoleColor>("What are your prefered colors?");
            colorsInput.CustomParser = value => (ConsoleColor)Enum.Parse(typeof(ConsoleColor), value, true);

            return colorsInput.Read();
        }
    }
}