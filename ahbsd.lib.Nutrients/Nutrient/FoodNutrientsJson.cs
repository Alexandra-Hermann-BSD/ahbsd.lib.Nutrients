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
// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ahbsd.lib.Nutrients.Nutrient;
//
//    var foodNutrients = FoodNutrients.FromJson(jsonString);
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ahbsd.lib.Nutrients.Nutrient
{

    public partial class FoodNutrientsJson : IFoodNutrientsJson
    {
        /// <summary>
        /// Gets or sets the Name of the Food.
        /// </summary>
        /// <value>The Name of the Food.</value>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Version of the Food.
        /// </summary>
        /// <value>The Version of the Food.</value>
        [JsonProperty("Version")]
        public ushort Version { get; set; }

        /// <summary>
        /// Gets or sets the first Date of the Food-Version.
        /// </summary>
        /// <value>The first Date of the Food-Version.</value>
        [JsonProperty("FirstDate")]
        public DateTime FirstDate { get; set; }

        /// <summary>
        /// Gets or sets the default Amount of food.
        /// </summary>
        /// <value>The default Amount of food.</value>
        [JsonProperty("DefaultAmount")]
        public double DefaultAmount { get; set; }

        /// <summary>
        /// Gets or sets the default Measurement of a food.
        /// </summary>
        /// <value>The default Measurement of a food.</value>
        [JsonProperty("DefaultMeasurement")]
        public string DefaultMeasurement { get; set; }

        /// <summary>
        /// Gets or sets the Dictionary with the nutrients of a food.
        /// </summary>
        /// <value>The Dictionary with the nutrients of a food.</value>
        [JsonProperty("NutrientValues")]
        public IDictionary<string, double?> NutrientValues { get; set; }
    }

    public partial class FoodNutrientsJson
    {
        /// <summary>
        /// Static function to get a <see cref="IFoodNutrientsJson"/> from a JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON-String.</param>
        /// <returns>The <see cref="IFoodNutrientsJson"/>.</returns>
        public static IFoodNutrientsJson FromJson(string json) => JsonConvert.DeserializeObject<IFoodNutrientsJson>(json, ahbsd.lib.Nutrients.Nutrient.FoodNutrientsJsonConverter.Settings);
    }

    public static class FoodNutrientsJsonSerialize
    {
        public static string ToJson(this IFoodNutrientsJson self) => JsonConvert.SerializeObject(self,
            ahbsd.lib.Nutrients.Nutrient.FoodNutrientsJsonConverter.Settings);
    }

    internal static class FoodNutrientsJsonConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
