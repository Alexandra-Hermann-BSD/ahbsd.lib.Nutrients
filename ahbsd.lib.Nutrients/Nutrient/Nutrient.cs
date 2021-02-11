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
using System.Text;
using System.Reflection;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// A Class for Nutrient info.
    /// </summary>
    public partial class Nutrient : Component, INutrient
    {
        private readonly int nID;
        private readonly string nName;
        private readonly string nAlternative;
        private string displayName;
        private CultureInfo culture;
        private IDictionary<CultureInfo, IOptionalUnit> optionalUnits;

        /// <summary>
        /// Constructor with id, name and unit.
        /// [optional] the alternative name.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="alternative">[optional] The alternative name.</param>
        public Nutrient(int id, string name, IUnit unit, string alternative = null)
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

            nAlternative = alternative;

            Unit = unit;

            DisplayName = Name;
            optionalUnits = new Dictionary<CultureInfo, IOptionalUnit>();

            culture = CultureInfo.CurrentCulture;
            optionalUnits.Add(culture, new OptionalUnitOz(unit, Container));
        }

        /// <summary>
        /// Constructor with id, name, unit and a container.
        /// [optional] the alternative name.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="container">The component.</param>
        /// <param name="alternative">[optional] The alternative name.</param>
        public Nutrient(int id, string name, IUnit unit, IContainer container, string alternative = null)
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

            nAlternative = alternative;

            Unit = unit;

            DisplayName = Name;
            optionalUnits = new Dictionary<CultureInfo, IOptionalUnit>();

            culture = CultureInfo.CurrentCulture;
            optionalUnits.Add(culture, new OptionalUnitOz(unit, Container));


            if (container != null)
            {
                container.Add(this, Name);
            }
        }

        #region implementation of INutrient

        /// <summary>
        /// Happens, if the <see cref="DisplayName"/> was changed from outside.
        /// </summary>
        public event ChangeEventHandler<string> OnDisplayNameChanged;
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
        /// Gets the alternative name of the nutrient.
        /// </summary>
        /// <value>The alternative name of the nutrient.</value>
        public string Alternative => nAlternative;
        /// <summary>
        /// Gets the display name of the nutrient.
        /// </summary>
        /// <value>The display name of the nutrient.</value>
        public string DisplayName
        {
            get => displayName;
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Equals(displayName))
                {
                    ChangeEventArgs<string> cea = new ChangeEventArgs<string>(displayName, value);
                    displayName = value;
                    OnDisplayNameChanged?.Invoke(this, cea);
                }
            }
        }
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
                INutrientTranslation translation;

                if (value != null && !value.Equals(culture))
                {
                    if (!optionalUnits.ContainsKey(value))
                    {
                        optionalUnits.Add(value, null);
                    }

                    ChangeEventArgs<CultureInfo> cea = new ChangeEventArgs<CultureInfo>(culture, value);
                    ChangeEventArgs<IOptionalUnit> ceaOU = new ChangeEventArgs<IOptionalUnit>(optionalUnits[culture], OptionalUnits[value]);
                    culture = value;
                    translation = GetNutrientTranslation(value);

                    displayName = Name switch
                    {
                        "Biotin" => translation.Biotin,
                        "Caffeine" => translation.Caffeine,
                        "Calcium" => translation.Calcium,
                        "Carbohydrates" => translation.Carbohydrates,
                        "Chloride" => translation.Chloride,
                        "Cholesterol" => translation.Cholesterol,
                        "Chromium" => translation.Chromium,
                        "Copper" => translation.Copper,
                        "FatMonosaturated" => translation.FatMonosaturated,
                        "FatPolysaturated" => translation.FatPolysaturated,
                        "FatSaturated" => translation.FatSaturated,
                        "FatTotal" => translation.FatTotal,
                        "Fiber" => translation.Fiber,
                        "Folate" => translation.Folate,
                        "Iodine" => translation.Iodine,
                        "Iron" => translation.Iron,
                        "Magnesium" => translation.Magnesium,
                        "Manganese" => translation.Manganese,
                        "Molybdenum" => translation.Molybdenum,
                        "Niacin" => translation.Niacin,
                        "PantotenicAcid" => translation.PantotenicAcid,
                        "Phosphorus" => translation.Phosphorus,
                        "Potassium" => translation.Potassium,
                        "Protein" => translation.Protein,
                        "Riboflavin" => translation.Riboflavin,
                        "Selenium" => translation.Selenium,
                        "Sodium" => translation.Sodium,
                        "Sugar" => translation.Sugar,
                        "Thiamin" => translation.Thiamin,
                        "VitaminA" => translation.VitaminA,
                        "VitaminB12" => translation.VitaminB12,
                        "VitaminB6" => translation.VitaminB6,
                        "VitaminC" => translation.VitaminC,
                        "VitaminD" => translation.VitaminD,
                        "VitaminE" => translation.VitaminE,
                        "VitaminK" => translation.VitaminK,
                        "Water" => translation.Water,
                        "Zinc" => translation.Zinc,
                        "Alcohol" => translation.Alcohol,
                        "Energy" => translation.Energy,
                        _ => Name,
                    };
                    OnCultureChanged?.Invoke(this, cea);
                    OnOptionalUnitChanged?.Invoke(this, ceaOU);
                }
            }
        }
        #endregion

        /// <summary>
        /// Gets a short wiew of this nutrient.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(DisplayName);

            if (!string.IsNullOrEmpty(Alternative))
            {
                stringBuilder.AppendFormat(" ({0})", Alternative);
            }

            stringBuilder.AppendFormat(" {0}", Unit);

            return stringBuilder.ToString();
        }
    }
}
