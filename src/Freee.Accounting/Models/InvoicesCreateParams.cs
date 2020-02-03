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
    /// InvoicesCreateParams
    /// </summary>
    [DataContract]
    public partial class InvoicesCreateParams :  IEquatable<InvoicesCreateParams>
    {
        /// <summary>
        /// 請求書ステータス  (draft: 下書き (デフォルト), issue: 発行(請求先ワークフローを利用している場合は指定できません))
        /// </summary>
        /// <value>請求書ステータス  (draft: 下書き (デフォルト), issue: 発行(請求先ワークフローを利用している場合は指定できません))</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InvoiceStatusEnum
        {
            /// <summary>
            /// Enum Draft for value: draft
            /// </summary>
            [EnumMember(Value = "draft")]
            Draft = 1,

            /// <summary>
            /// Enum Issue for value: issue
            /// </summary>
            [EnumMember(Value = "issue")]
            Issue = 2

        }

        /// <summary>
        /// 請求書ステータス  (draft: 下書き (デフォルト), issue: 発行(請求先ワークフローを利用している場合は指定できません))
        /// </summary>
        /// <value>請求書ステータス  (draft: 下書き (デフォルト), issue: 発行(請求先ワークフローを利用している場合は指定できません))</value>
        [DataMember(Name="invoice_status", EmitDefaultValue=false)]
        public InvoiceStatusEnum? InvoiceStatus { get; set; }
        /// <summary>
        /// 支払方法 (振込: transfer, 引き落とし: direct_debit)
        /// </summary>
        /// <value>支払方法 (振込: transfer, 引き落とし: direct_debit)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentTypeEnum
        {
            /// <summary>
            /// Enum Transfer for value: transfer
            /// </summary>
            [EnumMember(Value = "transfer")]
            Transfer = 1,

            /// <summary>
            /// Enum Directdebit for value: direct_debit
            /// </summary>
            [EnumMember(Value = "direct_debit")]
            Directdebit = 2

        }

        /// <summary>
        /// 支払方法 (振込: transfer, 引き落とし: direct_debit)
        /// </summary>
        /// <value>支払方法 (振込: transfer, 引き落とし: direct_debit)</value>
        [DataMember(Name="payment_type", EmitDefaultValue=false)]
        public PaymentTypeEnum? PaymentType { get; set; }
        /// <summary>
        /// 振込専用口座の利用(利用しない: not_use(デフォルト), 利用する: use)
        /// </summary>
        /// <value>振込専用口座の利用(利用しない: not_use(デフォルト), 利用する: use)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UseVirtualTransferAccountEnum
        {
            /// <summary>
            /// Enum Notuse for value: not_use
            /// </summary>
            [EnumMember(Value = "not_use")]
            Notuse = 1,

            /// <summary>
            /// Enum Use for value: use
            /// </summary>
            [EnumMember(Value = "use")]
            Use = 2

        }

        /// <summary>
        /// 振込専用口座の利用(利用しない: not_use(デフォルト), 利用する: use)
        /// </summary>
        /// <value>振込専用口座の利用(利用しない: not_use(デフォルト), 利用する: use)</value>
        [DataMember(Name="use_virtual_transfer_account", EmitDefaultValue=false)]
        public UseVirtualTransferAccountEnum? UseVirtualTransferAccount { get; set; }
        /// <summary>
        /// レイアウト(default_classic: レイアウト１/クラシック (デフォルト), standard_classic: レイアウト２/クラシック, envelope_classic: 封筒１/クラシック, carried_forward_standard_classic: レイアウト３（繰越金額欄あり）/クラシック, carried_forward_envelope_classic: 封筒２（繰越金額欄あり）/クラシック, default_modern: レイアウト１/モダン, standard_modern: レイアウト２/モダン, envelope_modern: 封筒/モダン)
        /// </summary>
        /// <value>レイアウト(default_classic: レイアウト１/クラシック (デフォルト), standard_classic: レイアウト２/クラシック, envelope_classic: 封筒１/クラシック, carried_forward_standard_classic: レイアウト３（繰越金額欄あり）/クラシック, carried_forward_envelope_classic: 封筒２（繰越金額欄あり）/クラシック, default_modern: レイアウト１/モダン, standard_modern: レイアウト２/モダン, envelope_modern: 封筒/モダン)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InvoiceLayoutEnum
        {
            /// <summary>
            /// Enum Defaultclassic for value: default_classic
            /// </summary>
            [EnumMember(Value = "default_classic")]
            Defaultclassic = 1,

            /// <summary>
            /// Enum Standardclassic for value: standard_classic
            /// </summary>
            [EnumMember(Value = "standard_classic")]
            Standardclassic = 2,

            /// <summary>
            /// Enum Envelopeclassic for value: envelope_classic
            /// </summary>
            [EnumMember(Value = "envelope_classic")]
            Envelopeclassic = 3,

            /// <summary>
            /// Enum Carriedforwardstandardclassic for value: carried_forward_standard_classic
            /// </summary>
            [EnumMember(Value = "carried_forward_standard_classic")]
            Carriedforwardstandardclassic = 4,

            /// <summary>
            /// Enum Carriedforwardenvelopeclassic for value: carried_forward_envelope_classic
            /// </summary>
            [EnumMember(Value = "carried_forward_envelope_classic")]
            Carriedforwardenvelopeclassic = 5,

            /// <summary>
            /// Enum Defaultmodern for value: default_modern
            /// </summary>
            [EnumMember(Value = "default_modern")]
            Defaultmodern = 6,

            /// <summary>
            /// Enum Standardmodern for value: standard_modern
            /// </summary>
            [EnumMember(Value = "standard_modern")]
            Standardmodern = 7,

            /// <summary>
            /// Enum Envelopemodern for value: envelope_modern
            /// </summary>
            [EnumMember(Value = "envelope_modern")]
            Envelopemodern = 8

        }

        /// <summary>
        /// レイアウト(default_classic: レイアウト１/クラシック (デフォルト), standard_classic: レイアウト２/クラシック, envelope_classic: 封筒１/クラシック, carried_forward_standard_classic: レイアウト３（繰越金額欄あり）/クラシック, carried_forward_envelope_classic: 封筒２（繰越金額欄あり）/クラシック, default_modern: レイアウト１/モダン, standard_modern: レイアウト２/モダン, envelope_modern: 封筒/モダン)
        /// </summary>
        /// <value>レイアウト(default_classic: レイアウト１/クラシック (デフォルト), standard_classic: レイアウト２/クラシック, envelope_classic: 封筒１/クラシック, carried_forward_standard_classic: レイアウト３（繰越金額欄あり）/クラシック, carried_forward_envelope_classic: 封筒２（繰越金額欄あり）/クラシック, default_modern: レイアウト１/モダン, standard_modern: レイアウト２/モダン, envelope_modern: 封筒/モダン)</value>
        [DataMember(Name="invoice_layout", EmitDefaultValue=false)]
        public InvoiceLayoutEnum? InvoiceLayout { get; set; }
        /// <summary>
        /// 請求書の消費税計算方法(inclusive: 内税表示, exclusive: 外税表示 (デフォルト))
        /// </summary>
        /// <value>請求書の消費税計算方法(inclusive: 内税表示, exclusive: 外税表示 (デフォルト))</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TaxEntryMethodEnum
        {
            /// <summary>
            /// Enum Inclusive for value: inclusive
            /// </summary>
            [EnumMember(Value = "inclusive")]
            Inclusive = 1,

            /// <summary>
            /// Enum Exclusive for value: exclusive
            /// </summary>
            [EnumMember(Value = "exclusive")]
            Exclusive = 2

        }

        /// <summary>
        /// 請求書の消費税計算方法(inclusive: 内税表示, exclusive: 外税表示 (デフォルト))
        /// </summary>
        /// <value>請求書の消費税計算方法(inclusive: 内税表示, exclusive: 外税表示 (デフォルト))</value>
        [DataMember(Name="tax_entry_method", EmitDefaultValue=false)]
        public TaxEntryMethodEnum? TaxEntryMethod { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesCreateParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InvoicesCreateParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesCreateParams" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="issueDate">請求日 (yyyy-mm-dd).</param>
        /// <param name="partnerId">取引先ID.</param>
        /// <param name="partnerCode">取引先コード.</param>
        /// <param name="invoiceNumber">請求書番号 (デフォルト: 自動採番されます).</param>
        /// <param name="title">タイトル (デフォルト: 請求書).</param>
        /// <param name="dueDate">期日 (yyyy-mm-dd).</param>
        /// <param name="bookingDate">売上計上日.</param>
        /// <param name="description">概要.</param>
        /// <param name="invoiceStatus">請求書ステータス  (draft: 下書き (デフォルト), issue: 発行(請求先ワークフローを利用している場合は指定できません)).</param>
        /// <param name="partnerName">取引先名.</param>
        /// <param name="partnerTitle">敬称（御中、様、(空白)の3つから選択）.</param>
        /// <param name="partnerContactInfo">取引先担当者名.</param>
        /// <param name="companyName">事業所名 (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="companyZipcode">郵便番号 (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="companyPrefectureCode">都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄 ) (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="companyAddress1">市区町村・番地 (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="companyAddress2">建物名・部屋番号など (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="companyContactInfo">事業所担当者名 (デフォルトは事業所設定情報が補完されます).</param>
        /// <param name="paymentType">支払方法 (振込: transfer, 引き落とし: direct_debit).</param>
        /// <param name="paymentBankInfo">支払口座.</param>
        /// <param name="useVirtualTransferAccount">振込専用口座の利用(利用しない: not_use(デフォルト), 利用する: use).</param>
        /// <param name="message">メッセージ (デフォルト: 下記の通りご請求申し上げます。).</param>
        /// <param name="notes">備考.</param>
        /// <param name="invoiceLayout">レイアウト(default_classic: レイアウト１/クラシック (デフォルト), standard_classic: レイアウト２/クラシック, envelope_classic: 封筒１/クラシック, carried_forward_standard_classic: レイアウト３（繰越金額欄あり）/クラシック, carried_forward_envelope_classic: 封筒２（繰越金額欄あり）/クラシック, default_modern: レイアウト１/モダン, standard_modern: レイアウト２/モダン, envelope_modern: 封筒/モダン).</param>
        /// <param name="taxEntryMethod">請求書の消費税計算方法(inclusive: 内税表示, exclusive: 外税表示 (デフォルト)).</param>
        /// <param name="invoiceContents">請求内容.</param>
        public InvoicesCreateParams(int companyId = default(int), string issueDate = default(string), int partnerId = default(int), string partnerCode = default(string), string invoiceNumber = default(string), string title = default(string), string dueDate = default(string), string bookingDate = default(string), string description = default(string), InvoiceStatusEnum? invoiceStatus = default(InvoiceStatusEnum?), string partnerName = default(string), string partnerTitle = default(string), string partnerContactInfo = default(string), string companyName = default(string), string companyZipcode = default(string), int companyPrefectureCode = default(int), string companyAddress1 = default(string), string companyAddress2 = default(string), string companyContactInfo = default(string), PaymentTypeEnum? paymentType = default(PaymentTypeEnum?), string paymentBankInfo = default(string), UseVirtualTransferAccountEnum? useVirtualTransferAccount = default(UseVirtualTransferAccountEnum?), string message = default(string), string notes = default(string), InvoiceLayoutEnum? invoiceLayout = default(InvoiceLayoutEnum?), TaxEntryMethodEnum? taxEntryMethod = default(TaxEntryMethodEnum?), List<InvoicesCreateParamsInvoiceContents> invoiceContents = default(List<InvoicesCreateParamsInvoiceContents>))
        {
            this.CompanyId = companyId;
            this.IssueDate = issueDate;
            this.PartnerId = partnerId;
            this.PartnerCode = partnerCode;
            this.InvoiceNumber = invoiceNumber;
            this.Title = title;
            this.DueDate = dueDate;
            this.BookingDate = bookingDate;
            this.Description = description;
            this.InvoiceStatus = invoiceStatus;
            this.PartnerName = partnerName;
            this.PartnerTitle = partnerTitle;
            this.PartnerContactInfo = partnerContactInfo;
            this.CompanyName = companyName;
            this.CompanyZipcode = companyZipcode;
            this.CompanyPrefectureCode = companyPrefectureCode;
            this.CompanyAddress1 = companyAddress1;
            this.CompanyAddress2 = companyAddress2;
            this.CompanyContactInfo = companyContactInfo;
            this.PaymentType = paymentType;
            this.PaymentBankInfo = paymentBankInfo;
            this.UseVirtualTransferAccount = useVirtualTransferAccount;
            this.Message = message;
            this.Notes = notes;
            this.InvoiceLayout = invoiceLayout;
            this.TaxEntryMethod = taxEntryMethod;
            this.InvoiceContents = invoiceContents;
        }
        
        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 請求日 (yyyy-mm-dd)
        /// </summary>
        /// <value>請求日 (yyyy-mm-dd)</value>
        [DataMember(Name="issue_date", EmitDefaultValue=false)]
        public string IssueDate { get; set; }

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
        [DataMember(Name="partner_code", EmitDefaultValue=false)]
        public string PartnerCode { get; set; }

        /// <summary>
        /// 請求書番号 (デフォルト: 自動採番されます)
        /// </summary>
        /// <value>請求書番号 (デフォルト: 自動採番されます)</value>
        [DataMember(Name="invoice_number", EmitDefaultValue=false)]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// タイトル (デフォルト: 請求書)
        /// </summary>
        /// <value>タイトル (デフォルト: 請求書)</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// 期日 (yyyy-mm-dd)
        /// </summary>
        /// <value>期日 (yyyy-mm-dd)</value>
        [DataMember(Name="due_date", EmitDefaultValue=false)]
        public string DueDate { get; set; }

        /// <summary>
        /// 売上計上日
        /// </summary>
        /// <value>売上計上日</value>
        [DataMember(Name="booking_date", EmitDefaultValue=false)]
        public string BookingDate { get; set; }

        /// <summary>
        /// 概要
        /// </summary>
        /// <value>概要</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// 取引先名
        /// </summary>
        /// <value>取引先名</value>
        [DataMember(Name="partner_name", EmitDefaultValue=false)]
        public string PartnerName { get; set; }

        /// <summary>
        /// 敬称（御中、様、(空白)の3つから選択）
        /// </summary>
        /// <value>敬称（御中、様、(空白)の3つから選択）</value>
        [DataMember(Name="partner_title", EmitDefaultValue=false)]
        public string PartnerTitle { get; set; }

        /// <summary>
        /// 取引先担当者名
        /// </summary>
        /// <value>取引先担当者名</value>
        [DataMember(Name="partner_contact_info", EmitDefaultValue=false)]
        public string PartnerContactInfo { get; set; }

        /// <summary>
        /// 事業所名 (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>事業所名 (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_name", EmitDefaultValue=false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 郵便番号 (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>郵便番号 (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_zipcode", EmitDefaultValue=false)]
        public string CompanyZipcode { get; set; }

        /// <summary>
        /// 都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄 ) (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄 ) (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_prefecture_code", EmitDefaultValue=false)]
        public int CompanyPrefectureCode { get; set; }

        /// <summary>
        /// 市区町村・番地 (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>市区町村・番地 (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_address1", EmitDefaultValue=false)]
        public string CompanyAddress1 { get; set; }

        /// <summary>
        /// 建物名・部屋番号など (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>建物名・部屋番号など (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_address2", EmitDefaultValue=false)]
        public string CompanyAddress2 { get; set; }

        /// <summary>
        /// 事業所担当者名 (デフォルトは事業所設定情報が補完されます)
        /// </summary>
        /// <value>事業所担当者名 (デフォルトは事業所設定情報が補完されます)</value>
        [DataMember(Name="company_contact_info", EmitDefaultValue=false)]
        public string CompanyContactInfo { get; set; }

        /// <summary>
        /// 支払口座
        /// </summary>
        /// <value>支払口座</value>
        [DataMember(Name="payment_bank_info", EmitDefaultValue=false)]
        public string PaymentBankInfo { get; set; }

        /// <summary>
        /// メッセージ (デフォルト: 下記の通りご請求申し上げます。)
        /// </summary>
        /// <value>メッセージ (デフォルト: 下記の通りご請求申し上げます。)</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        /// <value>備考</value>
        [DataMember(Name="notes", EmitDefaultValue=false)]
        public string Notes { get; set; }

        /// <summary>
        /// 請求内容
        /// </summary>
        /// <value>請求内容</value>
        [DataMember(Name="invoice_contents", EmitDefaultValue=false)]
        public List<InvoicesCreateParamsInvoiceContents> InvoiceContents { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InvoicesCreateParams {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerCode: ").Append(PartnerCode).Append("\n");
            sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  BookingDate: ").Append(BookingDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  InvoiceStatus: ").Append(InvoiceStatus).Append("\n");
            sb.Append("  PartnerName: ").Append(PartnerName).Append("\n");
            sb.Append("  PartnerTitle: ").Append(PartnerTitle).Append("\n");
            sb.Append("  PartnerContactInfo: ").Append(PartnerContactInfo).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  CompanyZipcode: ").Append(CompanyZipcode).Append("\n");
            sb.Append("  CompanyPrefectureCode: ").Append(CompanyPrefectureCode).Append("\n");
            sb.Append("  CompanyAddress1: ").Append(CompanyAddress1).Append("\n");
            sb.Append("  CompanyAddress2: ").Append(CompanyAddress2).Append("\n");
            sb.Append("  CompanyContactInfo: ").Append(CompanyContactInfo).Append("\n");
            sb.Append("  PaymentType: ").Append(PaymentType).Append("\n");
            sb.Append("  PaymentBankInfo: ").Append(PaymentBankInfo).Append("\n");
            sb.Append("  UseVirtualTransferAccount: ").Append(UseVirtualTransferAccount).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  InvoiceLayout: ").Append(InvoiceLayout).Append("\n");
            sb.Append("  TaxEntryMethod: ").Append(TaxEntryMethod).Append("\n");
            sb.Append("  InvoiceContents: ").Append(InvoiceContents).Append("\n");
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
            return this.Equals(input as InvoicesCreateParams);
        }

        /// <summary>
        /// Returns true if InvoicesCreateParams instances are equal
        /// </summary>
        /// <param name="input">Instance of InvoicesCreateParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InvoicesCreateParams input)
        {
            if (input == null)
                return false;

            return 
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
                    this.PartnerId == input.PartnerId ||
                    this.PartnerId.Equals(input.PartnerId)
                ) && 
                (
                    this.PartnerCode == input.PartnerCode ||
                    (this.PartnerCode != null &&
                    this.PartnerCode.Equals(input.PartnerCode))
                ) && 
                (
                    this.InvoiceNumber == input.InvoiceNumber ||
                    (this.InvoiceNumber != null &&
                    this.InvoiceNumber.Equals(input.InvoiceNumber))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.DueDate == input.DueDate ||
                    (this.DueDate != null &&
                    this.DueDate.Equals(input.DueDate))
                ) && 
                (
                    this.BookingDate == input.BookingDate ||
                    (this.BookingDate != null &&
                    this.BookingDate.Equals(input.BookingDate))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.InvoiceStatus == input.InvoiceStatus ||
                    this.InvoiceStatus.Equals(input.InvoiceStatus)
                ) && 
                (
                    this.PartnerName == input.PartnerName ||
                    (this.PartnerName != null &&
                    this.PartnerName.Equals(input.PartnerName))
                ) && 
                (
                    this.PartnerTitle == input.PartnerTitle ||
                    (this.PartnerTitle != null &&
                    this.PartnerTitle.Equals(input.PartnerTitle))
                ) && 
                (
                    this.PartnerContactInfo == input.PartnerContactInfo ||
                    (this.PartnerContactInfo != null &&
                    this.PartnerContactInfo.Equals(input.PartnerContactInfo))
                ) && 
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) && 
                (
                    this.CompanyZipcode == input.CompanyZipcode ||
                    (this.CompanyZipcode != null &&
                    this.CompanyZipcode.Equals(input.CompanyZipcode))
                ) && 
                (
                    this.CompanyPrefectureCode == input.CompanyPrefectureCode ||
                    this.CompanyPrefectureCode.Equals(input.CompanyPrefectureCode)
                ) && 
                (
                    this.CompanyAddress1 == input.CompanyAddress1 ||
                    (this.CompanyAddress1 != null &&
                    this.CompanyAddress1.Equals(input.CompanyAddress1))
                ) && 
                (
                    this.CompanyAddress2 == input.CompanyAddress2 ||
                    (this.CompanyAddress2 != null &&
                    this.CompanyAddress2.Equals(input.CompanyAddress2))
                ) && 
                (
                    this.CompanyContactInfo == input.CompanyContactInfo ||
                    (this.CompanyContactInfo != null &&
                    this.CompanyContactInfo.Equals(input.CompanyContactInfo))
                ) && 
                (
                    this.PaymentType == input.PaymentType ||
                    this.PaymentType.Equals(input.PaymentType)
                ) && 
                (
                    this.PaymentBankInfo == input.PaymentBankInfo ||
                    (this.PaymentBankInfo != null &&
                    this.PaymentBankInfo.Equals(input.PaymentBankInfo))
                ) && 
                (
                    this.UseVirtualTransferAccount == input.UseVirtualTransferAccount ||
                    this.UseVirtualTransferAccount.Equals(input.UseVirtualTransferAccount)
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.Notes == input.Notes ||
                    (this.Notes != null &&
                    this.Notes.Equals(input.Notes))
                ) && 
                (
                    this.InvoiceLayout == input.InvoiceLayout ||
                    this.InvoiceLayout.Equals(input.InvoiceLayout)
                ) && 
                (
                    this.TaxEntryMethod == input.TaxEntryMethod ||
                    this.TaxEntryMethod.Equals(input.TaxEntryMethod)
                ) && 
                (
                    this.InvoiceContents == input.InvoiceContents ||
                    this.InvoiceContents != null &&
                    input.InvoiceContents != null &&
                    this.InvoiceContents.SequenceEqual(input.InvoiceContents)
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
                if (this.IssueDate != null)
                    hashCode = hashCode * 59 + this.IssueDate.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerCode != null)
                    hashCode = hashCode * 59 + this.PartnerCode.GetHashCode();
                if (this.InvoiceNumber != null)
                    hashCode = hashCode * 59 + this.InvoiceNumber.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.DueDate != null)
                    hashCode = hashCode * 59 + this.DueDate.GetHashCode();
                if (this.BookingDate != null)
                    hashCode = hashCode * 59 + this.BookingDate.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.InvoiceStatus.GetHashCode();
                if (this.PartnerName != null)
                    hashCode = hashCode * 59 + this.PartnerName.GetHashCode();
                if (this.PartnerTitle != null)
                    hashCode = hashCode * 59 + this.PartnerTitle.GetHashCode();
                if (this.PartnerContactInfo != null)
                    hashCode = hashCode * 59 + this.PartnerContactInfo.GetHashCode();
                if (this.CompanyName != null)
                    hashCode = hashCode * 59 + this.CompanyName.GetHashCode();
                if (this.CompanyZipcode != null)
                    hashCode = hashCode * 59 + this.CompanyZipcode.GetHashCode();
                hashCode = hashCode * 59 + this.CompanyPrefectureCode.GetHashCode();
                if (this.CompanyAddress1 != null)
                    hashCode = hashCode * 59 + this.CompanyAddress1.GetHashCode();
                if (this.CompanyAddress2 != null)
                    hashCode = hashCode * 59 + this.CompanyAddress2.GetHashCode();
                if (this.CompanyContactInfo != null)
                    hashCode = hashCode * 59 + this.CompanyContactInfo.GetHashCode();
                hashCode = hashCode * 59 + this.PaymentType.GetHashCode();
                if (this.PaymentBankInfo != null)
                    hashCode = hashCode * 59 + this.PaymentBankInfo.GetHashCode();
                hashCode = hashCode * 59 + this.UseVirtualTransferAccount.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Notes != null)
                    hashCode = hashCode * 59 + this.Notes.GetHashCode();
                hashCode = hashCode * 59 + this.InvoiceLayout.GetHashCode();
                hashCode = hashCode * 59 + this.TaxEntryMethod.GetHashCode();
                if (this.InvoiceContents != null)
                    hashCode = hashCode * 59 + this.InvoiceContents.GetHashCode();
                return hashCode;
            }
        }

    }

}
