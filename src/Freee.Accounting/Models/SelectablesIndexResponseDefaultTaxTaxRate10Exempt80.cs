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
    /// SelectablesIndexResponseDefaultTaxTaxRate10Exempt80
    /// </summary>
    [DataContract(Name = "selectablesIndexResponse_default_tax_tax_rate_10_exempt_80")]
    public partial class SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 : IEquatable<SelectablesIndexResponseDefaultTaxTaxRate10Exempt80>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseDefaultTaxTaxRate10Exempt80" /> class.
        /// </summary>
        /// <param name="code">税区分コード（この項目はインボイス制度で利用する項目です。2023年7月頃から利用できる予定です。）.</param>
        /// <param name="name">税区分.</param>
        public SelectablesIndexResponseDefaultTaxTaxRate10Exempt80(int code = default(int), string name = default(string))
        {
            this.Code = code;
            this.Name = name;
        }

        /// <summary>
        /// 税区分コード（この項目はインボイス制度で利用する項目です。2023年7月頃から利用できる予定です。）
        /// </summary>
        /// <value>税区分コード（この項目はインボイス制度で利用する項目です。2023年7月頃から利用できる予定です。）</value>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public int Code { get; set; }

        /// <summary>
        /// 税区分
        /// </summary>
        /// <value>税区分</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as SelectablesIndexResponseDefaultTaxTaxRate10Exempt80);
        }

        /// <summary>
        /// Returns true if SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 instances are equal
        /// </summary>
        /// <param name="input">Instance of SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SelectablesIndexResponseDefaultTaxTaxRate10Exempt80 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Code == input.Code ||
                    this.Code.Equals(input.Code)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                hashCode = (hashCode * 59) + this.Code.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
