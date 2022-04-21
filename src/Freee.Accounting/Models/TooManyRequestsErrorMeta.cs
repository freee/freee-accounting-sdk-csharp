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
    /// TooManyRequestsErrorMeta
    /// </summary>
    [DataContract(Name = "tooManyRequestsError_meta")]
    public partial class TooManyRequestsErrorMeta : IEquatable<TooManyRequestsErrorMeta>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyRequestsErrorMeta" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TooManyRequestsErrorMeta() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TooManyRequestsErrorMeta" /> class.
        /// </summary>
        /// <param name="limit">設定されている上限値 (required).</param>
        /// <param name="period">使用回数をカウントする期間 (秒).</param>
        /// <param name="remaining">上限に達するまでの使用可能回数 (required).</param>
        /// <param name="reset">（上限値に達した場合）使用回数がリセットされる時刻 (required).</param>
        public TooManyRequestsErrorMeta(int limit = default(int), int period = default(int), int remaining = default(int), string reset = default(string))
        {
            this.Limit = limit;
            this.Remaining = remaining;
            // to ensure "reset" is required (not null)
            if (reset == null)
            {
                throw new ArgumentNullException("reset is a required property for TooManyRequestsErrorMeta and cannot be null");
            }
            this.Reset = reset;
            this.Period = period;
        }

        /// <summary>
        /// 設定されている上限値
        /// </summary>
        /// <value>設定されている上限値</value>
        [DataMember(Name = "limit", IsRequired = true, EmitDefaultValue = false)]
        public int Limit { get; set; }

        /// <summary>
        /// 使用回数をカウントする期間 (秒)
        /// </summary>
        /// <value>使用回数をカウントする期間 (秒)</value>
        [DataMember(Name = "period", EmitDefaultValue = false)]
        public int Period { get; set; }

        /// <summary>
        /// 上限に達するまでの使用可能回数
        /// </summary>
        /// <value>上限に達するまでの使用可能回数</value>
        [DataMember(Name = "remaining", IsRequired = true, EmitDefaultValue = false)]
        public int Remaining { get; set; }

        /// <summary>
        /// （上限値に達した場合）使用回数がリセットされる時刻
        /// </summary>
        /// <value>（上限値に達した場合）使用回数がリセットされる時刻</value>
        [DataMember(Name = "reset", IsRequired = true, EmitDefaultValue = false)]
        public string Reset { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TooManyRequestsErrorMeta {\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Period: ").Append(Period).Append("\n");
            sb.Append("  Remaining: ").Append(Remaining).Append("\n");
            sb.Append("  Reset: ").Append(Reset).Append("\n");
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
            return this.Equals(input as TooManyRequestsErrorMeta);
        }

        /// <summary>
        /// Returns true if TooManyRequestsErrorMeta instances are equal
        /// </summary>
        /// <param name="input">Instance of TooManyRequestsErrorMeta to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TooManyRequestsErrorMeta input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Limit == input.Limit ||
                    this.Limit.Equals(input.Limit)
                ) && 
                (
                    this.Period == input.Period ||
                    this.Period.Equals(input.Period)
                ) && 
                (
                    this.Remaining == input.Remaining ||
                    this.Remaining.Equals(input.Remaining)
                ) && 
                (
                    this.Reset == input.Reset ||
                    (this.Reset != null &&
                    this.Reset.Equals(input.Reset))
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
                hashCode = (hashCode * 59) + this.Limit.GetHashCode();
                hashCode = (hashCode * 59) + this.Period.GetHashCode();
                hashCode = (hashCode * 59) + this.Remaining.GetHashCode();
                if (this.Reset != null)
                {
                    hashCode = (hashCode * 59) + this.Reset.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
