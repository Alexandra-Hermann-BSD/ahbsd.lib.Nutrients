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
using System.Data.SQLite;
using ahbsd.lib.Nutrients.Producer;

namespace ahbsd.lib.Nutrients.Data
{
    /// <summary>
    /// An interface for the producer table.
    /// </summary>
    public interface IProducerTable
    {
        /// <summary>
        /// Gets the Column producer.pID.
        /// </summary>
        /// <value>The Column producer.pID.</value>
        DataColumn PID { get; }
        /// <summary>
        /// Gets the Column producer.name.
        /// </summary>
        /// <value>The Column producer.name.</value>
        DataColumn Name { get; }
        /// <summary>
        /// Gets the Column producer.Address.
        /// </summary>
        /// <value>The Column producer.Address.</value>
        DataColumn Address { get; }
        /// <summary>
        /// Gets the Column producer.City.
        /// </summary>
        /// <value>The Column producer.City.</value>
        DataColumn City { get; }
        /// <summary>
        /// Gets the Column producer.ZIP.
        /// </summary>
        /// <value>The Column producer.ZIP.</value>
        DataColumn ZIP { get; }
        /// <summary>
        /// Gets the Column producer.Country.
        /// </summary>
        /// <value>The Column producer.Country.</value>
        DataColumn Country { get; }
        /// <summary>
        /// Gets the Column producer.Website.
        /// </summary>
        /// <value>The Column producer.Website.</value>
        DataColumn Website { get; }

        /// <summary>
        /// Gets the producer from rowID.
        /// </summary>
        /// <param name="rowID">The rowID.</param>
        /// <returns>The producer from rowID.</returns>
        /// <exception cref="Exception">If rowID doesn't exists.</exception>
        IProducer GetProducer(int rowID);
        /// <summary>
        /// Gets a list of all producers from rows.
        /// </summary>
        /// <returns>A list of all producers from rows.</returns>
        IList<IProducer> GetProducer();
        /// <summary>
        /// Inserts a producer to the database.
        /// </summary>
        /// <param name="producer">The producerto insert.</param>
        /// <param name="connection">The Connection.</param>
        /// <returns><c>true</c> if </returns>
        bool Insert(IProducer producer, SQLiteConnection connection);
    }
}