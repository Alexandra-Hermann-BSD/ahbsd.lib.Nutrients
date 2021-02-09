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
using System.Data;
using ahbsd.lib.Nutrients.Measurement;
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Table for Nutrients.
    /// </summary>
    public class NutrientTable : DataTable
    {
        /// <summary>
        /// Constructor without amy parameters.
        /// </summary>
        public NutrientTable()
            : base("Nutrient")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The container.</param>
        public NutrientTable(IContainer container)
            : base("Nutrient")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, "Nutrient");
            }
        }

        /// <summary>
        /// Initializes this table.
        /// </summary>
        private void Initialize()
        {
            DataColumn NutrientID = new DataColumn("nID", typeof(int));
            DataColumn NutrientName = new DataColumn("name", typeof(string));
            DataColumn NutrientUnit = new DataColumn("unit", typeof(string));
            DataColumn NutrientAlternative = new DataColumn("Alternative", typeof(string));

            // Initialization Nutrient Table
            BeginInit();

            Columns.Add(NutrientID);
            Columns.Add(NutrientName);
            Columns.Add(NutrientUnit);
            Columns.Add(NutrientAlternative);

            Columns["nID"].AutoIncrement = true;
            Columns["nID"].Caption = "ID";

            Columns["name"].AllowDBNull = false;
            Columns["name"].Caption = "Nutrient Name";
            Columns["name"].MaxLength = 80;

            Columns["unit"].AllowDBNull = false;
            Columns["unit"].Caption = "Unit";
            Columns["unit"].MaxLength = 5;

            Columns["Alternative"].AllowDBNull = true;
            Columns["Alternative"].Caption = "Alternative Name";
            Columns["Alternative"].DefaultValue = DBNull.Value;

            EndInit();
        }

        /// <summary>
        /// Gets the Column NutrientID.
        /// </summary>
        /// <value>The Column NutrientID.</value>
        public DataColumn NutrientID => Columns["nID"];
        /// <summary>
        /// Gets the Column NutrientName.
        /// </summary>
        /// <value>The Column NutrientName.</value>
        public DataColumn NutrientName => Columns["name"];
        /// <summary>
        /// Gets the Column NutrientUnit.
        /// </summary>
        /// <value>The Column NutrientUnit.</value>
        public DataColumn NutrientUnit => Columns["unit"];
        /// <summary>
        /// Gets the Column NutrientAlternative.
        /// </summary>
        /// <value>The Column NutrientAlternative.</value>
        public DataColumn NutrientAlternative => Columns["Alternative"];

        /// <summary>
        /// Get a nutrient from a defined rowID.
        /// </summary>
        /// <param name="rowID">The defined rowID.</param>
        /// <returns>The nutrient from the defined rowID.</returns>
        /// <exception cref="Exception">If rowID isn't available.</exception>
        public INutrient GetNutrient(int rowID)
        {
            INutrient result;
            int id;
            string name;
            IUnit unit;
            DataRow row;

            if (Rows.Count > rowID)
            {
                row = Rows[rowID];
                id = (int)row[NutrientID];
                name = (string)row[NutrientName];
                unit = new Unit();
                result = new Nutrient.Nutrient(id, name, unit);
            }
            else
            {
                throw new Exception($"RowID {rowID} isn't available!");
            }

            return result;
        }
    }
}
