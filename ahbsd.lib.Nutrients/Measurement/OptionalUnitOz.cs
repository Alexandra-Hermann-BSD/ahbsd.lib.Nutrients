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
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text;

namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// An option for weight units from SI gram (g) to US ounzes (oz).
    /// </summary>
    public class OptionalUnitOz : Component, IOptionalUnit
    {
        /// <summary>
        /// The path to the json file.
        /// </summary>
        private string jsonFile;
        /// <summary>
        /// A current culture info.
        /// </summary>
        private CultureInfo cultureInfo;

        /// <summary>
        /// The value from gram to ounzes.
        /// </summary>
        private double g_oz;
        /// <summary>
        /// The value from ounzes to gram.
        /// </summary>
        private double oz_g;

        /// <summary>
        /// Constructor with a given base SI-Unit.
        /// </summary>
        /// <param name="unit">The given base SI-Unit.</param>
        public OptionalUnitOz(IUnit unit)
            : base()
        {
            Initialize(unit);
        }

        /// <summary>
        /// Constructor with a given base SI-Unit and a container.
        /// </summary>
        /// <param name="unit">The given base SI-Unit.</param>
        /// <param name="container">The container.</param>
        public OptionalUnitOz(IUnit unit, IContainer container)
            : base()
        {
            Initialize(unit);

            if (container != null)
            {
                container.Add(this, $"OptionalUnitOz_{BaseUnit.GetType().Name}");
            }
        }

        /// <summary>
        /// Initialization with the given base SI-Unit.
        /// </summary>
        /// <param name="unit">The given base SI-Unit.</param>
        private void Initialize(IUnit unit)
        {
            StreamReader reader;
            BaseUnit = unit;
            FormularSI = GetSI;
            FormulaOptional = GetOz;
            cultureInfo = CultureInfo.CurrentCulture;
            JsonElement je;
            string tmpname1, tmpname2;
            double factor;

            jsonFile = string.Format(IOptionalUnit.JsonFileFormat,
                DefaultCulture.Name, BaseUnit.GetType().Name);

            try
            {
                reader = new StreamReader(JsonFile, Encoding.UTF8);

                OptUnitJson = JsonDocument.Parse(reader.BaseStream);
                reader.Close();
            }
            catch (Exception)
            { }

            if (OptUnitJson != null)
            {
                je = OptUnitJson.RootElement;

                foreach (JsonProperty item in je.EnumerateObject())
                {
                    tmpname1 = item.Name;
                    foreach (JsonProperty item2 in item.Value.EnumerateObject())
                    {
                        tmpname2 = item2.Name;
                        factor = item2.Value.GetDouble();

                        if (tmpname1.Equals("g") && tmpname2.Equals("oz"))
                        {
                            g_oz = factor;
                        }
                        else if (tmpname1.Equals("oz") && tmpname2.Equals("g"))
                        {
                            oz_g = factor;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Function for the delegate <see cref="FormulaOptional"/>.
        /// </summary>
        /// <param name="input">The input SI value.</param>
        /// <returns>The calculated OZ value.</returns>
        private double GetOz(double input) => input * g_oz;

        /// <summary>
        /// Function for the delegate <see cref="FormularSI"/>.
        /// </summary>
        /// <param name="input">The input OZ value.</param>
        /// <returns>The calculated SI value.</returns>
        private double GetSI(double input) => input * oz_g;

        #region implementation of IOptionalUnit

        /// <summary>
        /// Occures, if <see cref="DefaultCulture"/> was changed by system.
        /// </summary>
        public event ChangeEventHandler<CultureInfo> OnCultureChanged;
        /// <summary>
        /// Gets the JsonFile name.
        /// </summary>
        /// <value>The JsonFile name.</value>
        public string JsonFile
        {
            get => jsonFile;
            private set => jsonFile = value;
        }
        /// <summary>
        /// Gets the base measurement.
        /// </summary>
        /// <value>The base measurement.</value>
        public IUnit BaseUnit { get; private set; }
        /// <summary>
        /// Gets the default culture for this optional unit.
        /// </summary>
        /// <value>The default culture for this optional unit.</value>
        public CultureInfo DefaultCulture
        {
            get => cultureInfo;
            protected internal set
            {
                if (value != null && !value.Equals(cultureInfo))
                {
                    ChangeEventArgs<CultureInfo> cea
                        = new ChangeEventArgs<CultureInfo>(cultureInfo, value);
                    cultureInfo = value;
                    OnCultureChanged?.Invoke(this, cea);
                }
            }
        }

        /// <summary>
        /// Gets the specific value change.
        /// </summary>
        /// <returns>The calculated value.</returns>
        public Formular FormulaOptional { get; private set; }
        /// <summary>
        /// Gets the SI value.
        /// </summary>
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
