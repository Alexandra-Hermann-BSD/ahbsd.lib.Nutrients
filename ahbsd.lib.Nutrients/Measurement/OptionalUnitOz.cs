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

namespace ahbsd.lib.Nutrients.Measurement
{
    public class OptionalUnitOz : Component, IOptionalUnit
    {
        private string jsonFile;
        private CultureInfo cultureInfo;

        public OptionalUnitOz(IUnit unit)
            : base()
        {
            Initialize(unit);
        }

        public OptionalUnitOz(IUnit unit, IContainer container)
            : base()
        {
            Initialize(unit);

            if (container != null)
            {
                container.Add(this, BaseUnit.GetType().Name);
            }
        }

        private double g_oz;
        private double oz_g;

        private void Initialize(IUnit unit)
        {
            StreamReader reader;
            BaseUnit = unit;
            FormularSI = GetSI;
            FormulaOptional = GetOz;
            cultureInfo = CultureInfo.CurrentCulture;

            jsonFile = string.Format(IOptionalUnit.JsonFileFormat,
                DefaultCulture.Name, BaseUnit.GetType().Name);

            try
            {
#if DEBUG
                reader = new StreamReader("Measurement/en_US_Unit.json", System.Text.Encoding.UTF8);
#else
                reader = new StreamReader(JsonFile, System.Text.Encoding.UTF8);
#endif

                OptUnitJson = JsonDocument.Parse(reader.BaseStream);
                reader.Close();
            }
            catch (Exception)
            {

            }
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
