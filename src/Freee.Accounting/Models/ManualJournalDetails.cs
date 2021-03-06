/*
 * freee API
 *
 *  <h1 id=\"freee_api\">freee API</h1> <hr /> <h2 id=\"start_guide\">スタートガイド</h2>  <p>freee API開発がはじめての方は<a href=\"https://developer.freee.co.jp/getting-started\">freee API スタートガイド</a>を参照してください。</p>  <hr /> <h2 id=\"specification\">仕様</h2>  <pre><code>【重要】会計freee APIの新バージョンについて 2020年12月まで、2つのバージョンが利用できる状態です。古いものは2020年12月に利用不可となります。<br> 新しいAPIを利用するにはリクエストヘッダーに以下を指定します。 X-Api-Version: 2020-06-15<br> 指定がない場合は2020年12月に廃止予定のAPIを利用することとなります。<br> 【重要】APIのバージョン指定をせずに利用し続ける場合 2020年12月に新しいバージョンのAPIに自動的に切り替わります。 詳細は、<a href=\"https://developer.freee.co.jp/release-note/2948\" target=\"_blank\">リリースノート</a>をご覧ください。<br> 旧バージョンのAPIリファレンスを確認したい場合は、<a href=\"https://freee.github.io/freee-api-schema/\" target=\"_blank\">旧バージョンのAPIリファレンスページ</a>をご覧ください。 </code></pre>  <h3 id=\"api_endpoint\">APIエンドポイント</h3>  <p>https://api.freee.co.jp/ (httpsのみ)</p>  <h3 id=\"about_authorize\">認証について</h3> <p>OAuth2.0を利用します。詳細は<a href=\"https://developer.freee.co.jp/docs\" target=\"_blank\">ドキュメントの認証</a>パートを参照してください。</p>  <h3 id=\"data_format\">データフォーマット</h3>  <p>リクエスト、レスポンスともにJSON形式をサポートしていますが、詳細は、API毎の説明欄（application/jsonなど）を確認してください。</p>  <h3 id=\"compatibility\">後方互換性ありの変更</h3>  <p>freeeでは、APIを改善していくために以下のような変更は後方互換性ありとして通知なく変更を入れることがあります。アプリケーション実装者は以下を踏まえて開発を行ってください。</p>  <ul> <li>新しいAPIリソース・エンドポイントの追加</li> <li>既存のAPIに対して必須ではない新しいリクエストパラメータの追加</li> <li>既存のAPIレスポンスに対する新しいプロパティの追加</li> <li>既存のAPIレスポンスに対するプロパティの順番の入れ変え</li> <li>keyとなっているidやcodeの長さの変更（長くする）</li> </ul>  <h3 id=\"common_response_header\">共通レスポンスヘッダー</h3>  <p>すべてのAPIのレスポンスには以下のHTTPヘッダーが含まれます。</p>  <ul> <li> <p>X-Freee-Request-ID</p> <ul> <li>各リクエスト毎に発行されるID</li> </ul> </li> </ul>  <h3 id=\"common_error_response\">共通エラーレスポンス</h3>  <ul> <li> <p>ステータスコードはレスポンス内のJSONに含まれる他、HTTPヘッダにも含まれる</p> </li> <li> <p>一部のエラーレスポンスにはエラーコードが含まれます。<br>詳細は、<a href=\"https://developer.freee.co.jp/tips/faq/40x-checkpoint\">HTTPステータスコード400台エラー時のチェックポイント</a>を参照してください</p> </li> <p>type</p>  <ul> <li>status : HTTPステータスコードの説明</li>  <li>validation : エラーの詳細の説明（開発者向け）</li> </ul> </li> </ul>  <p>レスポンスの例</p>  <pre><code>  {     &quot;status_code&quot; : 400,     &quot;errors&quot; : [       {         &quot;type&quot; : &quot;status&quot;,         &quot;messages&quot; : [&quot;不正なリクエストです。&quot;]       },       {         &quot;type&quot; : &quot;validation&quot;,         &quot;messages&quot; : [&quot;Date は不正な日付フォーマットです。入力例：2013-01-01&quot;]       }     ]   }</code></pre>  </br>  <h3 id=\"api_rate_limit\">API使用制限</h3>    <p>freeeは一定期間に過度のアクセスを検知した場合、APIアクセスをコントロールする場合があります。</p>   <p>その際のhttp status codeは403となります。制限がかかってから10分程度が過ぎると再度使用することができるようになります。</p>  <h4 id=\"reports_api_endpoint\">/reportsエンドポイント</h4>  <p>freeeは/reportsエンドポイントに対して1秒間に10以上のアクセスを検知した場合、APIアクセスをコントロールする場合があります。その際のhttp status codeは429（too many requests）となります。</p>  <p>レスポンスボディのmetaプロパティに以下を含めます。</p>  <ul>   <li>設定されている上限値</li>   <li>上限に達するまでの使用可能回数</li>   <li>（上限値に達した場合）使用回数がリセットされる時刻</li> </ul>  <h3 id=\"plan_api_rate_limit\">プラン別のAPI Rate Limit</h3>   <table border=\"1\">     <tbody>       <tr>         <th style=\"padding: 10px\"><strong>会計freeeプラン名</strong></th>         <th style=\"padding: 10px\"><strong>事業所とアプリケーション毎に1日でのAPIコール数</strong></th>       </tr>       <tr>         <td style=\"padding: 10px\">エンタープライズ</td>         <td style=\"padding: 10px\">10,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">プロフェッショナル</td>         <td style=\"padding: 10px\">5,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ベーシック</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ミニマム</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">上記以外</td>         <td style=\"padding: 10px\">3,000</td>       </tr>     </tbody>   </table>  <h3 id=\"webhook\">Webhookについて</h3>  <p>詳細は<a href=\"https://developer.freee.co.jp/docs/accounting/webhook\" target=\"_blank\">会計Webhook概要</a>を参照してください。</p>  <hr /> <h2 id=\"contact\">連絡先</h2>  <p>ご不明点、ご要望等は <a href=\"https://support.freee.co.jp/hc/ja/requests/new\">freee サポートデスクへのお問い合わせフォーム</a> からご連絡ください。</p> <hr />&copy; Since 2013 freee K.K.
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
    /// ManualJournalDetails
    /// </summary>
    [DataContract(Name = "manual_journal_details")]
    public partial class ManualJournalDetails : IEquatable<ManualJournalDetails>
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
        [DataMember(Name = "entry_side", IsRequired = true, EmitDefaultValue = false)]
        public EntrySideEnum EntrySide { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ManualJournalDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalDetails" /> class.
        /// </summary>
        /// <param name="accountItemId">勘定科目ID (required).</param>
        /// <param name="amount">金額（税込で指定してください） (required).</param>
        /// <param name="description">備考 (required).</param>
        /// <param name="entrySide">貸借(貸方: credit, 借方: debit) (required).</param>
        /// <param name="id">貸借行ID (required).</param>
        /// <param name="itemId">品目ID (required).</param>
        /// <param name="itemName">品目 (required).</param>
        /// <param name="partnerCode">取引先コード.</param>
        /// <param name="partnerId">取引先ID (required).</param>
        /// <param name="partnerLongName">正式名称（255文字以内） (required).</param>
        /// <param name="partnerName">取引先名 (required).</param>
        /// <param name="sectionId">部門ID (required).</param>
        /// <param name="sectionName">部門 (required).</param>
        /// <param name="segment1TagId">セグメント１ID.</param>
        /// <param name="segment1TagName">セグメント１ID.</param>
        /// <param name="segment2TagId">セグメント２ID.</param>
        /// <param name="segment2TagName">セグメント２.</param>
        /// <param name="segment3TagId">セグメント３ID.</param>
        /// <param name="segment3TagName">セグメント３.</param>
        /// <param name="tagIds">tagIds (required).</param>
        /// <param name="tagNames">tagNames (required).</param>
        /// <param name="taxCode">税区分コード (required).</param>
        /// <param name="vat">消費税額（指定しない場合は自動で計算されます） (required).</param>
        public ManualJournalDetails(int accountItemId = default(int), int amount = default(int), string description = default(string), EntrySideEnum entrySide = default(EntrySideEnum), long id = default(long), int? itemId = default(int?), string itemName = default(string), string partnerCode = default(string), int? partnerId = default(int?), string partnerLongName = default(string), string partnerName = default(string), int? sectionId = default(int?), string sectionName = default(string), long segment1TagId = default(long), int segment1TagName = default(int), long segment2TagId = default(long), int segment2TagName = default(int), long segment3TagId = default(long), int segment3TagName = default(int), List<int> tagIds = default(List<int>), List<string> tagNames = default(List<string>), int taxCode = default(int), int vat = default(int))
        {
            this.AccountItemId = accountItemId;
            this.Amount = amount;
            // to ensure "description" is required (not null)
            this.Description = description ?? throw new ArgumentNullException("description is a required property for ManualJournalDetails and cannot be null");
            this.EntrySide = entrySide;
            this.Id = id;
            // to ensure "itemId" is required (not null)
            this.ItemId = itemId ?? throw new ArgumentNullException("itemId is a required property for ManualJournalDetails and cannot be null");
            // to ensure "itemName" is required (not null)
            this.ItemName = itemName ?? throw new ArgumentNullException("itemName is a required property for ManualJournalDetails and cannot be null");
            // to ensure "partnerId" is required (not null)
            this.PartnerId = partnerId ?? throw new ArgumentNullException("partnerId is a required property for ManualJournalDetails and cannot be null");
            // to ensure "partnerLongName" is required (not null)
            this.PartnerLongName = partnerLongName ?? throw new ArgumentNullException("partnerLongName is a required property for ManualJournalDetails and cannot be null");
            // to ensure "partnerName" is required (not null)
            this.PartnerName = partnerName ?? throw new ArgumentNullException("partnerName is a required property for ManualJournalDetails and cannot be null");
            // to ensure "sectionId" is required (not null)
            this.SectionId = sectionId ?? throw new ArgumentNullException("sectionId is a required property for ManualJournalDetails and cannot be null");
            // to ensure "sectionName" is required (not null)
            this.SectionName = sectionName ?? throw new ArgumentNullException("sectionName is a required property for ManualJournalDetails and cannot be null");
            // to ensure "tagIds" is required (not null)
            this.TagIds = tagIds ?? throw new ArgumentNullException("tagIds is a required property for ManualJournalDetails and cannot be null");
            // to ensure "tagNames" is required (not null)
            this.TagNames = tagNames ?? throw new ArgumentNullException("tagNames is a required property for ManualJournalDetails and cannot be null");
            this.TaxCode = taxCode;
            this.Vat = vat;
            this.PartnerCode = partnerCode;
            this.Segment1TagId = segment1TagId;
            this.Segment1TagName = segment1TagName;
            this.Segment2TagId = segment2TagId;
            this.Segment2TagName = segment2TagName;
            this.Segment3TagId = segment3TagId;
            this.Segment3TagName = segment3TagName;
        }

        /// <summary>
        /// 勘定科目ID
        /// </summary>
        /// <value>勘定科目ID</value>
        [DataMember(Name = "account_item_id", IsRequired = true, EmitDefaultValue = false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 金額（税込で指定してください）
        /// </summary>
        /// <value>金額（税込で指定してください）</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = false)]
        public int Amount { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        /// <value>備考</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// 貸借行ID
        /// </summary>
        /// <value>貸借行ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// 品目ID
        /// </summary>
        /// <value>品目ID</value>
        [DataMember(Name = "item_id", IsRequired = true, EmitDefaultValue = true)]
        public int? ItemId { get; set; }

        /// <summary>
        /// 品目
        /// </summary>
        /// <value>品目</value>
        [DataMember(Name = "item_name", IsRequired = true, EmitDefaultValue = true)]
        public string ItemName { get; set; }

        /// <summary>
        /// 取引先コード
        /// </summary>
        /// <value>取引先コード</value>
        [DataMember(Name = "partner_code", EmitDefaultValue = true)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 取引先ID
        /// </summary>
        /// <value>取引先ID</value>
        [DataMember(Name = "partner_id", IsRequired = true, EmitDefaultValue = true)]
        public int? PartnerId { get; set; }

        /// <summary>
        /// 正式名称（255文字以内）
        /// </summary>
        /// <value>正式名称（255文字以内）</value>
        [DataMember(Name = "partner_long_name", IsRequired = true, EmitDefaultValue = true)]
        public string PartnerLongName { get; set; }

        /// <summary>
        /// 取引先名
        /// </summary>
        /// <value>取引先名</value>
        [DataMember(Name = "partner_name", IsRequired = true, EmitDefaultValue = true)]
        public string PartnerName { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        /// <value>部門ID</value>
        [DataMember(Name = "section_id", IsRequired = true, EmitDefaultValue = true)]
        public int? SectionId { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        /// <value>部門</value>
        [DataMember(Name = "section_name", IsRequired = true, EmitDefaultValue = true)]
        public string SectionName { get; set; }

        /// <summary>
        /// セグメント１ID
        /// </summary>
        /// <value>セグメント１ID</value>
        [DataMember(Name = "segment_1_tag_id", EmitDefaultValue = false)]
        public long Segment1TagId { get; set; }

        /// <summary>
        /// セグメント１ID
        /// </summary>
        /// <value>セグメント１ID</value>
        [DataMember(Name = "segment_1_tag_name", EmitDefaultValue = false)]
        public int Segment1TagName { get; set; }

        /// <summary>
        /// セグメント２ID
        /// </summary>
        /// <value>セグメント２ID</value>
        [DataMember(Name = "segment_2_tag_id", EmitDefaultValue = false)]
        public long Segment2TagId { get; set; }

        /// <summary>
        /// セグメント２
        /// </summary>
        /// <value>セグメント２</value>
        [DataMember(Name = "segment_2_tag_name", EmitDefaultValue = false)]
        public int Segment2TagName { get; set; }

        /// <summary>
        /// セグメント３ID
        /// </summary>
        /// <value>セグメント３ID</value>
        [DataMember(Name = "segment_3_tag_id", EmitDefaultValue = false)]
        public long Segment3TagId { get; set; }

        /// <summary>
        /// セグメント３
        /// </summary>
        /// <value>セグメント３</value>
        [DataMember(Name = "segment_3_tag_name", EmitDefaultValue = false)]
        public int Segment3TagName { get; set; }

        /// <summary>
        /// Gets or Sets TagIds
        /// </summary>
        [DataMember(Name = "tag_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<int> TagIds { get; set; }

        /// <summary>
        /// Gets or Sets TagNames
        /// </summary>
        [DataMember(Name = "tag_names", IsRequired = true, EmitDefaultValue = false)]
        public List<string> TagNames { get; set; }

        /// <summary>
        /// 税区分コード
        /// </summary>
        /// <value>税区分コード</value>
        [DataMember(Name = "tax_code", IsRequired = true, EmitDefaultValue = false)]
        public int TaxCode { get; set; }

        /// <summary>
        /// 消費税額（指定しない場合は自動で計算されます）
        /// </summary>
        /// <value>消費税額（指定しない場合は自動で計算されます）</value>
        [DataMember(Name = "vat", IsRequired = true, EmitDefaultValue = false)]
        public int Vat { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManualJournalDetails {\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EntrySide: ").Append(EntrySide).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerLongName: ").Append(PartnerLongName).Append("\n");
            sb.Append("  PartnerName: ").Append(PartnerName).Append("\n");
            sb.Append("  SectionId: ").Append(SectionId).Append("\n");
            sb.Append("  SectionName: ").Append(SectionName).Append("\n");
            sb.Append("  Segment1TagId: ").Append(Segment1TagId).Append("\n");
            sb.Append("  Segment1TagName: ").Append(Segment1TagName).Append("\n");
            sb.Append("  Segment2TagId: ").Append(Segment2TagId).Append("\n");
            sb.Append("  Segment2TagName: ").Append(Segment2TagName).Append("\n");
            sb.Append("  Segment3TagId: ").Append(Segment3TagId).Append("\n");
            sb.Append("  Segment3TagName: ").Append(Segment3TagName).Append("\n");
            sb.Append("  TagIds: ").Append(TagIds).Append("\n");
            sb.Append("  TagNames: ").Append(TagNames).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  Vat: ").Append(Vat).Append("\n");
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
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.Amount == input.Amount ||
                    this.Amount.Equals(input.Amount)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.EntrySide == input.EntrySide ||
                    this.EntrySide.Equals(input.EntrySide)
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
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
                    this.PartnerLongName == input.PartnerLongName ||
                    (this.PartnerLongName != null &&
                    this.PartnerLongName.Equals(input.PartnerLongName))
                ) && 
                (
                    this.PartnerName == input.PartnerName ||
                    (this.PartnerName != null &&
                    this.PartnerName.Equals(input.PartnerName))
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
                    this.TaxCode == input.TaxCode ||
                    this.TaxCode.Equals(input.TaxCode)
                ) && 
                (
                    this.Vat == input.Vat ||
                    this.Vat.Equals(input.Vat)
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
                hashCode = hashCode * 59 + this.AccountItemId.GetHashCode();
                hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.EntrySide.GetHashCode();
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.ItemId != null)
                    hashCode = hashCode * 59 + this.ItemId.GetHashCode();
                if (this.ItemName != null)
                    hashCode = hashCode * 59 + this.ItemName.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                if (this.PartnerId != null)
                    hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerLongName != null)
                    hashCode = hashCode * 59 + this.PartnerLongName.GetHashCode();
                if (this.PartnerName != null)
                    hashCode = hashCode * 59 + this.PartnerName.GetHashCode();
                if (this.SectionId != null)
                    hashCode = hashCode * 59 + this.SectionId.GetHashCode();
                if (this.SectionName != null)
                    hashCode = hashCode * 59 + this.SectionName.GetHashCode();
                hashCode = hashCode * 59 + this.Segment1TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment1TagName.GetHashCode();
                hashCode = hashCode * 59 + this.Segment2TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment2TagName.GetHashCode();
                hashCode = hashCode * 59 + this.Segment3TagId.GetHashCode();
                hashCode = hashCode * 59 + this.Segment3TagName.GetHashCode();
                if (this.TagIds != null)
                    hashCode = hashCode * 59 + this.TagIds.GetHashCode();
                if (this.TagNames != null)
                    hashCode = hashCode * 59 + this.TagNames.GetHashCode();
                hashCode = hashCode * 59 + this.TaxCode.GetHashCode();
                hashCode = hashCode * 59 + this.Vat.GetHashCode();
                return hashCode;
            }
        }

    }

}
