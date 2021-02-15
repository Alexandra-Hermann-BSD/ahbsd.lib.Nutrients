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
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Data.SQLite.Generic;
using System.IO;

namespace ahbsd.lib.Nutrients.Data.Creator
{
    /// <summary>
    /// A DataBase-Tool class.
    /// </summary>
    /// <remarks>
    /// If the database doesn't exists it creates a new one and fills it with
    /// the default nutrients.
    /// </remarks>
    public class DBTool : Container
    {
        /// <summary>
        /// The given DataBase name.
        /// </summary>
        private readonly string dbname;
        /// <summary>
        /// The connection string.
        /// </summary>
        protected string connectionString;

        /// <summary>
        /// The default DataBase name, if nothing is iven.
        /// </summary>
        public const string DefaultDBName = "nutrients";

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public DBTool()
            : base()
        {
            dbname = DefaultDBName;

            Initialize();
        }

        /// <summary>
        /// Constructor with a given DataBase name.
        /// </summary>
        /// <param name="dbName">The given DataBase name.</param>
        public DBTool(string dbName)
            : base()
        {
            dbname = dbName;

            Initialize();
        }

        private void Initialize()
        {
            SQLiteConnection connection;
            SQLiteDataAdapter nutrientDataAdapter;
            SQLiteDataAdapter unitDataAdapter;
            SQLiteDataAdapter producerDataAdapter;
            SQLiteDataAdapter foodDataAdapter;
            SQLiteDataAdapter foodnutrientDataAdapter;
            SQLiteDataAdapter versionDataAdapter;
            ExistingTables = new Dictionary<string, bool>(6);
            ExistingViews = new Dictionary<string, bool>(2);

            connectionString = string.Format(NutritionData.dataSourceFmt, dbname);
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

            _ = new NutrientsDataSet(this);

            // adding the components to Components…
            Add(connection, "Connection");
            Add(nutrientDataAdapter, "NutrientDataAdapter");
            Add(unitDataAdapter, "UnitDataAdapter");
            Add(producerDataAdapter, "ProducerDataAdapter");
            Add(foodDataAdapter, "FoodDataAdapter");
            Add(foodnutrientDataAdapter, "FoodnutrientDataAdapter");
            Add(versionDataAdapter, "VersionDataAdapter");

            ExistingTables.Add("food", false);
            ExistingTables.Add("foodnutrient", false);
            ExistingTables.Add("nutrient", false);
            ExistingTables.Add("producer", false);
            ExistingTables.Add("Unit", false);
            ExistingTables.Add("Version", false);

            ExistingViews.Add("viewFoodNutrients", false);
        }

        #region implement IDBTool
        /// <summary>
        /// Checks whether the data base and all it's tables exists or not.
        /// </summary>
        /// <returns>
        /// <c>true</c> if everything exist's, otherwise <c>false.</c>
        /// </returns>
        /// <remarks>
        /// If <c>false</c> is returned, additionally <see cref="ExistingTables"/>
        /// will show, which table's are missing.
        /// </remarks>
        public bool CheckExistance()
        {
            bool result = true;
            DataTable tmp;

            if (File.Exists($"Data/{dbname}.db"))
            {
                Connection.Open();

                foreach (KeyValuePair<string, bool> item in ExistingTables)
                {
                    try
                    {
                        tmp = (DataTable)Components[item.Key];
                    }
                    catch (Exception)
                    {
                        result &= false;
                    }

                    
                }

                Connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets the DataBase Name.
        /// </summary>
        /// <value>The DataBase Name.</value>
        public string DBName => dbname;
        /// <summary>
        /// Shows which tables already exist and which not.
        /// </summary>
        public IDictionary<string, bool> ExistingTables { get; private set; }
        /// <summary>
        /// Shows which views already exists and which not.
        /// </summary>
        public IDictionary<string, bool> ExistingViews { get; private set; }
        /// <summary>
        /// Gets the <see cref="SQLiteConnection"/>.
        /// </summary>
        /// <value>The SQLiteConnection.</value>
        public SQLiteConnection Connection
            => (SQLiteConnection)Components["Connection"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter NutrientDataAdapter
            => (SQLiteDataAdapter)Components["NutrientDataAdapter"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter UnitDataAdapter
            => (SQLiteDataAdapter)Components["UnitDataAdapter"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter ProducerDataAdapter
            => (SQLiteDataAdapter)Components["ProducerDataAdapter"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter FoodnutrientDataAdapter
            => (SQLiteDataAdapter)Components["FoodnutrientDataAdapter"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>. 
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter FoodDataAdapter
            => (SQLiteDataAdapter)Components["FoodDataAdapter"];

        /// <summary>
        /// Gets the <see cref="SQLiteDataAdapter"/>.
        /// </summary>
        /// <value>The SQLiteDataAdapter.</value>
        public SQLiteDataAdapter VersionDataAdapter
            => (SQLiteDataAdapter)Components["VersionDataAdapter"];

        /// <summary>
        /// Gets the <see cref="DataSet"/> DSNutrients.
        /// </summary>
        /// <value>The <see cref="DataSet"/> DSNutrients.</value>
        public DataSet DSNutrients => (DataSet)Components["DSNutrients"];

        #endregion
    }
}
