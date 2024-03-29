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
    /// ReceiptResponse
    /// </summary>
    [DataContract(Name = "receiptResponse")]
    public partial class ReceiptResponse : IEquatable<ReceiptResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ReceiptResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptResponse" /> class.
        /// </summary>
        /// <param name="receipt">receipt (required).</param>
        public ReceiptResponse(Receipt receipt = default(Receipt))
        {
            // to ensure "receipt" is required (not null)
            if (receipt == null) {
                throw new ArgumentNullException("receipt is a required property for ReceiptResponse and cannot be null");
            }
            this.Receipt = receipt;
        }

        /// <summary>
        /// Gets or Sets Receipt
        /// </summary>
        [DataMember(Name = "receipt", IsRequired = true, EmitDefaultValue = false)]
        public Receipt Receipt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReceiptResponse {\n");
            sb.Append("  Receipt: ").Append(Receipt).Append("\n");
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
            return this.Equals(input as ReceiptResponse);
        }

        /// <summary>
        /// Returns true if ReceiptResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ReceiptResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReceiptResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Receipt == input.Receipt ||
                    (this.Receipt != null &&
                    this.Receipt.Equals(input.Receipt))
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
                if (this.Receipt != null)
                {
                    hashCode = (hashCode * 59) + this.Receipt.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
