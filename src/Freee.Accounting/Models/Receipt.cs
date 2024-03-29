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
    /// Receipt
    /// </summary>
    [DataContract(Name = "receipt")]
    public partial class Receipt : IEquatable<Receipt>
    {
        /// <summary>
        /// この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 書類の種類（receipt: 領収書、invoice: 請求書、other: その他、null: OCR解析結果が保存されている時等） 
        /// </summary>
        /// <value>この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 書類の種類（receipt: 領収書、invoice: 請求書、other: その他、null: OCR解析結果が保存されている時等） </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DocumentTypeEnum
        {
            /// <summary>
            /// Enum Receipt for value: receipt
            /// </summary>
            [EnumMember(Value = "receipt")]
            Receipt = 1,

            /// <summary>
            /// Enum Invoice for value: invoice
            /// </summary>
            [EnumMember(Value = "invoice")]
            Invoice = 2,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 3

        }


        /// <summary>
        /// この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 書類の種類（receipt: 領収書、invoice: 請求書、other: その他、null: OCR解析結果が保存されている時等） 
        /// </summary>
        /// <value>この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 書類の種類（receipt: 領収書、invoice: 請求書、other: その他、null: OCR解析結果が保存されている時等） </value>
        [DataMember(Name = "document_type", EmitDefaultValue = true)]
        public DocumentTypeEnum? DocumentType { get; set; }
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
        /// この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 適格請求書等（qualified: 該当する、not_qualified: 該当しない、unselected: 未選択、null: OCR解析結果が保存されている時等） 
        /// </summary>
        /// <value>この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 適格請求書等（qualified: 該当する、not_qualified: 該当しない、unselected: 未選択、null: OCR解析結果が保存されている時等） </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum QualifiedInvoiceEnum
        {
            /// <summary>
            /// Enum Qualified for value: qualified
            /// </summary>
            [EnumMember(Value = "qualified")]
            Qualified = 1,

            /// <summary>
            /// Enum NotQualified for value: not_qualified
            /// </summary>
            [EnumMember(Value = "not_qualified")]
            NotQualified = 2,

            /// <summary>
            /// Enum Unselected for value: unselected
            /// </summary>
            [EnumMember(Value = "unselected")]
            Unselected = 3

        }


        /// <summary>
        /// この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 適格請求書等（qualified: 該当する、not_qualified: 該当しない、unselected: 未選択、null: OCR解析結果が保存されている時等） 
        /// </summary>
        /// <value>この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 適格請求書等（qualified: 該当する、not_qualified: 該当しない、unselected: 未選択、null: OCR解析結果が保存されている時等） </value>
        [DataMember(Name = "qualified_invoice", EmitDefaultValue = true)]
        public QualifiedInvoiceEnum? QualifiedInvoice { get; set; }
        /// <summary>
        /// ステータス(confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Confirmed for value: confirmed
            /// </summary>
            [EnumMember(Value = "confirmed")]
            Confirmed = 1,

            /// <summary>
            /// Enum Deleted for value: deleted
            /// </summary>
            [EnumMember(Value = "deleted")]
            Deleted = 2,

            /// <summary>
            /// Enum Ignored for value: ignored
            /// </summary>
            [EnumMember(Value = "ignored")]
            Ignored = 3

        }


        /// <summary>
        /// ステータス(confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Receipt() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt" /> class.
        /// </summary>
        /// <param name="createdAt">作成日時（ISO8601形式） (required).</param>
        /// <param name="description">メモ.</param>
        /// <param name="documentType">この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 書類の種類（receipt: 領収書、invoice: 請求書、other: その他、null: OCR解析結果が保存されている時等） .</param>
        /// <param name="fileSrc">ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。） &lt;br&gt; &lt;br&gt; file_srcは廃止予定の属性になります。&lt;br&gt; file_srcに替わり、証憑ファイルのダウンロード APIをご利用ください。&lt;br&gt; 証憑ファイルのダウンロードAPIを利用することで、以下のようになります。 &lt;ul&gt;   &lt;li&gt;アプリケーション利用者はfreee APIアプリケーションにログインしていれば、証憑ダウンロード毎にfreeeに改めてログインすることなくファイルが参照できるようになります。&lt;/li&gt; &lt;/ul&gt; (required).</param>
        /// <param name="id">ファイルボックス（証憑ファイル）ID (required).</param>
        /// <param name="invoiceRegistrationNumber">この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 インボイス制度適格請求書発行事業者登録番号（null: OCR解析結果が保存されている時等） - 先頭T数字13桁の固定14桁の文字列 &lt;a target&#x3D;\&quot;_blank\&quot; href&#x3D;\&quot;https://www.invoice-kohyo.nta.go.jp/index.html\&quot;&gt;国税庁インボイス制度適格請求書発行事業者公表サイト&lt;/a&gt; .</param>
        /// <param name="issueDate">発生日.</param>
        /// <param name="mimeType">MIMEタイプ (required).</param>
        /// <param name="origin">アップロード元種別 (required).</param>
        /// <param name="qualifiedInvoice">この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 適格請求書等（qualified: 該当する、not_qualified: 該当しない、unselected: 未選択、null: OCR解析結果が保存されている時等） .</param>
        /// <param name="receiptMetadatum">receiptMetadatum.</param>
        /// <param name="status">ステータス(confirmed:確認済み、deleted:削除済み、ignored:無視) (required).</param>
        /// <param name="user">user (required).</param>
        public Receipt(string createdAt = default(string), string description = default(string), DocumentTypeEnum? documentType = default(DocumentTypeEnum?), string fileSrc = default(string), int id = default(int), string invoiceRegistrationNumber = default(string), string issueDate = default(string), string mimeType = default(string), OriginEnum origin = default(OriginEnum), QualifiedInvoiceEnum? qualifiedInvoice = default(QualifiedInvoiceEnum?), DealReceiptMetadatum receiptMetadatum = default(DealReceiptMetadatum), StatusEnum status = default(StatusEnum), DealUser user = default(DealUser))
        {
            // to ensure "createdAt" is required (not null)
            if (createdAt == null) {
                throw new ArgumentNullException("createdAt is a required property for Receipt and cannot be null");
            }
            this.CreatedAt = createdAt;
            // to ensure "fileSrc" is required (not null)
            if (fileSrc == null) {
                throw new ArgumentNullException("fileSrc is a required property for Receipt and cannot be null");
            }
            this.FileSrc = fileSrc;
            this.Id = id;
            // to ensure "mimeType" is required (not null)
            if (mimeType == null) {
                throw new ArgumentNullException("mimeType is a required property for Receipt and cannot be null");
            }
            this.MimeType = mimeType;
            this.Origin = origin;
            this.Status = status;
            // to ensure "user" is required (not null)
            if (user == null) {
                throw new ArgumentNullException("user is a required property for Receipt and cannot be null");
            }
            this.User = user;
            this.Description = description;
            this.DocumentType = documentType;
            this.InvoiceRegistrationNumber = invoiceRegistrationNumber;
            this.IssueDate = issueDate;
            this.QualifiedInvoice = qualifiedInvoice;
            this.ReceiptMetadatum = receiptMetadatum;
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
        /// ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。） &lt;br&gt; &lt;br&gt; file_srcは廃止予定の属性になります。&lt;br&gt; file_srcに替わり、証憑ファイルのダウンロード APIをご利用ください。&lt;br&gt; 証憑ファイルのダウンロードAPIを利用することで、以下のようになります。 &lt;ul&gt;   &lt;li&gt;アプリケーション利用者はfreee APIアプリケーションにログインしていれば、証憑ダウンロード毎にfreeeに改めてログインすることなくファイルが参照できるようになります。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <value>ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。） &lt;br&gt; &lt;br&gt; file_srcは廃止予定の属性になります。&lt;br&gt; file_srcに替わり、証憑ファイルのダウンロード APIをご利用ください。&lt;br&gt; 証憑ファイルのダウンロードAPIを利用することで、以下のようになります。 &lt;ul&gt;   &lt;li&gt;アプリケーション利用者はfreee APIアプリケーションにログインしていれば、証憑ダウンロード毎にfreeeに改めてログインすることなくファイルが参照できるようになります。&lt;/li&gt; &lt;/ul&gt;</value>
        [DataMember(Name = "file_src", IsRequired = true, EmitDefaultValue = false)]
        [Obsolete]
        public string FileSrc { get; set; }

        /// <summary>
        /// ファイルボックス（証憑ファイル）ID
        /// </summary>
        /// <value>ファイルボックス（証憑ファイル）ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 インボイス制度適格請求書発行事業者登録番号（null: OCR解析結果が保存されている時等） - 先頭T数字13桁の固定14桁の文字列 &lt;a target&#x3D;\&quot;_blank\&quot; href&#x3D;\&quot;https://www.invoice-kohyo.nta.go.jp/index.html\&quot;&gt;国税庁インボイス制度適格請求書発行事業者公表サイト&lt;/a&gt; 
        /// </summary>
        /// <value>この項目はインボイス制度で利用する項目です。2023年4月頃から利用できる予定です。 インボイス制度適格請求書発行事業者登録番号（null: OCR解析結果が保存されている時等） - 先頭T数字13桁の固定14桁の文字列 &lt;a target&#x3D;\&quot;_blank\&quot; href&#x3D;\&quot;https://www.invoice-kohyo.nta.go.jp/index.html\&quot;&gt;国税庁インボイス制度適格請求書発行事業者公表サイト&lt;/a&gt; </value>
        [DataMember(Name = "invoice_registration_number", EmitDefaultValue = true)]
        public string InvoiceRegistrationNumber { get; set; }

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
        /// Gets or Sets ReceiptMetadatum
        /// </summary>
        [DataMember(Name = "receipt_metadatum", EmitDefaultValue = false)]
        public DealReceiptMetadatum ReceiptMetadatum { get; set; }

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
            sb.Append("class Receipt {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DocumentType: ").Append(DocumentType).Append("\n");
            sb.Append("  FileSrc: ").Append(FileSrc).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceRegistrationNumber: ").Append(InvoiceRegistrationNumber).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Origin: ").Append(Origin).Append("\n");
            sb.Append("  QualifiedInvoice: ").Append(QualifiedInvoice).Append("\n");
            sb.Append("  ReceiptMetadatum: ").Append(ReceiptMetadatum).Append("\n");
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
            return this.Equals(input as Receipt);
        }

        /// <summary>
        /// Returns true if Receipt instances are equal
        /// </summary>
        /// <param name="input">Instance of Receipt to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Receipt input)
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
                    this.DocumentType == input.DocumentType ||
                    this.DocumentType.Equals(input.DocumentType)
                ) && 
                (
                    this.FileSrc == input.FileSrc ||
                    (this.FileSrc != null &&
                    this.FileSrc.Equals(input.FileSrc))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.InvoiceRegistrationNumber == input.InvoiceRegistrationNumber ||
                    (this.InvoiceRegistrationNumber != null &&
                    this.InvoiceRegistrationNumber.Equals(input.InvoiceRegistrationNumber))
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
                    this.QualifiedInvoice == input.QualifiedInvoice ||
                    this.QualifiedInvoice.Equals(input.QualifiedInvoice)
                ) && 
                (
                    this.ReceiptMetadatum == input.ReceiptMetadatum ||
                    (this.ReceiptMetadatum != null &&
                    this.ReceiptMetadatum.Equals(input.ReceiptMetadatum))
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
                hashCode = (hashCode * 59) + this.DocumentType.GetHashCode();
                if (this.FileSrc != null)
                {
                    hashCode = (hashCode * 59) + this.FileSrc.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.InvoiceRegistrationNumber != null)
                {
                    hashCode = (hashCode * 59) + this.InvoiceRegistrationNumber.GetHashCode();
                }
                if (this.IssueDate != null)
                {
                    hashCode = (hashCode * 59) + this.IssueDate.GetHashCode();
                }
                if (this.MimeType != null)
                {
                    hashCode = (hashCode * 59) + this.MimeType.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Origin.GetHashCode();
                hashCode = (hashCode * 59) + this.QualifiedInvoice.GetHashCode();
                if (this.ReceiptMetadatum != null)
                {
                    hashCode = (hashCode * 59) + this.ReceiptMetadatum.GetHashCode();
                }
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
