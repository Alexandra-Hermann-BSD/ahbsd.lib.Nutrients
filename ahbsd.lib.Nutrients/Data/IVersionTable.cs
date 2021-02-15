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
using System.Collections.Generic;
using System.Data;
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// An interface for a version table.
    /// </summary>
    public interface IVersionTable
    {
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        DataColumn VID { get; }
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        DataColumn FID { get; }
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        DataColumn FirstDate { get; }
        /// <summary>
        /// Gets the version from row number rowID.
        /// </summary>
        /// <param name="rowID">The given row id.</param>
        /// <returns>The version from rowID.</returns>
        /// <exception cref="Exception">If the rowID doesn't exists.</exception>
        IVersion GetVersion(int rowID);
        /// <summary>
        /// Gets a list from all versions from the rows.
        /// </summary>
        /// <returns>A list from all versions from the rows.</returns>
        IList<IVersion> GetVersions();
    }
}
