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
using System.ComponentModel.DataAnnotations;
using System.Data;
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Interface for a <see cref="Nutrient.Food"/> Table.
    /// </summary>
    public interface IFoodTable
    {
        /// <summary>
        /// Gets the Food-ID.
        /// </summary>
        /// <value>The Food-ID.</value>
        DataColumn FID { get; }
        /// <summary>
        /// Gets the name of the food.
        /// </summary>
        /// <value>The name of the food.</value>
        DataColumn Name { get; }
        /// <summary>
        /// Gets the default language of this food.
        /// </summary>
        /// <value>The default language of this food.</value>
        DataColumn DefaultLanguage { get; }
        /// <summary>
        /// Gets the producer-id <see cref="IProducerTable.PID"/> of this food.
        /// </summary>
        /// <value>The producer-id of this food.</value>
        DataColumn ProducerID { get; }
        /// <summary>
        /// Gets the Barcode of this Food.
        /// </summary>
        /// <value>The Barcode of this Food.</value>
        DataColumn Barcode { get; }
        /// <summary>
        /// Gets the food from the given DataRow.
        /// </summary>
        /// <param name="dataRow">The given DataRow.</param>
        /// <returns>The food from the given DataRow.</returns>
        /// <exception cref="Exception">If the given DataRow doesn't exists.</exception>
        IFood GetFood(int dataRow);
        /// <summary>
        /// Gets a list with all foods from the rows.
        /// </summary>
        /// <returns>A list with all foods.</returns>
        IList<IFood> GetFoods();
    }
}
