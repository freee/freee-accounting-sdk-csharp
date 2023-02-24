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
    /// UserCapabilityJustUpdate
    /// </summary>
    [DataContract(Name = "userCapabilityJustUpdate")]
    public partial class UserCapabilityJustUpdate : IEquatable<UserCapabilityJustUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCapabilityJustUpdate" /> class.
        /// </summary>
        /// <param name="update">更新.</param>
        public UserCapabilityJustUpdate(bool update = default(bool))
        {
            this.Update = update;
        }

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
            sb.Append("class UserCapabilityJustUpdate {\n");
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
            return this.Equals(input as UserCapabilityJustUpdate);
        }

        /// <summary>
        /// Returns true if UserCapabilityJustUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of UserCapabilityJustUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserCapabilityJustUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
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
                hashCode = (hashCode * 59) + this.Update.GetHashCode();
                return hashCode;
            }
        }

    }

}