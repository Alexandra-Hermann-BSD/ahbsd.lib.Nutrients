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
    /// Class for FoodNutrient entry
    /// </summary>
    public class FoodNutrient : Component, IFoodNutrient
    {
        /// <summary>
        /// Constructor for a FoodNutrient entry without container.
        /// </summary>
        /// <param name="fID">The food ID.</param>
        /// <param name="nID">The NutrientID.</param>
        /// <param name="vID">The version ID.</param>
        /// <param name="amount">The amount of nutrient.</param>
        /// <param name="per">The amount of unit.</param>
        /// <param name="unit">The unit.</param>
        public FoodNutrient(int fID, int nID, int vID, double amount, double per, IUnit unit)
            : base()
        {
            FID = fID;
            NID = nID;
            VID = vID;
            Amount = amount;
            Per = per;
            Unit = unit;
        }

        /// <summary>
        /// Constructor for a FoodNutrient entry.
        /// </summary>
        /// <param name="fID">The food ID.</param>
        /// <param name="nID">The NutrientID.</param>
        /// <param name="vID">The version ID.</param>
        /// <param name="amount">The amount of nutrient.</param>
        /// <param name="per">The amount of unit.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="container">The container.</param>
        public FoodNutrient(int fID, int nID, int vID, double amount, double per, IUnit unit, IContainer container)
            : base()
        {
            FID = fID;
            NID = nID;
            VID = vID;
            Amount = amount;
            Per = per;
            Unit = unit;

            if (container != null)
            {
                container.Add(this, $"FoodNutrient-{fID}-{nID}-{vID}");
            }
        }

        #region implementation of IFoodNutrient
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        public int FID { get; private set; }
        /// <summary>
        /// Gets the NutrientID.
        /// </summary>
        /// <value>The NutrientID.</value>
        public int NID { get; private set; }
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        public int VID { get; private set; }
        /// <summary>
        /// Gets the amount of nutrient.
        /// </summary>
        /// <value>The amount of nutrient.</value>
        public double Amount { get; private set; }
        /// <summary>
        /// Gets the amount of unit.
        /// </summary>
        /// <value>The amount of unit.</value>
        public double Per { get; private set; }
        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public IUnit Unit { get; private set; }
        #endregion
    }
}
