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
            if (container != null)
            {
                container.Add(this, "DSNutrients");
            }

            InitiateDS();

        }

        /// <summary>
        /// Initiates the dataset.
        /// </summary>
        private void InitiateDS()
        {
            // deinition of single objects
            NutrientTable Nutrient = new NutrientTable(Container);
            UnitTable Unit = new UnitTable(Container);
            ProducerTable Producer = new ProducerTable(Container);
            FoodTable Food = new FoodTable(Container);
            FoodNutrientTable FoodNutrient = new FoodNutrientTable(Container);
            VersionTable Version = new VersionTable(Container);

            BeginInit();
            Clear();

            Tables.Add(Nutrient);
            Tables.Add(Unit);
            Tables.Add(Producer);
            Tables.Add(Food);
            Tables.Add(FoodNutrient);
            Tables.Add(Version);

            DataRelation foodProducer = new DataRelation("fk_food_producer", Producer.PID, Food.ProducerID);
            DataRelation versionFood = new DataRelation("fk_version_food", Food.FID, Version.FID);

            Relations.Add(foodProducer);
            Relations.Add(versionFood);

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
        /// <summary>
        /// Gets the <see cref="ProducerTable"/> Producer.
        /// </summary>
        /// <value>The <see cref="ProducerTable"/> Producer.</value>
        public ProducerTable Producer => (ProducerTable)Tables["Producer"];
        /// <summary>
        /// Gets the <see cref="FoodTable"/> Food.
        /// </summary>
        /// <value>The <see cref="FoodTable"/> Food.</value>
        public FoodTable Food => (FoodTable)Tables["food"];
        /// <summary>
        /// Gets the <see cref="FoodTable"/> Food.
        /// </summary>
        /// <value>The <see cref="FoodTable"/> Food.</value>
        public FoodNutrientTable FoodNutrient => (FoodNutrientTable)Tables["foodnutrient"];
        /// <summary>
        /// Gets the <see cref="VersionTable"/> Version.
        /// </summary>
        /// <value>The <see cref="VersionTable"/> Version.</value>
        public VersionTable Version => (VersionTable)Tables["Version"];
        #endregion
    }
}
