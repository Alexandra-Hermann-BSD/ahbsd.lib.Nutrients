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
using System.Collections.Generic;
using ahbsd.lib.Nutrients.Producer;

namespace ahbsd.lib.Nutrients.Nutrient
{
    public class FoodNutrients : Component, IFoodNutrients
    {

        private IFood _food;
        private IVersion _version;

        public FoodNutrients(IFood food, IVersion version)
            : base()
        {
            _food = food;
            _version = version;
            Initialize();
        }

        public FoodNutrients(IFood food, IVersion version, IContainer container)
            : base()
        {
            _food = food;
            _version = version;
            Initialize();

            if (container != null)
            {
                container.Add(this, $"{_food.Name}v{_version.VID}_{Nutrients.Count}Nutrients");
            }
        }

        private void Initialize()
        {
            Nutrients = new List<IFoodNutrient>();
        }

        #region implementation of IFoodNutrients
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public IVersion Version => _version;
        /// <summary>
        /// Gets the Food.
        /// </summary>
        /// <value>The Food.</value>
        public IFood Food => _food;
        /// <summary>
        /// Gets the producer.
        /// </summary>
        /// <value>The producer.</value>
        public IProducer Producer => lib.Nutrients.Producer.Producer.GetProducer((int)Food.ProducerID);
        /// <summary>
        /// Gets a List of Nutrients.
        /// </summary>
        /// <value>A List of Nutrients.</value>
        public IList<IFoodNutrient> Nutrients { get; private set; }

        public void AddNutrient(IFoodNutrient nutrient)
        {
            if (!Nutrients.Contains(nutrient))
            {
                Nutrients.Add(nutrient);
            }
            else
            {
                int pos = Nutrients.IndexOf(nutrient);

                Nutrients[pos] = nutrient;
            }
        }
        #endregion
    }
}
