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
    /// Class for the FoodNutrient Table.
    /// </summary>
    public class FoodNutrientTable : DataTable, IFoodNutrientTable
    {
        /// <summary>
        /// Constructor without container.
        /// </summary>
        public FoodNutrientTable()
            : base("FoodNutrient")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with container.
        /// </summary>
        /// <param name="container">The container.</param>
        public FoodNutrientTable(IContainer container)
            : base("FoodNutrient")
        {
            if (container != null)
            {
                container.Add(this, TableName);
            }

            Initialize();
        }

        /// <summary>
        /// Initializes this opbject.
        /// </summary>
        private void Initialize()
        {
            DataColumn FID = new DataColumn("fID", typeof(int));
            DataColumn NID = new DataColumn("nID", typeof(int));
            DataColumn VID = new DataColumn("vID", typeof(int));
            DataColumn Amount = new DataColumn("Amount", typeof(double));
            DataColumn Per = new DataColumn("Per", typeof(double));
            DataColumn Unit = new DataColumn("Unit", typeof(int));

            DataColumn[] pk = new DataColumn[3];

            BeginInit();
            FID.AutoIncrement = false;
            FID.AllowDBNull = false;
            FID.Caption = "Food-ID";

            NID.AutoIncrement = false;
            NID.AllowDBNull = false;
            NID.Caption = "Nutrient-ID";

            VID.AutoIncrement = false;
            VID.AllowDBNull = false;
            VID.Caption = "Version-ID";

            Amount.AllowDBNull = false;

            Per.AllowDBNull = false;

            Unit.AllowDBNull = false;

            Columns.Add(FID);
            Columns.Add(NID);
            Columns.Add(VID);
            Columns.Add(Amount);
            Columns.Add(Per);
            Columns.Add(Unit);

            pk[0] = FID;
            pk[1] = NID;
            pk[2] = VID;

            PrimaryKey = pk;

            EndInit();
        }

        #region implementation of IFoodNutrientTable
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        public DataColumn FID => Columns["fID"];
        /// <summary>
        /// Gets the NutrientID.
        /// </summary>
        /// <value>The NutrientID.</value>
        public DataColumn NID => Columns["nID"];
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        public DataColumn VID => Columns["vID"];
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        public DataColumn Amount => Columns["Amount"];
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        public DataColumn Per => Columns["Per"];
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public DataColumn Unit => Columns["Unit"];

        /// <summary>
        /// Gets the FoodNutrient entry from Row rowID.
        /// </summary>
        /// <param name="rowID">The rowID.</param>
        /// <returns>The FoodNutrient entry.</returns>
        /// <exception cref="Exception">If the rowID doesn't exists.</exception>
        public IFoodNutrient GetFoodNutrient(int rowID)
        {
            IFoodNutrient result = null;
            DataRow row;
            int nID, fID, vID, unit;
            double amount, per;
            IUnit u;

            if (rowID < Rows.Count)
            {
                row = Rows[rowID];
                fID = (int)row[FID];
                nID = (int)row[NID];
                vID = (int)row[VID];
                amount = (double)row[Amount];
                per = (double)row[Per];
                unit = (int)row[Unit];

                u = UnitTable.GetKnownUnit(unit);

                result = new FoodNutrient(fID, nID, vID, amount, per, u, Container);
            }



            return result;
        }
        /// <summary>
        /// Gets a list of all FoodNutrient entries.
        /// </summary>
        /// <returns>A list of all FoodNutrient entries.</returns>
        public IList<IFoodNutrient> GetFoodNutrients()
        {
            IList<IFoodNutrient> result = new List<IFoodNutrient>(Rows.Count);
            int nID, fID, vID, unit;
            double amount, per;
            IUnit u;
            IFoodNutrient tmp;

            foreach (DataRow row in Rows)
            {
                fID = (int)row[FID];
                nID = (int)row[NID];
                vID = (int)row[VID];
                amount = (double)row[Amount];
                per = (double)row[Per];
                unit = (int)row[Unit];

                u = UnitTable.GetKnownUnit(unit);
                tmp = new FoodNutrient(fID, nID, vID, amount, per, u, Container);
                result.Add(tmp);
            }

            return result;
        }
        #endregion
    }
}
