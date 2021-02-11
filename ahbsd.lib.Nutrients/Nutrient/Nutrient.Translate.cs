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
using System.Globalization;
using System;
using ahbsd.lib;
using System.ComponentModel;
using ahbsd.lib.Nutrients.Measurement;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// A Class for Nutrient info.
    /// </summary>
    public partial class Nutrient
    {
        /// <summary>
        /// The format from the translation file.
        /// </summary>
        public const string TranslationFileFormat = "Nutrient/Nutrients_{0}.json";

        /// <summary>
        /// Gets the path from the translation file by the given culture.
        /// </summary>
        /// <param name="culture">The given culture.</param>
        /// <returns>The path from the translation file.</returns>
        public static string GetTranslationFilePath(CultureInfo culture)
        {
            return string.Format(TranslationFileFormat, culture.Name);
        }

        /// <summary>
        /// Gets the Translations for the nutriants to the given culture.
        /// </summary>
        /// <param name="culture">The given culture.</param>
        /// <returns>The Translations for the nutriants.</returns>
        public static INutrientTranslation GetNutrientTranslation(CultureInfo culture)
        {
            INutrientTranslation result = default;
            string path = GetTranslationFilePath(culture);
            string translationData = null;
            INutrients nutrients;

            FileInfo translationFileInfo = new FileInfo(path);

            if (translationFileInfo.Exists)
            {
                translationData = File.ReadAllText(path);
                nutrients = Nutrients.FromJson(translationData);

                result = nutrients.NutrientTranslation;
            }

            return result;
        }
    }
}