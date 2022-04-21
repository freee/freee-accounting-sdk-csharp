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
    /// ExpenseApplicationLineTemplate
    /// </summary>
    [DataContract(Name = "expense_application_line_template")]
    public partial class ExpenseApplicationLineTemplate : IEquatable<ExpenseApplicationLineTemplate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ExpenseApplicationLineTemplate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplate" /> class.
        /// </summary>
        /// <param name="accountItemId">勘定科目ID.</param>
        /// <param name="accountItemName">勘定科目名 (required).</param>
        /// <param name="description">経費科目の説明.</param>
        /// <param name="id">経費科目ID (required).</param>
        /// <param name="lineDescription">内容の補足.</param>
        /// <param name="name">経費科目名 (required).</param>
        /// <param name="requiredReceipt">添付ファイルの必須/任意.</param>
        /// <param name="taxCode">税区分コード.</param>
        /// <param name="taxName">税区分名 (required).</param>
        public ExpenseApplicationLineTemplate(int accountItemId = default(int), string accountItemName = default(string), string description = default(string), int id = default(int), string lineDescription = default(string), string name = default(string), bool requiredReceipt = default(bool), int taxCode = default(int), string taxName = default(string))
        {
            // to ensure "accountItemName" is required (not null)
            if (accountItemName == null)
            {
                throw new ArgumentNullException("accountItemName is a required property for ExpenseApplicationLineTemplate and cannot be null");
            }
            this.AccountItemName = accountItemName;
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ExpenseApplicationLineTemplate and cannot be null");
            }
            this.Name = name;
            // to ensure "taxName" is required (not null)
            if (taxName == null)
            {
                throw new ArgumentNullException("taxName is a required property for ExpenseApplicationLineTemplate and cannot be null");
            }
            this.TaxName = taxName;
            this.AccountItemId = accountItemId;
            this.Description = description;
            this.LineDescription = lineDescription;
            this.RequiredReceipt = requiredReceipt;
            this.TaxCode = taxCode;
        }

        /// <summary>
        /// 勘定科目ID
        /// </summary>
        /// <value>勘定科目ID</value>
        [DataMember(Name = "account_item_id", EmitDefaultValue = false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 勘定科目名
        /// </summary>
        /// <value>勘定科目名</value>
        [DataMember(Name = "account_item_name", IsRequired = true, EmitDefaultValue = false)]
        public string AccountItemName { get; set; }

        /// <summary>
        /// 経費科目の説明
        /// </summary>
        /// <value>経費科目の説明</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// 経費科目ID
        /// </summary>
        /// <value>経費科目ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 内容の補足
        /// </summary>
        /// <value>内容の補足</value>
        [DataMember(Name = "line_description", EmitDefaultValue = false)]
        public string LineDescription { get; set; }

        /// <summary>
        /// 経費科目名
        /// </summary>
        /// <value>経費科目名</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// 添付ファイルの必須/任意
        /// </summary>
        /// <value>添付ファイルの必須/任意</value>
        [DataMember(Name = "required_receipt", EmitDefaultValue = true)]
        public bool RequiredReceipt { get; set; }

        /// <summary>
        /// 税区分コード
        /// </summary>
        /// <value>税区分コード</value>
        [DataMember(Name = "tax_code", EmitDefaultValue = false)]
        public int TaxCode { get; set; }

        /// <summary>
        /// 税区分名
        /// </summary>
        /// <value>税区分名</value>
        [DataMember(Name = "tax_name", IsRequired = true, EmitDefaultValue = false)]
        public string TaxName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExpenseApplicationLineTemplate {\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  AccountItemName: ").Append(AccountItemName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LineDescription: ").Append(LineDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RequiredReceipt: ").Append(RequiredReceipt).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxName: ").Append(TaxName).Append("\n");
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
            return this.Equals(input as ExpenseApplicationLineTemplate);
        }

        /// <summary>
        /// Returns true if ExpenseApplicationLineTemplate instances are equal
        /// </summary>
        /// <param name="input">Instance of ExpenseApplicationLineTemplate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExpenseApplicationLineTemplate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.AccountItemName == input.AccountItemName ||
                    (this.AccountItemName != null &&
                    this.AccountItemName.Equals(input.AccountItemName))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.LineDescription == input.LineDescription ||
                    (this.LineDescription != null &&
                    this.LineDescription.Equals(input.LineDescription))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.RequiredReceipt == input.RequiredReceipt ||
                    this.RequiredReceipt.Equals(input.RequiredReceipt)
                ) && 
                (
                    this.TaxCode == input.TaxCode ||
                    this.TaxCode.Equals(input.TaxCode)
                ) && 
                (
                    this.TaxName == input.TaxName ||
                    (this.TaxName != null &&
                    this.TaxName.Equals(input.TaxName))
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
                hashCode = (hashCode * 59) + this.AccountItemId.GetHashCode();
                if (this.AccountItemName != null)
                {
                    hashCode = (hashCode * 59) + this.AccountItemName.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.LineDescription != null)
                {
                    hashCode = (hashCode * 59) + this.LineDescription.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RequiredReceipt.GetHashCode();
                hashCode = (hashCode * 59) + this.TaxCode.GetHashCode();
                if (this.TaxName != null)
                {
                    hashCode = (hashCode * 59) + this.TaxName.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
