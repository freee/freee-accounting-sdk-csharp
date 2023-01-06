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
    /// SelectablesIndexResponseDefaultTax
    /// </summary>
    [DataContract(Name = "selectablesIndexResponse_default_tax")]
    public partial class SelectablesIndexResponseDefaultTax : IEquatable<SelectablesIndexResponseDefaultTax>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseDefaultTax" /> class.
        /// </summary>
        /// <param name="taxRate10">taxRate10.</param>
        /// <param name="taxRate10Exempt50">taxRate10Exempt50.</param>
        /// <param name="taxRate10Exempt80">taxRate10Exempt80.</param>
        /// <param name="taxRate5">taxRate5.</param>
        /// <param name="taxRate5Exempt50">taxRate5Exempt50.</param>
        /// <param name="taxRate5Exempt80">taxRate5Exempt80.</param>
        /// <param name="taxRate8">taxRate8.</param>
        /// <param name="taxRate8Exempt50">taxRate8Exempt50.</param>
        /// <param name="taxRate8Exempt80">taxRate8Exempt80.</param>
        /// <param name="taxRateR8">taxRateR8.</param>
        /// <param name="taxRateR8Exempt50">taxRateR8Exempt50.</param>
        /// <param name="taxRateR8Exempt80">taxRateR8Exempt80.</param>
        public SelectablesIndexResponseDefaultTax(SelectablesIndexResponseDefaultTaxTaxRate10 taxRate10 = default(SelectablesIndexResponseDefaultTaxTaxRate10), SelectablesIndexResponseDefaultTaxTaxRate10Exempt50 taxRate10Exempt50 = default(SelectablesIndexResponseDefaultTaxTaxRate10Exempt50), SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 taxRate10Exempt80 = default(SelectablesIndexResponseDefaultTaxTaxRate10Exempt80), SelectablesIndexResponseDefaultTaxTaxRate5 taxRate5 = default(SelectablesIndexResponseDefaultTaxTaxRate5), SelectablesIndexResponseDefaultTaxTaxRate5Exempt50 taxRate5Exempt50 = default(SelectablesIndexResponseDefaultTaxTaxRate5Exempt50), SelectablesIndexResponseDefaultTaxTaxRate5Exempt80 taxRate5Exempt80 = default(SelectablesIndexResponseDefaultTaxTaxRate5Exempt80), SelectablesIndexResponseDefaultTaxTaxRate8 taxRate8 = default(SelectablesIndexResponseDefaultTaxTaxRate8), SelectablesIndexResponseDefaultTaxTaxRate8Exempt50 taxRate8Exempt50 = default(SelectablesIndexResponseDefaultTaxTaxRate8Exempt50), SelectablesIndexResponseDefaultTaxTaxRate8Exempt80 taxRate8Exempt80 = default(SelectablesIndexResponseDefaultTaxTaxRate8Exempt80), SelectablesIndexResponseDefaultTaxTaxRateR8 taxRateR8 = default(SelectablesIndexResponseDefaultTaxTaxRateR8), SelectablesIndexResponseDefaultTaxTaxRateR8Exempt50 taxRateR8Exempt50 = default(SelectablesIndexResponseDefaultTaxTaxRateR8Exempt50), SelectablesIndexResponseDefaultTaxTaxRateR8Exempt80 taxRateR8Exempt80 = default(SelectablesIndexResponseDefaultTaxTaxRateR8Exempt80))
        {
            this.TaxRate10 = taxRate10;
            this.TaxRate10Exempt50 = taxRate10Exempt50;
            this.TaxRate10Exempt80 = taxRate10Exempt80;
            this.TaxRate5 = taxRate5;
            this.TaxRate5Exempt50 = taxRate5Exempt50;
            this.TaxRate5Exempt80 = taxRate5Exempt80;
            this.TaxRate8 = taxRate8;
            this.TaxRate8Exempt50 = taxRate8Exempt50;
            this.TaxRate8Exempt80 = taxRate8Exempt80;
            this.TaxRateR8 = taxRateR8;
            this.TaxRateR8Exempt50 = taxRateR8Exempt50;
            this.TaxRateR8Exempt80 = taxRateR8Exempt80;
        }

        /// <summary>
        /// Gets or Sets TaxRate10
        /// </summary>
        [DataMember(Name = "tax_rate_10", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate10 TaxRate10 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate10Exempt50
        /// </summary>
        [DataMember(Name = "tax_rate_10_exempt_50", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate10Exempt50 TaxRate10Exempt50 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate10Exempt80
        /// </summary>
        [DataMember(Name = "tax_rate_10_exempt_80", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 TaxRate10Exempt80 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate5
        /// </summary>
        [DataMember(Name = "tax_rate_5", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate5 TaxRate5 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate5Exempt50
        /// </summary>
        [DataMember(Name = "tax_rate_5_exempt_50", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate5Exempt50 TaxRate5Exempt50 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate5Exempt80
        /// </summary>
        [DataMember(Name = "tax_rate_5_exempt_80", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate5Exempt80 TaxRate5Exempt80 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate8
        /// </summary>
        [DataMember(Name = "tax_rate_8", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate8 TaxRate8 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate8Exempt50
        /// </summary>
        [DataMember(Name = "tax_rate_8_exempt_50", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate8Exempt50 TaxRate8Exempt50 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRate8Exempt80
        /// </summary>
        [DataMember(Name = "tax_rate_8_exempt_80", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRate8Exempt80 TaxRate8Exempt80 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRateR8
        /// </summary>
        [DataMember(Name = "tax_rate_r8", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRateR8 TaxRateR8 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRateR8Exempt50
        /// </summary>
        [DataMember(Name = "tax_rate_r8_exempt_50", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRateR8Exempt50 TaxRateR8Exempt50 { get; set; }

        /// <summary>
        /// Gets or Sets TaxRateR8Exempt80
        /// </summary>
        [DataMember(Name = "tax_rate_r8_exempt_80", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTaxTaxRateR8Exempt80 TaxRateR8Exempt80 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectablesIndexResponseDefaultTax {\n");
            sb.Append("  TaxRate10: ").Append(TaxRate10).Append("\n");
            sb.Append("  TaxRate10Exempt50: ").Append(TaxRate10Exempt50).Append("\n");
            sb.Append("  TaxRate10Exempt80: ").Append(TaxRate10Exempt80).Append("\n");
            sb.Append("  TaxRate5: ").Append(TaxRate5).Append("\n");
            sb.Append("  TaxRate5Exempt50: ").Append(TaxRate5Exempt50).Append("\n");
            sb.Append("  TaxRate5Exempt80: ").Append(TaxRate5Exempt80).Append("\n");
            sb.Append("  TaxRate8: ").Append(TaxRate8).Append("\n");
            sb.Append("  TaxRate8Exempt50: ").Append(TaxRate8Exempt50).Append("\n");
            sb.Append("  TaxRate8Exempt80: ").Append(TaxRate8Exempt80).Append("\n");
            sb.Append("  TaxRateR8: ").Append(TaxRateR8).Append("\n");
            sb.Append("  TaxRateR8Exempt50: ").Append(TaxRateR8Exempt50).Append("\n");
            sb.Append("  TaxRateR8Exempt80: ").Append(TaxRateR8Exempt80).Append("\n");
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
            return this.Equals(input as SelectablesIndexResponseDefaultTax);
        }

        /// <summary>
        /// Returns true if SelectablesIndexResponseDefaultTax instances are equal
        /// </summary>
        /// <param name="input">Instance of SelectablesIndexResponseDefaultTax to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SelectablesIndexResponseDefaultTax input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TaxRate10 == input.TaxRate10 ||
                    (this.TaxRate10 != null &&
                    this.TaxRate10.Equals(input.TaxRate10))
                ) && 
                (
                    this.TaxRate10Exempt50 == input.TaxRate10Exempt50 ||
                    (this.TaxRate10Exempt50 != null &&
                    this.TaxRate10Exempt50.Equals(input.TaxRate10Exempt50))
                ) && 
                (
                    this.TaxRate10Exempt80 == input.TaxRate10Exempt80 ||
                    (this.TaxRate10Exempt80 != null &&
                    this.TaxRate10Exempt80.Equals(input.TaxRate10Exempt80))
                ) && 
                (
                    this.TaxRate5 == input.TaxRate5 ||
                    (this.TaxRate5 != null &&
                    this.TaxRate5.Equals(input.TaxRate5))
                ) && 
                (
                    this.TaxRate5Exempt50 == input.TaxRate5Exempt50 ||
                    (this.TaxRate5Exempt50 != null &&
                    this.TaxRate5Exempt50.Equals(input.TaxRate5Exempt50))
                ) && 
                (
                    this.TaxRate5Exempt80 == input.TaxRate5Exempt80 ||
                    (this.TaxRate5Exempt80 != null &&
                    this.TaxRate5Exempt80.Equals(input.TaxRate5Exempt80))
                ) && 
                (
                    this.TaxRate8 == input.TaxRate8 ||
                    (this.TaxRate8 != null &&
                    this.TaxRate8.Equals(input.TaxRate8))
                ) && 
                (
                    this.TaxRate8Exempt50 == input.TaxRate8Exempt50 ||
                    (this.TaxRate8Exempt50 != null &&
                    this.TaxRate8Exempt50.Equals(input.TaxRate8Exempt50))
                ) && 
                (
                    this.TaxRate8Exempt80 == input.TaxRate8Exempt80 ||
                    (this.TaxRate8Exempt80 != null &&
                    this.TaxRate8Exempt80.Equals(input.TaxRate8Exempt80))
                ) && 
                (
                    this.TaxRateR8 == input.TaxRateR8 ||
                    (this.TaxRateR8 != null &&
                    this.TaxRateR8.Equals(input.TaxRateR8))
                ) && 
                (
                    this.TaxRateR8Exempt50 == input.TaxRateR8Exempt50 ||
                    (this.TaxRateR8Exempt50 != null &&
                    this.TaxRateR8Exempt50.Equals(input.TaxRateR8Exempt50))
                ) && 
                (
                    this.TaxRateR8Exempt80 == input.TaxRateR8Exempt80 ||
                    (this.TaxRateR8Exempt80 != null &&
                    this.TaxRateR8Exempt80.Equals(input.TaxRateR8Exempt80))
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
                if (this.TaxRate10 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate10.GetHashCode();
                }
                if (this.TaxRate10Exempt50 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate10Exempt50.GetHashCode();
                }
                if (this.TaxRate10Exempt80 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate10Exempt80.GetHashCode();
                }
                if (this.TaxRate5 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate5.GetHashCode();
                }
                if (this.TaxRate5Exempt50 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate5Exempt50.GetHashCode();
                }
                if (this.TaxRate5Exempt80 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate5Exempt80.GetHashCode();
                }
                if (this.TaxRate8 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate8.GetHashCode();
                }
                if (this.TaxRate8Exempt50 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate8Exempt50.GetHashCode();
                }
                if (this.TaxRate8Exempt80 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRate8Exempt80.GetHashCode();
                }
                if (this.TaxRateR8 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRateR8.GetHashCode();
                }
                if (this.TaxRateR8Exempt50 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRateR8Exempt50.GetHashCode();
                }
                if (this.TaxRateR8Exempt80 != null)
                {
                    hashCode = (hashCode * 59) + this.TaxRateR8Exempt80.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
