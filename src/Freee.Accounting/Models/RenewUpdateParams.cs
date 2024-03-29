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
    /// RenewUpdateParams
    /// </summary>
    [DataContract(Name = "renewUpdateParams")]
    public partial class RenewUpdateParams : IEquatable<RenewUpdateParams>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenewUpdateParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RenewUpdateParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RenewUpdateParams" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="details">+更新の明細行 (required).</param>
        /// <param name="updateDate">更新日 (yyyy-mm-dd) (required).</param>
        public RenewUpdateParams(int companyId = default(int), List<RenewUpdateParamsDetails> details = default(List<RenewUpdateParamsDetails>), string updateDate = default(string))
        {
            this.CompanyId = companyId;
            // to ensure "details" is required (not null)
            if (details == null) {
                throw new ArgumentNullException("details is a required property for RenewUpdateParams and cannot be null");
            }
            this.Details = details;
            // to ensure "updateDate" is required (not null)
            if (updateDate == null) {
                throw new ArgumentNullException("updateDate is a required property for RenewUpdateParams and cannot be null");
            }
            this.UpdateDate = updateDate;
        }

        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name = "company_id", IsRequired = true, EmitDefaultValue = false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// +更新の明細行
        /// </summary>
        /// <value>+更新の明細行</value>
        [DataMember(Name = "details", IsRequired = true, EmitDefaultValue = false)]
        public List<RenewUpdateParamsDetails> Details { get; set; }

        /// <summary>
        /// 更新日 (yyyy-mm-dd)
        /// </summary>
        /// <value>更新日 (yyyy-mm-dd)</value>
        [DataMember(Name = "update_date", IsRequired = true, EmitDefaultValue = false)]
        public string UpdateDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RenewUpdateParams {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  UpdateDate: ").Append(UpdateDate).Append("\n");
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
            return this.Equals(input as RenewUpdateParams);
        }

        /// <summary>
        /// Returns true if RenewUpdateParams instances are equal
        /// </summary>
        /// <param name="input">Instance of RenewUpdateParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RenewUpdateParams input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.Details == input.Details ||
                    this.Details != null &&
                    input.Details != null &&
                    this.Details.SequenceEqual(input.Details)
                ) && 
                (
                    this.UpdateDate == input.UpdateDate ||
                    (this.UpdateDate != null &&
                    this.UpdateDate.Equals(input.UpdateDate))
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
                hashCode = (hashCode * 59) + this.CompanyId.GetHashCode();
                if (this.Details != null)
                {
                    hashCode = (hashCode * 59) + this.Details.GetHashCode();
                }
                if (this.UpdateDate != null)
                {
                    hashCode = (hashCode * 59) + this.UpdateDate.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
