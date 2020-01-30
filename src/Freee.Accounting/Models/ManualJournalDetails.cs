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
    /// ManualJournalDetails
    /// </summary>
    [DataContract]
    public partial class ManualJournalDetails :  IEquatable<ManualJournalDetails>
    {
        /// <summary>
        /// 貸借(貸方: credit, 借方: debit)
        /// </summary>
        /// <value>貸借(貸方: credit, 借方: debit)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EntrySideEnum
        {
            /// <summary>
            /// Enum Credit for value: credit
            /// </summary>
            [EnumMember(Value = "credit")]
            Credit = 1,

            /// <summary>
            /// Enum Debit for value: debit
            /// </summary>
            [EnumMember(Value = "debit")]
            Debit = 2

        }

        /// <summary>
        /// 貸借(貸方: credit, 借方: debit)
        /// </summary>
        /// <value>貸借(貸方: credit, 借方: debit)</value>
        [DataMember(Name="entry_side", EmitDefaultValue=false)]
        public EntrySideEnum EntrySide { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ManualJournalDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalDetails" /> class.
        /// </summary>
        /// <param name="id">貸借行ID (required).</param>
        /// <param name="entrySide">貸借(貸方: credit, 借方: debit) (required).</param>
        /// <param name="accountItemId">勘定科目ID (required).</param>
        /// <param name="taxCode">税区分ID (required).</param>
        /// <param name="partnerId">取引先ID (required).</param>
        /// <param name="partnerName">取引先名 (required).</param>
        /// <param name="partnerCode">取引先コード.</param>
        /// <param name="partnerLongName">正式名称（255文字以内） (required).</param>
        /// <param name="itemId">品目ID (required).</param>
        /// <param name="itemName">品目 (required).</param>
        /// <param name="sectionId">部門ID (required).</param>
        /// <param name="sectionName">部門 (required).</param>
        /// <param name="tagIds">tagIds (required).</param>
        /// <param name="tagNames">tagNames (required).</param>
        /// <param name="segment1TagId">セグメント１ID.</param>
        /// <param name="segment1TagName">セグメント１ID.</param>
        /// <param name="segment2TagId">セグメント２ID.</param>
        /// <param name="segment2TagName">セグメント２.</param>
        /// <param name="segment3TagId">セグメント３ID.</param>
        /// <param name="segment3TagName">セグメント３.</param>
        /// <param name="amount">金額（税込で指定してください） (required).</param>
        /// <param name="vat">消費税額（指定しない場合は自動で計算されます） (required).</param>
        /// <param name="description">備考 (required).</param>
        public ManualJournalDetails(int id = default(int), EntrySideEnum entrySide = default(EntrySideEnum), int accountItemId = default(int), int taxCode = default(int), int? partnerId = default(int?), string partnerName = default(string), string partnerCode = default(string), string partnerLongName = default(string), int? itemId = default(int?), string itemName = default(string), int? sectionId = default(int?), string sectionName = default(string), List<int> tagIds = default(List<int>), List<string> tagNames = default(List<string>), int segment1TagId = default(int), int segment1TagName = default(int), int segment2TagId = default(int), int segment2TagName = default(int), int segment3TagId = default(int), int segment3TagName = default(int), int amount = default(int), int vat = default(int), string description = default(string))
        {
            this.Id = id;
            this.EntrySide = entrySide;
            this.AccountItemId = accountItemId;
            this.TaxCode = taxCode;
            // to ensure "partnerId" is required (not null)
            this.PartnerId = partnerId ?? throw new ArgumentNullException("partnerId is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "partnerName" is required (not null)
            this.PartnerName = partnerName ?? throw new ArgumentNullException("partnerName is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "partnerLongName" is required (not null)
            this.PartnerLongName = partnerLongName ?? throw new ArgumentNullException("partnerLongName is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "itemId" is required (not null)
            this.ItemId = itemId ?? throw new ArgumentNullException("itemId is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "itemName" is required (not null)
            this.ItemName = itemName ?? throw new ArgumentNullException("itemName is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "sectionId" is required (not null)
            this.SectionId = sectionId ?? throw new ArgumentNullException("sectionId is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "sectionName" is required (not null)
            this.SectionName = sectionName ?? throw new ArgumentNullException("sectionName is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "tagIds" is required (not null)
            this.TagIds = tagIds ?? throw new ArgumentNullException("tagIds is a required property for ManualJournalDetails and cannot be null");;
            // to ensure "tagNames" is required (not null)
            this.TagNames = tagNames ?? throw new ArgumentNullException("tagNames is a required property for ManualJournalDetails and cannot be null");;
            this.Amount = amount;
            this.Vat = vat;
            // to ensure "description" is required (not null)
            this.Description = description ?? throw new ArgumentNullException("description is a required property for ManualJournalDetails and cannot be null");;
            this.PartnerCode = partnerCode;
            this.Segment1TagId = segment1TagId;
            this.Segment1TagName = segment1TagName;
            this.Segment2TagId = segment2TagId;
            this.Segment2TagName = segment2TagName;
            this.Segment3TagId = segment3TagId;
            this.Segment3TagName = segment3TagName;
        }
        
        /// <summary>
        /// 貸借行ID
        /// </summary>
        /// <value>貸借行ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// 勘定科目ID
        /// </summary>
        /// <value>勘定科目ID</value>
        [DataMember(Name="account_item_id", EmitDefaultValue=false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 税区分ID
        /// </summary>
        /// <value>税区分ID</value>
        [DataMember(Name="tax_code", EmitDefaultValue=false)]
        public int TaxCode { get; set; }

        /// <summary>
        /// 取引先ID
        /// </summary>
        /// <value>取引先ID</value>
        [DataMember(Name="partner_id", EmitDefaultValue=true)]
        public int? PartnerId { get; set; }

        /// <summary>
        /// 取引先名
        /// </summary>
        /// <value>取引先名</value>
        [DataMember(Name="partner_name", EmitDefaultValue=true)]
        public string PartnerName { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        /// <value>取引先コード</value>
        [DataMember(Name="partner_code", EmitDefaultValue=true)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 正式名称（255文字以内）
        /// </summary>
        /// <value>正式名称（255文字以内）</value>
        [DataMember(Name="partner_long_name", EmitDefaultValue=true)]
        public string PartnerLongName { get; set; }

        /// <summary>
        /// 品目ID
        /// </summary>
        /// <value>品目ID</value>
        [DataMember(Name="item_id", EmitDefaultValue=true)]
        public int? ItemId { get; set; }

        /// <summary>
        /// 品目
        /// </summary>
        /// <value>品目</value>
        [DataMember(Name="item_name", EmitDefaultValue=true)]
        public string ItemName { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        /// <value>部門ID</value>
        [DataMember(Name="section_id", EmitDefaultValue=true)]
        public int? SectionId { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        /// <value>部門</value>
        [DataMember(Name="section_name", EmitDefaultValue=true)]
        public string SectionName { get; set; }

        /// <summary>
        /// Gets or Sets TagIds
        /// </summary>
        [DataMember(Name="tag_ids", EmitDefaultValue=false)]
        public List<int> TagIds { get; set; }

        /// <summary>
        /// Gets or Sets TagNames
        /// </summary>
        [DataMember(Name="tag_names", EmitDefaultValue=false)]
        public List<string> TagNames { get; set; }

        /// <summary>
        /// セグメント１ID
        /// </summary>
        /// <value>セグメント１ID</value>
        [DataMember(Name="segment_1_tag_id", EmitDefaultValue=false)]
        public int Segment1TagId { get; set; }

        /// <summary>
        /// セグメント１ID
        /// </summary>
        /// <value>セグメント１ID</value>
        [DataMember(Name="segment_1_tag_name", EmitDefaultValue=false)]
        public int Segment1TagName { get; set; }

        /// <summary>
        /// セグメント２ID
        /// </summary>
        /// <value>セグメント２ID</value>
        [DataMember(Name="segment_2_tag_id", EmitDefaultValue=false)]
        public int Segment2TagId { get; set; }

        /// <summary>
        /// セグメント２
        /// </summary>
        /// <value>セグメント２</value>
        [DataMember(Name="segment_2_tag_name", EmitDefaultValue=false)]
        public int Segment2TagName { get; set; }

        /// <summary>
        /// セグメント３ID
        /// </summary>
        /// <value>セグメント３ID</value>
        [DataMember(Name="segment_3_tag_id", EmitDefaultValue=false)]
        public int Segment3TagId { get; set; }

        /// <summary>
        /// セグメント３
        /// </summary>
        /// <value>セグメント３</value>
        [DataMember(Name="segment_3_tag_name", EmitDefaultValue=false)]
        public int Segment3TagName { get; set; }

        /// <summary>
        /// 金額（税込で指定してください）
        /// </summary>
        /// <value>金額（税込で指定してください）</value>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public int Amount { get; set; }

        /// <summary>
        /// 消費税額（指定しない場合は自動で計算されます）
        /// </summary>
        /// <value>消費税額（指定しない場合は自動で計算されます）</value>
        [DataMember(Name="vat", EmitDefaultValue=false)]
        public int Vat { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        /// <value>備考</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManualJournalDetails {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EntrySide: ").Append(EntrySide).Append("\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerName: ").Append(PartnerName).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  PartnerLongName: ").Append(PartnerLongName).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  SectionId: ").Append(SectionId).Append("\n");
            sb.Append("  SectionName: ").Append(SectionName).Append("\n");
            sb.Append("  TagIds: ").Append(TagIds).Append("\n");
            sb.Append("  TagNames: ").Append(TagNames).Append("\n");
            sb.Append("  Segment1TagId: ").Append(Segment1TagId).Append("\n");
            sb.Append("  Segment1TagName: ").Append(Segment1TagName).Append("\n");
            sb.Append("  Segment2TagId: ").Append(Segment2TagId).Append("\n");
            sb.Append("  Segment2TagName: ").Append(Segment2TagName).Append("\n");
            sb.Append("  Segment3TagId: ").Append(Segment3TagId).Append("\n");
            sb.Append("  Segment3TagName: ").Append(Segment3TagName).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Vat: ").Append(Vat).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as ManualJournalDetails);
        }

        /// <summary>
        /// Returns true if ManualJournalDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of ManualJournalDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManualJournalDetails input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.EntrySide == input.EntrySide ||
                    this.EntrySide.Equals(input.EntrySide)
                ) && 
                (
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.TaxCode == input.TaxCode ||
                    this.TaxCode.Equals(input.TaxCode)
                ) && 
                (
                    this.PartnerId == input.PartnerId ||
                    (this.PartnerId != null &&
                    this.PartnerId.Equals(input.PartnerId))
                ) && 
                (
                    this.PartnerName == input.PartnerName ||
                    (this.PartnerName != null &&
                    this.PartnerName.Equals(input.PartnerName))
                ) && 
                (
                    this.PartnerCode == input.PartnerCode ||
                    (this.PartnerCode != null &&
                    this.PartnerCode.Equals(input.PartnerCode))
                ) && 
                (
                    this.PartnerLongName == input.PartnerLongName ||
                    (this.PartnerLongName != null &&
                    this.PartnerLongName.Equals(input.PartnerLongName))
                ) && 
                (
                    this.ItemId == input.ItemId ||
                    (this.ItemId != null &&
                    this.ItemId.Equals(input.ItemId))
                ) && 
                (
                    this.ItemName == input.ItemName ||
                    (this.ItemName != null &&
                    this.ItemName.Equals(input.ItemName))
                ) && 
                (
                    this.SectionId == input.SectionId ||
                    (this.SectionId != null &&
                    this.SectionId.Equals(input.SectionId))
                ) && 
                (
                    this.SectionName == input.SectionName ||
                    (this.SectionName != null &&
                    this.SectionName.Equals(input.SectionName))
                ) && 
                (
                    this.TagIds == input.TagIds ||
                    this.TagIds != null &&
                    input.TagIds != null &&
                    this.TagIds.SequenceEqual(input.TagIds)
                ) && 
                (
                    this.TagNames == input.TagNames ||
                    this.TagNames != null &&
                    input.TagNames != null &&
                    this.TagNames.SequenceEqual(input.TagNames)
                ) && 
                (
                    this.Segment1TagId == input.Segment1TagId ||
                    this.Segment1TagId.Equals(input.Segment1TagId)
                ) && 
                (
                    this.Segment1TagName == input.Segment1TagName ||
                    this.Segment1TagName.Equals(input.Segment1TagName)
                ) && 
                (
                    this.Segment2TagId == input.Segment2TagId ||
                    this.Segment2TagId.Equals(input.Segment2TagId)
                ) && 
                (
                    this.Segment2TagName == input.Segment2TagName ||
                    this.Segment2TagName.Equals(input.Segment2TagName)
                ) && 
                (
                    this.Segment3TagId == input.Segment3TagId ||
                    this.Segment3TagId.Equals(input.Segment3TagId)
                ) && 
                (
                    this.Segment3TagName == input.Segment3TagName ||
                    this.Segment3TagName.Equals(input.Segment3TagName)
                ) && 
                (
                    this.Amount == input.Amount ||
                    this.Amount.Equals(input.Amount)
                ) && 
                (
                    this.Vat == input.Vat ||
                    this.Vat.Equals(input.Vat)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                hashCode = hashCode * 59 + this.EntrySide.GetHashCode();
                hashCode = hashCode * 59 + this.AccountItemId.GetHashCode();
                hashCode = hashCode * 59 + this.TaxCode.GetHashCode();
                if (this.PartnerId != null)
                    hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerName != null)
                    hashCode = hashCode * 59 + this.PartnerName.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                if (this.PartnerLongName != null)
                    hashCode = hashCode * 59 + this.PartnerLongName.GetHashCode();
                if (this.ItemId != null)
                    hashCode = hashCode * 59 + this.ItemId.GetHashCode();
                if (this.ItemName != null)
                    hashCode = hashCode * 59 + this.ItemName.GetHashCode();
                if (this.SectionId != null)
                    hashCode = hashCode * 59 + this.SectionId.GetHashCode();
                if (this.SectionName != null)
                    hashCode = hashCode * 59 + this.SectionName.GetHashCode();
                if (this.TagIds != null)
                    hashCode = hashCode * 59 + this.TagIds.GetHashCode();
                if (this.TagNames != null)
                    hashCode = hashCode * 59 + this.TagNames.GetHashCode();
                hashCode = hashCode * 59 + this.Segment1TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment1TagName.GetHashCode();
                hashCode = hashCode * 59 + this.Segment2TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment2TagName.GetHashCode();
                hashCode = hashCode * 59 + this.Segment3TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment3TagName.GetHashCode();
                hashCode = hashCode * 59 + this.Amount.GetHashCode();
                hashCode = hashCode * 59 + this.Vat.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                return hashCode;
            }
        }

    }

}
