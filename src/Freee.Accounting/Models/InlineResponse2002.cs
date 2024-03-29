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
    /// InlineResponse2002
    /// </summary>
    [DataContract(Name = "inline_response_200_2")]
    public partial class InlineResponse2002 : IEquatable<InlineResponse2002>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse2002" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InlineResponse2002() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse2002" /> class.
        /// </summary>
        /// <param name="expenseApplicationLineTemplates">expenseApplicationLineTemplates (required).</param>
        public InlineResponse2002(List<ExpenseApplicationLineTemplate> expenseApplicationLineTemplates = default(List<ExpenseApplicationLineTemplate>))
        {
            // to ensure "expenseApplicationLineTemplates" is required (not null)
            if (expenseApplicationLineTemplates == null) {
                throw new ArgumentNullException("expenseApplicationLineTemplates is a required property for InlineResponse2002 and cannot be null");
            }
            this.ExpenseApplicationLineTemplates = expenseApplicationLineTemplates;
        }

        /// <summary>
        /// Gets or Sets ExpenseApplicationLineTemplates
        /// </summary>
        [DataMember(Name = "expense_application_line_templates", IsRequired = true, EmitDefaultValue = false)]
        public List<ExpenseApplicationLineTemplate> ExpenseApplicationLineTemplates { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InlineResponse2002 {\n");
            sb.Append("  ExpenseApplicationLineTemplates: ").Append(ExpenseApplicationLineTemplates).Append("\n");
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
            return this.Equals(input as InlineResponse2002);
        }

        /// <summary>
        /// Returns true if InlineResponse2002 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse2002 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse2002 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ExpenseApplicationLineTemplates == input.ExpenseApplicationLineTemplates ||
                    this.ExpenseApplicationLineTemplates != null &&
                    input.ExpenseApplicationLineTemplates != null &&
                    this.ExpenseApplicationLineTemplates.SequenceEqual(input.ExpenseApplicationLineTemplates)
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
                if (this.ExpenseApplicationLineTemplates != null)
                {
                    hashCode = (hashCode * 59) + this.ExpenseApplicationLineTemplates.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
