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
    /// <summary>
    /// Class for a version table.
    /// </summary>
    public class VersionTable : DataTable, IVersionTable
    {
        /// <summary>
        /// Constructor without any parameters.
        /// </summary>
        public VersionTable()
            : base("Version")
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with a container.
        /// </summary>
        /// <param name="container">The container.</param>
        public VersionTable(IContainer container)
            : base("Version")
        {
            Initialize();

            if (container != null)
            {
                container.Add(this, TableName);
            }
        }

        /// <summary>
        /// Initializes this object.
        /// </summary>
        private void Initialize()
        {
            DataColumn vID = new DataColumn("vID", typeof(int));
            DataColumn fID = new DataColumn("fID", typeof(int));
            DataColumn firstDate = new DataColumn("firstDate", typeof(DateTime));

            vID.AllowDBNull = false;
            vID.Caption = "ID";
            vID.AutoIncrement = true;

            fID.AllowDBNull = false;
            fID.Caption = "Food ID";

            firstDate.AllowDBNull = false;
            firstDate.Caption = "First Date";

            Columns.Add(vID);
            Columns.Add(fID);
            Columns.Add(firstDate);
        }

        #region implementation of IVersionTable
        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        public DataColumn VID => Columns["vID"];
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        public DataColumn FID => Columns["fID"];
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        public DataColumn FirstDate => Columns["firstDate"];

        /// <summary>
        /// Gets the version from row number rowID.
        /// </summary>
        /// <param name="rowID">The given row id.</param>
        /// <returns>The version from rowID.</returns>
        /// <exception cref="Exception">If the rowID doesn't exists.</exception>
        public IVersion GetVersion(int rowID)
        {
            int vid, fid;
            DateTime firstdate;
            DataRow row;

            IVersion result;
            if (Rows.Count > rowID)
            {
                row = Rows[rowID];
                vid = (int)row[VID];
                fid = (int)row[FID];
                firstdate = (DateTime)row[FirstDate];

                result = new Nutrient.Version(vid, fid, Container, null, firstdate);
            }
            else
            {
                throw new Exception($"RowID {rowID} doesn't exist; max row is {Rows.Count - 1}…");
            }

            return result;
        }

        /// <summary>
        /// Gets a list from all versions from the rows.
        /// </summary>
        /// <returns>A list from all versions from the rows.</returns>
        public IList<IVersion> GetVersions()
        {
            IList<IVersion> result = new List<IVersion>(Rows.Count);
            int vid, fid;
            DateTime firstdate;
            IVersion tmp;

            foreach (DataRow row in Rows)
            {
                vid = (int)row[VID];
                fid = (int)row[FID];
                firstdate = (DateTime)row[FirstDate];

                tmp = new Nutrient.Version(vid, fid, Container, null, firstdate);
                result.Add(tmp);
            }

            return result;
        }
        #endregion
    }
}
