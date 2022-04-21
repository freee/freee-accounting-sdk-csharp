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
    /// TagParams
    /// </summary>
    [DataContract(Name = "tagParams")]
    public partial class TagParams : IEquatable<TagParams>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TagParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TagParams" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="name">メモタグ名 (30文字以内) (required).</param>
        /// <param name="shortcut1">ショートカット1 (20文字以内).</param>
        /// <param name="shortcut2">ショートカット2 (20文字以内).</param>
        public TagParams(int companyId = default(int), string name = default(string), string shortcut1 = default(string), string shortcut2 = default(string))
        {
            this.CompanyId = companyId;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for TagParams and cannot be null");
            }
            this.Name = name;
            this.Shortcut1 = shortcut1;
            this.Shortcut2 = shortcut2;
        }

        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name = "company_id", IsRequired = true, EmitDefaultValue = false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// メモタグ名 (30文字以内)
        /// </summary>
        /// <value>メモタグ名 (30文字以内)</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// ショートカット1 (20文字以内)
        /// </summary>
        /// <value>ショートカット1 (20文字以内)</value>
        [DataMember(Name = "shortcut1", EmitDefaultValue = false)]
        public string Shortcut1 { get; set; }

        /// <summary>
        /// ショートカット2 (20文字以内)
        /// </summary>
        /// <value>ショートカット2 (20文字以内)</value>
        [DataMember(Name = "shortcut2", EmitDefaultValue = false)]
        public string Shortcut2 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TagParams {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Shortcut1: ").Append(Shortcut1).Append("\n");
            sb.Append("  Shortcut2: ").Append(Shortcut2).Append("\n");
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
            return this.Equals(input as TagParams);
        }

        /// <summary>
        /// Returns true if TagParams instances are equal
        /// </summary>
        /// <param name="input">Instance of TagParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TagParams input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Shortcut1 == input.Shortcut1 ||
                    (this.Shortcut1 != null &&
                    this.Shortcut1.Equals(input.Shortcut1))
                ) && 
                (
                    this.Shortcut2 == input.Shortcut2 ||
                    (this.Shortcut2 != null &&
                    this.Shortcut2.Equals(input.Shortcut2))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Shortcut1 != null)
                {
                    hashCode = (hashCode * 59) + this.Shortcut1.GetHashCode();
                }
                if (this.Shortcut2 != null)
                {
                    hashCode = (hashCode * 59) + this.Shortcut2.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
