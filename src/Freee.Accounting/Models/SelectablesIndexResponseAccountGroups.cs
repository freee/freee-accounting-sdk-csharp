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
    /// SelectablesIndexResponseAccountGroups
    /// </summary>
    [DataContract(Name = "selectablesIndexResponse_account_groups")]
    public partial class SelectablesIndexResponseAccountGroups : IEquatable<SelectablesIndexResponseAccountGroups>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountGroups" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SelectablesIndexResponseAccountGroups() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountGroups" /> class.
        /// </summary>
        /// <param name="accountCategoryId">勘定科目カテゴリーID (required).</param>
        /// <param name="accountStructureId">年度ID (required).</param>
        /// <param name="createdAt">作成日時.</param>
        /// <param name="detailType">詳細パラメータの種類.</param>
        /// <param name="id">決算書表示名（小カテゴリー）ID (required).</param>
        /// <param name="index">並び順 (required).</param>
        /// <param name="name">決算書表示名 (required).</param>
        /// <param name="updatedAt">更新日時.</param>
        public SelectablesIndexResponseAccountGroups(int accountCategoryId = default(int), int accountStructureId = default(int), string createdAt = default(string), int detailType = default(int), int id = default(int), int index = default(int), string name = default(string), string updatedAt = default(string))
        {
            this.AccountCategoryId = accountCategoryId;
            this.AccountStructureId = accountStructureId;
            this.Id = id;
            this.Index = index;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for SelectablesIndexResponseAccountGroups and cannot be null");
            }
            this.Name = name;
            this.CreatedAt = createdAt;
            this.DetailType = detailType;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 勘定科目カテゴリーID
        /// </summary>
        /// <value>勘定科目カテゴリーID</value>
        [DataMember(Name = "account_category_id", IsRequired = true, EmitDefaultValue = false)]
        public int AccountCategoryId { get; set; }

        /// <summary>
        /// 年度ID
        /// </summary>
        /// <value>年度ID</value>
        [DataMember(Name = "account_structure_id", IsRequired = true, EmitDefaultValue = false)]
        public int AccountStructureId { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        /// <value>作成日時</value>
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 詳細パラメータの種類
        /// </summary>
        /// <value>詳細パラメータの種類</value>
        [DataMember(Name = "detail_type", EmitDefaultValue = false)]
        public int DetailType { get; set; }

        /// <summary>
        /// 決算書表示名（小カテゴリー）ID
        /// </summary>
        /// <value>決算書表示名（小カテゴリー）ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 並び順
        /// </summary>
        /// <value>並び順</value>
        [DataMember(Name = "index", IsRequired = true, EmitDefaultValue = false)]
        public int Index { get; set; }

        /// <summary>
        /// 決算書表示名
        /// </summary>
        /// <value>決算書表示名</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        /// <value>更新日時</value>
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectablesIndexResponseAccountGroups {\n");
            sb.Append("  AccountCategoryId: ").Append(AccountCategoryId).Append("\n");
            sb.Append("  AccountStructureId: ").Append(AccountStructureId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  DetailType: ").Append(DetailType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
            return this.Equals(input as SelectablesIndexResponseAccountGroups);
        }

        /// <summary>
        /// Returns true if SelectablesIndexResponseAccountGroups instances are equal
        /// </summary>
        /// <param name="input">Instance of SelectablesIndexResponseAccountGroups to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SelectablesIndexResponseAccountGroups input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountCategoryId == input.AccountCategoryId ||
                    this.AccountCategoryId.Equals(input.AccountCategoryId)
                ) && 
                (
                    this.AccountStructureId == input.AccountStructureId ||
                    this.AccountStructureId.Equals(input.AccountStructureId)
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.DetailType == input.DetailType ||
                    this.DetailType.Equals(input.DetailType)
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Index == input.Index ||
                    this.Index.Equals(input.Index)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
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
                hashCode = (hashCode * 59) + this.AccountCategoryId.GetHashCode();
                hashCode = (hashCode * 59) + this.AccountStructureId.GetHashCode();
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DetailType.GetHashCode();
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
