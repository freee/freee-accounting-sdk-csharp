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
    /// InlineResponse20011
    /// </summary>
    [DataContract(Name = "inline_response_200_11")]
    public partial class InlineResponse20011 : IEquatable<InlineResponse20011>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20011" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InlineResponse20011() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20011" /> class.
        /// </summary>
        /// <param name="transfers">transfers (required).</param>
        public InlineResponse20011(List<Transfer> transfers = default(List<Transfer>))
        {
            // to ensure "transfers" is required (not null)
            if (transfers == null) {
                throw new ArgumentNullException("transfers is a required property for InlineResponse20011 and cannot be null");
            }
            this.Transfers = transfers;
        }

        /// <summary>
        /// Gets or Sets Transfers
        /// </summary>
        [DataMember(Name = "transfers", IsRequired = true, EmitDefaultValue = false)]
        public List<Transfer> Transfers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InlineResponse20011 {\n");
            sb.Append("  Transfers: ").Append(Transfers).Append("\n");
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
            return this.Equals(input as InlineResponse20011);
        }

        /// <summary>
        /// Returns true if InlineResponse20011 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20011 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20011 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Transfers == input.Transfers ||
                    this.Transfers != null &&
                    input.Transfers != null &&
                    this.Transfers.SequenceEqual(input.Transfers)
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
                if (this.Transfers != null)
                {
                    hashCode = (hashCode * 59) + this.Transfers.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
