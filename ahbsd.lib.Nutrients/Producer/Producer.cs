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
using System.Net.Sockets;
using System.Text;
using ahbsd.lib;

namespace ahbsd.lib.Nutrients.Producer
{
    /// <summary>
    /// A Class for a Producer of food.
    /// </summary>
    public class Producer : Component, IProducer
    {
        private string _address;
        private string _city;
        private string _zip;
        private string _country;
        private Uri _website;

        protected internal static IDictionary<int, IProducer> KnownProducers { get; private set; }

        public static IProducer GetProducer(int id) => KnownProducers[id];

        static Producer()
        {
            KnownProducers = new Dictionary<int, IProducer>();
        }

        /// <summary>
        /// Constructor with ID, (Company) name, address, city, zip, country and a website..
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The Name.</param>
        /// <param name="address">The Address.</param>
        /// <param name="city">The City.</param>
        /// <param name="zip">The ZIP.</param>
        /// <param name="country">The Country.</param>
        /// <param name="website">The Website.</param>
        /// <exception cref="Exception">If name, address, city or country isn't set.</exception>
        public Producer(int id, string name, string address, string city, string zip, string country, string website)
            : base()
        {
            ID = id;
            bool error = false;
            string errorMsg = string.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                Name = name.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Name must be set; '{name}' is invalid!";
            }

            if (!string.IsNullOrEmpty(address))
            {
                _address = address.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Address must be set; '{address}' is invalid!";
            }

            if (!string.IsNullOrEmpty(city))
            {
                _city = city;
            }
            else
            {
                error = true;
                errorMsg = $"City must be set; '{city}' is invalid!";
            }

            if (zip != null)
            {
                _zip = zip.Trim();
            }
            else
            {
                _zip = zip;
            }

            if (!string.IsNullOrEmpty(country))
            {
                _country = country.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Country must be set; '{country}' is invalid!";
            }

            if (!string.IsNullOrEmpty(website))
            {
                _website = new Uri(website.Trim());
            }
            else
            {
                _website = null;
            }

            if (error)
            {
                throw new Exception(errorMsg);
            }

            KnownProducers.Add(id, this);
        }

        /// <summary>
        /// Constructor with ID, (Company) name, address, city, zip, country, website and a container.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The Name.</param>
        /// <param name="address">The Address.</param>
        /// <param name="city">The City.</param>
        /// <param name="zip">The ZIP.</param>
        /// <param name="country">The Country.</param>
        /// <param name="website">The Website.</param>
        /// <param name="container">The container.</param>
        /// <exception cref="Exception">If name, address, city, country isn't set.</exception>
        public Producer(int id, string name, string address, string city, string zip, string country, string website, IContainer container)
            : base()
        {
            ID = id;
            bool error = false;
            string errorMsg = string.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                Name = name.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Name must be set; '{name}' is invalid!";
            }

            if (!string.IsNullOrEmpty(address))
            {
                _address = address.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Address must be set; '{address}' is invalid!";
            }

            if (!string.IsNullOrEmpty(city))
            {
                _city = city;
            }
            else
            {
                error = true;
                errorMsg = $"City must be set; '{city}' is invalid!";
            }

            if (zip != null)
            {
                _zip = zip.Trim();
            }
            else
            {
                _zip = zip;
            }

            if (!string.IsNullOrEmpty(country))
            {
                _country = country.Trim();
            }
            else
            {
                error = true;
                errorMsg = $"Country must be set; '{country}' is invalid!";
            }

            if (!string.IsNullOrEmpty(website))
            {
                _website = new Uri(website.Trim());
            }
            else
            {
                _website = null;
            }

            if (container != null)
            {
                container.Add(this, $"Producer: {Name}");
            }

            if (error)
            {
                throw new Exception(errorMsg);
            }

