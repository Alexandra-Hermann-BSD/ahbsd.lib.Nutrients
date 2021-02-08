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
using System.Data;
using ahbsd.lib.Nutrients.Measurement;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Interface for <see cref="UnitTable"/>.
    /// </summary>
    public interface IUnitTable
    {
        /// <summary>
        /// Gets the Column UnitID.
        /// </summary>
        /// <value>The Column UnitID.</value>
        DataColumn UnitID { get; }
        /// <summary>
        /// Gets the Column UnitName.
        /// </summary>
        /// <value>The Column UnitName.</value>
        DataColumn UnitName { get; }

        /// <summary>
        /// Gets the <see cref="IUnit"/> from Row[rowID].
        /// </summary>
        /// <param name="rowID">The RowID.</param>
        /// <returns>The <see cref="IUnit"/> from Row[rowID].</returns>
        /// <exception cref="Exception">If rowID doesn't exists.</exception>
        IUnit GetUnit(int rowID);
        /// <summary>
        /// Gets a List of <see cref="IUnit"/>s, if Rows are available.
        /// </summary>
        /// <returns>
        /// A List of <see cref="IUnit"/>s, if Rows are available, otherwise
        /// <c>null</c>.
        /// </returns>
        IList<IUnit> GetUnits();
    }
}