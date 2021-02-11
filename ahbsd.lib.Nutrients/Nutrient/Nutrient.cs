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
using System;
using ahbsd.lib;
using System.ComponentModel;
using ahbsd.lib.Nutrients.Measurement;
using System.Collections.Generic;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// A Class for Nutrient info.
    /// </summary>
    public class Nutrient : Component, INutrient
    {
        private readonly int nID;
        private readonly string nName;
        private CultureInfo culture;
        private IDictionary<CultureInfo, IOptionalUnit> optionalUnits;

        /// <summary>
        /// Constructor with id, name and unit.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="unit">The unit.</param>
        public Nutrient(int id, string name, IUnit unit)
            : base()
        {
            nID = id;

            if (name.Trim().Length <= 80)
            {
                nName = name.Trim();
            }
            else
            {
                throw new Exception($"Max length for name is 80; the length of \n'{name.Trim()}'\n is {name.Trim().Length} > 80!");
            }

            Unit = unit;

            DisplayName = Name;
            optionalUnits = new Dictionary<CultureInfo, IOptionalUnit>();

            culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Constructor with id, name, unit and a container.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="container">The component.</param>
        public Nutrient(int id, string name, IUnit unit, IContainer container)
            : base()
        {
            nID = id;

            if (name.Trim().Length <= 80)
            {
                nName = name.Trim();
            }
            else
            {
                throw new Exception($"Max length for name is 80; the length of \n'{name.Trim()}'\n is {name.Trim().Length} > 80!");
            }

            Unit = unit;

            DisplayName = Name;
            optionalUnits = new Dictionary<CultureInfo, IOptionalUnit>();

            culture = CultureInfo.CurrentCulture;

            if (container != null)
            {
                container.Add(this, Name);
            }
        }

        #region implementation of INutrient
        /// <summary>
        /// Happens, if <see cref="OptionalUnit"/> has changed.
        /// </summary>
        public event ChangeEventHandler<IOptionalUnit> OnOptionalUnitChanged;
        /// <summary>
        /// Happenes, if <see cref="CurrentCulture"/> changes.
        /// </summary>
        public event ChangeEventHandler<CultureInfo> OnCultureChanged;
        /// <summary>
        /// Gets the NutrientID.
        /// </summary>
        /// <value>The NutrientID.</value>
        public int ID => nID;
        /// <summary>
        /// Gets the name of the nutrient.
        /// </summary>
        /// <value>The name of the nutrient.</value>
        public string Name => nName;
        /// <summary>
        /// Gets the display name of the nutrient.
        /// </summary>
        /// <value>The display name of the nutrient.</value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets the Measurement.
        /// </summary>
        /// <value>The Measurement.</value>
        public IUnit Unit { get; private set; }
        /// <summary>
        /// Gets the optional measurements ordered by Culture.
        /// </summary>
        /// <value>The optional measurements ordered by Culture.</value>
        public IDictionary<CultureInfo, IOptionalUnit> OptionalUnits => optionalUnits;

        /// <summary>
        /// Gets the optional unit for the current culture.
        /// </summary>
        /// <value>The optional unit for the current culture.</value>
        public IOptionalUnit OptionalUnit => OptionalUnits[CurrentCulture];

        /// <summary>
        /// Gets the current culture.
        /// </summary>
        /// <value>The current culture.</value>
        public CultureInfo CurrentCulture
        {
            get => culture;
            set
            {
                if (value != null && !value.Equals(culture))
                {
                    ChangeEventArgs<CultureInfo> cea = new ChangeEventArgs<CultureInfo>(culture, value);
                    ChangeEventArgs<IOptionalUnit> ceaOU = new ChangeEventArgs<IOptionalUnit>(optionalUnits[culture], OptionalUnits[value]);
                    culture = value;

                    OnCultureChanged?.Invoke(this, cea);
                    OnOptionalUnitChanged?.Invoke(this, ceaOU);
                }
            }
        }
        #endregion
    }
}
