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
using ahbsd.lib.Nutrients.Measurement;

namespace ahbsd.lib.Nutrients.Nutrient
{
    public class Nutrient : INutrient
    {
        private readonly int nID;
        private readonly string nName;
        private CultureInfo culture;
        private IOptionalUnit optionalUnit;

        /// <summary>
        /// Constructor with id, name and unit.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="unit">The unit.</param>
        public Nutrient(int id, string name, IUnit unit)
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
            optionalUnit = null;
            culture = CultureInfo.CurrentCulture;
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
        /// Gets the optional measurement - if available.
        /// </summary>
        /// <value>The optional measurement.</value>
        public IOptionalUnit OptionalUnit
        {
            get => optionalUnit;
            set
            {
                if (value != null && !value.Equals(optionalUnit))
                {
                    ChangeEventArgs<IOptionalUnit> cea
                        = new ChangeEventArgs<IOptionalUnit>(optionalUnit,
                        value);
                    optionalUnit = value;

                    if (!optionalUnit.DefaultCulture.Equals(CurrentCulture))
                    {
                        CurrentCulture = optionalUnit.DefaultCulture;
                    }

                    OnOptionalUnitChanged?.Invoke(this, cea);
                }
            }
        }
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
                    culture = value;

                    OnCultureChanged?.Invoke(this, cea);
                }
            }
        }
        #endregion
    }
}
