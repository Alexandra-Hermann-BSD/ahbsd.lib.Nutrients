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
    /// Class for the view viewFoodNutrients.
    /// </summary>
    public class ViewFoodNutrientsTable : DataTable, IViewFoodNutrientsTable
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public ViewFoodNutrientsTable()
            : base("viewFoodNutritions")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The container.</param>
        public ViewFoodNutrientsTable(IContainer container)
            : base("viewFoodNutritions")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, TableName);
            }
        }

        /// <summary>
        /// Initializes the Table.
        /// </summary>
        private void Initialize()
        {
            /*
            v.vID,
            v.firstDate,
            f.name AS Food,
            p.pID,
            p.name AS Producer,
            n.name AS Nutrient,
            fn.Amount,
            n.unit,
            fn.Per,
            u.name AS UnitType
            */

            DataColumn vID = new DataColumn("vID", typeof(int));
            DataColumn firstDate = new DataColumn("firstDate", typeof(DateTime));
            DataColumn Food = new DataColumn("Food", typeof(string));
            DataColumn pID = new DataColumn("pID", typeof(int));
            DataColumn Producer = new DataColumn("Producer", typeof(string));
            DataColumn Nutrient = new DataColumn("Nutrient", typeof(string));
            DataColumn Amount = new DataColumn("Amount", typeof(double));
            DataColumn unit = new DataColumn("unit", typeof(string));
            DataColumn Per = new DataColumn("Per", typeof(double));
            DataColumn UnitType = new DataColumn("UnitType", typeof(string));

            vID.AllowDBNull = false;
            firstDate.AllowDBNull = false;
            Food.AllowDBNull = false;
            pID.AllowDBNull = true;
            Producer.AllowDBNull = true;
            Nutrient.AllowDBNull = false;
            Amount.AllowDBNull = false;
            unit.AllowDBNull = false;
            Per.AllowDBNull = false;
            UnitType.AllowDBNull = false;


            Columns.Add(vID);
            Columns.Add(firstDate);
            Columns.Add(Food);
            Columns.Add(pID);
            Columns.Add(Producer);
            Columns.Add(Nutrient);
            Columns.Add(Amount);
            Columns.Add(unit);
            Columns.Add(Per);
            Columns.Add(UnitType);
        }

        #region implementation of IViewFoodNutrientsTable
        /// <summary>
        /// Gets the version.ID.
        /// </summary>
        /// <value>The version.ID.</value>
        public DataColumn VID => Columns["vID"];
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        public DataColumn FirstDate => Columns["firstName"];
        /// <summary>
        /// Gets the name of the food.
        /// </summary>
        /// <value>The name of the food.</value>
        public DataColumn Food => Columns["Food"];
        /// <summary>
        /// Gets the Column producer.pID.
        /// </summary>
        /// <value>The Column producer.pID.</value>
        public DataColumn PID => Columns["pID"];
        /// <summary>
        /// Gets the Column producer.name.
        /// </summary>
        /// <value>The Column producer.name.</value>
        public DataColumn Producer => Columns["Producer"];
        /// <summary>
        /// Gets the Column Nutrient.Name.
        /// </summary>
        /// <value>The Column Nutrient.Name.</value>
        public DataColumn Nutrient => Columns["Nutrient"];
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        public DataColumn Amount => Columns["Amount"];
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public DataColumn Unit => Columns["unit"];
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        public DataColumn Per => Columns["Per"];
        /// <summary>
        /// Gets the Column UnitName.
        /// </summary>
        /// <value>The Column UnitName.</value>
        public DataColumn UnitType => Columns["UnitType"];
        #endregion
    }
}
