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
    /// PaymentRequestResponse
    /// </summary>
    [DataContract(Name = "paymentRequestResponse")]
    public partial class PaymentRequestResponse : IEquatable<PaymentRequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequestResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PaymentRequestResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequestResponse" /> class.
        /// </summary>
        /// <param name="paymentRequest">paymentRequest (required).</param>
        public PaymentRequestResponse(PaymentRequestResponsePaymentRequest paymentRequest = default(PaymentRequestResponsePaymentRequest))
        {
            // to ensure "paymentRequest" is required (not null)
            if (paymentRequest == null)
            {
                throw new ArgumentNullException("paymentRequest is a required property for PaymentRequestResponse and cannot be null");
            }
            this.PaymentRequest = paymentRequest;
        }

        /// <summary>
        /// Gets or Sets PaymentRequest
        /// </summary>
        [DataMember(Name = "payment_request", IsRequired = true, EmitDefaultValue = false)]
        public PaymentRequestResponsePaymentRequest PaymentRequest { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentRequestResponse {\n");
            sb.Append("  PaymentRequest: ").Append(PaymentRequest).Append("\n");
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
            return this.Equals(input as PaymentRequestResponse);
        }

        /// <summary>
        /// Returns true if PaymentRequestResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentRequestResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentRequestResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.PaymentRequest == input.PaymentRequest ||
                    (this.PaymentRequest != null &&
                    this.PaymentRequest.Equals(input.PaymentRequest))
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
                if (this.PaymentRequest != null)
                {
                    hashCode = (hashCode * 59) + this.PaymentRequest.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
