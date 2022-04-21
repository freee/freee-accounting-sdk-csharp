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
    /// BankResponse
    /// </summary>
    [DataContract(Name = "bankResponse")]
    public partial class BankResponse : IEquatable<BankResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BankResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BankResponse" /> class.
        /// </summary>
        /// <param name="bank">bank (required).</param>
        public BankResponse(Bank bank = default(Bank))
        {
            // to ensure "bank" is required (not null)
            if (bank == null)
            {
                throw new ArgumentNullException("bank is a required property for BankResponse and cannot be null");
            }
            this.Bank = bank;
        }

        /// <summary>
        /// Gets or Sets Bank
        /// </summary>
        [DataMember(Name = "bank", IsRequired = true, EmitDefaultValue = false)]
        public Bank Bank { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BankResponse {\n");
            sb.Append("  Bank: ").Append(Bank).Append("\n");
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
            return this.Equals(input as BankResponse);
        }

        /// <summary>
        /// Returns true if BankResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of BankResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BankResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Bank == input.Bank ||
                    (this.Bank != null &&
                    this.Bank.Equals(input.Bank))
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
                if (this.Bank != null)
                {
                    hashCode = (hashCode * 59) + this.Bank.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
