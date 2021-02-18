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
using System.Collections.Generic;
using System.ComponentModel;
using ahbsd.lib.Nutrients.Producer;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface for Nutrients of a food.
    /// </summary>
    public interface IFoodNutrients : IComponent
    {
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        IVersion Version { get; }
        /// <summary>
        /// Gets the Food.
        /// </summary>
        /// <value>The Food.</value>
        IFood Food { get; }
        /// <summary>
        /// Gets the producer.
        /// </summary>
        /// <value>The producer.</value>
        IProducer Producer { get; }
        /// <summary>
        /// Gets a List of Nutrients.
        /// </summary>
        /// <value>A List of Nutrients.</value>
        IList<IFoodNutrient> Nutrients { get; }
    }
}
