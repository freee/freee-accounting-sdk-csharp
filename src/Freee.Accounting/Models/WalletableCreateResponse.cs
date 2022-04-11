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
    /// WalletableCreateResponse
    /// </summary>
    [DataContract(Name = "walletableCreateResponse")]
    public partial class WalletableCreateResponse : IEquatable<WalletableCreateResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletableCreateResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WalletableCreateResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletableCreateResponse" /> class.
        /// </summary>
        /// <param name="walletable">walletable (required).</param>
        public WalletableCreateResponse(WalletableCreateResponseWalletable walletable = default(WalletableCreateResponseWalletable))
        {
            // to ensure "walletable" is required (not null)
            if (walletable == null)
            {
                throw new ArgumentNullException("walletable is a required property for WalletableCreateResponse and cannot be null");
            }
            this.Walletable = walletable;
        }

        /// <summary>
        /// Gets or Sets Walletable
        /// </summary>
        [DataMember(Name = "walletable", IsRequired = true, EmitDefaultValue = false)]
        public WalletableCreateResponseWalletable Walletable { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WalletableCreateResponse {\n");
            sb.Append("  Walletable: ").Append(Walletable).Append("\n");
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
            return this.Equals(input as WalletableCreateResponse);
        }

        /// <summary>
        /// Returns true if WalletableCreateResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of WalletableCreateResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WalletableCreateResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Walletable == input.Walletable ||
                    (this.Walletable != null &&
                    this.Walletable.Equals(input.Walletable))
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
                if (this.Walletable != null)
                {
                    hashCode = (hashCode * 59) + this.Walletable.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
