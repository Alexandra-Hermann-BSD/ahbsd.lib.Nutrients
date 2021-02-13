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
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Data.SQLite.Generic;
using System.Linq;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// A class to work with the data for Nutrition.
    /// </summary>
    public partial class NutritionData : Container
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// The default DataSource.
        /// </summary>
        public readonly string DataSource;

        /// <summary>
        /// The default format for data-sources.
        /// </summary>
        protected const string dataSourceFmt = "Data Source=Data/{0}.db";

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public NutritionData()
            : base()
        {
            connectionString = CreateDataSource("nutrients");
            DataSource = connectionString;
            Initialize();
        }

        /// <summary>
        /// Constructor with a database name.
        /// </summary>
        /// <param name="database">The database name.</param>
        public NutritionData(string database)
            : base()
        {
            connectionString = CreateDataSource(database);
            DataSource = connectionString;
            Initialize();
        }

        /// <summary>
        /// Initialize the object.
        /// </summary>
        private void Initialize()
        {
            SQLiteConnection connection;
            SQLiteDataAdapter nutrientDataAdapter;
            SQLiteDataAdapter unitDataAdapter;
            SQLiteDataAdapter producerDataAdapter;
            SQLiteDataAdapter foodDataAdapter;
            NutrientsDataSet dsNutrient;

            // creating the database parts.
            connection = new SQLiteConnection(connectionString, true);

            nutrientDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM nutrient;",
                connection);
            unitDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM Unit;",
                connection);
            producerDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM Producer;",
                connection);
            foodDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM food;",
                connection);

            dsNutrient = new NutrientsDataSet(this);

            // adding the components to Components…
            Add(connection, "Connection");
            Add(nutrientDataAdapter, "NutrientDataAdapter");
            Add(unitDataAdapter, "UnitDataAdapter");
            Add(producerDataAdapter, "ProducerDataAdapter");
            Add(foodDataAdapter, "FoodDataAdapter");

            // adding event handlers
            Connection.StateChange += Connection_StateChange;
            NutrientDataAdapter.FillError += DataAdapter_FillError;
            NutrientDataAdapter.RowUpdated += DataAdapter_RowUpdated;
            UnitDataAdapter.FillError += DataAdapter_FillError;
            UnitDataAdapter.RowUpdated += DataAdapter_RowUpdated;
            ProducerDataAdapter.FillError += DataAdapter_FillError;
            ProducerDataAdapter.RowUpdated += DataAdapter_RowUpdated;
            FoodDataAdapter.FillError += DataAdapter_FillError;
            FoodDataAdapter.RowUpdated += DataAdapter_RowUpdated;

        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
        }

        private void DataAdapter_RowUpdated(object sender, RowUpdatedEventArgs e)
        {
        }

        private void DataAdapter_FillError(object sender, FillErrorEventArgs e)
        {
        }

    }
}
