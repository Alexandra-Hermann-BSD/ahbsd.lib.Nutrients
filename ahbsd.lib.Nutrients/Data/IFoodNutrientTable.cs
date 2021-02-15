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
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Interface for a FoodNutrient table.
    /// </summary>
    public interface IFoodNutrientTable
    {
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        DataColumn FID { get; }
        /// <summary>
        /// Gets the NutrientID.
        /// </summary>
        /// <value>The NutrientID.</value>
        DataColumn NID { get; }
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        DataColumn VID { get; }
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        DataColumn Amount { get; }
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        DataColumn Per { get; }
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        DataColumn Unit { get; }
        /// <summary>
        /// Gets the FoodNutrient entry from Row rowID.
        /// </summary>
        /// <param name="rowID">The rowID.</param>
        /// <returns>The FoodNutrient entry.</returns>
        /// <exception cref="Exception">If the rowID doesn't exists.</exception>
        IFoodNutrient GetFoodNutrient(int rowID);
        /// <summary>
        /// Gets a list of all FoodNutrient entries.
        /// </summary>
        /// <returns>A list of all FoodNutrient entries.</returns>
        IList<IFoodNutrient> GetFoodNutrients();
    }
}
