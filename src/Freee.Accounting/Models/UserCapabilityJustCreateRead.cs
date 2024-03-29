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
    /// UserCapabilityJustCreateRead
    /// </summary>
    [DataContract(Name = "userCapabilityJustCreateRead")]
    public partial class UserCapabilityJustCreateRead : IEquatable<UserCapabilityJustCreateRead>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCapabilityJustCreateRead" /> class.
        /// </summary>
        /// <param name="create">作成.</param>
        /// <param name="read">閲覧.</param>
        public UserCapabilityJustCreateRead(bool create = default(bool), bool read = default(bool))
        {
            this.Create = create;
            this.Read = read;
        }

        /// <summary>
        /// 作成
        /// </summary>
        /// <value>作成</value>
        [DataMember(Name = "create", EmitDefaultValue = true)]
        public bool Create { get; set; }

        /// <summary>
        /// 閲覧
        /// </summary>
        /// <value>閲覧</value>
        [DataMember(Name = "read", EmitDefaultValue = true)]
        public bool Read { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserCapabilityJustCreateRead {\n");
            sb.Append("  Create: ").Append(Create).Append("\n");
            sb.Append("  Read: ").Append(Read).Append("\n");
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
            return this.Equals(input as UserCapabilityJustCreateRead);
        }

        /// <summary>
        /// Returns true if UserCapabilityJustCreateRead instances are equal
        /// </summary>
        /// <param name="input">Instance of UserCapabilityJustCreateRead to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserCapabilityJustCreateRead input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Create == input.Create ||
                    this.Create.Equals(input.Create)
                ) && 
                (
                    this.Read == input.Read ||
                    this.Read.Equals(input.Read)
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
                hashCode = (hashCode * 59) + this.Create.GetHashCode();
                hashCode = (hashCode * 59) + this.Read.GetHashCode();
                return hashCode;
            }
        }

    }

}
