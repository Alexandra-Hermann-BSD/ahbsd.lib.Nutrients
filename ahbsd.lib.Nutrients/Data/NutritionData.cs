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
using System.Data.SQLite.Linq;
using System.Linq;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// A class to work with the data for Nutrition.
    /// </summary>
    public class NutritionData : Container
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public NutritionData()
            : base()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize the object.
        /// </summary>
        private void Initialize()
        {
            // creating the database parts.
            SQLiteConnection connection = new SQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();



            // adding the components to Components…
            Add(connection, "Connection");
            Add(dataAdapter, "DataAdapter");

            // adding event handlers
            Connection.StateChange += Connection_StateChange;
            DataAdapter.FillError += DataAdapter_FillError;
            DataAdapter.RowUpdated += DataAdapter_RowUpdated;
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
        public SQLiteDataAdapter DataAdapter
            => (SQLiteDataAdapter)Components["DataAdapter"];

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

                if (string.IsNullOrEmpty(value) && !value.Equals(connectionString))
                {
                    ChangeEventArgs<string> cea = new ChangeEventArgs<string>(connectionString, value);

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
    }
}
