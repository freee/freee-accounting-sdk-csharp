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
    /// PartnerResponse
    /// </summary>
    [DataContract(Name = "partnerResponse")]
    public partial class PartnerResponse : IEquatable<PartnerResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PartnerResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerResponse" /> class.
        /// </summary>
        /// <param name="partner">partner (required).</param>
        public PartnerResponse(PartnerResponsePartner partner = default(PartnerResponsePartner))
        {
            // to ensure "partner" is required (not null)
            if (partner == null)
            {
                throw new ArgumentNullException("partner is a required property for PartnerResponse and cannot be null");
            }
            this.Partner = partner;
        }

        /// <summary>
        /// Gets or Sets Partner
        /// </summary>
        [DataMember(Name = "partner", IsRequired = true, EmitDefaultValue = false)]
        public PartnerResponsePartner Partner { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PartnerResponse {\n");
            sb.Append("  Partner: ").Append(Partner).Append("\n");
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
            return this.Equals(input as PartnerResponse);
        }

        /// <summary>
        /// Returns true if PartnerResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of PartnerResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PartnerResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Partner == input.Partner ||
                    (this.Partner != null &&
                    this.Partner.Equals(input.Partner))
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
                if (this.Partner != null)
                {
                    hashCode = (hashCode * 59) + this.Partner.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
