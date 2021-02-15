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
using System.Text;
using ahbsd.lib.Nutrients.Producer;

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
        protected internal const string dataSourceFmt = "Data Source=Data/{0}.db";

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
            SQLiteDataAdapter foodnutrientDataAdapter;
            SQLiteDataAdapter versionDataAdapter;
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
            foodnutrientDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM foodnutrient;",
                connection);
            versionDataAdapter
                = new SQLiteDataAdapter("SELECT * FROM Version;",
                connection);

            dsNutrient = new NutrientsDataSet(this);

            // adding the components to Components…
            Add(connection, "Connection");
            Add(nutrientDataAdapter, "NutrientDataAdapter");
            Add(unitDataAdapter, "UnitDataAdapter");
            Add(producerDataAdapter, "ProducerDataAdapter");
            Add(foodDataAdapter, "FoodDataAdapter");
            Add(foodnutrientDataAdapter, "FoodnutrientDataAdapter");
            Add(versionDataAdapter, "VersionDataAdapter");

            ProducerDataAdapter.InsertCommand = GetProducerInsert();

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
            FoodnutrientDataAdapter.FillError += DataAdapter_FillError;
            FoodnutrientDataAdapter.RowUpdated += DataAdapter_RowUpdated;
            VersionDataAdapter.FillError += DataAdapter_FillError;
            VersionDataAdapter.RowUpdated += DataAdapter_RowUpdated;

        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
        }

        private void DataAdapter_RowUpdated(object sender, RowUpdatedEventArgs e)
        {
#if DEBUG
            Console.WriteLine($"RowUpdated from '{sender}': {e.Status}");
#endif
        }

        private void DataAdapter_FillError(object sender, FillErrorEventArgs e)
        {
#if DEBUG
            Console.WriteLine($"FillError from '{sender}' / {e.DataTable.TableName}:\n" +
                $"{e.Errors.GetType()}\nMessage: {e.Errors.Message}");
#endif
        }

        /// <summary>
        /// Create a <see cref="SQLiteCommand"/> to insert a producer.
        /// </summary>
        /// <returns>The created <see cref="SQLiteCommand"/>.</returns>
        protected SQLiteCommand GetProducerInsert()
        {
            SQLiteCommand result = new SQLiteCommand(Connection);

            result.Parameters.Add("$name", DbType.String);
            result.Parameters["$name"].SourceColumn = "name";
            result.Parameters["$name"].IsNullable = false;
            result.Parameters.Add("$Address", DbType.String);
            result.Parameters["$Address"].SourceColumn = "Address";
            result.Parameters["$Address"].IsNullable = false;
            result.Parameters.Add("$City", DbType.String);
            result.Parameters["$City"].SourceColumn = "City";
            result.Parameters["$City"].IsNullable = false;
            result.Parameters.Add("$ZIP", DbType.String);
            result.Parameters["$ZIP"].SourceColumn = "ZIP";
            result.Parameters["$ZIP"].IsNullable = true;
            result.Parameters.Add("$Country", DbType.String, 3);
            result.Parameters["$Country"].SourceColumn = "Country";
            result.Parameters["$Country"].IsNullable = false;
            result.Parameters.Add("$Website", DbType.String);
            result.Parameters["$Website"].SourceColumn = "Website";
            result.Parameters["$Website"].IsNullable = true;

            result.CommandText = "INSERT INTO producer " +
                "(name, Address, City, ZIP, Country, Website) " +
                "VALUES($name, $Address, $City, $ZIP, $Country, $Website);";


            return result;
        }

        /// <summary>
        /// Create a <see cref="SQLiteCommand"/> to insert a given producer.
        /// </summary>
        /// <param name="producer">The given producer.</param>
        /// <returns>The created <see cref="SQLiteCommand"/>.</returns>
        public SQLiteCommand GetProducerInsert(IProducer producer)
        {
            SQLiteCommand result = new SQLiteCommand(Connection);

            StringBuilder[] builders = new StringBuilder[2];
            builders[0] = new StringBuilder("INSERT INTO producer (");
            builders[1] = new StringBuilder("VALUES(");

            builders[0].Append("name, ");
            builders[1].AppendFormat("'{0}', ", producer.Name);
            builders[0].Append("Address, ");
            builders[1].AppendFormat("'{0}', ", producer.Address);
            builders[0].Append("City, ");
            builders[1].AppendFormat("'{0}', ", producer.City);

            if (!string.IsNullOrEmpty(producer.ZIP))
            {
                builders[0].Append("ZIP, ");
                builders[1].AppendFormat("'{0}', ", producer.ZIP);
            }

            builders[0].Append("Country");
            builders[1].AppendFormat("'{0}'", producer.Country);

            if (producer.Website != null)
            {
                builders[0].Append(", Website");
                builders[1].AppendFormat(", '{0}'", producer.Website.AbsolutePath);
            }

            builders[0].Append(") ");
            builders[1].Append(");");

            result.CommandText = builders[0].ToString() + builders[1].ToString();

            result.Prepare();

            ProducerDataAdapter.InsertCommand = result;
            return result;
        }

    }
}
