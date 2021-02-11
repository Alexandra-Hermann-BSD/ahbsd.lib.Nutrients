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
using System.ComponentModel;
using System.Globalization;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface for food.
    /// </summary>
    public interface IFood : IComponent
    {
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        int FID { get; }
        /// <summary>
        /// Gets the food name.
        /// </summary>
        /// <value>The food name.</value>
        string Name { get; }
        /// <summary>
        /// Gets the default language for this food.
        /// </summary>
        /// <value>The default language.</value>
        /// <remarks>
        /// The same as <see cref="CultureInfo.TwoLetterISOLanguageName"/>.
        /// </remarks>
        string DefaultLanguage { get; }
        /// <summary>
        /// Gets the ProducerID.
        /// </summary>
        /// <value>The ProducerID.</value>
        /// <remarks><see cref="Producer.IProducer.ID"/></remarks>
        int? ProducerID { get; }
        /// <summary>
        /// Gets the Barcode.
        /// </summary>
        /// <value>The Barcode.</value>
        int? Barcode { get; }

    }
}
