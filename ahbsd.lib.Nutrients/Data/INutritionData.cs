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
using System.Data;
using System.Data.SQLite;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// An interface to work with the data for Nutrition.
    /// </summary>
    public interface INutritionData : IContainer
    {
        /// <summary>
        /// Gets the <see cref="SQLiteConnection"/>.
        /// </summary>
        /// <value>The SQLiteConnection.</value>
        SQLiteConnection Connection { get; }
        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        SQLiteDataAdapter NutrientDataAdapter { get; }
        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        SQLiteDataAdapter UnitDataAdapter { get; }
        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        SQLiteDataAdapter ProducerDataAdapter { get; }
        /// <summary>
        /// Gets the <see cref="DataSet"/> DSNutrients.
        /// </summary>
        /// <value>The <see cref="DataSet"/> DSNutrients.</value>
        DataSet DSNutrients { get; }
        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        /// <value>The ConnectionString.</value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Happenes if the <see cref="ConnectionString"/> has changes.
        /// </summary>
        event ChangeEventHandler<string> OnConnectionChanged;

        /// <summary>
        /// Fills the DataSet with nutrients.nutrient data.
        /// </summary>
        /// <returns>The amount of Rows.</returns>
        int FillNutrients();
        /// <summary>
        /// Fills the Dataset with nutrients.Unit data
        /// </summary>
        /// <returns>The amount of Rows.</returns>
        int FillUnits();
        /// <summary>
        /// Fills the DataSet with nutrients.Producer data.
        /// </summary>
        /// <returns>The Amount of Rows.</returns>
        int FillProducer();
        /// <summary>
        /// Fills the Dataset with all data.
        /// </summary>
        /// <returns>The amount of all Rows.</returns>
        int FillAll();
    }
}