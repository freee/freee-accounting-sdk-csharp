/* 
 * freee API
 *
 *  <h1 id=\"freee_api\">freee API</h1> <hr /> <h2 id=\"start_guide\">スタートガイド</h2>  <p>freee API開発がはじめての方は<a href=\"https://developer.freee.co.jp/getting-started\">freee API スタートガイド</a>を参照してください。</p>  <hr /> <h2 id=\"specification\">仕様</h2>  <pre><code>【重要】会計freee APIの新バージョンについて 2020年12月まで、2つのバージョンが利用できる状態です。古いものは2020年12月に利用不可となります。<br> 新しいAPIを利用するにはリクエストヘッダーに以下を指定します。 X-Api-Version: 2020-06-15<br> 指定がない場合は2020年12月に廃止予定のAPIを利用することとなります。<br> 【重要】APIのバージョン指定をせずに利用し続ける場合 2020年12月に新しいバージョンのAPIに自動的に切り替わります。 詳細は、<a href=\"https://developer.freee.co.jp/release-note/2948\" target=\"_blank\">リリースノート</a>をご覧ください。<br> 旧バージョンのAPIリファレンスを確認したい場合は、<a href=\"https://freee.github.io/freee-api-schema/\" target=\"_blank\">旧バージョンのAPIリファレンスページ</a>をご覧ください。 </code></pre>  <h3 id=\"api_endpoint\">APIエンドポイント</h3>  <p>https://api.freee.co.jp/ (httpsのみ)</p>  <h3 id=\"about_authorize\">認証について</h3> <p>OAuth2.0を利用します。詳細は<a href=\"https://developer.freee.co.jp/docs\" target=\"_blank\">ドキュメントの認証</a>パートを参照してください。</p>  <h3 id=\"data_format\">データフォーマット</h3>  <p>リクエスト、レスポンスともにJSON形式をサポートしていますが、詳細は、API毎の説明欄（application/jsonなど）を確認してください。</p>  <h3 id=\"compatibility\">後方互換性ありの変更</h3>  <p>freeeでは、APIを改善していくために以下のような変更は後方互換性ありとして通知なく変更を入れることがあります。アプリケーション実装者は以下を踏まえて開発を行ってください。</p>  <ul> <li>新しいAPIリソース・エンドポイントの追加</li> <li>既存のAPIに対して必須ではない新しいリクエストパラメータの追加</li> <li>既存のAPIレスポンスに対する新しいプロパティの追加</li> <li>既存のAPIレスポンスに対するプロパティの順番の入れ変え</li> <li>keyとなっているidやcodeの長さの変更（長くする）</li> </ul>  <h3 id=\"common_response_header\">共通レスポンスヘッダー</h3>  <p>すべてのAPIのレスポンスには以下のHTTPヘッダーが含まれます。</p>  <ul> <li> <p>X-Freee-Request-ID</p> <ul> <li>各リクエスト毎に発行されるID</li> </ul> </li> </ul>  <h3 id=\"common_error_response\">共通エラーレスポンス</h3>  <ul> <li> <p>ステータスコードはレスポンス内のJSONに含まれる他、HTTPヘッダにも含まれる</p> </li> <li> <p>一部のエラーレスポンスにはエラーコードが含まれます。<br>詳細は、<a href=\"https://developer.freee.co.jp/tips/faq/40x-checkpoint\">HTTPステータスコード400台エラー時のチェックポイント</a>を参照してください</p> </li> <p>type</p>  <ul> <li>status : HTTPステータスコードの説明</li>  <li>validation : エラーの詳細の説明（開発者向け）</li> </ul> </li> </ul>  <p>レスポンスの例</p>  <pre><code>  {     &quot;status_code&quot; : 400,     &quot;errors&quot; : [       {         &quot;type&quot; : &quot;status&quot;,         &quot;messages&quot; : [&quot;不正なリクエストです。&quot;]       },       {         &quot;type&quot; : &quot;validation&quot;,         &quot;messages&quot; : [&quot;Date は不正な日付フォーマットです。入力例：2013-01-01&quot;]       }     ]   }</code></pre>  </br>  <h3 id=\"api_rate_limit\">API使用制限</h3>    <p>freeeは一定期間に過度のアクセスを検知した場合、APIアクセスをコントロールする場合があります。</p>   <p>その際のhttp status codeは403となります。制限がかかってから10分程度が過ぎると再度使用することができるようになります。</p>  <h4 id=\"reports_api_endpoint\">/reportsエンドポイント</h4>  <p>freeeは/reportsエンドポイントに対して1秒間に10以上のアクセスを検知した場合、APIアクセスをコントロールする場合があります。その際のhttp status codeは429（too many requests）となります。</p>  <p>レスポンスボディのmetaプロパティに以下を含めます。</p>  <ul>   <li>設定されている上限値</li>   <li>上限に達するまでの使用可能回数</li>   <li>（上限値に達した場合）使用回数がリセットされる時刻</li> </ul>  <h3 id=\"plan_api_rate_limit\">プラン別のAPI Rate Limit</h3>   <table border=\"1\">     <tbody>       <tr>         <th style=\"padding: 10px\"><strong>会計freeeプラン名</strong></th>         <th style=\"padding: 10px\"><strong>事業所とアプリケーション毎に1日でのAPIコール数</strong></th>       </tr>       <tr>         <td style=\"padding: 10px\">エンタープライズ</td>         <td style=\"padding: 10px\">10,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">プロフェッショナル</td>         <td style=\"padding: 10px\">5,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ベーシック</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ミニマム</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">上記以外</td>         <td style=\"padding: 10px\">3,000</td>       </tr>     </tbody>   </table>  <hr /> <h2 id=\"contact\">連絡先</h2>  <p>ご不明点、ご要望等は <a href=\"https://support.freee.co.jp/hc/ja/requests/new\">freee サポートデスクへのお問い合わせフォーム</a> からご連絡ください。</p> <hr />&copy; Since 2013 freee K.K.
 *
 * The version of the OpenAPI document: v1.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenAPIDateConverter = Freee.Accounting.Client.OpenAPIDateConverter;

namespace Freee.Accounting.Models
{
    /// <summary>
    /// DealCreateParams
    /// </summary>
    [DataContract]
    public partial class DealCreateParams :  IEquatable<DealCreateParams>
    {
        /// <summary>
        /// 収支区分 (収入: income, 支出: expense)
        /// </summary>
        /// <value>収支区分 (収入: income, 支出: expense)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Income for value: income
            /// </summary>
            [EnumMember(Value = "income")]
            Income = 1,

            /// <summary>
            /// Enum Expense for value: expense
            /// </summary>
            [EnumMember(Value = "expense")]
            Expense = 2

        }

        /// <summary>
        /// 収支区分 (収入: income, 支出: expense)
        /// </summary>
        /// <value>収支区分 (収入: income, 支出: expense)</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DealCreateParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealCreateParams" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="details">details (required).</param>
        /// <param name="dueDate">支払期日(yyyy-mm-dd).</param>
        /// <param name="issueDate">発生日 (yyyy-mm-dd) (required).</param>
        /// <param name="partnerCode">取引先コード.</param>
        /// <param name="partnerId">取引先ID.</param>
        /// <param name="payments">支払行一覧（配列）：未指定の場合、未決済の取引を作成します。.</param>
        /// <param name="receiptIds">証憑ファイルID（配列）.</param>
        /// <param name="refNumber">管理番号.</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (required).</param>
        public DealCreateParams(int companyId = default(int), List<DealCreateParamsDetails> details = default(List<DealCreateParamsDetails>), string dueDate = default(string), string issueDate = default(string), string partnerCode = default(string), int partnerId = default(int), List<DealCreateParamsPayments> payments = default(List<DealCreateParamsPayments>), List<int> receiptIds = default(List<int>), string refNumber = default(string), TypeEnum type = default(TypeEnum))
        {
            this.CompanyId = companyId;
            // to ensure "details" is required (not null)
            this.Details = details ?? throw new ArgumentNullException("details is a required property for DealCreateParams and cannot be null");
            // to ensure "issueDate" is required (not null)
            this.IssueDate = issueDate ?? throw new ArgumentNullException("issueDate is a required property for DealCreateParams and cannot be null");
            this.Type = type;
            this.DueDate = dueDate;
            this.PartnerCode = partnerCode;
            this.PartnerId = partnerId;
            this.Payments = payments;
            this.ReceiptIds = receiptIds;
            this.RefNumber = refNumber;
        }
        
        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [DataMember(Name="details", EmitDefaultValue=false)]
        public List<DealCreateParamsDetails> Details { get; set; }

        /// <summary>
        /// 支払期日(yyyy-mm-dd)
        /// </summary>
        /// <value>支払期日(yyyy-mm-dd)</value>
        [DataMember(Name="due_date", EmitDefaultValue=false)]
        public string DueDate { get; set; }

        /// <summary>
        /// 発生日 (yyyy-mm-dd)
        /// </summary>
        /// <value>発生日 (yyyy-mm-dd)</value>
        [DataMember(Name="issue_date", EmitDefaultValue=false)]
        public string IssueDate { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        /// <value>取引先コード</value>
        [DataMember(Name="partner_code", EmitDefaultValue=false)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 取引先ID
        /// </summary>
        /// <value>取引先ID</value>
        [DataMember(Name="partner_id", EmitDefaultValue=false)]
        public int PartnerId { get; set; }

        /// <summary>
        /// 支払行一覧（配列）：未指定の場合、未決済の取引を作成します。
        /// </summary>
        /// <value>支払行一覧（配列）：未指定の場合、未決済の取引を作成します。</value>
        [DataMember(Name="payments", EmitDefaultValue=false)]
        public List<DealCreateParamsPayments> Payments { get; set; }

        /// <summary>
        /// 証憑ファイルID（配列）
        /// </summary>
        /// <value>証憑ファイルID（配列）</value>
        [DataMember(Name="receipt_ids", EmitDefaultValue=false)]
        public List<int> ReceiptIds { get; set; }

        /// <summary>
        /// 管理番号
        /// </summary>
        /// <value>管理番号</value>
        [DataMember(Name="ref_number", EmitDefaultValue=false)]
        public string RefNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DealCreateParams {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  Payments: ").Append(Payments).Append("\n");
            sb.Append("  ReceiptIds: ").Append(ReceiptIds).Append("\n");
            sb.Append("  RefNumber: ").Append(RefNumber).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DealCreateParams);
        }

        /// <summary>
        /// Returns true if DealCreateParams instances are equal
        /// </summary>
        /// <param name="input">Instance of DealCreateParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DealCreateParams input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.Details == input.Details ||
                    this.Details != null &&
                    input.Details != null &&
                    this.Details.SequenceEqual(input.Details)
                ) && 
                (
                    this.DueDate == input.DueDate ||
                    (this.DueDate != null &&
                    this.DueDate.Equals(input.DueDate))
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
                    this.PartnerId.Equals(input.PartnerId)
                ) && 
                (
                    this.Payments == input.Payments ||
                    this.Payments != null &&
                    input.Payments != null &&
                    this.Payments.SequenceEqual(input.Payments)
                ) && 
                (
                    this.ReceiptIds == input.ReceiptIds ||
                    this.ReceiptIds != null &&
                    input.ReceiptIds != null &&
                    this.ReceiptIds.SequenceEqual(input.ReceiptIds)
                ) && 
                (
                    this.RefNumber == input.RefNumber ||
                    (this.RefNumber != null &&
                    this.RefNumber.Equals(input.RefNumber))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
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
                hashCode = hashCode * 59 + this.CompanyId.GetHashCode();
                if (this.Details != null)
                    hashCode = hashCode * 59 + this.Details.GetHashCode();
                if (this.DueDate != null)
                    hashCode = hashCode * 59 + this.DueDate.GetHashCode();
                if (this.IssueDate != null)
                    hashCode = hashCode * 59 + this.IssueDate.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.Payments != null)
                    hashCode = hashCode * 59 + this.Payments.GetHashCode();
                if (this.ReceiptIds != null)
                    hashCode = hashCode * 59 + this.ReceiptIds.GetHashCode();
                if (this.RefNumber != null)
                    hashCode = hashCode * 59 + this.RefNumber.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                return hashCode;
            }
        }

    }

}