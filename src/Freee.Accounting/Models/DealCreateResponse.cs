/*
 * freee API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Freee.Accounting.Client.OpenAPIDateConverter;

namespace Freee.Accounting.Models
{
    /// <summary>
    /// DealCreateResponse
    /// </summary>
    [DataContract(Name = "dealCreateResponse")]
    public partial class DealCreateResponse : IEquatable<DealCreateResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DealCreateResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateResponse" /> class.
        /// </summary>
        /// <param name="deal">deal (required).</param>
        public DealCreateResponse(DealCreateResponseDeal deal = default(DealCreateResponseDeal))
        {
            // to ensure "deal" is required (not null)
            if (deal == null) {
                throw new ArgumentNullException("deal is a required property for DealCreateResponse and cannot be null");
            }
            this.Deal = deal;
        }

        /// <summary>
        /// Gets or Sets Deal
        /// </summary>
        [DataMember(Name = "deal", IsRequired = true, EmitDefaultValue = false)]
        public DealCreateResponseDeal Deal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DealCreateResponse {\n");
            sb.Append("  Deal: ").Append(Deal).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DealCreateResponse);
        }

        /// <summary>
        /// Returns true if DealCreateResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of DealCreateResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DealCreateResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Deal == input.Deal ||
                    (this.Deal != null &&
                    this.Deal.Equals(input.Deal))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Deal != null)
                {
                    hashCode = (hashCode * 59) + this.Deal.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
