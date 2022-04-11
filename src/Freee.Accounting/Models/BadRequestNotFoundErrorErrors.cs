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
    /// BadRequestNotFoundErrorErrors
    /// </summary>
    [DataContract(Name = "badRequestNotFoundError_errors")]
    public partial class BadRequestNotFoundErrorErrors : IEquatable<BadRequestNotFoundErrorErrors>
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Status for value: status
            /// </summary>
            [EnumMember(Value = "status")]
            Status = 1,

            /// <summary>
            /// Enum Validation for value: validation
            /// </summary>
            [EnumMember(Value = "validation")]
            Validation = 2,

            /// <summary>
            /// Enum Error for value: error
            /// </summary>
            [EnumMember(Value = "error")]
            Error = 3

        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestNotFoundErrorErrors" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BadRequestNotFoundErrorErrors() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestNotFoundErrorErrors" /> class.
        /// </summary>
        /// <param name="messages">messages (required).</param>
        /// <param name="type">type (required).</param>
        public BadRequestNotFoundErrorErrors(List<string> messages = default(List<string>), TypeEnum type = default(TypeEnum))
        {
            // to ensure "messages" is required (not null)
            if (messages == null)
            {
                throw new ArgumentNullException("messages is a required property for BadRequestNotFoundErrorErrors and cannot be null");
            }
            this.Messages = messages;
            this.Type = type;
        }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [DataMember(Name = "messages", IsRequired = true, EmitDefaultValue = false)]
        public List<string> Messages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BadRequestNotFoundErrorErrors {\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(input as BadRequestNotFoundErrorErrors);
        }

        /// <summary>
        /// Returns true if BadRequestNotFoundErrorErrors instances are equal
        /// </summary>
        /// <param name="input">Instance of BadRequestNotFoundErrorErrors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BadRequestNotFoundErrorErrors input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Messages == input.Messages ||
                    this.Messages != null &&
                    input.Messages != null &&
                    this.Messages.SequenceEqual(input.Messages)
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                if (this.Messages != null)
                {
                    hashCode = (hashCode * 59) + this.Messages.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                return hashCode;
            }
        }

    }

}
