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
using ahbsd.lib.Exceptions;
using System.ComponentModel;

namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// Class for entries in the table Unit. 
    /// </summary>
    public class Unit : Component, IUnit
    {
        /// <summary>
        /// The UnitID.
        /// </summary>
        private readonly int uID;
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string uName;

        /// <summary>
        /// Constructor with a given ID and name.
        /// </summary>
        /// <param name="uid">The given ID.</param>
        /// <param name="name">The given name.</param>
        /// <exception cref="Exception{T}">If trimmed length of name is greater than 5.</exception>
        public Unit(int uid, string name)
            : base()
        {
            Exception<string> ex;
            uID = uid;

            if (name.Trim().Length <= 5)
            {
                uName = name.Trim(); ;
            }
            else
            {
                ex = new Exception<string>($"Max size for name is 5, but {name.Trim()} is longer: {name.Trim().Length} > 5!", name.Trim());
                throw ex;
            }

            Value = 0.0;
        }

        /// <summary>
        /// Constructor with a given ID, name and container.
        /// </summary>
        /// <param name="uid">The given ID.</param>
        /// <param name="name">The given name.</param>
        /// <param name="container">The container.</param>
        /// <exception cref="Exception{T}">If trimmed length of name is greater than 5.</exception>
        public Unit(int uid, string name, IContainer container)
            : base()
        {
            Exception<string> ex;
            uID = uid;

            if (name.Trim().Length <= 5)
            {
                uName = name.Trim(); ;
            }
            else
            {
                ex = new Exception<string>($"Max size for name is 5, but {name.Trim()} is longer: {name.Trim().Length} > 5!", name.Trim());
                throw ex;
            }

            Value = 0.0;

            if (container != null)
            {
                container.Add(this, Name);
            }
        }

        #region implementation of IUnit
        /// <summary>
        /// Gets the UnitID.
        /// </summary>
        /// <value>The UnitID.</value>
        public int UID => uID;
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => uName;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; set; }
        #endregion

        /// <summary>
        /// Returns the Unit (without it's number.
        /// </summary>
        /// <returns>The Unit.</returns>
        public override string ToString() => Name;
    }
}
