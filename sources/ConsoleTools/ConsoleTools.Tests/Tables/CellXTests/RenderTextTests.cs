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

using System;
using System.Collections.Generic;
using DustInTheWind.ConsoleTools.Controls.Tables;
using DustInTheWind.ConsoleTools.Controls.Tables.RenderingModel;
using Moq;
using NUnit.Framework;

namespace DustInTheWind.ConsoleTools.Tests.Tables.CellXTests
{
    [TestFixture]
    public class RenderTextTests
    {
        private List<string> renderOutput;
        private Mock<ITablePrinter> tablePrinter;

        [SetUp]
        public void SetUp()
        {
            renderOutput = new List<string>();

            tablePrinter = new Mock<ITablePrinter>();
            tablePrinter
                .Setup(x => x.Write(It.IsAny<string>(), It.IsAny<ConsoleColor?>(), It.IsAny<ConsoleColor?>()))
                .Callback<string, ConsoleColor?, ConsoleColor?>((line, fg, bg) =>
                {
                    renderOutput.Add(line);
                });
        }

        [Test]
        public void HavingContentShorterThanCellWidth_WhenRendered_LineIsFilledWithSpaces()
        {
            CellX cell = new CellX
            {
                Content = "text",
                Size = new Size(10, 1)
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new[] { "text      " }));
        }

        [Test]
        public void HavingContentLongerThanCellWidth_WhenRendered_ThenLineIsNotTrimmed()
        {
            CellX cell = new CellX
            {
                Content = "some long text",
                Size = new Size(10, 1)
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new List<string> { "some long text" }));
        }

        [Test]
        public void HavingContentWithLessLinesThanCellHeight_WhenRendered_ThenEmptyLinesAreAdded()
        {
            CellX cell = new CellX
            {
                Content = "text",
                Size = new Size(10, 2)
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new List<string>
            {
                "text      ",
                "          "
            }));
        }

        [Test]
        public void HavingContentWithMoreLinesThanCellHeight_WhenRendered_ThenOnlyTheRequiredLinesAreRendered()
        {
            CellX cell = new CellX
            {
                Content = new MultilineText(new[] { "line1", "line2", "line3" }),
                Size = new Size(10, 2)
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new List<string>
            {
                "line1     ",
                "line2     "
            }));
        }

        [Test]
        public void HavingPaddingLeftAndContentShorterThanCellWidth_WhenRendered_LineContainsPaddingLeft()
        {
            CellX cell = new CellX
            {
                Content = "text",
                Size = new Size(10, 1),
                PaddingLeft = 2
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new[] { "  text    " }));
        }

        [Test]
        public void HavingPaddingRightAndContentShorterThanCellWidth_WhenRendered_LineContainsPaddingRight()
        {
            CellX cell = new CellX
            {
                Content = "text",
                Size = new Size(10, 1),
                PaddingRight = 2,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            RenderAllLines(cell);

            Assert.That(renderOutput, Is.EqualTo(new[] { "    text  " }));
        }

        private void RenderAllLines(CellX cellX)
        {
            for (int i = 0; i < cellX.Size.Height; i++)
                cellX.RenderNextLine(tablePrinter.Object);
        }
    }
}