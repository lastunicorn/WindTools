﻿// ConsoleTools
// Copyright (C) 2017-2020 Dust in the Wind
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

using System.Collections.Generic;
using System.Linq;
using DustInTheWind.ConsoleTools.Controls.Tables;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.Tables.DataRowListTests
{
    [TestFixture]
    public class AddStringsTests
    {
        private DataGrid dataGrid;
        private DataRowList dataRowList;

        [SetUp]
        public void SetUp()
        {
            dataGrid = new DataGrid();
            dataRowList = new DataRowList(dataGrid);
        }

        [Test]
        public void HavingAnEmptyDataRowList_WhenThreeStringsAreAdded_ThenRowCountIs1()
        {
            dataRowList.Add("value 1", "value 2", "value 3");

            Assert.That(dataRowList.Count, Is.EqualTo(1));
        }

        [Test]
        public void HavingAnEmptyDataRowList_WhenThreeStringsAreAdded_ThenRowContainsThreeCellsWithCorrectValues()
        {
            dataRowList.Add("value 1", "value 2", "value 3");

            IEnumerable<string> actual = dataRowList[0]
                .Select(x => x.Content.ToString());
            IEnumerable<string> expected = new List<string>
            {
                "value 1", "value 2", "value 3"
            };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void HavingAnEmptyDataRowList_WhenNullStringIsAdded_ThenRowContainsEmptyCell()
        {
            dataRowList.Add((string)null);

            Assert.That(dataRowList[0][0].IsEmpty, Is.True);
        }
    }
}