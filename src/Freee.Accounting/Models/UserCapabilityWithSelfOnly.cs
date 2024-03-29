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
    /// UserCapabilityWithSelfOnly
    /// </summary>
    [DataContract(Name = "userCapabilityWithSelfOnly")]
    public partial class UserCapabilityWithSelfOnly : IEquatable<UserCapabilityWithSelfOnly>
    {
        /// <summary>
        /// 「自分のみ」がonになっている場合はself_only、offになっている場合はallになります。
        /// </summary>
        /// <value>「自分のみ」がonになっている場合はself_only、offになっている場合はallになります。</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AllowedTargetEnum
        {
            /// <summary>
            /// Enum SelfOnly for value: self_only
            /// </summary>
            [EnumMember(Value = "self_only")]
            SelfOnly = 1,

            /// <summary>
            /// Enum All for value: all
            /// </summary>
            [EnumMember(Value = "all")]
            All = 2

        }


        /// <summary>
        /// 「自分のみ」がonになっている場合はself_only、offになっている場合はallになります。
        /// </summary>
        /// <value>「自分のみ」がonになっている場合はself_only、offになっている場合はallになります。</value>
        [DataMember(Name = "allowed_target", EmitDefaultValue = false)]
        public AllowedTargetEnum? AllowedTarget { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCapabilityWithSelfOnly" /> class.
        /// </summary>
        /// <param name="allowedTarget">「自分のみ」がonになっている場合はself_only、offになっている場合はallになります。.</param>
        /// <param name="create">作成.</param>
        /// <param name="destroy">削除.</param>
        /// <param name="read">閲覧.</param>
        /// <param name="update">更新.</param>
        public UserCapabilityWithSelfOnly(AllowedTargetEnum? allowedTarget = default(AllowedTargetEnum?), bool create = default(bool), bool destroy = default(bool), bool read = default(bool), bool update = default(bool))
        {
            this.AllowedTarget = allowedTarget;
            this.Create = create;
            this.Destroy = destroy;
            this.Read = read;
            this.Update = update;
        }

        /// <summary>
        /// 作成
        /// </summary>
        /// <value>作成</value>
        [DataMember(Name = "create", EmitDefaultValue = true)]
        public bool Create { get; set; }

        /// <summary>
        /// 削除
        /// </summary>
        /// <value>削除</value>
        [DataMember(Name = "destroy", EmitDefaultValue = true)]
        public bool Destroy { get; set; }

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
            sb.Append("class UserCapabilityWithSelfOnly {\n");
            sb.Append("  AllowedTarget: ").Append(AllowedTarget).Append("\n");
            sb.Append("  Create: ").Append(Create).Append("\n");
            sb.Append("  Destroy: ").Append(Destroy).Append("\n");
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
            return this.Equals(input as UserCapabilityWithSelfOnly);
        }

        /// <summary>
        /// Returns true if UserCapabilityWithSelfOnly instances are equal
        /// </summary>
        /// <param name="input">Instance of UserCapabilityWithSelfOnly to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserCapabilityWithSelfOnly input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AllowedTarget == input.AllowedTarget ||
                    this.AllowedTarget.Equals(input.AllowedTarget)
                ) && 
                (
                    this.Create == input.Create ||
                    this.Create.Equals(input.Create)
                ) && 
                (
                    this.Destroy == input.Destroy ||
                    this.Destroy.Equals(input.Destroy)
                ) && 
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
                hashCode = (hashCode * 59) + this.AllowedTarget.GetHashCode();
                hashCode = (hashCode * 59) + this.Create.GetHashCode();
                hashCode = (hashCode * 59) + this.Destroy.GetHashCode();
                hashCode = (hashCode * 59) + this.Read.GetHashCode();
                hashCode = (hashCode * 59) + this.Update.GetHashCode();
                return hashCode;
            }
        }

    }

}
