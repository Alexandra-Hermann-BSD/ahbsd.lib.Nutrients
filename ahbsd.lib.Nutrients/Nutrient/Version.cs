﻿//
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
namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Class for nutrisins versioning.
    /// </summary>
    public class Version : Component, IVersion
    {
        /// <summary>
        /// The version ID.
        /// </summary>
        private int vid;
        /// <summary>
        /// The food ID.
        /// </summary>
        private int fid;
        /// <summary>
        /// The food with the <see cref="FID"/>.
        /// </summary>
        private IFood food;
        /// <summary>
        /// The first Date this version was build.
        /// </summary>
        private DateTime firstdate;

        /// <summary>
        /// Constructor without container.
        /// </summary>
        /// <param name="vID">The version ID.</param>
        /// <param name="fID">The food ID.</param>
        /// <param name="f">[optional] The food with the <see cref="FID"/>.</param>
        /// <param name="firstDate">[optional] The first Date this version was build.</param>
        public Version(int vID, int fID, IFood f = null, DateTime? firstDate = null)
            : base()
        {
            vid = vID;
            fid = fID;

            if (firstDate == null)
            {
                firstdate = DateTime.Now;
            }
            else
            {
                firstdate = (DateTime)firstDate;
            }

            food = f;

            if (food != null)
            {
                fid = food.FID;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vID">The version ID.</param>
        /// <param name="fID">The food ID.</param>
        /// <param name="container">The container.</param>
        /// <param name="f">[optional] The food with the <see cref="FID"/>.</param>
        /// <param name="firstDate">[optional] The first Date this version was build.</param>
        public Version(int vID, int fID, IContainer container, IFood f = null, DateTime? firstDate = null)
            : base()
        {
            vid = vID;
            fid = fID;
            string tmp = "";

            if (firstDate == null)
            {
                firstdate = DateTime.Now;
            }
            else
            {
                firstdate = (DateTime)firstDate;
            }

            food = f;

            if (food != null)
            {
                fid = food.FID;
                tmp = $"Food \"{food.Name}\" [{fid}]";
            }
            else 
            {
                tmp = $"Food [{fid}]";
            }

            if (container != null)
            {
                container.Add(this, tmp);
            }
        }

        #region implementation of IVersion

        /// <summary>
        /// Gets the version ID.
        /// </summary>
        /// <value>The version ID.</value>
        public int VID => vid;
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        public int FID => fid;
        /// <summary>
        /// Gets the first Date this version was build.
        /// </summary>
        /// <value>The first Date this version was build.</value>
        public DateTime FirstDate => firstdate;
        /// <summary>
        /// Gets the food with the <see cref="FID"/>.
        /// </summary>
        /// <value>The food with the <see cref="FID"/>.</value>
        public IFood Food => food;
        #endregion
    }
}
