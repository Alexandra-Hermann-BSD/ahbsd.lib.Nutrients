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

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Table Unit.
    /// </summary>
    public class UnitTable : DataTable, IUnitTable
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public UnitTable()
            : base("Unit")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container"></param>
        public UnitTable(IContainer container)
            : base("Unit")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, "Unit");
            }
        }

        /// <summary>
        /// Initialize this table.
        /// </summary>
        private void Initialize()
        {
            DataColumn UnitID = new DataColumn("uID", typeof(int));
            DataColumn UnitName = new DataColumn("name", typeof(string));

            BeginInit();

            Columns.Add(UnitID);
            Columns.Add(UnitName);

            Columns["uID"].AutoIncrement = true;
            Columns["uID"].AllowDBNull = false;
            Columns["uID"].Caption = "ID";

            Columns["name"].AllowDBNull = false;
            Columns["name"].Caption = "Unit";
            Columns["name"].MaxLength = 5;

            EndInit();
        }

        #region implementation of IUnitTable
        /// <summary>
        /// Gets the Column UnitID.
        /// </summary>
        /// <value>The Column UnitID.</value>
        public DataColumn UnitID => Columns["uID"];
        /// <summary>
        /// Gets the Column UnitName.
        /// </summary>
        /// <value>The Column UnitName.</value>
        public DataColumn UnitName => Columns["name"];

        /// <summary>
        /// Gets the <see cref="IUnit"/> from Row[rowID].
        /// </summary>
        /// <param name="rowID">The RowID.</param>
        /// <returns>The <see cref="IUnit"/> from Row[rowID].</returns>
        /// <exception cref="Exception">If rowID doesn't exists.</exception>
        public IUnit GetUnit(int rowID)
        {
            IUnit result;
            int id;
            string name;
            DataRow row;

            if (Rows.Count > rowID)
            {
                row = Rows[rowID];

                id = (int)row[UnitID];
                name = (string)row[UnitName];

                result = new Unit(id, name);
            }
            else
            {
                throw new Exception($"Row[{rowID}] does not exists!");
            }

            return result;
        }

        /// <summary>
        /// Gets a List of <see cref="IUnit"/>s, if Rows are available.
        /// </summary>
        /// <returns>
        /// A List of <see cref="IUnit"/>s, if Rows are available, otherwise
        /// <c>null</c>.
        /// </returns>
        public IList<IUnit> GetUnits()
        {
            IList<IUnit> result = null;
            int id;
            string name;

            if (Rows.Count > 0)
            {
                result = new List<IUnit>(Rows.Count);

                foreach (DataRow row in Rows)
                {
                    id = (int)row[UnitID];
                    name = (string)row[UnitName];

                    result.Add(new Unit(id, name));
                }
            }

            return result;
        }
        #endregion
    }
}
