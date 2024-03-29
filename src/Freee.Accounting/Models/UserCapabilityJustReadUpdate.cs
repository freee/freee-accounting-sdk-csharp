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
    /// UserCapabilityJustReadUpdate
    /// </summary>
    [DataContract(Name = "userCapabilityJustReadUpdate")]
    public partial class UserCapabilityJustReadUpdate : IEquatable<UserCapabilityJustReadUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCapabilityJustReadUpdate" /> class.
        /// </summary>
        /// <param name="read">閲覧.</param>
        /// <param name="update">更新.</param>
        public UserCapabilityJustReadUpdate(bool read = default(bool), bool update = default(bool))
        {
            this.Read = read;
            this.Update = update;
        }

        /// <summary>
        /// 閲覧
        /// </summary>
        /// <value>閲覧</value>
        [DataMember(Name = "read", EmitDefaultValue = true)]
        public bool Read { get; set; }

        /// <summary>
        /// 更新
        /// </summary>
        /// <value>更新</value>
        [DataMember(Name = "update", EmitDefaultValue = true)]
        public bool Update { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserCapabilityJustReadUpdate {\n");
            sb.Append("  Read: ").Append(Read).Append("\n");
            sb.Append("  Update: ").Append(Update).Append("\n");
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
            return this.Equals(input as UserCapabilityJustReadUpdate);
        }

        /// <summary>
        /// Returns true if UserCapabilityJustReadUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of UserCapabilityJustReadUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserCapabilityJustReadUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Read == input.Read ||
                    this.Read.Equals(input.Read)
                ) && 
                (
                    this.Update == input.Update ||
                    this.Update.Equals(input.Update)
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
                hashCode = (hashCode * 59) + this.Read.GetHashCode();
                hashCode = (hashCode * 59) + this.Update.GetHashCode();
                return hashCode;
            }
        }

    }

}
