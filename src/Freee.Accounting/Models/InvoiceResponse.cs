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
    /// InvoiceResponse
    /// </summary>
    [DataContract(Name = "invoiceResponse")]
    public partial class InvoiceResponse : IEquatable<InvoiceResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InvoiceResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceResponse" /> class.
        /// </summary>
        /// <param name="invoice">invoice (required).</param>
        public InvoiceResponse(InvoiceResponseInvoice invoice = default(InvoiceResponseInvoice))
        {
            // to ensure "invoice" is required (not null)
            if (invoice == null) {
                throw new ArgumentNullException("invoice is a required property for InvoiceResponse and cannot be null");
            }
            this.Invoice = invoice;
        }

        /// <summary>
        /// Gets or Sets Invoice
        /// </summary>
        [DataMember(Name = "invoice", IsRequired = true, EmitDefaultValue = false)]
        public InvoiceResponseInvoice Invoice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoiceResponse {\n");
            sb.Append("  Invoice: ").Append(Invoice).Append("\n");
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
            return this.Equals(input as InvoiceResponse);
        }

        /// <summary>
        /// Returns true if InvoiceResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of InvoiceResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InvoiceResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Invoice == input.Invoice ||
                    (this.Invoice != null &&
                    this.Invoice.Equals(input.Invoice))
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
                if (this.Invoice != null)
                {
                    hashCode = (hashCode * 59) + this.Invoice.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
