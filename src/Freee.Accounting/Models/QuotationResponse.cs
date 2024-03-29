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
    /// QuotationResponse
    /// </summary>
    [DataContract(Name = "quotationResponse")]
    public partial class QuotationResponse : IEquatable<QuotationResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotationResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuotationResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotationResponse" /> class.
        /// </summary>
        /// <param name="quotation">quotation (required).</param>
        public QuotationResponse(QuotationResponseQuotation quotation = default(QuotationResponseQuotation))
        {
            // to ensure "quotation" is required (not null)
            if (quotation == null) {
                throw new ArgumentNullException("quotation is a required property for QuotationResponse and cannot be null");
            }
            this.Quotation = quotation;
        }

        /// <summary>
        /// Gets or Sets Quotation
        /// </summary>
        [DataMember(Name = "quotation", IsRequired = true, EmitDefaultValue = false)]
        public QuotationResponseQuotation Quotation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class QuotationResponse {\n");
            sb.Append("  Quotation: ").Append(Quotation).Append("\n");
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
            return this.Equals(input as QuotationResponse);
        }

        /// <summary>
        /// Returns true if QuotationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of QuotationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuotationResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Quotation == input.Quotation ||
                    (this.Quotation != null &&
                    this.Quotation.Equals(input.Quotation))
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
                if (this.Quotation != null)
                {
                    hashCode = (hashCode * 59) + this.Quotation.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
