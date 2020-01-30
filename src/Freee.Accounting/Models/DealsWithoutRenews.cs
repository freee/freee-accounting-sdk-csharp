/* 
 * freee API
 *
 *  <h1 id=\"freee_api\">freee API</h1> <hr /> <h2 id=\"\">スタートガイド</h2> <p>1. セットアップ</p> <ol> <ul><li><a href=\"https://support.freee.co.jp/hc/ja/articles/202847230\" class=\"external-link\" rel=\"nofollow\">freeeアカウント（無料）</a>を<a href=\"https://secure.freee.co.jp/users/sign_up\" class=\"external-link\" rel=\"nofollow\">作成</a>します（すでにお持ちの場合は次へ）</li><li><a href=\"https://app.secure.freee.co.jp/developers/demo_companies/description\" class=\"external-link\" rel=\"nofollow\">開発者向け事業所・環境を作成</a>します</li><li><span><a href=\"https://app.secure.freee.co.jp/developers/applications\" class=\"external-link\" rel=\"nofollow\">前のステップで作成した事業所を選択してfreeeアプリを追加</a>します</span></li><li>Client IDをCopyしておきます</li> </ul> </ol>  <p>2. 実際にAPIを叩いてみる（ブラウザからAPIのレスポンスを確認する）</p> <ol> <ul><li><span><span>以下のURLの●をclient_idに入れ替えて<a href=\"https://app.secure.freee.co.jp/developers/tutorials/3-%E3%82%A2%E3%82%AF%E3%82%BB%E3%82%B9%E3%83%88%E3%83%BC%E3%82%AF%E3%83%B3%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B#%E8%AA%8D%E5%8F%AF%E3%82%B3%E3%83%BC%E3%83%89%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B\" class=\"external-link\" rel=\"nofollow\">アクセストークンを取得</a>します</span></span><ul><li><span><span><pre><code>https://accounts.secure.freee.co.jp/public_api/authorize?client_id=●&amp;redirect_uri=urn%3Aietf%3Awg%3Aoauth%3A2.0%3Aoob&amp;response_type=token</a></code></pre></span></span></li></ul></li><li><span><a href=\"https://developer.freee.co.jp/docs/accounting/reference#/%E9%80%A3%E7%B5%A1%E5%85%88\" class=\"external-link\" rel=\"nofollow\">APIリファレンス</a>で<code>Authorize</code>を押下します</span></li><li><span>アクセストークン<span><span>を入力して</span></span>&nbsp;もう一度<span><code>Authorize</code>を押下して<code>Close</code>を押下します</span></span></li><li>リファレンス内のCompanies（事業所）に移動し、<code>Try it out</code>を押下し、<code>Execute</code>を押下します</li><li>Response bodyを参照し、事業所ID(id属性)を活用して、Companies以外のエンドポイントでどのようなデータのやりとりできるのか確認します</li></ul> </ol> <p>3. 連携を実装する</p> <ol> <ul><li><a href=\"https://developer.freee.co.jp/tips\" class=\"external-link\" rel=\"nofollow\">API TIPS</a>を参考に、ユースケースごとの連携の概要を学びます。<span>例えば</span><span>&nbsp;</span><a href=\"https://developer.freee.co.jp/tips/how-to-cooperate-salesmanegement-system\" class=\"external-link\" rel=\"nofollow\">SFA、CRM、販売管理システムから会計freeeへの連携</a>や<a href=\"https://developer.freee.co.jp/tips/how-to-cooperate-excel-and-spreadsheet\" class=\"external-link\" rel=\"nofollow\">エクセルやgoogle spreadsheetからの連携</a>です</li><li>実利用向け事業所がすでにある場合は利用、ない場合は作成します（セットアップで作成したのは開発者向け環境のため活用不可）</li><li><a href=\"https://developer.freee.co.jp/docs/accounting/reference\" class=\"external-link\" rel=\"nofollow\">API documentation</a><span>&nbsp;を参照し、躓いた場合は</span><span>&nbsp;</span><a href=\"https://developer.freee.co.jp/community/forum/community\" class=\"external-link\" rel=\"nofollow\">Community</a><span>&nbsp;で質問してみましょう</span></li></ul> </ol> <p>アプリケーションの登録方法や認証方法、またはAPIの活用方法でご不明な点がある場合は<a href=\"https://support.freee.co.jp/hc/ja/sections/115000030743\">ヘルプセンター</a>もご確認ください</p> <hr /> <h2 id=\"_2\">仕様</h2>  <h3 id=\"api\">APIエンドポイント</h3>  <p>https://api.freee.co.jp/ (httpsのみ)</p>  <h3 id=\"_3\">認証方式</h3>  <p><a href=\"http://tools.ietf.org/html/rfc6749\">OAuth2</a>に対応</p>  <ul> <li>Authorization Code Flow (Webアプリ向け)</li>  <li>Implicit Flow (Mobileアプリ向け)</li> </ul>  <h3 id=\"_4\">認証エンドポイント</h3>  <p>https://accounts.secure.freee.co.jp/</p>  <ul> <li>authorize : https://accounts.secure.freee.co.jp/public_api/authorize</li>  <li>token : https://accounts.secure.freee.co.jp/public_api/token</li> </ul>  <h3 id=\"_5\">アクセストークンのリフレッシュ</h3>  <p>認証時に得たrefresh_token を使ってtoken の期限をリフレッシュして新規に発行することが出来ます。</p>  <p>grant_type=refresh_token で https://accounts.secure.freee.co.jp/public_api/token にアクセスすればリフレッシュされます。</p>  <p>e.g.)</p>  <p>POST: https://accounts.secure.freee.co.jp/public_api/token</p>  <p>params: grant_type=refresh_token&amp;client_id=UID&amp;client_secret=SECRET&amp;refresh_token=REFRESH_TOKEN</p>  <p>詳細は<a href=\"https://github.com/applicake/doorkeeper/wiki/Enable-Refresh-Token-Credentials#flow\">refresh_token</a>を参照下さい。</p>  <h3 id=\"_6\">アクセストークンの破棄</h3>  <p>認証時に得たaccess_tokenまたはrefresh_tokenを使って、tokenを破棄することができます。 token=access_tokenまたはtoken=refresh_tokenでhttps://accounts.secure.freee.co.jp/public_api/revokeにアクセスすると破棄されます。token_type_hintでaccess_tokenまたはrefresh_tokenを陽に指定できます。</p>  <p>e.g.)</p>  <p>POST: https://accounts.secure.freee.co.jp/public_api/revoke</p>  <p>params: token=ACCESS_TOKEN</p>  <p>または</p>  <p>params: token=REFRESH_TOKEN</p>  <p>または</p>  <p>params: token=ACCESS_TOKEN&amp;token_type_hint=access_token</p>  <p>または</p>  <p>params: token=REFRESH_TOKEN&amp;token_type_hint=refresh_token</p>  <p>詳細は <a href=\"https://tools.ietf.org/html/rfc7009\">OAuth 2.0 Token revocation</a> をご参照ください。</p>  <h3 id=\"_7\">データフォーマット</h3>  <p>リクエスト、レスポンスともにJSON形式をサポート</p>  <h3 id=\"_8\">共通レスポンスヘッダー</h3>  <p>すべてのAPIのレスポンスには以下のHTTPヘッダーが含まれます。</p>  <ul> <li> <p>X-Freee-Request-ID</p> <ul> <li>各リクエスト毎に発行されるID</li> </ul> </li> </ul>  <h3 id=\"_9\">共通エラーレスポンス</h3>  <ul> <li> <p>ステータスコードはレスポンス内のJSONに含まれる他、HTTPヘッダにも含まれる</p> </li>  <li> <p>type</p>  <ul> <li>status : HTTPステータスコードの説明</li>  <li>validation : エラーの詳細の説明（開発者向け）</li> </ul> </li> </ul>  <p>レスポンスの例</p>  <pre><code>  {     &quot;status_code&quot; : 400,     &quot;errors&quot; : [       {         &quot;type&quot; : &quot;status&quot;,         &quot;messages&quot; : [&quot;不正なリクエストです。&quot;]       },       {         &quot;type&quot; : &quot;validation&quot;,         &quot;messages&quot; : [&quot;Date は不正な日付フォーマットです。入力例：2013-01-01&quot;]       }     ]   }</code></pre> <hr /> <h2 id=\"_10\">連絡先</h2>  <p>ご不明点、ご要望等は <a href=\"https://support.freee.co.jp/hc/ja/requests/new\">freee サポートデスクへのお問い合わせフォーム</a> からご連絡ください。</p> <hr />&copy; Since 2013 freee K.K.
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
    /// DealsWithoutRenews
    /// </summary>
    [DataContract]
    public partial class DealsWithoutRenews :  IEquatable<DealsWithoutRenews>
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
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// 決済状況 (未決済: unsettled, 完了: settled)
        /// </summary>
        /// <value>決済状況 (未決済: unsettled, 完了: settled)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Unsettled for value: unsettled
            /// </summary>
            [EnumMember(Value = "unsettled")]
            Unsettled = 1,

            /// <summary>
            /// Enum Settled for value: settled
            /// </summary>
            [EnumMember(Value = "settled")]
            Settled = 2

        }

        /// <summary>
        /// 決済状況 (未決済: unsettled, 完了: settled)
        /// </summary>
        /// <value>決済状況 (未決済: unsettled, 完了: settled)</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealsWithoutRenews" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DealsWithoutRenews() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealsWithoutRenews" /> class.
        /// </summary>
        /// <param name="id">取引ID (required).</param>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="issueDate">発生日 (yyyy-mm-dd) (required).</param>
        /// <param name="dueDate">支払期日 (yyyy-mm-dd).</param>
        /// <param name="amount">金額 (required).</param>
        /// <param name="dueAmount">支払金額.</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense).</param>
        /// <param name="partnerId">取引先ID (required).</param>
        /// <param name="partnerCode">取引先コード.</param>
        /// <param name="refNumber">管理番号.</param>
        /// <param name="status">決済状況 (未決済: unsettled, 完了: settled) (required).</param>
        /// <param name="details">取引の明細行.</param>
        /// <param name="payments">取引の支払行.</param>
        public DealsWithoutRenews(int id = default(int), int companyId = default(int), string issueDate = default(string), string dueDate = default(string), int amount = default(int), int dueAmount = default(int), TypeEnum? type = default(TypeEnum?), int partnerId = default(int), string partnerCode = default(string), string refNumber = default(string), StatusEnum status = default(StatusEnum), List<DealsDetails> details = default(List<DealsDetails>), List<DealsPayments> payments = default(List<DealsPayments>))
        {
            this.Id = id;
            this.CompanyId = companyId;
            // to ensure "issueDate" is required (not null)
            this.IssueDate = issueDate ?? throw new ArgumentNullException("issueDate is a required property for DealsWithoutRenews and cannot be null");;
            this.Amount = amount;
            this.PartnerId = partnerId;
            this.Status = status;
            this.DueDate = dueDate;
            this.DueAmount = dueAmount;
            this.Type = type;
            this.PartnerCode = partnerCode;
            this.RefNumber = refNumber;
            this.Details = details;
            this.Payments = payments;
        }
        
        /// <summary>
        /// 取引ID
        /// </summary>
        /// <value>取引ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 発生日 (yyyy-mm-dd)
        /// </summary>
        /// <value>発生日 (yyyy-mm-dd)</value>
        [DataMember(Name="issue_date", EmitDefaultValue=false)]
        public string IssueDate { get; set; }

        /// <summary>
        /// 支払期日 (yyyy-mm-dd)
        /// </summary>
        /// <value>支払期日 (yyyy-mm-dd)</value>
        [DataMember(Name="due_date", EmitDefaultValue=false)]
        public string DueDate { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        /// <value>金額</value>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public int Amount { get; set; }

        /// <summary>
        /// 支払金額
        /// </summary>
        /// <value>支払金額</value>
        [DataMember(Name="due_amount", EmitDefaultValue=false)]
        public int DueAmount { get; set; }

        /// <summary>
        /// 取引先ID
        /// </summary>
        /// <value>取引先ID</value>
        [DataMember(Name="partner_id", EmitDefaultValue=false)]
        public int PartnerId { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        /// <value>取引先コード</value>
        [DataMember(Name="partner_code", EmitDefaultValue=true)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 管理番号
        /// </summary>
        /// <value>管理番号</value>
        [DataMember(Name="ref_number", EmitDefaultValue=false)]
        public string RefNumber { get; set; }

        /// <summary>
        /// 取引の明細行
        /// </summary>
        /// <value>取引の明細行</value>
        [DataMember(Name="details", EmitDefaultValue=false)]
        public List<DealsDetails> Details { get; set; }

        /// <summary>
        /// 取引の支払行
        /// </summary>
        /// <value>取引の支払行</value>
        [DataMember(Name="payments", EmitDefaultValue=false)]
        public List<DealsPayments> Payments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DealsWithoutRenews {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  DueAmount: ").Append(DueAmount).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  RefNumber: ").Append(RefNumber).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Payments: ").Append(Payments).Append("\n");
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
            return this.Equals(input as DealsWithoutRenews);
        }

        /// <summary>
        /// Returns true if DealsWithoutRenews instances are equal
        /// </summary>
        /// <param name="input">Instance of DealsWithoutRenews to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DealsWithoutRenews input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.IssueDate == input.IssueDate ||
                    (this.IssueDate != null &&
                    this.IssueDate.Equals(input.IssueDate))
                ) && 
                (
                    this.DueDate == input.DueDate ||
                    (this.DueDate != null &&
                    this.DueDate.Equals(input.DueDate))
                ) && 
                (
                    this.Amount == input.Amount ||
                    this.Amount.Equals(input.Amount)
                ) && 
                (
                    this.DueAmount == input.DueAmount ||
                    this.DueAmount.Equals(input.DueAmount)
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.PartnerId == input.PartnerId ||
                    this.PartnerId.Equals(input.PartnerId)
                ) && 
                (
                    this.PartnerCode == input.PartnerCode ||
                    (this.PartnerCode != null &&
                    this.PartnerCode.Equals(input.PartnerCode))
                ) && 
                (
                    this.RefNumber == input.RefNumber ||
                    (this.RefNumber != null &&
                    this.RefNumber.Equals(input.RefNumber))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Details == input.Details ||
                    this.Details != null &&
                    input.Details != null &&
                    this.Details.SequenceEqual(input.Details)
                ) && 
                (
                    this.Payments == input.Payments ||
                    this.Payments != null &&
                    input.Payments != null &&
                    this.Payments.SequenceEqual(input.Payments)
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
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.CompanyId.GetHashCode();
                if (this.IssueDate != null)
                    hashCode = hashCode * 59 + this.IssueDate.GetHashCode();
                if (this.DueDate != null)
                    hashCode = hashCode * 59 + this.DueDate.GetHashCode();
                hashCode = hashCode * 59 + this.Amount.GetHashCode();
                hashCode = hashCode * 59 + this.DueAmount.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                if (this.RefNumber != null)
                    hashCode = hashCode * 59 + this.RefNumber.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Details != null)
                    hashCode = hashCode * 59 + this.Details.GetHashCode();
                if (this.Payments != null)
                    hashCode = hashCode * 59 + this.Payments.GetHashCode();
                return hashCode;
            }
        }

    }

}
