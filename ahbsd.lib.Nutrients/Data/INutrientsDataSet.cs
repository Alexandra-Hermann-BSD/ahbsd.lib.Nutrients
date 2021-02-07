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
using System.Data;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Interface for <see cref="NutrientsDataSet"/> or similar.
    /// </summary>
    public interface INutrientsDataSet
    {
        /// <summary>
        /// Gets the <see cref="DataTable"/> Nutrient.
        /// </summary>
        /// <value>The <see cref="DataTable"/> Nutrient.</value>
        DataTable Nutrient { get; }
        /// <summary>
        /// Gets the <see cref="DataTable"/> Unit.
        /// </summary>
        /// <value>The <see cref="DataTable"/> Unit.</value>
        DataTable Unit { get; }
    }
}