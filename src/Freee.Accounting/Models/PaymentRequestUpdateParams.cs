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
    /// PaymentRequestUpdateParams
    /// </summary>
    [DataContract(Name = "paymentRequestUpdateParams")]
    public partial class PaymentRequestUpdateParams : IEquatable<PaymentRequestUpdateParams>
    {
        /// <summary>
        /// &#39;口座種別(ordinary: 普通、checking: 当座、earmarked: 納税準備預金、savings: 貯蓄、other: その他)&#39;&lt;br&gt; &#39;支払先指定時には無効&#39;&lt;br&gt; &#39;デフォルトは ordinary: 普通 です&#39; 
        /// </summary>
        /// <value>&#39;口座種別(ordinary: 普通、checking: 当座、earmarked: 納税準備預金、savings: 貯蓄、other: その他)&#39;&lt;br&gt; &#39;支払先指定時には無効&#39;&lt;br&gt; &#39;デフォルトは ordinary: 普通 です&#39; </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccountTypeEnum
        {
            /// <summary>
            /// Enum Ordinary for value: ordinary
            /// </summary>
            [EnumMember(Value = "ordinary")]
            Ordinary = 1,

            /// <summary>
            /// Enum Checking for value: checking
            /// </summary>
            [EnumMember(Value = "checking")]
            Checking = 2,

            /// <summary>
            /// Enum Earmarked for value: earmarked
            /// </summary>
            [EnumMember(Value = "earmarked")]
            Earmarked = 3,

            /// <summary>
            /// Enum Savings for value: savings
            /// </summary>
            [EnumMember(Value = "savings")]
            Savings = 4,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 5

        }


        /// <summary>
        /// &#39;口座種別(ordinary: 普通、checking: 当座、earmarked: 納税準備預金、savings: 貯蓄、other: その他)&#39;&lt;br&gt; &#39;支払先指定時には無効&#39;&lt;br&gt; &#39;デフォルトは ordinary: 普通 です&#39; 
        /// </summary>
        /// <value>&#39;口座種別(ordinary: 普通、checking: 当座、earmarked: 納税準備預金、savings: 貯蓄、other: その他)&#39;&lt;br&gt; &#39;支払先指定時には無効&#39;&lt;br&gt; &#39;デフォルトは ordinary: 普通 です&#39; </value>
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public AccountTypeEnum? AccountType { get; set; }
        /// <summary>
        /// &#39;支払方法(none: 指定なし, domestic_bank_transfer: 国内振込, abroad_bank_transfer: 国外振込, account_transfer: 口座振替, credit_card: クレジットカード)&#39;&lt;br&gt; &#39;デフォルトは none: 指定なし です。&#39; 
        /// </summary>
        /// <value>&#39;支払方法(none: 指定なし, domestic_bank_transfer: 国内振込, abroad_bank_transfer: 国外振込, account_transfer: 口座振替, credit_card: クレジットカード)&#39;&lt;br&gt; &#39;デフォルトは none: 指定なし です。&#39; </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentMethodEnum
        {
            /// <summary>
            /// Enum None for value: none
            /// </summary>
            [EnumMember(Value = "none")]
            None = 1,

            /// <summary>
            /// Enum DomesticBankTransfer for value: domestic_bank_transfer
            /// </summary>
            [EnumMember(Value = "domestic_bank_transfer")]
            DomesticBankTransfer = 2,

            /// <summary>
            /// Enum AbroadBankTransfer for value: abroad_bank_transfer
            /// </summary>
            [EnumMember(Value = "abroad_bank_transfer")]
            AbroadBankTransfer = 3,

            /// <summary>
            /// Enum AccountTransfer for value: account_transfer
            /// </summary>
            [EnumMember(Value = "account_transfer")]
            AccountTransfer = 4,

            /// <summary>
            /// Enum CreditCard for value: credit_card
            /// </summary>
            [EnumMember(Value = "credit_card")]
            CreditCard = 5

        }


        /// <summary>
        /// &#39;支払方法(none: 指定なし, domestic_bank_transfer: 国内振込, abroad_bank_transfer: 国外振込, account_transfer: 口座振替, credit_card: クレジットカード)&#39;&lt;br&gt; &#39;デフォルトは none: 指定なし です。&#39; 
        /// </summary>
        /// <value>&#39;支払方法(none: 指定なし, domestic_bank_transfer: 国内振込, abroad_bank_transfer: 国外振込, account_transfer: 口座振替, credit_card: クレジットカード)&#39;&lt;br&gt; &#39;デフォルトは none: 指定なし です。&#39; </value>
        [DataMember(Name = "payment_method", EmitDefaultValue = false)]
        public PaymentMethodEnum? PaymentMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequestUpdateParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PaymentRequestUpdateParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRequestUpdateParams" /> class.
        /// </summary>
        /// <param name="accountName">受取人名（カナ）（48文字以内）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="accountNumber">口座番号（半角数字1桁〜7桁）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="accountType">&#39;口座種別(ordinary: 普通、checking: 当座、earmarked: 納税準備預金、savings: 貯蓄、other: その他)&#39;&lt;br&gt; &#39;支払先指定時には無効&#39;&lt;br&gt; &#39;デフォルトは ordinary: 普通 です&#39; .</param>
        /// <param name="applicationDate">申請日 (yyyy-mm-dd)&lt;br&gt; 指定しない場合は当日の日付が登録されます。&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効 .</param>
        /// <param name="approvalFlowRouteId">申請経路ID&lt;br&gt; 指定する申請経路IDは、申請経路APIを利用して取得してください。  (required).</param>
        /// <param name="approverId">承認者のユーザーID&lt;br&gt; 「承認者を指定」の経路を申請経路として使用する場合に指定してください。&lt;br&gt; 指定する承認者のユーザーIDは、申請経路APIを利用して取得してください。 .</param>
        /// <param name="bankCode">銀行コード（半角数字1桁〜4桁）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="bankName">銀行名（255文字以内）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="bankNameKana">銀行名（カナ）（15文字以内）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="branchCode">支店番号（半角数字1桁〜3桁）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="branchKana">支店名（カナ）（15文字以内）&lt;br&gt; 指定可能な文字は、英数・カナ・丸括弧・ハイフン・スペースのみです。&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="branchName">支店名（255文字以内）&lt;br&gt; 支払先指定時には無効 .</param>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="description">備考.</param>
        /// <param name="documentCode">請求書番号（255文字以内）.</param>
        /// <param name="draft">支払依頼のステータス&lt;br&gt; falseを指定した時は申請中（in_progress）で支払依頼を更新します。&lt;br&gt; trueを指定した時は下書き（draft）で支払依頼を更新します。&lt;br&gt; 未指定の時は下書きとみなして支払依頼を更新します。  (required).</param>
        /// <param name="issueDate">発生日 (yyyy-mm-dd) (required).</param>
        /// <param name="partnerCode">支払先の取引先コード&lt;br&gt; 支払先の取引先ID指定時には無効 .</param>
        /// <param name="partnerId">支払先の取引先ID.</param>
        /// <param name="paymentDate">支払期限 (yyyy-mm-dd).</param>
        /// <param name="paymentMethod">&#39;支払方法(none: 指定なし, domestic_bank_transfer: 国内振込, abroad_bank_transfer: 国外振込, account_transfer: 口座振替, credit_card: クレジットカード)&#39;&lt;br&gt; &#39;デフォルトは none: 指定なし です。&#39; .</param>
        /// <param name="paymentRequestLines">支払依頼の項目行一覧（配列） (required).</param>
        /// <param name="receiptIds">証憑ファイルID（ファイルボックスのファイルID）（配列）.</param>
        /// <param name="title">申請タイトル&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効  (required).</param>
        public PaymentRequestUpdateParams(string accountName = default(string), string accountNumber = default(string), AccountTypeEnum? accountType = default(AccountTypeEnum?), string applicationDate = default(string), int approvalFlowRouteId = default(int), int approverId = default(int), string bankCode = default(string), string bankName = default(string), string bankNameKana = default(string), string branchCode = default(string), string branchKana = default(string), string branchName = default(string), int companyId = default(int), string description = default(string), string documentCode = default(string), bool draft = default(bool), string issueDate = default(string), string partnerCode = default(string), int? partnerId = default(int?), string paymentDate = default(string), PaymentMethodEnum? paymentMethod = default(PaymentMethodEnum?), List<PaymentRequestUpdateParamsPaymentRequestLines> paymentRequestLines = default(List<PaymentRequestUpdateParamsPaymentRequestLines>), List<int> receiptIds = default(List<int>), string title = default(string))
        {
            this.ApprovalFlowRouteId = approvalFlowRouteId;
            this.CompanyId = companyId;
            this.Draft = draft;
            // to ensure "issueDate" is required (not null)
            if (issueDate == null)
            {
                throw new ArgumentNullException("issueDate is a required property for PaymentRequestUpdateParams and cannot be null");
            }
            this.IssueDate = issueDate;
            // to ensure "paymentRequestLines" is required (not null)
            if (paymentRequestLines == null)
            {
                throw new ArgumentNullException("paymentRequestLines is a required property for PaymentRequestUpdateParams and cannot be null");
            }
            this.PaymentRequestLines = paymentRequestLines;
            // to ensure "title" is required (not null)
            if (title == null)
            {
                throw new ArgumentNullException("title is a required property for PaymentRequestUpdateParams and cannot be null");
            }
            this.Title = title;
            this.AccountName = accountName;
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.ApplicationDate = applicationDate;
            this.ApproverId = approverId;
            this.BankCode = bankCode;
            this.BankName = bankName;
            this.BankNameKana = bankNameKana;
            this.BranchCode = branchCode;
            this.BranchKana = branchKana;
            this.BranchName = branchName;
            this.Description = description;
            this.DocumentCode = documentCode;
            this.PartnerCode = partnerCode;
            this.PartnerId = partnerId;
            this.PaymentDate = paymentDate;
            this.PaymentMethod = paymentMethod;
            this.ReceiptIds = receiptIds;
        }

        /// <summary>
        /// 受取人名（カナ）（48文字以内）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>受取人名（カナ）（48文字以内）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }

        /// <summary>
        /// 口座番号（半角数字1桁〜7桁）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>口座番号（半角数字1桁〜7桁）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 申請日 (yyyy-mm-dd)&lt;br&gt; 指定しない場合は当日の日付が登録されます。&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効 
        /// </summary>
        /// <value>申請日 (yyyy-mm-dd)&lt;br&gt; 指定しない場合は当日の日付が登録されます。&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効 </value>
        [DataMember(Name = "application_date", EmitDefaultValue = false)]
        public string ApplicationDate { get; set; }

        /// <summary>
        /// 申請経路ID&lt;br&gt; 指定する申請経路IDは、申請経路APIを利用して取得してください。 
        /// </summary>
        /// <value>申請経路ID&lt;br&gt; 指定する申請経路IDは、申請経路APIを利用して取得してください。 </value>
        [DataMember(Name = "approval_flow_route_id", IsRequired = true, EmitDefaultValue = false)]
        public int ApprovalFlowRouteId { get; set; }

        /// <summary>
        /// 承認者のユーザーID&lt;br&gt; 「承認者を指定」の経路を申請経路として使用する場合に指定してください。&lt;br&gt; 指定する承認者のユーザーIDは、申請経路APIを利用して取得してください。 
        /// </summary>
        /// <value>承認者のユーザーID&lt;br&gt; 「承認者を指定」の経路を申請経路として使用する場合に指定してください。&lt;br&gt; 指定する承認者のユーザーIDは、申請経路APIを利用して取得してください。 </value>
        [DataMember(Name = "approver_id", EmitDefaultValue = false)]
        public int ApproverId { get; set; }

        /// <summary>
        /// 銀行コード（半角数字1桁〜4桁）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>銀行コード（半角数字1桁〜4桁）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "bank_code", EmitDefaultValue = false)]
        public string BankCode { get; set; }

        /// <summary>
        /// 銀行名（255文字以内）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>銀行名（255文字以内）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "bank_name", EmitDefaultValue = false)]
        public string BankName { get; set; }

        /// <summary>
        /// 銀行名（カナ）（15文字以内）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>銀行名（カナ）（15文字以内）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "bank_name_kana", EmitDefaultValue = false)]
        public string BankNameKana { get; set; }

        /// <summary>
        /// 支店番号（半角数字1桁〜3桁）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>支店番号（半角数字1桁〜3桁）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "branch_code", EmitDefaultValue = false)]
        public string BranchCode { get; set; }

        /// <summary>
        /// 支店名（カナ）（15文字以内）&lt;br&gt; 指定可能な文字は、英数・カナ・丸括弧・ハイフン・スペースのみです。&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>支店名（カナ）（15文字以内）&lt;br&gt; 指定可能な文字は、英数・カナ・丸括弧・ハイフン・スペースのみです。&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "branch_kana", EmitDefaultValue = false)]
        public string BranchKana { get; set; }

        /// <summary>
        /// 支店名（255文字以内）&lt;br&gt; 支払先指定時には無効 
        /// </summary>
        /// <value>支店名（255文字以内）&lt;br&gt; 支払先指定時には無効 </value>
        [DataMember(Name = "branch_name", EmitDefaultValue = false)]
        public string BranchName { get; set; }

        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name = "company_id", IsRequired = true, EmitDefaultValue = false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        /// <value>備考</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// 請求書番号（255文字以内）
        /// </summary>
        /// <value>請求書番号（255文字以内）</value>
        [DataMember(Name = "document_code", EmitDefaultValue = false)]
        public string DocumentCode { get; set; }

        /// <summary>
        /// 支払依頼のステータス&lt;br&gt; falseを指定した時は申請中（in_progress）で支払依頼を更新します。&lt;br&gt; trueを指定した時は下書き（draft）で支払依頼を更新します。&lt;br&gt; 未指定の時は下書きとみなして支払依頼を更新します。 
        /// </summary>
        /// <value>支払依頼のステータス&lt;br&gt; falseを指定した時は申請中（in_progress）で支払依頼を更新します。&lt;br&gt; trueを指定した時は下書き（draft）で支払依頼を更新します。&lt;br&gt; 未指定の時は下書きとみなして支払依頼を更新します。 </value>
        [DataMember(Name = "draft", IsRequired = true, EmitDefaultValue = true)]
        public bool Draft { get; set; }

        /// <summary>
        /// 発生日 (yyyy-mm-dd)
        /// </summary>
        /// <value>発生日 (yyyy-mm-dd)</value>
        [DataMember(Name = "issue_date", IsRequired = true, EmitDefaultValue = false)]
        public string IssueDate { get; set; }

        /// <summary>
        /// 支払先の取引先コード&lt;br&gt; 支払先の取引先ID指定時には無効 
        /// </summary>
        /// <value>支払先の取引先コード&lt;br&gt; 支払先の取引先ID指定時には無効 </value>
        [DataMember(Name = "partner_code", EmitDefaultValue = true)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 支払先の取引先ID
        /// </summary>
        /// <value>支払先の取引先ID</value>
        [DataMember(Name = "partner_id", EmitDefaultValue = true)]
        public int? PartnerId { get; set; }

        /// <summary>
        /// 支払期限 (yyyy-mm-dd)
        /// </summary>
        /// <value>支払期限 (yyyy-mm-dd)</value>
        [DataMember(Name = "payment_date", EmitDefaultValue = true)]
        public string PaymentDate { get; set; }

        /// <summary>
        /// 支払依頼の項目行一覧（配列）
        /// </summary>
        /// <value>支払依頼の項目行一覧（配列）</value>
        [DataMember(Name = "payment_request_lines", IsRequired = true, EmitDefaultValue = false)]
        public List<PaymentRequestUpdateParamsPaymentRequestLines> PaymentRequestLines { get; set; }

        /// <summary>
        /// 証憑ファイルID（ファイルボックスのファイルID）（配列）
        /// </summary>
        /// <value>証憑ファイルID（ファイルボックスのファイルID）（配列）</value>
        [DataMember(Name = "receipt_ids", EmitDefaultValue = false)]
        public List<int> ReceiptIds { get; set; }

        /// <summary>
        /// 申請タイトル&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効 
        /// </summary>
        /// <value>申請タイトル&lt;br&gt; 申請者が、下書き状態もしくは差戻し状態の支払依頼に対して指定する場合のみ有効 </value>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentRequestUpdateParams {\n");
            sb.Append("  AccountName: ").Append(AccountName).Append("\n");
            sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
            sb.Append("  AccountType: ").Append(AccountType).Append("\n");
            sb.Append("  ApplicationDate: ").Append(ApplicationDate).Append("\n");
            sb.Append("  ApprovalFlowRouteId: ").Append(ApprovalFlowRouteId).Append("\n");
            sb.Append("  ApproverId: ").Append(ApproverId).Append("\n");
            sb.Append("  BankCode: ").Append(BankCode).Append("\n");
            sb.Append("  BankName: ").Append(BankName).Append("\n");
            sb.Append("  BankNameKana: ").Append(BankNameKana).Append("\n");
            sb.Append("  BranchCode: ").Append(BranchCode).Append("\n");
            sb.Append("  BranchKana: ").Append(BranchKana).Append("\n");
            sb.Append("  BranchName: ").Append(BranchName).Append("\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DocumentCode: ").Append(DocumentCode).Append("\n");
            sb.Append("  Draft: ").Append(Draft).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PaymentDate: ").Append(PaymentDate).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  PaymentRequestLines: ").Append(PaymentRequestLines).Append("\n");
            sb.Append("  ReceiptIds: ").Append(ReceiptIds).Append("\n");
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
            return this.Equals(input as PaymentRequestUpdateParams);
        }

        /// <summary>
        /// Returns true if PaymentRequestUpdateParams instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentRequestUpdateParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentRequestUpdateParams input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountName == input.AccountName ||
                    (this.AccountName != null &&
                    this.AccountName.Equals(input.AccountName))
                ) && 
                (
                    this.AccountNumber == input.AccountNumber ||
                    (this.AccountNumber != null &&
                    this.AccountNumber.Equals(input.AccountNumber))
                ) && 
                (
                    this.AccountType == input.AccountType ||
                    this.AccountType.Equals(input.AccountType)
                ) && 
                (
                    this.ApplicationDate == input.ApplicationDate ||
                    (this.ApplicationDate != null &&
                    this.ApplicationDate.Equals(input.ApplicationDate))
                ) && 
                (
                    this.ApprovalFlowRouteId == input.ApprovalFlowRouteId ||
                    this.ApprovalFlowRouteId.Equals(input.ApprovalFlowRouteId)
                ) && 
                (
                    this.ApproverId == input.ApproverId ||
                    this.ApproverId.Equals(input.ApproverId)
                ) && 
                (
                    this.BankCode == input.BankCode ||
                    (this.BankCode != null &&
                    this.BankCode.Equals(input.BankCode))
                ) && 
                (
                    this.BankName == input.BankName ||
                    (this.BankName != null &&
                    this.BankName.Equals(input.BankName))
                ) && 
                (
                    this.BankNameKana == input.BankNameKana ||
                    (this.BankNameKana != null &&
                    this.BankNameKana.Equals(input.BankNameKana))
                ) && 
                (
                    this.BranchCode == input.BranchCode ||
                    (this.BranchCode != null &&
                    this.BranchCode.Equals(input.BranchCode))
                ) && 
                (
                    this.BranchKana == input.BranchKana ||
                    (this.BranchKana != null &&
                    this.BranchKana.Equals(input.BranchKana))
                ) && 
                (
                    this.BranchName == input.BranchName ||
                    (this.BranchName != null &&
                    this.BranchName.Equals(input.BranchName))
                ) && 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DocumentCode == input.DocumentCode ||
                    (this.DocumentCode != null &&
                    this.DocumentCode.Equals(input.DocumentCode))
                ) && 
                (
                    this.Draft == input.Draft ||
                    this.Draft.Equals(input.Draft)
                ) && 
                (
                    this.IssueDate == input.IssueDate ||
                    (this.IssueDate != null &&
                    this.IssueDate.Equals(input.IssueDate))
                ) && 
                (
                    this.PartnerCode == input.PartnerCode ||
                    (this.PartnerCode != null &&
                    this.PartnerCode.Equals(input.PartnerCode))
                ) && 
                (
                    this.PartnerId == input.PartnerId ||
                    (this.PartnerId != null &&
                    this.PartnerId.Equals(input.PartnerId))
                ) && 
                (
                    this.PaymentDate == input.PaymentDate ||
                    (this.PaymentDate != null &&
                    this.PaymentDate.Equals(input.PaymentDate))
                ) && 
                (
                    this.PaymentMethod == input.PaymentMethod ||
                    this.PaymentMethod.Equals(input.PaymentMethod)
                ) && 
                (
                    this.PaymentRequestLines == input.PaymentRequestLines ||
                    this.PaymentRequestLines != null &&
                    input.PaymentRequestLines != null &&
                    this.PaymentRequestLines.SequenceEqual(input.PaymentRequestLines)
                ) && 
                (
                    this.ReceiptIds == input.ReceiptIds ||
                    this.ReceiptIds != null &&
                    input.ReceiptIds != null &&
                    this.ReceiptIds.SequenceEqual(input.ReceiptIds)
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
                if (this.AccountName != null)
                {
                    hashCode = (hashCode * 59) + this.AccountName.GetHashCode();
                }
                if (this.AccountNumber != null)
                {
                    hashCode = (hashCode * 59) + this.AccountNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AccountType.GetHashCode();
                if (this.ApplicationDate != null)
                {
                    hashCode = (hashCode * 59) + this.ApplicationDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ApprovalFlowRouteId.GetHashCode();
                hashCode = (hashCode * 59) + this.ApproverId.GetHashCode();
                if (this.BankCode != null)
                {
                    hashCode = (hashCode * 59) + this.BankCode.GetHashCode();
                }
                if (this.BankName != null)
                {
                    hashCode = (hashCode * 59) + this.BankName.GetHashCode();
                }
                if (this.BankNameKana != null)
                {
                    hashCode = (hashCode * 59) + this.BankNameKana.GetHashCode();
                }
                if (this.BranchCode != null)
                {
                    hashCode = (hashCode * 59) + this.BranchCode.GetHashCode();
                }
                if (this.BranchKana != null)
                {
                    hashCode = (hashCode * 59) + this.BranchKana.GetHashCode();
                }
                if (this.BranchName != null)
                {
                    hashCode = (hashCode * 59) + this.BranchName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CompanyId.GetHashCode();
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.DocumentCode != null)
                {
                    hashCode = (hashCode * 59) + this.DocumentCode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Draft.GetHashCode();
                if (this.IssueDate != null)
                {
                    hashCode = (hashCode * 59) + this.IssueDate.GetHashCode();
                }
                if (this.PartnerCode != null)
                {
                    hashCode = (hashCode * 59) + this.PartnerCode.GetHashCode();
                }
                if (this.PartnerId != null)
                {
                    hashCode = (hashCode * 59) + this.PartnerId.GetHashCode();
                }
                if (this.PaymentDate != null)
                {
                    hashCode = (hashCode * 59) + this.PaymentDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PaymentMethod.GetHashCode();
                if (this.PaymentRequestLines != null)
                {
                    hashCode = (hashCode * 59) + this.PaymentRequestLines.GetHashCode();
                }
                if (this.ReceiptIds != null)
                {
                    hashCode = (hashCode * 59) + this.ReceiptIds.GetHashCode();
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
