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
using System.Data;
using System.Data.SQLite;

namespace ahbsd.lib.Nutrients.Data
{
    public partial class NutritionData : INutritionData
    {

        #region implementation of INutritionData
        /// <summary>
        /// Happenes if the <see cref="ConnectionString"/> has changes.
        /// </summary>
        public event ChangeEventHandler<string> OnConnectionChanged;

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

        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        /// <value>The ConnectionString.</value>
        public string ConnectionString
        {
            get => connectionString;
            set
            {
                bool wasConnected = false;

                if (!string.IsNullOrEmpty(value)
                    && !value.Equals(connectionString))
                {
                    ChangeEventArgs<string> cea
                        = new ChangeEventArgs<string>(connectionString, value);

                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                        wasConnected = true;
                    }

                    connectionString = value;
                    Connection.ConnectionString = connectionString;

                    OnConnectionChanged?.Invoke(this, cea);

                    if (wasConnected)
                    {
                        try
                        {
                            Connection.Open();
                        }
                        catch (Exception)
                        { }
                    }
                }
            }
        }

        /// <summary>
        /// Fills the Dataset with nutrients.Unit data
        /// </summary>
        /// <returns>The amount of Rows.</returns>
        public int FillUnits()
        {
            return UnitDataAdapter.Fill(DSNutrients, "Unit");
        }

        /// <summary>
        /// Fills the DataSet with nutrients.nutrient data.
        /// </summary>
        /// <returns>The amount of Rows.</returns>
        public int FillNutrients()
        {
            return NutrientDataAdapter.Fill(DSNutrients, "Nutrient");
        }

        /// <summary>
        /// Fills the DataSet with nutrients.Producer data.
        /// </summary>
        /// <returns>The Amount of Rows.</returns>
        public int FillProducer()
        {
            return ProducerDataAdapter.Fill(DSNutrients, "Producer");
        }

        /// <summary>
        /// Fills the DataSet with nutrients.food data.
        /// </summary>
        /// <returns>The Amount of Rows.</returns>
        public int FillFood()
        {
            return FoodDataAdapter.Fill(DSNutrients, "food");
        }

        /// <summary>
        /// Fills the DataSet with nutrients.food data.
        /// </summary>
        /// <returns>The Amount of Rows.</returns>
        public int FillVersion()
        {
            return VersionDataAdapter.Fill(DSNutrients, "Version");
        }

        /// <summary>
        /// Fills the Dataset with all data.
        /// </summary>
        /// <returns>The amount of all Rows.</returns>
        public int FillAll()
        {
            int result = 0;

            result += FillUnits();
            result += FillNutrients();
            result += FillProducer();
            result += FillFood();
            result += FillVersion();

            return result;
        }

        #endregion


        /// <summary>
        /// Creates a DataSource.
        /// </summary>
        /// <param name="dbName">The name of the database.</param>
        /// <returns>The created DataSource.</returns>
        public static string CreateDataSource(string dbName)
        {
            SQLiteConnectionStringBuilder sb
                = new SQLiteConnectionStringBuilder(
                    string.Format(dataSourceFmt, dbName)
                  )
                {
                    JournalMode = SQLiteJournalModeEnum.Default,
                    SyncMode = SynchronizationModes.Full
                };

            return sb.ToString();
        }
    }
}