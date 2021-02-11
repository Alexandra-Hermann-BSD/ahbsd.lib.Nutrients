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
using Newtonsoft.Json;

namespace ahbsd.lib.Nutrients.Nutrient
{
    /// <summary>
    /// Interface for nutrient translation.
    /// </summary>
    public interface INutrientTranslation
    {
        /// <summary>
        /// Gets or sets the translation of Biotin.
        /// </summary>
        /// <value>The translation of Biotin.</value>
        [JsonProperty("Biotin")]
        string Biotin { get; set; }

        /// <summary>
        /// Gets or sets the translation of Caffeine.
        /// </summary>
        /// <value>The translation of Caffeine.</value>
        [JsonProperty("Caffeine")]
        string Caffeine { get; set; }

        /// <summary>
        /// Gets or sets the translation of Calcium.
        /// </summary>
        /// <value>The translation of Calcium.</value>
        [JsonProperty("Calcium")]
        string Calcium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Carbohydrates.
        /// </summary>
        /// <value>The translation of Carbohydrates.</value>
        [JsonProperty("Carbohydrates")]
        string Carbohydrates { get; set; }

        /// <summary>
        /// Gets or sets the translation of Chloride.
        /// </summary>
        /// <value>The translation of Chloride.</value>
        [JsonProperty("Chloride")]
        string Chloride { get; set; }

        /// <summary>
        /// Gets or sets the translation of Cholesterol.
        /// </summary>
        /// <value>The translation of Cholesterol.</value>
        [JsonProperty("Cholesterol")]
        string Cholesterol { get; set; }

        /// <summary>
        /// Gets or sets the translation of Chromium.
        /// </summary>
        /// <value>The translation of Chromium.</value>
        [JsonProperty("Chromium")]
        string Chromium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Copper.
        /// </summary>
        /// <value>The translation of Copper.</value>
        [JsonProperty("Copper")]
        string Copper { get; set; }

        /// <summary>
        /// Gets or sets the translation of FatMonosaturated.
        /// </summary>
        /// <value>The translation of FatMonosaturated.</value>
        [JsonProperty("FatMonosaturated")]
        string FatMonosaturated { get; set; }

        /// <summary>
        /// Gets or sets the translation of FatPolysaturated.
        /// </summary>
        /// <value>The translation of FatPolysaturated.</value>
        [JsonProperty("FatPolysaturated")]
        string FatPolysaturated { get; set; }

        /// <summary>
        /// Gets or sets the translation of FatSaturated.
        /// </summary>
        /// <value>The translation of FatSaturated.</value>
        [JsonProperty("FatSaturated")]
        string FatSaturated { get; set; }

        /// <summary>
        /// Gets or sets the translation of FatTotal.
        /// </summary>
        /// <value>The translation of FatTotal.</value>
        [JsonProperty("FatTotal")]
        string FatTotal { get; set; }

        /// <summary>
        /// Gets or sets the translation of Fiber.
        /// </summary>
        /// <value>The translation of Fiber.</value>
        [JsonProperty("Fiber")]
        string Fiber { get; set; }

        /// <summary>
        /// Gets or sets the translation of Folate.
        /// </summary>
        /// <value>The translation of Folate.</value>
        [JsonProperty("Folate")]
        string Folate { get; set; }

        /// <summary>
        /// Gets or sets the translation of Iodine.
        /// </summary>
        /// <value>The translation of Iodine.</value>
        [JsonProperty("Iodine")]
        string Iodine { get; set; }

        /// <summary>
        /// Gets or sets the translation of Iron.
        /// </summary>
        /// <value>The translation of Iron.</value>
        [JsonProperty("Iron")]
        string Iron { get; set; }

        /// <summary>
        /// Gets or sets the translation of Magnesium.
        /// </summary>
        /// <value>The translation of Magnesium.</value>
        [JsonProperty("Magnesium")]
        string Magnesium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Manganese.
        /// </summary>
        /// <value>The translation of Manganese.</value>
        [JsonProperty("Manganese")]
        string Manganese { get; set; }

