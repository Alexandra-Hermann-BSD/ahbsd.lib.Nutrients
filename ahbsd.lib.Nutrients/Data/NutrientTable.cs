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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ahbsd.lib.Nutrients.Measurement;
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Table for Nutrients.
    /// </summary>
    public class NutrientTable : DataTable, INutrientTable
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
                container.Add(this, TableName);
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
            DataColumn[] pk = new DataColumn[1];

            // Initialization Nutrient Table
            BeginInit();

            Columns.Add(NutrientID);
            Columns.Add(NutrientName);
            Columns.Add(NutrientUnit);
            Columns.Add(NutrientAlternative);

            NutrientID.AutoIncrement = true;
            NutrientID.Caption = "ID";

            NutrientName.AllowDBNull = false;
            NutrientName.Caption = "Nutrient Name";
            NutrientName.MaxLength = 80;

            NutrientUnit.AllowDBNull = false;
            NutrientUnit.Caption = "Unit";
            NutrientUnit.MaxLength = 5;

            NutrientAlternative.AllowDBNull = true;
            NutrientAlternative.Caption = "Alternative Name";
            NutrientAlternative.DefaultValue = DBNull.Value;

            pk[0] = NutrientID;

            PrimaryKey = pk;


            EndInit();
        }

        #region implementation of INutrientTable
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
            int id, uid;
            string name;
            string nutrientUnit;
            string alternative;
            
            IUnit unit;
            DataRow row;

            if (Rows.Count > rowID)
            {
                row = Rows[rowID];
                id = (int)row[NutrientID];
                name = (string)row[NutrientName];
                alternative = (string)row[NutrientAlternative];
                nutrientUnit = (string)row[NutrientUnit];
                uid = UnitTable.GetUID(nutrientUnit);
                unit = new Unit(uid, nutrientUnit);
                result = new Nutrient.Nutrient(id, name, unit, Container, alternative);
            }
            else
            {
                throw new Exception($"RowID {rowID} isn't available!");
            }

            return result;
        }

        /// <summary>
        /// Gets a list with all current Nutrients in the Rows.
        /// </summary>
        /// <returns>A list with all current Nutrients in the Rows.</returns>
        public IList<INutrient> GetNutrients()
        {
            IList<INutrient> result = new List<INutrient>(Rows.Count);
            INutrient tmp;
            int id, uid;
            string name;
            string alternative;
            string nutrientUnit;
            IUnit unit;


            foreach (DataRow row in Rows)
            {
                id = (int)row[NutrientID];
                name = (string)row[NutrientName];

                if (row[NutrientAlternative] != DBNull.Value)
                {
                    alternative = (string)row[NutrientAlternative];
                }
                else
                {
                    alternative = null;
                }

                nutrientUnit = (string)row[NutrientUnit];
                uid = UnitTable.GetUID(nutrientUnit);
                unit = new Unit(uid, nutrientUnit);
                tmp = new Nutrient.Nutrient(id, name, unit, Container, alternative);
                result.Add(tmp);
            }

            return result;
        }
        #endregion
    }
}