            KnownProducers.Add(id, this);
        }

        #region implementation of IProducer
        /// <summary>
        /// Happenes, if the <see cref="Address"/> has changed.
        /// </summary>
        public event ChangeEventHandler<string> OnAddressChanged;
        /// <summary>
        /// Happenes, if the <see cref="City"/> has changed.
        /// </summary>
        public event ChangeEventHandler<string> OnCityChanged;
        /// <summary>
        /// Happenes if the <see cref="ZIP"/> has changed.
        /// </summary>
        public event ChangeEventHandler<string> OnZIPChanged;
        /// <summary>
        /// Happenes, if the <see cref="Country"/> has changed.
        /// </summary>
        public event ChangeEventHandler<string> OnCountryChanged;
        /// <summary>
        /// Happenes, if the <see cref="Website"/> has changed.
        /// </summary>
        public event ChangeEventHandler<Uri> OnWebsiteChanged;
        /// <summary>
        /// Gets the producer ID.
        /// </summary>
        /// <value>The producer ID.</value>
        public int ID { get; private set; }
        /// <summary>
        /// Gets the producer (company) name.
        /// </summary>
        /// <value>The producer name.</value>
        public string Name { get; private set; }
        /// <summary>
        /// Gets or sets the address of the producer.
        /// </summary>
        /// <value>The address of the producer.</value>
        public string Address
        {
            get => _address;
            set
            {
                if (!string.IsNullOrEmpty(value)
                    && !value.Trim().Equals(_address.Trim()))
                {
                    ChangeEventArgs<string> cea =
                        new ChangeEventArgs<string>(_address, value);

                    _address = value.Trim();
                    OnAddressChanged?.Invoke(this, cea);
                }
            }
        }
        /// <summary>
        /// Gets or sets the city of the producer.
        /// </summary>
        /// <value>The city of the producer.</value>
        public string City
        {
            get => _city;
            set
            {
                if (!string.IsNullOrEmpty(value)
                    && !value.Trim().Equals(_city.Trim()))
                {
                    ChangeEventArgs<string> cea =
                        new ChangeEventArgs<string>(_city, value);

                    _city = value.Trim();
                    OnCityChanged?.Invoke(this, cea);
                }
            }
        }
        /// <summary>
        /// Gets or sets the ZIP of the Producer.
        /// </summary>
        /// <value>The ZIP of the Producer.</value>
        public string ZIP
        {
            get => _zip;
            set
            {
                if (!string.IsNullOrEmpty(value)
                    && !value.Trim().Equals(_zip.Trim()))
                {
                    ChangeEventArgs<string> cea =
                        new ChangeEventArgs<string>(_zip, value);

                    _zip = value.Trim();
                    OnZIPChanged?.Invoke(this, cea);
                }
            }
        }
        /// <summary>
        /// Gets or sets the country of the producer.
        /// </summary>
        /// <value>The country of the producer.</value>
        public string Country
        {
            get => _country;
            set
            {
                if (!string.IsNullOrEmpty(value)
                    && !value.Trim().Equals(_country.Trim()))
                {
                    ChangeEventArgs<string> cea =
                        new ChangeEventArgs<string>(_country, value);

                    _country = value.Trim();
                    OnCountryChanged?.Invoke(this, cea);
                }
            }
        }
        /// <summary>
        /// Gets or sets the website of the producer.
        /// </summary>
        /// <value>The website of the producer.</value>
        public Uri Website
        {
            get => _website;
            set
            {
                if (value != null
                    && !value.Equals(_website))
                {
                    ChangeEventArgs<Uri> cea =
                        new ChangeEventArgs<Uri>(_website, value);

                    _website = value;
                    OnWebsiteChanged?.Invoke(this, cea);
                }
            }
        }
        #endregion

        /// <summary>
        /// Returns a simple view of this Producer.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(Name);

            if (Website != null)
            {
                stringBuilder.Append($" | Web: {Website.Host}");
            }

            return stringBuilder.ToString();
        }

        
    }
}
