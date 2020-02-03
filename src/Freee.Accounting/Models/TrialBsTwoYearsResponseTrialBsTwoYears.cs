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
    /// TrialBsTwoYearsResponseTrialBsTwoYears
    /// </summary>
    [DataContract]
    public partial class TrialBsTwoYearsResponseTrialBsTwoYears :  IEquatable<TrialBsTwoYearsResponseTrialBsTwoYears>
    {
        /// <summary>
        /// 勘定科目の表示（勘定科目: account_item, 決算書表示:group）(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>勘定科目の表示（勘定科目: account_item, 決算書表示:group）(条件に指定した時のみ含まれる）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccountItemDisplayTypeEnum
        {
            /// <summary>
            /// Enum Accountitem for value: account_item
            /// </summary>
            [EnumMember(Value = "account_item")]
            Accountitem = 1,

            /// <summary>
            /// Enum Group for value: group
            /// </summary>
            [EnumMember(Value = "group")]
            Group = 2

        }

        /// <summary>
        /// 勘定科目の表示（勘定科目: account_item, 決算書表示:group）(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>勘定科目の表示（勘定科目: account_item, 決算書表示:group）(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="account_item_display_type", EmitDefaultValue=false)]
        public AccountItemDisplayTypeEnum? AccountItemDisplayType { get; set; }
        /// <summary>
        /// 内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item）(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item）(条件に指定した時のみ含まれる）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BreakdownDisplayTypeEnum
        {
            /// <summary>
            /// Enum Partner for value: partner
            /// </summary>
            [EnumMember(Value = "partner")]
            Partner = 1,

            /// <summary>
            /// Enum Item for value: item
            /// </summary>
            [EnumMember(Value = "item")]
            Item = 2,

            /// <summary>
            /// Enum Accountitem for value: account_item
            /// </summary>
            [EnumMember(Value = "account_item")]
            Accountitem = 3

        }

        /// <summary>
        /// 内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item）(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item）(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="breakdown_display_type", EmitDefaultValue=false)]
        public BreakdownDisplayTypeEnum? BreakdownDisplayType { get; set; }
        /// <summary>
        /// 決算整理仕訳のみ: only, 決算整理仕訳以外: without(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>決算整理仕訳のみ: only, 決算整理仕訳以外: without(条件に指定した時のみ含まれる）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AdjustmentEnum
        {
            /// <summary>
            /// Enum Only for value: only
            /// </summary>
            [EnumMember(Value = "only")]
            Only = 1,

            /// <summary>
            /// Enum Without for value: without
            /// </summary>
            [EnumMember(Value = "without")]
            Without = 2

        }

        /// <summary>
        /// 決算整理仕訳のみ: only, 決算整理仕訳以外: without(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>決算整理仕訳のみ: only, 決算整理仕訳以外: without(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="adjustment", EmitDefaultValue=false)]
        public AdjustmentEnum? Adjustment { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponseTrialBsTwoYears" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TrialBsTwoYearsResponseTrialBsTwoYears() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponseTrialBsTwoYears" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="upToDate">集計結果が最新かどうか (required).</param>
        /// <param name="fiscalYear">会計年度(条件に指定した時、または条件に月、日条件がない時のみ含まれる）.</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm)(条件に指定した時のみ含まれる）.</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm)(条件に指定した時のみ含まれる）.</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd)(条件に指定した時のみ含まれる）.</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd)(条件に指定した時のみ含まれる）.</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group）(条件に指定した時のみ含まれる）.</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item）(条件に指定した時のみ含まれる）.</param>
        /// <param name="partnerId">取引先ID(条件に指定した時のみ含まれる）.</param>
        /// <param name="partnerCode">取引先コード(条件に指定した時のみ含まれる）.</param>
        /// <param name="itemId">品目ID(条件に指定した時のみ含まれる）.</param>
        /// <param name="adjustment">決算整理仕訳のみ: only, 決算整理仕訳以外: without(条件に指定した時のみ含まれる）.</param>
        /// <param name="createdAt">作成日時.</param>
        /// <param name="balances">balances (required).</param>
        public TrialBsTwoYearsResponseTrialBsTwoYears(int companyId = default(int), bool upToDate = default(bool), int fiscalYear = default(int), int startMonth = default(int), int endMonth = default(int), string startDate = default(string), string endDate = default(string), AccountItemDisplayTypeEnum? accountItemDisplayType = default(AccountItemDisplayTypeEnum?), BreakdownDisplayTypeEnum? breakdownDisplayType = default(BreakdownDisplayTypeEnum?), int partnerId = default(int), string partnerCode = default(string), int itemId = default(int), AdjustmentEnum? adjustment = default(AdjustmentEnum?), string createdAt = default(string), List<TrialBsTwoYearsResponseTrialBsTwoYearsBalances> balances = default(List<TrialBsTwoYearsResponseTrialBsTwoYearsBalances>))
        {
            this.CompanyId = companyId;
            this.UpToDate = upToDate;
            // to ensure "balances" is required (not null)
            this.Balances = balances ?? throw new ArgumentNullException("balances is a required property for TrialBsTwoYearsResponseTrialBsTwoYears and cannot be null");;
            this.FiscalYear = fiscalYear;
            this.StartMonth = startMonth;
            this.EndMonth = endMonth;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountItemDisplayType = accountItemDisplayType;
            this.BreakdownDisplayType = breakdownDisplayType;
            this.PartnerId = partnerId;
            this.PartnerCode = partnerCode;
            this.ItemId = itemId;
            this.Adjustment = adjustment;
            this.CreatedAt = createdAt;
        }
        
        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 集計結果が最新かどうか
        /// </summary>
        /// <value>集計結果が最新かどうか</value>
        [DataMember(Name="up_to_date", EmitDefaultValue=false)]
        public bool UpToDate { get; set; }

        /// <summary>
        /// 会計年度(条件に指定した時、または条件に月、日条件がない時のみ含まれる）
        /// </summary>
        /// <value>会計年度(条件に指定した時、または条件に月、日条件がない時のみ含まれる）</value>
        [DataMember(Name="fiscal_year", EmitDefaultValue=false)]
        public int FiscalYear { get; set; }

        /// <summary>
        /// 発生月で絞込：開始会計月(mm)(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>発生月で絞込：開始会計月(mm)(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="start_month", EmitDefaultValue=false)]
        public int StartMonth { get; set; }

        /// <summary>
        /// 発生月で絞込：終了会計月(mm)(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>発生月で絞込：終了会計月(mm)(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="end_month", EmitDefaultValue=false)]
        public int EndMonth { get; set; }

        /// <summary>
        /// 発生日で絞込：開始日(yyyy-mm-dd)(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>発生日で絞込：開始日(yyyy-mm-dd)(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        /// 発生日で絞込：終了日(yyyy-mm-dd)(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>発生日で絞込：終了日(yyyy-mm-dd)(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="end_date", EmitDefaultValue=false)]
        public string EndDate { get; set; }

        /// <summary>
        /// 取引先ID(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>取引先ID(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="partner_id", EmitDefaultValue=false)]
        public int PartnerId { get; set; }

        /// <summary>
        /// 取引先コード(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>取引先コード(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="partner_code", EmitDefaultValue=false)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 品目ID(条件に指定した時のみ含まれる）
        /// </summary>
        /// <value>品目ID(条件に指定した時のみ含まれる）</value>
        [DataMember(Name="item_id", EmitDefaultValue=false)]
        public int ItemId { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        /// <value>作成日時</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets Balances
        /// </summary>
        [DataMember(Name="balances", EmitDefaultValue=false)]
        public List<TrialBsTwoYearsResponseTrialBsTwoYearsBalances> Balances { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrialBsTwoYearsResponseTrialBsTwoYears {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  UpToDate: ").Append(UpToDate).Append("\n");
            sb.Append("  FiscalYear: ").Append(FiscalYear).Append("\n");
            sb.Append("  StartMonth: ").Append(StartMonth).Append("\n");
            sb.Append("  EndMonth: ").Append(EndMonth).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  AccountItemDisplayType: ").Append(AccountItemDisplayType).Append("\n");
            sb.Append("  BreakdownDisplayType: ").Append(BreakdownDisplayType).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  Adjustment: ").Append(Adjustment).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Balances: ").Append(Balances).Append("\n");
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
            return this.Equals(input as TrialBsTwoYearsResponseTrialBsTwoYears);
        }

        /// <summary>
        /// Returns true if TrialBsTwoYearsResponseTrialBsTwoYears instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialBsTwoYearsResponseTrialBsTwoYears to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialBsTwoYearsResponseTrialBsTwoYears input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.UpToDate == input.UpToDate ||
                    this.UpToDate.Equals(input.UpToDate)
                ) && 
                (
                    this.FiscalYear == input.FiscalYear ||
                    this.FiscalYear.Equals(input.FiscalYear)
                ) && 
                (
                    this.StartMonth == input.StartMonth ||
                    this.StartMonth.Equals(input.StartMonth)
                ) && 
                (
                    this.EndMonth == input.EndMonth ||
                    this.EndMonth.Equals(input.EndMonth)
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
                ) && 
                (
                    this.AccountItemDisplayType == input.AccountItemDisplayType ||
                    this.AccountItemDisplayType.Equals(input.AccountItemDisplayType)
                ) && 
                (
                    this.BreakdownDisplayType == input.BreakdownDisplayType ||
                    this.BreakdownDisplayType.Equals(input.BreakdownDisplayType)
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
                    this.ItemId == input.ItemId ||
                    this.ItemId.Equals(input.ItemId)
                ) && 
                (
                    this.Adjustment == input.Adjustment ||
                    this.Adjustment.Equals(input.Adjustment)
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.Balances == input.Balances ||
                    this.Balances != null &&
                    input.Balances != null &&
                    this.Balances.SequenceEqual(input.Balances)
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
                hashCode = hashCode * 59 + this.UpToDate.GetHashCode();
                hashCode = hashCode * 59 + this.FiscalYear.GetHashCode();
                hashCode = hashCode * 59 + this.StartMonth.GetHashCode();
                hashCode = hashCode * 59 + this.EndMonth.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                hashCode = hashCode * 59 + this.AccountItemDisplayType.GetHashCode();
                hashCode = hashCode * 59 + this.BreakdownDisplayType.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                hashCode = hashCode * 59 + this.ItemId.GetHashCode();
                hashCode = hashCode * 59 + this.Adjustment.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.Balances != null)
                    hashCode = hashCode * 59 + this.Balances.GetHashCode();
                return hashCode;
            }
        }

    }

}
