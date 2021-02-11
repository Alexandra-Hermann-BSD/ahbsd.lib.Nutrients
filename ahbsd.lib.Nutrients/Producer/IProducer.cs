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
using System.ComponentModel;
using ahbsd.lib;

namespace ahbsd.lib.Nutrients.Producer
{
    /// <summary>
    /// Interface for a producer of food.
    /// </summary>
    public interface IProducer : IComponent
    {
        /// <summary>
        /// Happenes, if the <see cref="Address"/> has changed.
        /// </summary>
        event ChangeEventHandler<string> OnAddressChanged;
        /// <summary>
        /// Happenes, if the <see cref="City"/> has changed.
        /// </summary>
        event ChangeEventHandler<string> OnCityChanged;
        /// <summary>
        /// Happenes if the <see cref="ZIP"/> has changed.
        /// </summary>
        event ChangeEventHandler<string> OnZIPChanged;
        /// <summary>
        /// Happenes, if the <see cref="Country"/> has changed.
        /// </summary>
        event ChangeEventHandler<string> OnCountryChanged;
        /// <summary>
        /// Happenes, if the <see cref="Website"/> has changed.
        /// </summary>
        event ChangeEventHandler<Uri> OnWebsiteChanged; 
        /// <summary>
        /// Gets the producer ID.
        /// </summary>
        /// <value>The producer ID.</value>
        int ID { get; }
        /// <summary>
        /// Gets the producer (company) name.
        /// </summary>
        /// <value>The producer name.</value>
        string Name { get; }
        /// <summary>
        /// Gets or sets the address of the producer.
        /// </summary>
        /// <value>The address of the producer.</value>
        string Address { get; set; }
        /// <summary>
        /// Gets or sets the city of the producer.
        /// </summary>
        /// <value>The city of the producer.</value>
        string City { get; set; }
        /// <summary>
        /// Gets or sets the ZIP of the Producer.
        /// </summary>
        /// <value>The ZIP of the Producer.</value>
        string ZIP { get; set; }
        /// <summary>
        /// Gets or sets the country of the producer.
        /// </summary>
        /// <value>The country of the producer.</value>
        string Country { get; set; }
        /// <summary>
        /// Gets or sets the website of the producer.
        /// </summary>
        /// <value>The website of the producer.</value>
        Uri Website { get; set; }
    }
}
