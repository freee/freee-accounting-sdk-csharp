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
    /// DealCreateResponseDealReceipts
    /// </summary>
    [DataContract(Name = "dealCreateResponse_deal_receipts")]
    public partial class DealCreateResponseDealReceipts : IEquatable<DealCreateResponseDealReceipts>
    {
        /// <summary>
        /// アップロード元種別
        /// </summary>
        /// <value>アップロード元種別</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OriginEnum
        {
            /// <summary>
            /// Enum Unknown for value: unknown
            /// </summary>
            [EnumMember(Value = "unknown")]
            Unknown = 1,

            /// <summary>
            /// Enum Web for value: web
            /// </summary>
            [EnumMember(Value = "web")]
            Web = 2,

            /// <summary>
            /// Enum MobileCamera for value: mobile_camera
            /// </summary>
            [EnumMember(Value = "mobile_camera")]
            MobileCamera = 3,

            /// <summary>
            /// Enum MobileAlbum for value: mobile_album
            /// </summary>
            [EnumMember(Value = "mobile_album")]
            MobileAlbum = 4,

            /// <summary>
            /// Enum Scansnap for value: scansnap
            /// </summary>
            [EnumMember(Value = "scansnap")]
            Scansnap = 5,

            /// <summary>
            /// Enum Scannable for value: scannable
            /// </summary>
            [EnumMember(Value = "scannable")]
            Scannable = 6,

            /// <summary>
            /// Enum Dropbox for value: dropbox
            /// </summary>
            [EnumMember(Value = "dropbox")]
            Dropbox = 7,

            /// <summary>
            /// Enum Mail for value: mail
            /// </summary>
            [EnumMember(Value = "mail")]
            Mail = 8,

            /// <summary>
            /// Enum SafetyContactFile for value: safety_contact_file
            /// </summary>
            [EnumMember(Value = "safety_contact_file")]
            SafetyContactFile = 9,

            /// <summary>
            /// Enum PublicApi for value: public_api
            /// </summary>
            [EnumMember(Value = "public_api")]
            PublicApi = 10

        }


        /// <summary>
        /// アップロード元種別
        /// </summary>
        /// <value>アップロード元種別</value>
        [DataMember(Name = "origin", IsRequired = true, EmitDefaultValue = false)]
        public OriginEnum Origin { get; set; }
        /// <summary>
        /// ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Unconfirmed for value: unconfirmed
            /// </summary>
            [EnumMember(Value = "unconfirmed")]
            Unconfirmed = 1,

            /// <summary>
            /// Enum Confirmed for value: confirmed
            /// </summary>
            [EnumMember(Value = "confirmed")]
            Confirmed = 2,

            /// <summary>
            /// Enum Deleted for value: deleted
            /// </summary>
            [EnumMember(Value = "deleted")]
            Deleted = 3,

            /// <summary>
            /// Enum Ignored for value: ignored
            /// </summary>
            [EnumMember(Value = "ignored")]
            Ignored = 4

        }


        /// <summary>
        /// ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateResponseDealReceipts" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DealCreateResponseDealReceipts() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateResponseDealReceipts" /> class.
        /// </summary>
        /// <param name="createdAt">作成日時（ISO8601形式） (required).</param>
        /// <param name="description">メモ.</param>
        /// <param name="id">証憑ファイルID（ファイルボックスのファイルID） (required).</param>
        /// <param name="issueDate">発生日.</param>
        /// <param name="mimeType">MIMEタイプ (required).</param>
        /// <param name="origin">アップロード元種別 (required).</param>
        /// <param name="status">ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視) (required).</param>
        /// <param name="user">user (required).</param>
        public DealCreateResponseDealReceipts(string createdAt = default(string), string description = default(string), int id = default(int), string issueDate = default(string), string mimeType = default(string), OriginEnum origin = default(OriginEnum), StatusEnum status = default(StatusEnum), DealUser user = default(DealUser))
        {
            // to ensure "createdAt" is required (not null)
            if (createdAt == null) {
                throw new ArgumentNullException("createdAt is a required property for DealCreateResponseDealReceipts and cannot be null");
            }
            this.CreatedAt = createdAt;
            this.Id = id;
            // to ensure "mimeType" is required (not null)
            if (mimeType == null) {
                throw new ArgumentNullException("mimeType is a required property for DealCreateResponseDealReceipts and cannot be null");
            }
            this.MimeType = mimeType;
            this.Origin = origin;
            this.Status = status;
            // to ensure "user" is required (not null)
            if (user == null) {
                throw new ArgumentNullException("user is a required property for DealCreateResponseDealReceipts and cannot be null");
            }
            this.User = user;
            this.Description = description;
            this.IssueDate = issueDate;
        }

        /// <summary>
        /// 作成日時（ISO8601形式）
        /// </summary>
        /// <value>作成日時（ISO8601形式）</value>
        [DataMember(Name = "created_at", IsRequired = true, EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        /// <value>メモ</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// 証憑ファイルID（ファイルボックスのファイルID）
        /// </summary>
        /// <value>証憑ファイルID（ファイルボックスのファイルID）</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 発生日
        /// </summary>
        /// <value>発生日</value>
        [DataMember(Name = "issue_date", EmitDefaultValue = false)]
        public string IssueDate { get; set; }

        /// <summary>
        /// MIMEタイプ
        /// </summary>
        /// <value>MIMEタイプ</value>
        [DataMember(Name = "mime_type", IsRequired = true, EmitDefaultValue = false)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", IsRequired = true, EmitDefaultValue = false)]
        public DealUser User { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DealCreateResponseDealReceipts {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Origin: ").Append(Origin).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
            return this.Equals(input as DealCreateResponseDealReceipts);
        }

        /// <summary>
        /// Returns true if DealCreateResponseDealReceipts instances are equal
        /// </summary>
        /// <param name="input">Instance of DealCreateResponseDealReceipts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DealCreateResponseDealReceipts input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
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
                    this.IssueDate == input.IssueDate ||
                    (this.IssueDate != null &&
                    this.IssueDate.Equals(input.IssueDate))
                ) && 
                (
                    this.MimeType == input.MimeType ||
                    (this.MimeType != null &&
                    this.MimeType.Equals(input.MimeType))
                ) && 
                (
                    this.Origin == input.Origin ||
                    this.Origin.Equals(input.Origin)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
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
                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.IssueDate != null)
                {
                    hashCode = (hashCode * 59) + this.IssueDate.GetHashCode();
                }
                if (this.MimeType != null)
                {
                    hashCode = (hashCode * 59) + this.MimeType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Origin.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                if (this.User != null)
                {
                    hashCode = (hashCode * 59) + this.User.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}