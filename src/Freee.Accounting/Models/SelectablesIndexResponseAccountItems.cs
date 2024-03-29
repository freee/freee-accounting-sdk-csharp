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
    /// SelectablesIndexResponseAccountItems
    /// </summary>
    [DataContract(Name = "selectablesIndexResponse_account_items")]
    public partial class SelectablesIndexResponseAccountItems : IEquatable<SelectablesIndexResponseAccountItems>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountItems" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SelectablesIndexResponseAccountItems() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountItems" /> class.
        /// </summary>
        /// <param name="defaultTax">defaultTax.</param>
        /// <param name="desc">勘定科目の説明.</param>
        /// <param name="help">勘定科目の説明（詳細）.</param>
        /// <param name="id">勘定科目ID (required).</param>
        /// <param name="name">勘定科目.</param>
        /// <param name="shortcut">ショートカット.</param>
        public SelectablesIndexResponseAccountItems(SelectablesIndexResponseDefaultTax defaultTax = default(SelectablesIndexResponseDefaultTax), string desc = default(string), string help = default(string), int id = default(int), string name = default(string), string shortcut = default(string))
        {
            this.Id = id;
            this.DefaultTax = defaultTax;
            this.Desc = desc;
            this.Help = help;
            this.Name = name;
            this.Shortcut = shortcut;
        }

        /// <summary>
        /// Gets or Sets DefaultTax
        /// </summary>
        [DataMember(Name = "default_tax", EmitDefaultValue = false)]
        public SelectablesIndexResponseDefaultTax DefaultTax { get; set; }

        /// <summary>
        /// 勘定科目の説明
        /// </summary>
        /// <value>勘定科目の説明</value>
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string Desc { get; set; }

        /// <summary>
        /// 勘定科目の説明（詳細）
        /// </summary>
        /// <value>勘定科目の説明（詳細）</value>
        [DataMember(Name = "help", EmitDefaultValue = false)]
        public string Help { get; set; }

        /// <summary>
        /// 勘定科目ID
        /// </summary>
        /// <value>勘定科目ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 勘定科目
        /// </summary>
        /// <value>勘定科目</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// ショートカット
        /// </summary>
        /// <value>ショートカット</value>
        [DataMember(Name = "shortcut", EmitDefaultValue = false)]
        public string Shortcut { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectablesIndexResponseAccountItems {\n");
            sb.Append("  DefaultTax: ").Append(DefaultTax).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  Help: ").Append(Help).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Shortcut: ").Append(Shortcut).Append("\n");
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
            return this.Equals(input as SelectablesIndexResponseAccountItems);
        }

        /// <summary>
        /// Returns true if SelectablesIndexResponseAccountItems instances are equal
        /// </summary>
        /// <param name="input">Instance of SelectablesIndexResponseAccountItems to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SelectablesIndexResponseAccountItems input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.DefaultTax == input.DefaultTax ||
                    (this.DefaultTax != null &&
                    this.DefaultTax.Equals(input.DefaultTax))
                ) && 
                (
                    this.Desc == input.Desc ||
                    (this.Desc != null &&
                    this.Desc.Equals(input.Desc))
                ) && 
                (
                    this.Help == input.Help ||
                    (this.Help != null &&
                    this.Help.Equals(input.Help))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Shortcut == input.Shortcut ||
                    (this.Shortcut != null &&
                    this.Shortcut.Equals(input.Shortcut))
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
                if (this.DefaultTax != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultTax.GetHashCode();
                }
                if (this.Desc != null)
                {
                    hashCode = (hashCode * 59) + this.Desc.GetHashCode();
                }
                if (this.Help != null)
                {
                    hashCode = (hashCode * 59) + this.Help.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Shortcut != null)
                {
                    hashCode = (hashCode * 59) + this.Shortcut.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
