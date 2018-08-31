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

namespace DustInTheWind.ConsoleTools
{
    /// <summary>
    /// Displays a control repeatedly until the <see cref="RequestClose"/> method is called.
    /// </summary>
    public class ControlRepeater : Control
    {
        private volatile bool closeWasRequested;
        private Control control;

        private bool isDisplaying;

        /// <summary>
        /// Gets or sets the control that is to be displayed repeatedly.
        /// </summary>
        public Control Control
        {
            get => control;
            set
            {
                if (control is IRepeatableControl repeatableControl1)
                    repeatableControl1.CloseNeeded -= HandleCloseNeeded;

                if (isDisplaying)
                    throw new Exception("The control cannot be changed while the Display method is running.");

                control = value;

                if (control is IRepeatableControl repeatableControl2)
                    repeatableControl2.CloseNeeded += HandleCloseNeeded;
            }
        }

        private void HandleCloseNeeded(object sender, EventArgs e)
        {
            closeWasRequested = true;
        }

        /// <summary>
        /// Gets a value that specifies if the control was requested to close.
        /// </summary>
        protected bool CloseWasRequested => closeWasRequested;

        protected override void DoDisplayContent()
        {
            isDisplaying = true;
            try
            {
                if (Control == null)
                    return;

                closeWasRequested = false;

                while (!closeWasRequested)
                    Control.Display();
            }
            finally
            {
                isDisplaying = false;
            }
        }

        /// <summary>
        /// Sets the <see cref="CloseWasRequested"/> flag.
        /// The control will exit next time when it checks the flag.
        /// </summary>
        public void RequestClose()
        {
            closeWasRequested = true;

            if (Control is IRepeatableControl repeatableControl)
                repeatableControl.RequestClose();
        }
    }
}