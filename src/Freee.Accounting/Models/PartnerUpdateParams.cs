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
    /// PartnerUpdateParams
    /// </summary>
    [DataContract]
    public partial class PartnerUpdateParams :  IEquatable<PartnerUpdateParams>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerUpdateParams" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PartnerUpdateParams() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerUpdateParams" /> class.
        /// </summary>
        /// <param name="companyId">事業所ID (required).</param>
        /// <param name="name">取引先名 (255文字以内) (required).</param>
        /// <param name="shortcut1">ショートカット１ (255文字以内).</param>
        /// <param name="shortcut2">ショートカット２ (255文字以内).</param>
        /// <param name="longName">正式名称（255文字以内）.</param>
        /// <param name="nameKana">カナ名称（255文字以内）.</param>
        /// <param name="defaultTitle">敬称（御中、様、(空白)の3つから選択）.</param>
        /// <param name="phone">電話番号.</param>
        /// <param name="contactName">担当者 氏名 (255文字以内).</param>
        /// <param name="email">担当者 メールアドレス (255文字以内).</param>
        /// <param name="addressAttributes">addressAttributes.</param>
        /// <param name="partnerDocSettingAttributes">partnerDocSettingAttributes.</param>
        /// <param name="partnerBankAccountAttributes">partnerBankAccountAttributes.</param>
        public PartnerUpdateParams(int companyId = default(int), string name = default(string), string shortcut1 = default(string), string shortcut2 = default(string), string longName = default(string), string nameKana = default(string), string defaultTitle = default(string), string phone = default(string), string contactName = default(string), string email = default(string), PartnerCreateParamsAddressAttributes addressAttributes = default(PartnerCreateParamsAddressAttributes), PartnerCreateParamsPartnerDocSettingAttributes partnerDocSettingAttributes = default(PartnerCreateParamsPartnerDocSettingAttributes), PartnerCreateParamsPartnerBankAccountAttributes partnerBankAccountAttributes = default(PartnerCreateParamsPartnerBankAccountAttributes))
        {
            this.CompanyId = companyId;
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for PartnerUpdateParams and cannot be null");;
            this.Shortcut1 = shortcut1;
            this.Shortcut2 = shortcut2;
            this.LongName = longName;
            this.NameKana = nameKana;
            this.DefaultTitle = defaultTitle;
            this.Phone = phone;
            this.ContactName = contactName;
            this.Email = email;
            this.AddressAttributes = addressAttributes;
            this.PartnerDocSettingAttributes = partnerDocSettingAttributes;
            this.PartnerBankAccountAttributes = partnerBankAccountAttributes;
        }
        
        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public int CompanyId { get; set; }

        /// <summary>
        /// 取引先名 (255文字以内)
        /// </summary>
        /// <value>取引先名 (255文字以内)</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// ショートカット１ (255文字以内)
        /// </summary>
        /// <value>ショートカット１ (255文字以内)</value>
        [DataMember(Name="shortcut1", EmitDefaultValue=false)]
        public string Shortcut1 { get; set; }

        /// <summary>
        /// ショートカット２ (255文字以内)
        /// </summary>
        /// <value>ショートカット２ (255文字以内)</value>
        [DataMember(Name="shortcut2", EmitDefaultValue=false)]
        public string Shortcut2 { get; set; }

        /// <summary>
        /// 正式名称（255文字以内）
        /// </summary>
        /// <value>正式名称（255文字以内）</value>
        [DataMember(Name="long_name", EmitDefaultValue=false)]
        public string LongName { get; set; }

        /// <summary>
        /// カナ名称（255文字以内）
        /// </summary>
        /// <value>カナ名称（255文字以内）</value>
        [DataMember(Name="name_kana", EmitDefaultValue=false)]
        public string NameKana { get; set; }

        /// <summary>
        /// 敬称（御中、様、(空白)の3つから選択）
        /// </summary>
        /// <value>敬称（御中、様、(空白)の3つから選択）</value>
        [DataMember(Name="default_title", EmitDefaultValue=false)]
        public string DefaultTitle { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        /// <value>電話番号</value>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        /// 担当者 氏名 (255文字以内)
        /// </summary>
        /// <value>担当者 氏名 (255文字以内)</value>
        [DataMember(Name="contact_name", EmitDefaultValue=false)]
        public string ContactName { get; set; }

        /// <summary>
        /// 担当者 メールアドレス (255文字以内)
        /// </summary>
        /// <value>担当者 メールアドレス (255文字以内)</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets AddressAttributes
        /// </summary>
        [DataMember(Name="address_attributes", EmitDefaultValue=false)]
        public PartnerCreateParamsAddressAttributes AddressAttributes { get; set; }

        /// <summary>
        /// Gets or Sets PartnerDocSettingAttributes
        /// </summary>
        [DataMember(Name="partner_doc_setting_attributes", EmitDefaultValue=false)]
        public PartnerCreateParamsPartnerDocSettingAttributes PartnerDocSettingAttributes { get; set; }

        /// <summary>
        /// Gets or Sets PartnerBankAccountAttributes
        /// </summary>
        [DataMember(Name="partner_bank_account_attributes", EmitDefaultValue=false)]
        public PartnerCreateParamsPartnerBankAccountAttributes PartnerBankAccountAttributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PartnerUpdateParams {\n");
            sb.Append("  CompanyId: ").Append(CompanyId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Shortcut1: ").Append(Shortcut1).Append("\n");
            sb.Append("  Shortcut2: ").Append(Shortcut2).Append("\n");
            sb.Append("  LongName: ").Append(LongName).Append("\n");
            sb.Append("  NameKana: ").Append(NameKana).Append("\n");
            sb.Append("  DefaultTitle: ").Append(DefaultTitle).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  ContactName: ").Append(ContactName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  AddressAttributes: ").Append(AddressAttributes).Append("\n");
            sb.Append("  PartnerDocSettingAttributes: ").Append(PartnerDocSettingAttributes).Append("\n");
            sb.Append("  PartnerBankAccountAttributes: ").Append(PartnerBankAccountAttributes).Append("\n");
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
            return this.Equals(input as PartnerUpdateParams);
        }

        /// <summary>
        /// Returns true if PartnerUpdateParams instances are equal
        /// </summary>
        /// <param name="input">Instance of PartnerUpdateParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PartnerUpdateParams input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompanyId == input.CompanyId ||
                    this.CompanyId.Equals(input.CompanyId)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Shortcut1 == input.Shortcut1 ||
                    (this.Shortcut1 != null &&
                    this.Shortcut1.Equals(input.Shortcut1))
                ) && 
                (
                    this.Shortcut2 == input.Shortcut2 ||
                    (this.Shortcut2 != null &&
                    this.Shortcut2.Equals(input.Shortcut2))
                ) && 
                (
                    this.LongName == input.LongName ||
                    (this.LongName != null &&
                    this.LongName.Equals(input.LongName))
                ) && 
                (
                    this.NameKana == input.NameKana ||
                    (this.NameKana != null &&
                    this.NameKana.Equals(input.NameKana))
                ) && 
                (
                    this.DefaultTitle == input.DefaultTitle ||
                    (this.DefaultTitle != null &&
                    this.DefaultTitle.Equals(input.DefaultTitle))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.ContactName == input.ContactName ||
                    (this.ContactName != null &&
                    this.ContactName.Equals(input.ContactName))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.AddressAttributes == input.AddressAttributes ||
                    (this.AddressAttributes != null &&
                    this.AddressAttributes.Equals(input.AddressAttributes))
                ) && 
                (
                    this.PartnerDocSettingAttributes == input.PartnerDocSettingAttributes ||
                    (this.PartnerDocSettingAttributes != null &&
                    this.PartnerDocSettingAttributes.Equals(input.PartnerDocSettingAttributes))
                ) && 
                (
                    this.PartnerBankAccountAttributes == input.PartnerBankAccountAttributes ||
                    (this.PartnerBankAccountAttributes != null &&
                    this.PartnerBankAccountAttributes.Equals(input.PartnerBankAccountAttributes))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Shortcut1 != null)
                    hashCode = hashCode * 59 + this.Shortcut1.GetHashCode();
                if (this.Shortcut2 != null)
                    hashCode = hashCode * 59 + this.Shortcut2.GetHashCode();
                if (this.LongName != null)
                    hashCode = hashCode * 59 + this.LongName.GetHashCode();
                if (this.NameKana != null)
                    hashCode = hashCode * 59 + this.NameKana.GetHashCode();
                if (this.DefaultTitle != null)
                    hashCode = hashCode * 59 + this.DefaultTitle.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.ContactName != null)
                    hashCode = hashCode * 59 + this.ContactName.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.AddressAttributes != null)
                    hashCode = hashCode * 59 + this.AddressAttributes.GetHashCode();
                if (this.PartnerDocSettingAttributes != null)
                    hashCode = hashCode * 59 + this.PartnerDocSettingAttributes.GetHashCode();
                if (this.PartnerBankAccountAttributes != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributes.GetHashCode();
                return hashCode;
            }
        }

    }

}
