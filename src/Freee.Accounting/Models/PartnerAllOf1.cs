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
    /// PartnerAllOf1
    /// </summary>
    [DataContract]
    public partial class PartnerAllOf1 :  IEquatable<PartnerAllOf1>
    {
        /// <summary>
        /// 請求書送付方法(mail:メール、posting:郵送、mail_and_posting:メールと郵送)
        /// </summary>
        /// <value>請求書送付方法(mail:メール、posting:郵送、mail_and_posting:メールと郵送)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PartnerDocSettingAttributesSendingMethodEnum
        {
            /// <summary>
            /// Enum Mail for value: mail
            /// </summary>
            [EnumMember(Value = "mail")]
            Mail = 1,

            /// <summary>
            /// Enum Posting for value: posting
            /// </summary>
            [EnumMember(Value = "posting")]
            Posting = 2,

            /// <summary>
            /// Enum Mainandposting for value: main_and_posting
            /// </summary>
            [EnumMember(Value = "main_and_posting")]
            Mainandposting = 3

        }

        /// <summary>
        /// 請求書送付方法(mail:メール、posting:郵送、mail_and_posting:メールと郵送)
        /// </summary>
        /// <value>請求書送付方法(mail:メール、posting:郵送、mail_and_posting:メールと郵送)</value>
        [DataMember(Name="partner_doc_setting_attributes[sending_method]", EmitDefaultValue=true)]
        public PartnerDocSettingAttributesSendingMethodEnum? PartnerDocSettingAttributesSendingMethod { get; set; }
        /// <summary>
        /// 口座種別(ordinary:普通、checking:当座、earmarked:納税準備預金、savings:貯蓄、other:その他)
        /// </summary>
        /// <value>口座種別(ordinary:普通、checking:当座、earmarked:納税準備預金、savings:貯蓄、other:その他)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PartnerBankAccountAttributesAccountTypeEnum
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
        /// 口座種別(ordinary:普通、checking:当座、earmarked:納税準備預金、savings:貯蓄、other:その他)
        /// </summary>
        /// <value>口座種別(ordinary:普通、checking:当座、earmarked:納税準備預金、savings:貯蓄、other:その他)</value>
        [DataMember(Name="partner_bank_account_attributes[account_type]", EmitDefaultValue=true)]
        public PartnerBankAccountAttributesAccountTypeEnum? PartnerBankAccountAttributesAccountType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerAllOf1" /> class.
        /// </summary>
        /// <param name="longName">正式名称（255文字以内）.</param>
        /// <param name="nameKana">カナ名称（255文字以内）.</param>
        /// <param name="defaultTitle">敬称（御中、様、(空白)の3つから選択）.</param>
        /// <param name="phone">電話番号.</param>
        /// <param name="contactName">担当者 氏名.</param>
        /// <param name="email">担当者 メールアドレス.</param>
        /// <param name="addressAttributesZipcode">郵便番号.</param>
        /// <param name="addressAttributesPrefectureCode">都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄.</param>
        /// <param name="addressAttributesStreetName1">市区町村・番地.</param>
        /// <param name="addressAttributesStreetName2">建物名・部屋番号など.</param>
        /// <param name="partnerDocSettingAttributesSendingMethod">請求書送付方法(mail:メール、posting:郵送、mail_and_posting:メールと郵送).</param>
        /// <param name="partnerBankAccountAttributesBankName">銀行名.</param>
        /// <param name="partnerBankAccountAttributesBankNameKana">銀行名（カナ）.</param>
        /// <param name="partnerBankAccountAttributesBankCode">銀行番号.</param>
        /// <param name="partnerBankAccountAttributesBranchName">支店名.</param>
        /// <param name="partnerBankAccountAttributesBranchKana">支店名（カナ）.</param>
        /// <param name="partnerBankAccountAttributesBranchCode">受取人名（カナ）.</param>
        /// <param name="partnerBankAccountAttributesAccountType">口座種別(ordinary:普通、checking:当座、earmarked:納税準備預金、savings:貯蓄、other:その他).</param>
        /// <param name="partnerBankAccountAttributesAccountNumber">口座番号.</param>
        /// <param name="partnerBankAccountAttributesAccountName">受取人名（カナ）.</param>
        /// <param name="partnerBankAccountAttributesLongAccountName">受取人名.</param>
        public PartnerAllOf1(string longName = default(string), string nameKana = default(string), string defaultTitle = default(string), string phone = default(string), string contactName = default(string), string email = default(string), string addressAttributesZipcode = default(string), int addressAttributesPrefectureCode = default(int), string addressAttributesStreetName1 = default(string), string addressAttributesStreetName2 = default(string), PartnerDocSettingAttributesSendingMethodEnum? partnerDocSettingAttributesSendingMethod = default(PartnerDocSettingAttributesSendingMethodEnum?), string partnerBankAccountAttributesBankName = default(string), string partnerBankAccountAttributesBankNameKana = default(string), string partnerBankAccountAttributesBankCode = default(string), string partnerBankAccountAttributesBranchName = default(string), string partnerBankAccountAttributesBranchKana = default(string), string partnerBankAccountAttributesBranchCode = default(string), PartnerBankAccountAttributesAccountTypeEnum? partnerBankAccountAttributesAccountType = default(PartnerBankAccountAttributesAccountTypeEnum?), string partnerBankAccountAttributesAccountNumber = default(string), string partnerBankAccountAttributesAccountName = default(string), string partnerBankAccountAttributesLongAccountName = default(string))
        {
            this.LongName = longName;
            this.NameKana = nameKana;
            this.DefaultTitle = defaultTitle;
            this.Phone = phone;
            this.ContactName = contactName;
            this.Email = email;
            this.AddressAttributesZipcode = addressAttributesZipcode;
            this.AddressAttributesPrefectureCode = addressAttributesPrefectureCode;
            this.AddressAttributesStreetName1 = addressAttributesStreetName1;
            this.AddressAttributesStreetName2 = addressAttributesStreetName2;
            this.PartnerDocSettingAttributesSendingMethod = partnerDocSettingAttributesSendingMethod;
            this.PartnerBankAccountAttributesBankName = partnerBankAccountAttributesBankName;
            this.PartnerBankAccountAttributesBankNameKana = partnerBankAccountAttributesBankNameKana;
            this.PartnerBankAccountAttributesBankCode = partnerBankAccountAttributesBankCode;
            this.PartnerBankAccountAttributesBranchName = partnerBankAccountAttributesBranchName;
            this.PartnerBankAccountAttributesBranchKana = partnerBankAccountAttributesBranchKana;
            this.PartnerBankAccountAttributesBranchCode = partnerBankAccountAttributesBranchCode;
            this.PartnerBankAccountAttributesAccountType = partnerBankAccountAttributesAccountType;
            this.PartnerBankAccountAttributesAccountNumber = partnerBankAccountAttributesAccountNumber;
            this.PartnerBankAccountAttributesAccountName = partnerBankAccountAttributesAccountName;
            this.PartnerBankAccountAttributesLongAccountName = partnerBankAccountAttributesLongAccountName;
        }
        
        /// <summary>
        /// 正式名称（255文字以内）
        /// </summary>
        /// <value>正式名称（255文字以内）</value>
        [DataMember(Name="long_name", EmitDefaultValue=true)]
        public string LongName { get; set; }

        /// <summary>
        /// カナ名称（255文字以内）
        /// </summary>
        /// <value>カナ名称（255文字以内）</value>
        [DataMember(Name="name_kana", EmitDefaultValue=true)]
        public string NameKana { get; set; }

        /// <summary>
        /// 敬称（御中、様、(空白)の3つから選択）
        /// </summary>
        /// <value>敬称（御中、様、(空白)の3つから選択）</value>
        [DataMember(Name="default_title", EmitDefaultValue=true)]
        public string DefaultTitle { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        /// <value>電話番号</value>
        [DataMember(Name="phone", EmitDefaultValue=true)]
        public string Phone { get; set; }

        /// <summary>
        /// 担当者 氏名
        /// </summary>
        /// <value>担当者 氏名</value>
        [DataMember(Name="contact_name", EmitDefaultValue=true)]
        public string ContactName { get; set; }

        /// <summary>
        /// 担当者 メールアドレス
        /// </summary>
        /// <value>担当者 メールアドレス</value>
        [DataMember(Name="email", EmitDefaultValue=true)]
        public string Email { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        /// <value>郵便番号</value>
        [DataMember(Name="address_attributes[zipcode]", EmitDefaultValue=true)]
        public string AddressAttributesZipcode { get; set; }

        /// <summary>
        /// 都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄
        /// </summary>
        /// <value>都道府県コード（0:北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄</value>
        [DataMember(Name="address_attributes[prefecture_code]", EmitDefaultValue=false)]
        public int AddressAttributesPrefectureCode { get; set; }

        /// <summary>
        /// 市区町村・番地
        /// </summary>
        /// <value>市区町村・番地</value>
        [DataMember(Name="address_attributes[street_name1]", EmitDefaultValue=true)]
        public string AddressAttributesStreetName1 { get; set; }

        /// <summary>
        /// 建物名・部屋番号など
        /// </summary>
        /// <value>建物名・部屋番号など</value>
        [DataMember(Name="address_attributes[street_name2]", EmitDefaultValue=true)]
        public string AddressAttributesStreetName2 { get; set; }

        /// <summary>
        /// 銀行名
        /// </summary>
        /// <value>銀行名</value>
        [DataMember(Name="partner_bank_account_attributes[bank_name]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBankName { get; set; }

        /// <summary>
        /// 銀行名（カナ）
        /// </summary>
        /// <value>銀行名（カナ）</value>
        [DataMember(Name="partner_bank_account_attributes[bank_name_kana]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBankNameKana { get; set; }

        /// <summary>
        /// 銀行番号
        /// </summary>
        /// <value>銀行番号</value>
        [DataMember(Name="partner_bank_account_attributes[bank_code]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBankCode { get; set; }

        /// <summary>
        /// 支店名
        /// </summary>
        /// <value>支店名</value>
        [DataMember(Name="partner_bank_account_attributes[branch_name]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBranchName { get; set; }

        /// <summary>
        /// 支店名（カナ）
        /// </summary>
        /// <value>支店名（カナ）</value>
        [DataMember(Name="partner_bank_account_attributes[branch_kana]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBranchKana { get; set; }

        /// <summary>
        /// 受取人名（カナ）
        /// </summary>
        /// <value>受取人名（カナ）</value>
        [DataMember(Name="partner_bank_account_attributes[branch_code]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesBranchCode { get; set; }

        /// <summary>
        /// 口座番号
        /// </summary>
        /// <value>口座番号</value>
        [DataMember(Name="partner_bank_account_attributes[account_number]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesAccountNumber { get; set; }

        /// <summary>
        /// 受取人名（カナ）
        /// </summary>
        /// <value>受取人名（カナ）</value>
        [DataMember(Name="partner_bank_account_attributes[account_name]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesAccountName { get; set; }

        /// <summary>
        /// 受取人名
        /// </summary>
        /// <value>受取人名</value>
        [DataMember(Name="partner_bank_account_attributes[long_account_name]", EmitDefaultValue=true)]
        public string PartnerBankAccountAttributesLongAccountName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PartnerAllOf1 {\n");
            sb.Append("  LongName: ").Append(LongName).Append("\n");
            sb.Append("  NameKana: ").Append(NameKana).Append("\n");
            sb.Append("  DefaultTitle: ").Append(DefaultTitle).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  ContactName: ").Append(ContactName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  AddressAttributesZipcode: ").Append(AddressAttributesZipcode).Append("\n");
            sb.Append("  AddressAttributesPrefectureCode: ").Append(AddressAttributesPrefectureCode).Append("\n");
            sb.Append("  AddressAttributesStreetName1: ").Append(AddressAttributesStreetName1).Append("\n");
            sb.Append("  AddressAttributesStreetName2: ").Append(AddressAttributesStreetName2).Append("\n");
            sb.Append("  PartnerDocSettingAttributesSendingMethod: ").Append(PartnerDocSettingAttributesSendingMethod).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBankName: ").Append(PartnerBankAccountAttributesBankName).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBankNameKana: ").Append(PartnerBankAccountAttributesBankNameKana).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBankCode: ").Append(PartnerBankAccountAttributesBankCode).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBranchName: ").Append(PartnerBankAccountAttributesBranchName).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBranchKana: ").Append(PartnerBankAccountAttributesBranchKana).Append("\n");
            sb.Append("  PartnerBankAccountAttributesBranchCode: ").Append(PartnerBankAccountAttributesBranchCode).Append("\n");
            sb.Append("  PartnerBankAccountAttributesAccountType: ").Append(PartnerBankAccountAttributesAccountType).Append("\n");
            sb.Append("  PartnerBankAccountAttributesAccountNumber: ").Append(PartnerBankAccountAttributesAccountNumber).Append("\n");
            sb.Append("  PartnerBankAccountAttributesAccountName: ").Append(PartnerBankAccountAttributesAccountName).Append("\n");
            sb.Append("  PartnerBankAccountAttributesLongAccountName: ").Append(PartnerBankAccountAttributesLongAccountName).Append("\n");
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
            return this.Equals(input as PartnerAllOf1);
        }

        /// <summary>
        /// Returns true if PartnerAllOf1 instances are equal
        /// </summary>
        /// <param name="input">Instance of PartnerAllOf1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PartnerAllOf1 input)
        {
            if (input == null)
                return false;

            return 
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
                    this.AddressAttributesZipcode == input.AddressAttributesZipcode ||
                    (this.AddressAttributesZipcode != null &&
                    this.AddressAttributesZipcode.Equals(input.AddressAttributesZipcode))
                ) && 
                (
                    this.AddressAttributesPrefectureCode == input.AddressAttributesPrefectureCode ||
                    this.AddressAttributesPrefectureCode.Equals(input.AddressAttributesPrefectureCode)
                ) && 
                (
                    this.AddressAttributesStreetName1 == input.AddressAttributesStreetName1 ||
                    (this.AddressAttributesStreetName1 != null &&
                    this.AddressAttributesStreetName1.Equals(input.AddressAttributesStreetName1))
                ) && 
                (
                    this.AddressAttributesStreetName2 == input.AddressAttributesStreetName2 ||
                    (this.AddressAttributesStreetName2 != null &&
                    this.AddressAttributesStreetName2.Equals(input.AddressAttributesStreetName2))
                ) && 
                (
                    this.PartnerDocSettingAttributesSendingMethod == input.PartnerDocSettingAttributesSendingMethod ||
                    this.PartnerDocSettingAttributesSendingMethod.Equals(input.PartnerDocSettingAttributesSendingMethod)
                ) && 
                (
                    this.PartnerBankAccountAttributesBankName == input.PartnerBankAccountAttributesBankName ||
                    (this.PartnerBankAccountAttributesBankName != null &&
                    this.PartnerBankAccountAttributesBankName.Equals(input.PartnerBankAccountAttributesBankName))
                ) && 
                (
                    this.PartnerBankAccountAttributesBankNameKana == input.PartnerBankAccountAttributesBankNameKana ||
                    (this.PartnerBankAccountAttributesBankNameKana != null &&
                    this.PartnerBankAccountAttributesBankNameKana.Equals(input.PartnerBankAccountAttributesBankNameKana))
                ) && 
                (
                    this.PartnerBankAccountAttributesBankCode == input.PartnerBankAccountAttributesBankCode ||
                    (this.PartnerBankAccountAttributesBankCode != null &&
                    this.PartnerBankAccountAttributesBankCode.Equals(input.PartnerBankAccountAttributesBankCode))
                ) && 
                (
                    this.PartnerBankAccountAttributesBranchName == input.PartnerBankAccountAttributesBranchName ||
                    (this.PartnerBankAccountAttributesBranchName != null &&
                    this.PartnerBankAccountAttributesBranchName.Equals(input.PartnerBankAccountAttributesBranchName))
                ) && 
                (
                    this.PartnerBankAccountAttributesBranchKana == input.PartnerBankAccountAttributesBranchKana ||
                    (this.PartnerBankAccountAttributesBranchKana != null &&
                    this.PartnerBankAccountAttributesBranchKana.Equals(input.PartnerBankAccountAttributesBranchKana))
                ) && 
                (
                    this.PartnerBankAccountAttributesBranchCode == input.PartnerBankAccountAttributesBranchCode ||
                    (this.PartnerBankAccountAttributesBranchCode != null &&
                    this.PartnerBankAccountAttributesBranchCode.Equals(input.PartnerBankAccountAttributesBranchCode))
                ) && 
                (
                    this.PartnerBankAccountAttributesAccountType == input.PartnerBankAccountAttributesAccountType ||
                    this.PartnerBankAccountAttributesAccountType.Equals(input.PartnerBankAccountAttributesAccountType)
                ) && 
                (
                    this.PartnerBankAccountAttributesAccountNumber == input.PartnerBankAccountAttributesAccountNumber ||
                    (this.PartnerBankAccountAttributesAccountNumber != null &&
                    this.PartnerBankAccountAttributesAccountNumber.Equals(input.PartnerBankAccountAttributesAccountNumber))
                ) && 
                (
                    this.PartnerBankAccountAttributesAccountName == input.PartnerBankAccountAttributesAccountName ||
                    (this.PartnerBankAccountAttributesAccountName != null &&
                    this.PartnerBankAccountAttributesAccountName.Equals(input.PartnerBankAccountAttributesAccountName))
                ) && 
                (
                    this.PartnerBankAccountAttributesLongAccountName == input.PartnerBankAccountAttributesLongAccountName ||
                    (this.PartnerBankAccountAttributesLongAccountName != null &&
                    this.PartnerBankAccountAttributesLongAccountName.Equals(input.PartnerBankAccountAttributesLongAccountName))
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
                if (this.AddressAttributesZipcode != null)
                    hashCode = hashCode * 59 + this.AddressAttributesZipcode.GetHashCode();
                hashCode = hashCode * 59 + this.AddressAttributesPrefectureCode.GetHashCode();
                if (this.AddressAttributesStreetName1 != null)
                    hashCode = hashCode * 59 + this.AddressAttributesStreetName1.GetHashCode();
                if (this.AddressAttributesStreetName2 != null)
                    hashCode = hashCode * 59 + this.AddressAttributesStreetName2.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerDocSettingAttributesSendingMethod.GetHashCode();
                if (this.PartnerBankAccountAttributesBankName != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBankName.GetHashCode();
                if (this.PartnerBankAccountAttributesBankNameKana != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBankNameKana.GetHashCode();
                if (this.PartnerBankAccountAttributesBankCode != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBankCode.GetHashCode();
                if (this.PartnerBankAccountAttributesBranchName != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBranchName.GetHashCode();
                if (this.PartnerBankAccountAttributesBranchKana != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBranchKana.GetHashCode();
                if (this.PartnerBankAccountAttributesBranchCode != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesBranchCode.GetHashCode();
                hashCode = hashCode * 59 + this.PartnerBankAccountAttributesAccountType.GetHashCode();
                if (this.PartnerBankAccountAttributesAccountNumber != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesAccountNumber.GetHashCode();
                if (this.PartnerBankAccountAttributesAccountName != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesAccountName.GetHashCode();
                if (this.PartnerBankAccountAttributesLongAccountName != null)
                    hashCode = hashCode * 59 + this.PartnerBankAccountAttributesLongAccountName.GetHashCode();
                return hashCode;
            }
        }

    }

}
