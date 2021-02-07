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

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Defines the dataset for the database nutrients.
    /// </summary>
    public class NutrientsDataSet : DataSet
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public NutrientsDataSet()
            : base("DSNutrients")
        {
            InitiateDS();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The container.</param>
        public NutrientsDataSet(IContainer container)
            : base("DSNutrients")
        {
            InitiateDS();
            container.Add(this, "DSNutrients");
        }

        /// <summary>
        /// Initiates the dataset.
        /// </summary>
        private void InitiateDS()
        {
            // deinition of single objects
            DataTable Nutrient = new DataTable("Nutrient");
            DataTable Unit = new DataTable("Unit");

            DataColumn NutrientID = new DataColumn("nID", typeof(int));
            DataColumn NutrientName = new DataColumn("name", typeof(string));
            DataColumn NutrientUnit = new DataColumn("unit", typeof(string));
            DataColumn NutrientAlternative = new DataColumn("Alternative", typeof(string));

            DataColumn UnitID = new DataColumn("uID", typeof(int));
            DataColumn UnitName = new DataColumn("name", typeof(string));

            // Initialization Nutrient Table
            Nutrient.BeginInit();

            Nutrient.Columns.Add(NutrientID);
            Nutrient.Columns.Add(NutrientName);
            Nutrient.Columns.Add(NutrientUnit);
            Nutrient.Columns.Add(NutrientAlternative);

            Nutrient.Columns["nID"].AutoIncrement = true;
            Nutrient.Columns["nID"].Caption = "ID";

            Nutrient.Columns["name"].AllowDBNull = false;
            Nutrient.Columns["name"].Caption = "Nutrient Name";
            Nutrient.Columns["name"].MaxLength = 80;

            Nutrient.Columns["unit"].AllowDBNull = false;
            Nutrient.Columns["unit"].Caption = "Unit";
            Nutrient.Columns["unit"].MaxLength = 5;

            Nutrient.Columns["Alternative"].AllowDBNull = true;
            Nutrient.Columns["Alternative"].Caption = "Alternative Name";
            Nutrient.Columns["Alternative"].DefaultValue = DBNull.Value;

            Nutrient.EndInit();

            // Initialization Unit Table
            Unit.BeginInit();

            Unit.Columns.Add(UnitID);
            Unit.Columns.Add(UnitName);

            Unit.Columns["uID"].AutoIncrement = true;
            Unit.Columns["uID"].Caption = "ID";

            Unit.Columns["name"].AllowDBNull = false;
            Unit.Columns["name"].Caption = "Unit Name";
            Unit.Columns["name"].MaxLength = 5;

            Unit.EndInit();


            BeginInit();
            Clear();

            Tables.Add(Nutrient);
            Tables.Add(Unit);

            EndInit();
        }
    }
}
