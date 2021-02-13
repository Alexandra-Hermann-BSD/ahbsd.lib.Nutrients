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
using System.ComponentModel;
using System.Globalization;

namespace ahbsd.lib.Nutrients.Nutrient
{
    public class Food : Component, IFood
    {
        //*
        public Food(
            int fid,
            string name,
            string defLng,
            int? pID = null,
            ulong? barcode = null)
            : base()
        {
            FID = fid;
            Name = name.Trim();
            DefaultLanguage = defLng.Trim();
            ProducerID = pID;
            Barcode = barcode;
        } // */

        public Food(
            int fid,
            string name,
            string defLng,
            IContainer container,
            int? pID = null,
            ulong? barcode = null)
            : base()
        {
            FID = fid;
            Name = name.Trim();
            DefaultLanguage = defLng.Trim();
            ProducerID = pID;
            Barcode = barcode;

            if (container != null)
            {
                container.Add(this, $"food[{fid}]");
            }
        }

        #region implementation of IFood
        /// <summary>
        /// Gets the food ID.
        /// </summary>
        /// <value>The food ID.</value>
        public int FID { get; private set; }
        /// <summary>
        /// Gets the food name.
        /// </summary>
        /// <value>The food name.</value>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the default language for this food.
        /// </summary>
        /// <value>The default language.</value>
        /// <remarks>
        /// The same as <see cref="CultureInfo.TwoLetterISOLanguageName"/>.
        /// </remarks>
        public string DefaultLanguage { get; private set; }
        /// <summary>
        /// Gets the ProducerID.
        /// </summary>
        /// <value>The ProducerID.</value>
        /// <remarks><see cref="Producer.IProducer.ID"/></remarks>
        public int? ProducerID { get; private set; }
        /// <summary>
        /// Gets the Barcode.
        /// </summary>
        /// <value>The Barcode.</value>
        public ulong? Barcode { get; private set; }
        #endregion

        /// <summary>
        /// Gets he language from a <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="cultureInfo">The CultureInfo.</param>
        /// <returns>The language from the CultureInfo.</returns>
        public static string GetLanguage(CultureInfo cultureInfo)
            => cultureInfo.TwoLetterISOLanguageName;
    }
}
