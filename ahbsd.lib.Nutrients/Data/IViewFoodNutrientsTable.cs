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
using System.Data;

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

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Interface for the view viewFoodNutrients
    /// </summary>
    public interface IViewFoodNutrientsTable
    {
        /// <summary>
        /// Gets the version.ID.
        /// </summary>
        /// <value>The version.ID.</value>
        DataColumn VID { get; }
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        DataColumn FirstDate { get; }
        /// <summary>
        /// Gets the name of the food.
        /// </summary>
        /// <value>The name of the food.</value>
        DataColumn Food { get; }
        /// <summary>
        /// Gets the Column producer.pID.
        /// </summary>
        /// <value>The Column producer.pID.</value>
        DataColumn PID { get; }
        /// <summary>
        /// Gets the Column producer.name.
        /// </summary>
        /// <value>The Column producer.name.</value>
        DataColumn Producer { get; }
        /// <summary>
        /// Gets the Column Nutrient.Name.
        /// </summary>
        /// <value>The Column Nutrient.Name.</value>
        DataColumn Nutrient { get; }
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        DataColumn Amount { get; }
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        DataColumn Unit { get; }
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        DataColumn Per { get; }
        /// <summary>
        /// Gets the Column UnitName.
        /// </summary>
        /// <value>The Column UnitName.</value>
        DataColumn UnitType { get; }
    }
}
