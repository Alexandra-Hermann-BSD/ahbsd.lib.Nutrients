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
using ahbsd.lib.Nutrients.Nutrient;

namespace ahbsd.lib.Nutrients.Data
{
    public class FoodTable : DataTable, IFoodTable
    {
        public FoodTable()
            : base("food")
        {
            Initialize();
        }

        public FoodTable(IContainer container)
            : base("food")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, TableName);
            }
        }

        private void Initialize()
        {
            DataColumn FID = new DataColumn("fID", typeof(int));
            DataColumn Name = new DataColumn("name", typeof(string));
            DataColumn DefaultLanguage = new DataColumn("defaultLanguage", typeof(string));
            DataColumn ProducerID = new DataColumn("producerID", typeof(int));
            DataColumn Barcode = new DataColumn("barcode", typeof(ulong));

            BeginInit();
            FID.AllowDBNull = false;
            FID.AutoIncrement = true;
            FID.Caption = "ID";

            Name.AllowDBNull = false;
            Name.Caption = "Name";

            DefaultLanguage.Caption = "Language";
            DefaultLanguage.AllowDBNull = false;
            DefaultLanguage.MaxLength = 3;

            ProducerID.Caption = "Producer ID";
            ProducerID.AllowDBNull = true;
            ProducerID.DefaultValue = DBNull.Value;

            Barcode.Caption = "Barcode";
            Barcode.AllowDBNull = true;
            Barcode.DefaultValue = DBNull.Value;

            Columns.Add(FID);
            Columns.Add(Name);
            Columns.Add(DefaultLanguage);
            Columns.Add(ProducerID);
            Columns.Add(Barcode);
            EndInit();
        }

        #region implementation of IFoodTable
        /// <summary>
        /// Gets the Food-ID.
        /// </summary>
        /// <value>The Food-ID.</value>
        public DataColumn FID => Columns["fID"];
        /// <summary>
        /// Gets the name of the food.
        /// </summary>
        /// <value>The name of the food.</value>
        public DataColumn Name => Columns["name"];
        /// <summary>
        /// Gets the default language of this food.
        /// </summary>
        /// <value>The default language of this food.</value>
        public DataColumn DefaultLanguage => Columns["defaultLanguage"];
        /// <summary>
        /// Gets the producer-id <see cref="IProducerTable.PID"/> of this food.
        /// </summary>
        /// <value>The producer-id of this food.</value>
        public DataColumn ProducerID => Columns["producerID"];
        /// <summary>
        /// Gets the Barcode of this Food.
        /// </summary>
        /// <value>The Barcode of this Food.</value>
        public DataColumn Barcode => Columns["barcode"];
        /// <summary>
        /// Gets the food from the given DataRow.
        /// </summary>
        /// <param name="dataRow">The given DataRow.</param>
        /// <returns>The food from the given DataRow.</returns>
        /// <exception cref="Exception">If the given DataRow doesn't exists.</exception>
        public IFood GetFood(int dataRow)
        {
            IFood result = null;
            int fid;
            int? producerID;
            ulong? barcode;
            string name, defaultLng;
            DataRow row;

            if (Rows.Count > dataRow)
            {
                row = Rows[dataRow];
                fid = (int)row[FID];
                name = (string)row[Name];
                defaultLng = (string)row[DefaultLanguage];

                if (row[ProducerID].Equals(DBNull.Value))
                {
                    producerID = null;
                }
                else
                {
                    producerID = (int)row[ProducerID];
                }

                if (row[Barcode].Equals(DBNull.Value))
                {
                    barcode = null;
                }
                else
                {
                    barcode = (ulong)row[Barcode];
                }

                result = new Food(fid, name, defaultLng, Container, producerID, barcode);
            }

            return result;
        }
        /// <summary>
        /// Gets a list with all foods from the rows.
        /// </summary>
        /// <returns>A list with all foods.</returns>
        public IList<IFood> GetFoods()
        {
            IList<IFood> result = new List<IFood>(Rows.Count);
            int fid;
            int? producerID;
            ulong? barcode;
            string name, defaultLng;
            IFood tmpFood;

            foreach (DataRow row in Rows)
            {
                fid = (int)row[FID];
                name = (string)row[Name];
                defaultLng = (string)row[DefaultLanguage];

                if (row[ProducerID].Equals(DBNull.Value))
                {
                    producerID = null;
                }
                else
                {
                    producerID = (int)row[ProducerID];
                }

                if (row[Barcode].Equals(DBNull.Value))
                {
                    barcode = null;
                }
                else
                {
                    barcode = (ulong)row[Barcode];
                }

                tmpFood = new Food(fid, name, defaultLng, Container, producerID, barcode);
                result.Add(tmpFood);
            }


            return result;
        }
        #endregion
    }
}
