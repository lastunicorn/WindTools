// ConsoleTools
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

// --------------------------------------------------------------------------------
// Bugs or feature requests
// --------------------------------------------------------------------------------
// Note: For any bug or feature request please add a new issue on GitHub: https://github.com/lastunicorn/ConsoleTools/issues/new/choose

using System;
using System.Collections;
using System.Collections.Generic;

namespace DustInTheWind.ConsoleTools.Controls.Tables
{
    /// <summary>
    /// Represents the title row of a table.
    /// </summary>
    public class TitleRow : RowBase
    {
        /// <summary>
        /// Gets or sets the cell displayed in the title row.
        /// This is the unique cell of the row.
        /// </summary>
        public TitleCell TitleCell { get; }

        /// <summary>
        /// Gets the number of cells contained by the title row.
        /// It is always 1.
        /// </summary>
        public override int CellCount { get; } = 1;

        /// <summary>
        /// Gets a value that specifies if the current instance of the <see cref="TitleRow"/> has a content to be displayed.
        /// </summary>
        public bool HasContent => TitleCell?.Content?.IsEmpty == false;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleRow"/> class with
        /// empty content.
        /// </summary>
        public TitleRow()
        {
            TitleCell = new TitleCell
            {
                ParentRow = this,
                Content = MultilineText.Empty
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleRow"/> class with
        /// the text content.
        /// </summary>
        public TitleRow(string title)
        {
            TitleCell = new TitleCell
            {
                ParentRow = this,
                Content = title == null
                    ? MultilineText.Empty
                    : new MultilineText(title)
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleRow"/> class with
        /// a <see cref="MultilineText"/> content.
        /// </summary>
        public TitleRow(MultilineText title)
        {
            TitleCell = new TitleCell
            {
                ParentRow = this,
                Content = title ?? MultilineText.Empty
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleRow"/> class with
        /// an <see cref="object"/> representing the content.
        /// </summary>
        public TitleRow(object title)
        {
            TitleCell = new TitleCell
            {
                ParentRow = this,
                Content = title?.ToString() ?? MultilineText.Empty
            };
        }

        /// <summary>
        /// Calculates the space (in characters) the current instance occupies without other restrictions.
        /// </summary>
        public Size CalculatePreferredSize()
        {
            bool displayBorder = ParentDataGrid?.DisplayBorder ?? false;

            int titleRowWidth = 0;

            if (displayBorder)
                titleRowWidth += 1;

            Size cellSize = TitleCell.CalculatePreferredSize();
            titleRowWidth += cellSize.Width;

            if (displayBorder)
                titleRowWidth += 1;

            return new Size(titleRowWidth, cellSize.Height);
        }

        public override IEnumerator<CellBase> GetEnumerator()
        {
            return new TitleCellEnumerator(this);
        }

        #region Enumerator Class

        private class TitleCellEnumerator : IEnumerator<TitleCell>
        {
            private readonly TitleRow titleRow;

            public TitleCell Current { get; private set; }

            object IEnumerator.Current => Current;

            public TitleCellEnumerator(TitleRow titleRow)
            {
                this.titleRow = titleRow ?? throw new ArgumentNullException(nameof(titleRow));
            }

            public bool MoveNext()
            {
                if (Current != null)
                    return false;

                Current = titleRow.TitleCell;
                return true;
            }

            public void Reset()
            {
                Current = null;
            }

            public void Dispose()
            {
            }
        }

        #endregion
    }
}