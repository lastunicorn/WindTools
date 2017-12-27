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

using DustInTheWind.ConsoleTools.TabularData;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.TableTests
{
    [TestFixture]
    public class CustomBorderTests
    {
        [Test]
        public void render_simple_table_with_custom_border()
        {
            Table table = new Table();
            table.Border = new TableBorder("╔═╗║╝═╚║╦╣╩╠╬║═");
            table.AddRow(new[] { "one", "ichi", "eins" });
            table.AddRow(new[] { "two", "ni", "zwei" });
            table.AddRow(new[] { "three", "san", "drei" });

            string expected =
@"╔═══════╦══════╦══════╗
║ one   ║ ichi ║ eins ║
║ two   ║ ni   ║ zwei ║
║ three ║ san  ║ drei ║
╚═══════╩══════╩══════╝
";

            Assert.That(table.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void render_table_with_custom_border_and_title()
        {
            Table table = new Table();
            table.Title = new MultilineText("My Title");
            table.Border = new TableBorder("╔═╗║╝═╚║╦╣╩╠╬║═");
            table.AddRow(new[] { "one", "ichi", "eins" });
            table.AddRow(new[] { "two", "ni", "zwei" });
            table.AddRow(new[] { "three", "san", "drei" });

            string expected =
@"╔═════════════════════╗
║ My Title            ║
╠═══════╦══════╦══════╣
║ one   ║ ichi ║ eins ║
║ two   ║ ni   ║ zwei ║
║ three ║ san  ║ drei ║
╚═══════╩══════╩══════╝
";

            Assert.That(table.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void render_table_with_custom_border_and_headers()
        {
            Table table = new Table();
            table.Border = new TableBorder("╔═╗║╝═╚║╦╣╩╠╬║═");
            table.DisplayColumnHeaders = true;
            table.Columns.Add(new Column("One"));
            table.Columns.Add(new Column("Two"));
            table.Columns.Add(new Column("Three"));
            table.AddRow(new[] { "one", "ichi", "eins" });
            table.AddRow(new[] { "two", "ni", "zwei" });
            table.AddRow(new[] { "three", "san", "drei" });

            string expected =
@"╔═══════╦══════╦═══════╗
║ One   ║ Two  ║ Three ║
╠═══════╬══════╬═══════╣
║ one   ║ ichi ║ eins  ║
║ two   ║ ni   ║ zwei  ║
║ three ║ san  ║ drei  ║
╚═══════╩══════╩═══════╝
";

            Assert.That(table.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void render_table_with_custom_border_title_and_headers()
        {
            Table table = new Table();
            table.Border = new TableBorder("╔═╗║╝═╚║╦╣╩╠╬║═");
            table.Title = new MultilineText("My Title");
            table.DisplayColumnHeaders = true;
            table.Columns.Add(new Column("One"));
            table.Columns.Add(new Column("Two"));
            table.Columns.Add(new Column("Three"));
            table.AddRow(new[] { "one", "ichi", "eins" });
            table.AddRow(new[] { "two", "ni", "zwei" });
            table.AddRow(new[] { "three", "san", "drei" });

            string expected =
@"╔══════════════════════╗
║ My Title             ║
╠═══════╦══════╦═══════╣
║ One   ║ Two  ║ Three ║
╠═══════╬══════╬═══════╣
║ one   ║ ichi ║ eins  ║
║ two   ║ ni   ║ zwei  ║
║ three ║ san  ║ drei  ║
╚═══════╩══════╩═══════╝
";

            Assert.That(table.ToString(), Is.EqualTo(expected));
        }
    }
}