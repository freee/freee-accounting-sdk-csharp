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
    /// SelectablesIndexResponseAccountCategories
    /// </summary>
    [DataContract(Name = "selectablesIndexResponse_account_categories")]
    public partial class SelectablesIndexResponseAccountCategories : IEquatable<SelectablesIndexResponseAccountCategories>
    {
        /// <summary>
        /// 収支
        /// </summary>
        /// <value>収支</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BalanceEnum
        {
            /// <summary>
            /// Enum Expense for value: expense
            /// </summary>
            [EnumMember(Value = "expense")]
            Expense = 1,

            /// <summary>
            /// Enum Income for value: income
            /// </summary>
            [EnumMember(Value = "income")]
            Income = 2

        }


        /// <summary>
        /// 収支
        /// </summary>
        /// <value>収支</value>
        [DataMember(Name = "balance", IsRequired = true, EmitDefaultValue = false)]
        public BalanceEnum Balance { get; set; }
        /// <summary>
        /// 事業形態（個人事業主: personal、法人: corporate）
        /// </summary>
        /// <value>事業形態（個人事業主: personal、法人: corporate）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrgCodeEnum
        {
            /// <summary>
            /// Enum Personal for value: personal
            /// </summary>
            [EnumMember(Value = "personal")]
            Personal = 1,

            /// <summary>
            /// Enum Corporate for value: corporate
            /// </summary>
            [EnumMember(Value = "corporate")]
            Corporate = 2

        }


        /// <summary>
        /// 事業形態（個人事業主: personal、法人: corporate）
        /// </summary>
        /// <value>事業形態（個人事業主: personal、法人: corporate）</value>
        [DataMember(Name = "org_code", IsRequired = true, EmitDefaultValue = false)]
        public OrgCodeEnum OrgCode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountCategories" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SelectablesIndexResponseAccountCategories() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectablesIndexResponseAccountCategories" /> class.
        /// </summary>
        /// <param name="accountItems">勘定科目の一覧 (required).</param>
        /// <param name="balance">収支 (required).</param>
        /// <param name="desc">カテゴリーの説明.</param>
        /// <param name="orgCode">事業形態（個人事業主: personal、法人: corporate） (required).</param>
        /// <param name="role">カテゴリーコード (required).</param>
        /// <param name="title">カテゴリー名 (required).</param>
        public SelectablesIndexResponseAccountCategories(List<SelectablesIndexResponseAccountItems> accountItems = default(List<SelectablesIndexResponseAccountItems>), BalanceEnum balance = default(BalanceEnum), string desc = default(string), OrgCodeEnum orgCode = default(OrgCodeEnum), string role = default(string), string title = default(string))
        {
            // to ensure "accountItems" is required (not null)
            if (accountItems == null)
            {
                throw new ArgumentNullException("accountItems is a required property for SelectablesIndexResponseAccountCategories and cannot be null");
            }
            this.AccountItems = accountItems;
            this.Balance = balance;
            this.OrgCode = orgCode;
            // to ensure "role" is required (not null)
            if (role == null)
            {
                throw new ArgumentNullException("role is a required property for SelectablesIndexResponseAccountCategories and cannot be null");
            }
            this.Role = role;
            // to ensure "title" is required (not null)
            if (title == null)
            {
                throw new ArgumentNullException("title is a required property for SelectablesIndexResponseAccountCategories and cannot be null");
            }
            this.Title = title;
            this.Desc = desc;
        }

        /// <summary>
        /// 勘定科目の一覧
        /// </summary>
        /// <value>勘定科目の一覧</value>
        [DataMember(Name = "account_items", IsRequired = true, EmitDefaultValue = false)]
        public List<SelectablesIndexResponseAccountItems> AccountItems { get; set; }

        /// <summary>
        /// カテゴリーの説明
        /// </summary>
        /// <value>カテゴリーの説明</value>
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string Desc { get; set; }

        /// <summary>
        /// カテゴリーコード
        /// </summary>
        /// <value>カテゴリーコード</value>
        [DataMember(Name = "role", IsRequired = true, EmitDefaultValue = false)]
        public string Role { get; set; }

        /// <summary>
        /// カテゴリー名
        /// </summary>
        /// <value>カテゴリー名</value>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectablesIndexResponseAccountCategories {\n");
            sb.Append("  AccountItems: ").Append(AccountItems).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Desc: ").Append(Desc).Append("\n");
            sb.Append("  OrgCode: ").Append(OrgCode).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
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
            return this.Equals(input as SelectablesIndexResponseAccountCategories);
        }

        /// <summary>
        /// Returns true if SelectablesIndexResponseAccountCategories instances are equal
        /// </summary>
        /// <param name="input">Instance of SelectablesIndexResponseAccountCategories to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SelectablesIndexResponseAccountCategories input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountItems == input.AccountItems ||
                    this.AccountItems != null &&
                    input.AccountItems != null &&
                    this.AccountItems.SequenceEqual(input.AccountItems)
                ) && 
                (
                    this.Balance == input.Balance ||
                    this.Balance.Equals(input.Balance)
                ) && 
                (
                    this.Desc == input.Desc ||
                    (this.Desc != null &&
                    this.Desc.Equals(input.Desc))
                ) && 
                (
                    this.OrgCode == input.OrgCode ||
                    this.OrgCode.Equals(input.OrgCode)
                ) && 
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
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
                if (this.AccountItems != null)
                {
                    hashCode = (hashCode * 59) + this.AccountItems.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Balance.GetHashCode();
                if (this.Desc != null)
                {
                    hashCode = (hashCode * 59) + this.Desc.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.OrgCode.GetHashCode();
                if (this.Role != null)
                {
                    hashCode = (hashCode * 59) + this.Role.GetHashCode();
                }
                if (this.Title != null)
                {
                    hashCode = (hashCode * 59) + this.Title.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
