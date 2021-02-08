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
using System;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace ahbsd.lib.Nutrients.Measurement
{
    public class OptionalUnitOz : IOptionalUnit
    {
        public OptionalUnitOz(IUnit unit)
        {
            BaseUnit = unit;
            FormularSI = GetSI;
            FormulaOptional = GetOz;
        }

        private double GetOz(IUnit input)
        {
            double result = 0.0;

            return result;
        }

        private double GetSI(IUnit input)
        {
            double result = 0.0;

            return result;
        }
        #region implementation of IOptionalUnit

        /// <summary>
        /// Gets the base measurement.
        /// </summary>
        /// <value>The base measurement.</value>
        public IUnit BaseUnit { get; private set; }
        /// <summary>
        /// Gets the default culture for this optional unit.
        /// </summary>
        /// <value>The default culture for this optional unit.</value>
        public CultureInfo DefaultCulture { get; }

        /// <summary>
        /// Gets the specific value change.
        /// </summary>
        /// <param name="formular">The formular to use.</param>
        /// <returns>The calculated value.</returns>
        public Formular FormulaOptional { get; private set; }
        /// <summary>
        /// Gets the SI value.
        /// </summary>
        /// <param name="formular">The formular to use.</param>
        /// <returns>The calculated value.</returns>
        public Formular FormularSI { get; private set; }

        /// <summary>
        /// Gets a Json Document that holds the calculation variables.
        /// </summary>
        /// <value>A Json Document that holds the calculation variables.</value>
        public JsonDocument OptUnitJson { get; private set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value
        {
            get => BaseUnit.Value;
            set => BaseUnit.Value = value;
        }

        /// <summary>
        /// Gets the UnitID.
        /// </summary>
        /// <value>The UnitID.</value>
        public int UID => BaseUnit.UID;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => BaseUnit.Name;
        #endregion
    }
}