        /// <summary>
        /// Gets or sets the translation of Molybdenum.
        /// </summary>
        /// <value>The translation of Molybdenum.</value>
        [JsonProperty("Molybdenum")]
        string Molybdenum { get; set; }

        /// <summary>
        /// Gets or sets the translation of Niacin.
        /// </summary>
        /// <value>The translation of Niacin.</value>
        [JsonProperty("Niacin")]
        string Niacin { get; set; }

        /// <summary>
        /// Gets or sets the translation of PantotenicAcid.
        /// </summary>
        /// <value>The translation of PantotenicAcid.</value>
        [JsonProperty("PantotenicAcid")]
        string PantotenicAcid { get; set; }

        /// <summary>
        /// Gets or sets the translation of Phosphorus.
        /// </summary>
        /// <value>The translation of Phosphorus.</value>
        [JsonProperty("Phosphorus")]
        string Phosphorus { get; set; }

        /// <summary>
        /// Gets or sets the translation of Potassium.
        /// </summary>
        /// <value>The translation of Potassium.</value>
        [JsonProperty("Potassium")]
        string Potassium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Protein.
        /// </summary>
        /// <value>The translation of Protein.</value>
        [JsonProperty("Protein")]
        string Protein { get; set; }

        /// <summary>
        /// Gets or sets the translation of Riboflavin.
        /// </summary>
        /// <value>The translation of Riboflavin.</value>
        [JsonProperty("Riboflavin")]
        string Riboflavin { get; set; }

        /// <summary>
        /// Gets or sets the translation of Selenium.
        /// </summary>
        /// <value>The translation of Selenium.</value>
        [JsonProperty("Selenium")]
        string Selenium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Sodium.
        /// </summary>
        /// <value>The translation of Sodium.</value>
        [JsonProperty("Sodium")]
        string Sodium { get; set; }

        /// <summary>
        /// Gets or sets the translation of Sugar.
        /// </summary>
        /// <value>The translation of Sugar.</value>
        [JsonProperty("Sugar")]
        string Sugar { get; set; }

        /// <summary>
        /// Gets or sets the translation of Thiamin.
        /// </summary>
        /// <value>The translation of Thiamin.</value>
        [JsonProperty("Thiamin")]
        string Thiamin { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminA.
        /// </summary>
        /// <value>The translation of VitaminA.</value>
        [JsonProperty("VitaminA")]
        string VitaminA { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminB12.
        /// </summary>
        /// <value>The translation of VitaminB12.</value>
        [JsonProperty("VitaminB12")]
        string VitaminB12 { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminB6.
        /// </summary>
        /// <value>The translation of VitaminB6.</value>
        [JsonProperty("VitaminB6")]
        string VitaminB6 { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminC.
        /// </summary>
        /// <value>The translation of VitaminC.</value>
        [JsonProperty("VitaminC")]
        string VitaminC { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminD.
        /// </summary>
        /// <value>The translation of VitaminD.</value>
        [JsonProperty("VitaminD")]
        string VitaminD { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminE.
        /// </summary>
        /// <value>The translation of VitaminE.</value>
        [JsonProperty("VitaminE")]
        string VitaminE { get; set; }

        /// <summary>
        /// Gets or sets the translation of VitaminK.
        /// </summary>
        /// <value>The translation of VitaminK.</value>
        [JsonProperty("VitaminK")]
        string VitaminK { get; set; }

        /// <summary>
        /// Gets or sets the translation of Water.
        /// </summary>
        /// <value>The translation of Water.</value>
        [JsonProperty("Water")]
        string Water { get; set; }

        /// <summary>
        /// Gets or sets the translation of Zinc.
        /// </summary>
        /// <value>The translation of Zinc.</value>
        [JsonProperty("Zinc")]
        string Zinc { get; set; }

        /// <summary>
        /// Gets or sets the translation of Alcohol.
        /// </summary>
        /// <value>The translation of Alcohol.</value>
        [JsonProperty("Alcohol")]
        string Alcohol { get; set; }

        /// <summary>
        /// Gets or sets the translation of Energy.
        /// </summary>
        /// <value>The translation of Energy.</value>
        [JsonProperty("Energy")]
        string Energy { get; set; }
    }
}