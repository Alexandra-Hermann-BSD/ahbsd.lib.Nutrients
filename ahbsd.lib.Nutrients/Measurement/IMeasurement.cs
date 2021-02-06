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
namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// Interface for international default measurement of SI standard.
    /// </summary>
    public interface IMeasurement
    {
        /// <summary>
        /// Gets the name of the measurement.
        /// </summary>
        /// <value>The name of the measurement.</value>
        string Name { get; }
        /// <summary>
        /// Gets the short sign.
        /// </summary>
        /// <value>The short sign.</value>
        string ShortSign { get; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        double Value { get; set; }
    }
}
