﻿//
//  Copyright 2021  Alexandra Hermann – Beratung, Software, Design
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Globalization;

namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// Interface for expanding a given measurement.
    /// </summary>
    public interface IMeasurementOptional : IMeasurement
    {
        /// <summary>
        /// Gets the base measurement.
        /// </summary>
        /// <value>The base measurement.</value>
        IMeasurement BaseMeasurement { get; }
        /// <summary>
        /// Gets the default culture for this optional measurement.
        /// </summary>
        /// <value>The default culture for this optional measurement.</value>
        CultureInfo DefaultCulture { get; }
        /// <summary>
        /// Gets or sets the optional value.
        /// </summary>
        /// <value>The optional value.</value>
        double OptionalValue { get; set; }
        /// <summary>
        /// Gets the specific value change.
        /// </summary>
        /// <param name="formular">The formular to use.</param>
        /// <returns>The calculated value.</returns>
        double FormulaOptional(Formular formular);
        /// <summary>
        /// Gets the SI value.
        /// </summary>
        /// <param name="formular">The formular to use.</param>
        /// <returns>The clculated value.</returns>
        double FormularSI(Formular formular);
    }

    /// <summary>
    /// Delegate for seperate functions to calculate the values.
    /// </summary>
    /// <param name="input">The input value.</param>
    /// <returns>The calculated result.</returns>
    public delegate double Formular(IMeasurement input);
}
