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
namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface for food version.
    /// </summary>
    public interface IVersion : IComponent
    {
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        int VID { get; }
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        int FID { get; }
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        DateTime FirstDate { get; }
        /// <summary>
        /// Gets the food with the <see cref="FID"/>.
        /// </summary>
        /// <value>The food with the <see cref="FID"/>.</value>
        IFood Food { get; }
    }
}
