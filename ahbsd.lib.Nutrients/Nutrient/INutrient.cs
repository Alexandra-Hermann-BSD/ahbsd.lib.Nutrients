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
using System.Globalization;
using ahbsd.lib.Nutrients.Measurement;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface for the main info of a nutrient itselfs.
    /// </summary>
    /// <remarks>
    /// The default measurements are in SI, for optional measurements the
    /// formulas must be defined in other classes.
    /// <seealso cref="ahbsd.lib.Nutrients.Measurement"/>.
    /// The default names are international as well.
    /// </remarks>
    public interface INutrient
    {
        /// <summary>
        /// Gets the name of the nutrient.
        /// </summary>
        /// <value>The name of the nutrient.</value>
        string Name { get; }
        /// <summary>
        /// Gets the display name of the nutrient.
        /// </summary>
        /// <value>The display name of the nutrient.</value>
        string DisplayName { get; set; }
        /// <summary>
        /// Gets the Measurement.
        /// </summary>
        /// <value>The Measurement.</value>
        IMeasurement Measurement { get; }
        /// <summary>
        /// Gets the optional measurement - if available.
        /// </summary>
        /// <value>The optional measurement.</value>
        IMeasurementOptional OptionalMeasurement { get; }
        /// <summary>
        /// Gets the current culture.
        /// </summary>
        /// <value>The current culture.</value>
        CultureInfo CurrentCulture { get; }
    }
}
