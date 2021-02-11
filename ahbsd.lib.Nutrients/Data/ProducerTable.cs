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
using System.Data.SqlTypes;
using ahbsd.lib.Nutrients.Producer;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// Class for a Table of Producer Data.
    /// </summary>
    public class ProducerTable : DataTable, IProducerTable
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public ProducerTable()
            : base("Producer")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The Container.</param>
        public ProducerTable(IContainer container)
            : base("Producer")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, TableName);
            }
        }


        private void Initialize()
        {
            DataColumn pID = new DataColumn("pID", typeof(int));
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn Address = new DataColumn("Address", typeof(string));
            DataColumn City = new DataColumn("City", typeof(string));
            DataColumn ZIP = new DataColumn("ZIP", typeof(string));
            DataColumn Country = new DataColumn("Country", typeof(string));
            DataColumn Website = new DataColumn("Website", typeof(string));

            BeginInit();

            Columns.Add(pID);
            Columns.Add(name);
            Columns.Add(Address);
            Columns.Add(City);
            Columns.Add(ZIP);
            Columns.Add(Country);
            Columns.Add(Website);


            Columns["pID"].AllowDBNull = false;
            Columns["pID"].AutoIncrement = true;
            Columns["pID"].Caption = "ID";

            Columns["name"].AllowDBNull = false;
            Columns["name"].Caption = "Producer Name";

            Columns["Address"].AllowDBNull = false;

            Columns["City"].AllowDBNull = false;

            Columns["ZIP"].AllowDBNull = true;
            Columns["ZIP"].DefaultValue = DBNull.Value;

            Columns["Country"].AllowDBNull = false;
            Columns["Country"].DefaultValue = "US";

            Columns["Website"].AllowDBNull = true;
            Columns["Website"].DefaultValue = DBNull.Value;

            EndInit();
        }

        #region implementation of IProducerTable
        /// <summary>
        /// Gets the Column producer.pID.
        /// </summary>
        /// <value>The Column producer.pID.</value>
        public DataColumn PID => Columns["pID"];
        /// <summary>
        /// Gets the Column producer.name.
        /// </summary>
        /// <value>The Column producer.name.</value>
        public DataColumn Name => Columns["name"];
        /// <summary>
        /// Gets the Column producer.Address.
        /// </summary>
        /// <value>The Column producer.Address.</value>
        public DataColumn Address => Columns["Address"];
        /// <summary>
        /// Gets the Column producer.City.
        /// </summary>
        /// <value>The Column producer.City.</value>
        public DataColumn City => Columns["City"];
        /// <summary>
        /// Gets the Column producer.ZIP.
        /// </summary>
        /// <value>The Column producer.ZIP.</value>
        public DataColumn ZIP => Columns["ZIP"];
        /// <summary>
        /// Gets the Column producer.Country.
        /// </summary>
        /// <value>The Column producer.Country.</value>
        public DataColumn Country => Columns["Country"];
        /// <summary>
        /// Gets the Column producer.Website.
        /// </summary>
        /// <value>The Column producer.Website.</value>
        public DataColumn Website => Columns["Website"];

        /// <summary>
        /// Gets the producer from rowID.
        /// </summary>
        /// <param name="rowID">The rowID.</param>
        /// <returns>The producer from rowID.</returns>
        /// <exception cref="Exception">If rowID doesn't exists.</exception>
        public IProducer GetProducer(int rowID)
        {
            IProducer result = null;
            int id;
            string name, address, city, zip, country, website;
            DataRow row;

            if (Rows.Count > rowID)
            {
                row = Rows[rowID];
                id = (int)row[PID];
                name = (string)row[Name];
                address = (string)row[Address];
                city = (string)row[City];
                zip = (string)row[ZIP];
                country = (string)row[Country];
                website = (string)row[Website];

                result = new Producer.Producer(id, name, address, city, zip, country, website, Container);
            }
            else
            {
                throw new Exception($"Row {rowID} doesn't exist; there are only {Rows.Count} rows.");
            }

            return result;
        }

        /// <summary>
        /// Gets a list of all producers from rows.
        /// </summary>
        /// <returns>A list of all producers from rows.</returns>
        public IList<IProducer> GetProducer()
        {
            IList<IProducer> result = new List<IProducer>(Rows.Count);
            int id;
            string name, address, city, zip, country, website;
            IProducer tmp;

            foreach (DataRow row in Rows)
            {
                id = (int)row[PID];
                name = (string)row[Name];
                address = (string)row[Address];
                city = (string)row[City];
                zip = (string)row[ZIP];
                country = (string)row[Country];
                website = (string)row[Website];

                tmp = new Producer.Producer(id, name, address, city, zip, country, website, Container);
                result.Add(tmp);
            }

            return result;
        }


        #endregion
    }
}
