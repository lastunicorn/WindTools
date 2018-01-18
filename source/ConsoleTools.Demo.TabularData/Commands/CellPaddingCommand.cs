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

using DustInTheWind.ConsoleTools.MenuControl;
using DustInTheWind.ConsoleTools.TabularData;

namespace DustInTheWind.ConsoleTools.Demo.TabularData.Commands
{
    internal class CellPaddingCommand : ICommand
    {
        public bool IsActive => true;

        public void Execute()
        {
            DisplayDefaultPaddingExample();
            DisplayPaddingLeftExample();
            DisplayPaddingRightExample();
        }

        private static void DisplayDefaultPaddingExample()
        {
            DataGrid dataGrid = new DataGrid("Default Padding is 1");

            dataGrid.Rows.Add(new[] { "First item", 1.ToString() });
            dataGrid.Rows.Add(new[] { "Second item", 2.ToString() });
            dataGrid.Rows.Add(new[] { "Third item", 3.ToString() });
            dataGrid.Rows.Add(new[] { "Forth item", 4.ToString() });
            dataGrid.Rows.Add(new[] { "Fifth item", 5.ToString() });

            dataGrid.Render();
        }

        private static void DisplayPaddingLeftExample()
        {
            DataGrid dataGrid = new DataGrid("Padding left = 3");

            dataGrid.Rows.Add(new[] { "First item", 1.ToString() });
            dataGrid.Rows.Add(new[] { "Second item", 2.ToString() });
            dataGrid.Rows.Add(new[] { "Third item", 3.ToString() });
            dataGrid.Rows.Add(new[] { "Forth item", 4.ToString() });
            dataGrid.Rows.Add(new[] { "Fifth item", 5.ToString() });

            dataGrid.PaddingLeft = 3;

            dataGrid.Render();
        }

        private static void DisplayPaddingRightExample()
        {
            DataGrid dataGrid = new DataGrid("Padding right = 3");

            dataGrid.Rows.Add(new[] { "First item", 1.ToString() });
            dataGrid.Rows.Add(new[] { "Second item", 2.ToString() });
            dataGrid.Rows.Add(new[] { "Third item", 3.ToString() });
            dataGrid.Rows.Add(new[] { "Forth item", 4.ToString() });
            dataGrid.Rows.Add(new[] { "Fifth item", 5.ToString() });

            dataGrid.PaddingRight = 3;

            dataGrid.Render();
        }
    }
}