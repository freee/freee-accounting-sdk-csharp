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
    /// ApprovalRequestsIndexResponse
    /// </summary>
    [DataContract(Name = "approvalRequestsIndexResponse")]
    public partial class ApprovalRequestsIndexResponse : IEquatable<ApprovalRequestsIndexResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalRequestsIndexResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApprovalRequestsIndexResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalRequestsIndexResponse" /> class.
        /// </summary>
        /// <param name="approvalRequests">approvalRequests (required).</param>
        public ApprovalRequestsIndexResponse(List<ApprovalRequestsIndexResponseApprovalRequests> approvalRequests = default(List<ApprovalRequestsIndexResponseApprovalRequests>))
        {
            // to ensure "approvalRequests" is required (not null)
            if (approvalRequests == null) {
                throw new ArgumentNullException("approvalRequests is a required property for ApprovalRequestsIndexResponse and cannot be null");
            }
            this.ApprovalRequests = approvalRequests;
        }

        /// <summary>
        /// Gets or Sets ApprovalRequests
        /// </summary>
        [DataMember(Name = "approval_requests", IsRequired = true, EmitDefaultValue = false)]
        public List<ApprovalRequestsIndexResponseApprovalRequests> ApprovalRequests { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApprovalRequestsIndexResponse {\n");
            sb.Append("  ApprovalRequests: ").Append(ApprovalRequests).Append("\n");
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
            return this.Equals(input as ApprovalRequestsIndexResponse);
        }

        /// <summary>
        /// Returns true if ApprovalRequestsIndexResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ApprovalRequestsIndexResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApprovalRequestsIndexResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ApprovalRequests == input.ApprovalRequests ||
                    this.ApprovalRequests != null &&
                    input.ApprovalRequests != null &&
                    this.ApprovalRequests.SequenceEqual(input.ApprovalRequests)
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
                if (this.ApprovalRequests != null)
                {
                    hashCode = (hashCode * 59) + this.ApprovalRequests.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
