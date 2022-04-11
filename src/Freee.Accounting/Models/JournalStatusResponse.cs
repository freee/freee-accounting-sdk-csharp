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
    /// JournalStatusResponse
    /// </summary>
    [DataContract(Name = "journalStatusResponse")]
    public partial class JournalStatusResponse : IEquatable<JournalStatusResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalStatusResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JournalStatusResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalStatusResponse" /> class.
        /// </summary>
        /// <param name="journals">journals (required).</param>
        public JournalStatusResponse(JournalStatusResponseJournals journals = default(JournalStatusResponseJournals))
        {
            // to ensure "journals" is required (not null)
            if (journals == null)
            {
                throw new ArgumentNullException("journals is a required property for JournalStatusResponse and cannot be null");
            }
            this.Journals = journals;
        }

        /// <summary>
        /// Gets or Sets Journals
        /// </summary>
        [DataMember(Name = "journals", IsRequired = true, EmitDefaultValue = false)]
        public JournalStatusResponseJournals Journals { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JournalStatusResponse {\n");
            sb.Append("  Journals: ").Append(Journals).Append("\n");
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
            return this.Equals(input as JournalStatusResponse);
        }

        /// <summary>
        /// Returns true if JournalStatusResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of JournalStatusResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JournalStatusResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Journals == input.Journals ||
                    (this.Journals != null &&
                    this.Journals.Equals(input.Journals))
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
                if (this.Journals != null)
                {
                    hashCode = (hashCode * 59) + this.Journals.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
