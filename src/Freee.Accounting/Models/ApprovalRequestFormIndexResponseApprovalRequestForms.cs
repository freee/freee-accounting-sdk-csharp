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
    /// ApprovalRequestFormIndexResponseApprovalRequestForms
    /// </summary>
    [DataContract(Name = "approvalRequestFormIndexResponse_approval_request_forms")]
    public partial class ApprovalRequestFormIndexResponseApprovalRequestForms : IEquatable<ApprovalRequestFormIndexResponseApprovalRequestForms>
    {
        /// <summary>
        /// ステータス(draft: 申請で使用しない、active: 申請で使用する、deleted: 削除済み)
        /// </summary>
        /// <value>ステータス(draft: 申請で使用しない、active: 申請で使用する、deleted: 削除済み)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Draft for value: draft
            /// </summary>
            [EnumMember(Value = "draft")]
            Draft = 1,

            /// <summary>
            /// Enum Active for value: active
            /// </summary>
            [EnumMember(Value = "active")]
            Active = 2,

            /// <summary>
            /// Enum Deleted for value: deleted
            /// </summary>
            [EnumMember(Value = "deleted")]
            Deleted = 3

        }


        /// <summary>
        /// ステータス(draft: 申請で使用しない、active: 申請で使用する、deleted: 削除済み)
        /// </summary>
        /// <value>ステータス(draft: 申請で使用しない、active: 申請で使用する、deleted: 削除済み)</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalRequestFormIndexResponseApprovalRequestForms" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApprovalRequestFormIndexResponseApprovalRequestForms() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalRequestFormIndexResponseApprovalRequestForms" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="createdDate">作成日時 (required).</param>
        /// <param name="description">申請フォームの説明 (required).</param>
        /// <param name="formOrder">表示順（申請者が選択する申請フォームの表示順を設定できます。小さい数ほど上位に表示されます。（0を除く整数のみ。マイナス不可）未入力の場合、表示順が後ろになります。同じ数字が入力された場合、登録順で表示されます。） (required).</param>
        /// <param name="id">申請フォームID (required).</param>
        /// <param name="name">申請フォームの名前 (required).</param>
        /// <param name="routeSettingCount">適用された経路数 (required).</param>
        /// <param name="status">ステータス(draft: 申請で使用しない、active: 申請で使用する、deleted: 削除済み) (required).</param>
        public ApprovalRequestFormIndexResponseApprovalRequestForms(int companyId = default(int), string createdDate = default(string), string description = default(string), int? formOrder = default(int?), int id = default(int), string name = default(string), int routeSettingCount = default(int), StatusEnum status = default(StatusEnum))
        {
            this.CompanyId = companyId;
            // to ensure "createdDate" is required (not null)
            if (createdDate == null)
            {
                throw new ArgumentNullException("createdDate is a required property for ApprovalRequestFormIndexResponseApprovalRequestForms and cannot be null");
            }
            this.CreatedDate = createdDate;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for ApprovalRequestFormIndexResponseApprovalRequestForms and cannot be null");
            }
            this.Description = description;
            // to ensure "formOrder" is required (not null)
            if (formOrder == null)
            {
                throw new ArgumentNullException("formOrder is a required property for ApprovalRequestFormIndexResponseApprovalRequestForms and cannot be null");
            }
            this.FormOrder = formOrder;
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ApprovalRequestFormIndexResponseApprovalRequestForms and cannot be null");
            }
            this.Name = name;
            this.RouteSettingCount = routeSettingCount;
            this.Status = status;
        }

        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name = "company_id", IsRequired = true, EmitDefaultValue = false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        /// <value>作成日時</value>
        [DataMember(Name = "created_date", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 申請フォームの説明
        /// </summary>
        /// <value>申請フォームの説明</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// 表示順（申請者が選択する申請フォームの表示順を設定できます。小さい数ほど上位に表示されます。（0を除く整数のみ。マイナス不可）未入力の場合、表示順が後ろになります。同じ数字が入力された場合、登録順で表示されます。）
        /// </summary>
        /// <value>表示順（申請者が選択する申請フォームの表示順を設定できます。小さい数ほど上位に表示されます。（0を除く整数のみ。マイナス不可）未入力の場合、表示順が後ろになります。同じ数字が入力された場合、登録順で表示されます。）</value>
        [DataMember(Name = "form_order", IsRequired = true, EmitDefaultValue = true)]
        public int? FormOrder { get; set; }

        /// <summary>
        /// 申請フォームID
        /// </summary>
        /// <value>申請フォームID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 申請フォームの名前
        /// </summary>
        /// <value>申請フォームの名前</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// 適用された経路数
        /// </summary>
        /// <value>適用された経路数</value>
        [DataMember(Name = "route_setting_count", IsRequired = true, EmitDefaultValue = false)]
        public int RouteSettingCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApprovalRequestFormIndexResponseApprovalRequestForms {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FormOrder: ").Append(FormOrder).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RouteSettingCount: ").Append(RouteSettingCount).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as ApprovalRequestFormIndexResponseApprovalRequestForms);
        }

        /// <summary>
        /// Returns true if ApprovalRequestFormIndexResponseApprovalRequestForms instances are equal
        /// </summary>
        /// <param name="input">Instance of ApprovalRequestFormIndexResponseApprovalRequestForms to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApprovalRequestFormIndexResponseApprovalRequestForms input)
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
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.FormOrder == input.FormOrder ||
                    (this.FormOrder != null &&
                    this.FormOrder.Equals(input.FormOrder))
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
                    this.RouteSettingCount == input.RouteSettingCount ||
                    this.RouteSettingCount.Equals(input.RouteSettingCount)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                if (this.CreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDate.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.FormOrder != null)
                {
                    hashCode = (hashCode * 59) + this.FormOrder.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RouteSettingCount.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                return hashCode;
            }
        }

    }

}
