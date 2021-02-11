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
    /// Interface for a NutrientTable
    /// </summary>
    public interface INutrientTable
    {
        /// <summary>
        /// Gets the Column NutrientID.
        /// </summary>
        /// <value>The Column NutrientID.</value>
        DataColumn NutrientID { get; }
        /// <summary>
        /// Gets the Column NutrientName.
        /// </summary>
        /// <value>The Column NutrientName.</value>
        DataColumn NutrientName { get; }
        /// <summary>
        /// Gets the Column NutrientUnit.
        /// </summary>
        /// <value>The Column NutrientUnit.</value>
        DataColumn NutrientUnit { get; }
        /// <summary>
        /// Gets the Column NutrientAlternative.
        /// </summary>
        /// <value>The Column NutrientAlternative.</value>
        DataColumn NutrientAlternative { get; }

        /// <summary>
        /// Get a nutrient from a defined rowID.
        /// </summary>
        /// <param name="rowID">The defined rowID.</param>
        /// <returns>The nutrient from the defined rowID.</returns>
        /// <exception cref="Exception">If rowID isn't available.</exception>
        INutrient GetNutrient(int rowID);
        /// <summary>
        /// Gets a list with all current Nutrients in the Rows.
        /// </summary>
        /// <returns>A list with all current Nutrients in the Rows.</returns>
        IList<INutrient> GetNutrients();
    }
}