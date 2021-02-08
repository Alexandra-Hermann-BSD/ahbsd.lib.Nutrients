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
using System.ComponentModel;
using System.Data;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Defines the dataset for the database nutrients.
    /// </summary>
    public class NutrientsDataSet : DataSet, INutrientsDataSet
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public NutrientsDataSet()
            : base("DSNutrients")
        {
            InitiateDS();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The container.</param>
        public NutrientsDataSet(IContainer container)
            : base("DSNutrients")
        {
            InitiateDS();
            container.Add(this, "DSNutrients");
        }

        /// <summary>
        /// Initiates the dataset.
        /// </summary>
        private void InitiateDS()
        {
            // deinition of single objects
            NutrientTable Nutrient = new NutrientTable();
            UnitTable Unit = new UnitTable();

            BeginInit();
            Clear();

            Tables.Add(Nutrient);
            Tables.Add(Unit);

            EndInit();
        }

        #region implementation of INutrientsDataSet
        /// <summary>
        /// Gets the <see cref="NutrientTable"/> Nutrient.
        /// </summary>
        /// <value>The <see cref="NutrientTable"/> Nutrient.</value>
        public NutrientTable Nutrient => (NutrientTable)Tables["Nutrient"];
        /// <summary>
        /// Gets the <see cref="UnitTable"/> Unit.
        /// </summary>
        /// <value>The <see cref="UnitTable"/> Unit.</value>
        public UnitTable Unit => (UnitTable)Tables["Unit"];
        #endregion
    }
}
