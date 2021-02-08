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
using ahbsd.lib.Exceptions;
namespace ahbsd.lib.Nutrients.Measurement
{
    /// <summary>
    /// Class for entries in the table Unit. 
    /// </summary>
    public struct Unit : IUnit
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
        /// <exception cref="Exception{string}">If trimmed length of name is greater than 5.</exception>
        public Unit(int uid, string name)
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
        #endregion
    }
}
