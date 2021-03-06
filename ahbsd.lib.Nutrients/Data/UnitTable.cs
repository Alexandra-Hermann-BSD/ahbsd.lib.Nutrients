﻿//
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
        /// Static constructor.
        /// </summary>
        static UnitTable()
        {
            KnownUnits = new List<IUnit>();
        }

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
            DataColumn unitID = new DataColumn("uID", typeof(int));
            DataColumn unitName = new DataColumn("name", typeof(string));
            DataColumn[] pk = new DataColumn[1];

            BeginInit();

            Columns.Add(unitID);
            Columns.Add(unitName);

            UnitID.AutoIncrement = true;
            UnitID.AllowDBNull = false;
            UnitID.Caption = "ID";

            UnitName.AllowDBNull = false;
            UnitName.Caption = "Unit";
            UnitName.MaxLength = 5;

            pk[0] = UnitID;
            PrimaryKey = pk;

            EndInit();
        }

        /// <summary>
        /// Gets a list of known units.
        /// </summary>
        /// <value>A list of known units.</value>
        public static IList<IUnit> KnownUnits { get; private set; }

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

                KnownUnits = result;
            }

            return result;
        }

        /// <summary>
        /// Gets the UnitID by it's name.
        /// </summary>
        /// <param name="name">The unit name.</param>
        /// <returns>The unit ID.</returns>
        /// <exception cref="Exception">If name is not available.</exception>
        public int GetUnitID(string name)
        {
            int result = 0;
            bool found = false;
            IList<IUnit> units = GetUnits();

            KnownUnits = units;

            foreach (var unit in units)
            {
                if (unit.Name.Equals(name))
                {
                    found = true;
                    result = unit.UID;
                    break;
                }
            }

            if (!found)
            {
                throw new Exception($"'{name}' doesn't exists!");
            }

            return result;
        }
        #endregion

        /// <summary>
        /// Gets the UnitID by the unit's name or -1, if it wasn't found.
        /// </summary>
        /// <param name="name">The unit's name.</param>
        /// <returns>The UnitID or -1, if it wasn't found.</returns>
        public static int GetUID(string name)
        {
            int result = -1;

            foreach (IUnit unit in KnownUnits)
            {
                if (unit.Name.Equals(name))
                {
                    result = unit.UID;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the UnitID by the unit's id or <c>null</c>, if it wasn't found.
        /// </summary>
        /// <param name="id">The unit's id.</param>
        /// <returns>The UnitID or <c>null</c>, if it wasn't found.</returns>
        public static IUnit GetKnownUnit(int id)
        {
            IUnit result = null;

            foreach (IUnit unit in KnownUnits)
            {
                if (unit.UID.Equals(id))
                {
                    result = unit;
                    break;
                }
            }

            return result;
        }
    }
}
