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

using DustInTheWind.ConsoleTools.TabularData;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.TabularData.TableTests
{
    [TestFixture]
    public class TablePaddingTests
    {
        private DataGrid dataGrid;

        [SetUp]
        public void SetUp()
        {
            dataGrid = new DataGrid("My Title");

            dataGrid.Rows.Add(new[] { "1234567", "123456", "one two" });
            dataGrid.Rows.Add(new[] { "1", "asd", "asas" });
            dataGrid.Rows.Add(new[] { "12", "a", "errr" });
        }

        [Test]
        public void added_a_padding_left_of_2()
        {
            dataGrid.PaddingLeft = 2;

            const string expected =
@"+-------------------------------+
|  My Title                     |
+----------+---------+----------+
|  1234567 |  123456 |  one two |
|  1       |  asd    |  asas    |
|  12      |  a      |  errr    |
+----------+---------+----------+
";

            Assert.That(dataGrid.PaddingLeft, Is.EqualTo(2));
            Assert.That(dataGrid.PaddingRight, Is.EqualTo(1));
            CustomAssert.TableRender(dataGrid, expected);
        }

        [Test]
        public void added_a_padding_right_of_2()
        {
            dataGrid.PaddingRight = 2;

            const string expected =
@"+-------------------------------+
| My Title                      |
+----------+---------+----------+
| 1234567  | 123456  | one two  |
| 1        | asd     | asas     |
| 12       | a       | errr     |
+----------+---------+----------+
";

            Assert.That(dataGrid.PaddingLeft, Is.EqualTo(1));
            Assert.That(dataGrid.PaddingRight, Is.EqualTo(2));
            CustomAssert.TableRender(dataGrid, expected);
        }
    }
}