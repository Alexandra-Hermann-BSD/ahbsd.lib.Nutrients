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
using ahbsd.lib.Nutrients.Measurement;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface or FoodNutrient entry
    /// </summary>
    public interface IFoodNutrient : IComponent
    {
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        int FID { get; }
        /// <summary>
        /// Gets the NutrientID.
        /// </summary>
        /// <value>The NutrientID.</value>
        int NID { get; }
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        int VID { get; }
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        double Amount { get; }
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        double Per { get; }
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        IUnit Unit { get; }
    }
}
