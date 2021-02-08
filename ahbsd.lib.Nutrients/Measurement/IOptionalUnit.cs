//
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
using System.Globalization;
using System.IO;
using System.Text.Json;
using ahbsd.lib;

namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// Interface for expanding a given unit.
    /// </summary>
    public interface IOptionalUnit : IUnit
    {
        /// <summary>
        /// Occures, if <see cref="DefaultCulture"/> was changed by system.
        /// </summary>
        event ChangeEventHandler<CultureInfo> OnCultureChanged;
        /// <summary>
        /// Constant format for json files; 0 is Culture (e.g.: en-US) 1 is area
        /// (e.g. Unit).
        /// </summary>
        const string JsonFileFormat = "Measurement/{0}_{1}.json";
        /// <summary>
        /// Gets the JsonFile name.
        /// </summary>
        /// <value>The JsonFile name.</value>
        string JsonFile { get; }
        /// <summary>
        /// Gets the base measurement.
        /// </summary>
        /// <value>The base measurement.</value>
        IUnit BaseUnit { get; }
        /// <summary>
        /// Gets the default culture for this optional unit.
        /// </summary>
        /// <value>The default culture for this optional unit.</value>
        CultureInfo DefaultCulture { get; }
        /// <summary>
        /// Gets the specific value change.
        /// </summary>
        /// <returns>The calculated value.</returns>
        Formular FormulaOptional { get; }
        /// <summary>
        /// Gets the SI value.
        /// </summary>
        /// <returns>The calculated value.</returns>
        Formular FormularSI { get; }
        /// <summary>
        /// Gets a Json Document that holds the calculation variables.
        /// </summary>
        /// <value>A Json Document that holds the calculation variables.</value>
        JsonDocument OptUnitJson { get; }
    }

    /// <summary>
    /// Delegate for seperate functions to calculate the values.
    /// </summary>
    /// <param name="input">The input value.</param>
    /// <returns>The calculated result.</returns>
    public delegate double Formular(double input);
}
