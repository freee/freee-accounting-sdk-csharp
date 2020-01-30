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
    /// CompaniesShowResponseCompany
    /// </summary>
    [DataContract]
    public partial class CompaniesShowResponseCompany :  IEquatable<CompaniesShowResponseCompany>
    {
        /// <summary>
        /// 仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））
        /// </summary>
        /// <value>仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TxnNumberFormatEnum
        {
            /// <summary>
            /// Enum Notused for value: not_used
            /// </summary>
            [EnumMember(Value = "not_used")]
            Notused = 1,

            /// <summary>
            /// Enum Digits for value: digits
            /// </summary>
            [EnumMember(Value = "digits")]
            Digits = 2,

            /// <summary>
            /// Enum Alnum for value: alnum
            /// </summary>
            [EnumMember(Value = "alnum")]
            Alnum = 3

        }

        /// <summary>
        /// 仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））
        /// </summary>
        /// <value>仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））</value>
        [DataMember(Name="txn_number_format", EmitDefaultValue=false)]
        public TxnNumberFormatEnum TxnNumberFormat { get; set; }
        /// <summary>
        /// ユーザーの権限
        /// </summary>
        /// <value>ユーザーの権限</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RoleEnum
        {
            /// <summary>
            /// Enum Admin for value: admin
            /// </summary>
            [EnumMember(Value = "admin")]
            Admin = 1,

            /// <summary>
            /// Enum Simpleaccounting for value: simple_accounting
            /// </summary>
            [EnumMember(Value = "simple_accounting")]
            Simpleaccounting = 2,

            /// <summary>
            /// Enum Selfonly for value: self_only
            /// </summary>
            [EnumMember(Value = "self_only")]
            Selfonly = 3,

            /// <summary>
            /// Enum Readonly for value: read_only
            /// </summary>
            [EnumMember(Value = "read_only")]
            Readonly = 4

        }

        /// <summary>
        /// ユーザーの権限
        /// </summary>
        /// <value>ユーザーの権限</value>
        [DataMember(Name="role", EmitDefaultValue=false)]
        public RoleEnum Role { get; set; }
        /// <summary>
        /// 種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）
        /// </summary>
        /// <value>種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IndustryClassEnum
        {
            /// <summary>
            /// Enum Empty for value: 
            /// </summary>
            [EnumMember(Value = "")]
            Empty = 1,

            /// <summary>
            /// Enum Agricultureforestryfisheriesore for value: agriculture_forestry_fisheries_ore
            /// </summary>
            [EnumMember(Value = "agriculture_forestry_fisheries_ore")]
            Agricultureforestryfisheriesore = 2,

            /// <summary>
            /// Enum Construction for value: construction
            /// </summary>
            [EnumMember(Value = "construction")]
            Construction = 3,

            /// <summary>
            /// Enum Manufacturingprocessing for value: manufacturing_processing
            /// </summary>
            [EnumMember(Value = "manufacturing_processing")]
            Manufacturingprocessing = 4,

            /// <summary>
            /// Enum It for value: it
            /// </summary>
            [EnumMember(Value = "it")]
            It = 5,

            /// <summary>
            /// Enum Transportationlogistics for value: transportation_logistics
            /// </summary>
            [EnumMember(Value = "transportation_logistics")]
            Transportationlogistics = 6,

            /// <summary>
            /// Enum Retailwholesale for value: retail_wholesale
            /// </summary>
            [EnumMember(Value = "retail_wholesale")]
            Retailwholesale = 7,

            /// <summary>
            /// Enum Financeinsurance for value: finance_insurance
            /// </summary>
            [EnumMember(Value = "finance_insurance")]
            Financeinsurance = 8,

            /// <summary>
            /// Enum Realestaterental for value: real_estate_rental
            /// </summary>
            [EnumMember(Value = "real_estate_rental")]
            Realestaterental = 9,

            /// <summary>
            /// Enum Profession for value: profession
            /// </summary>
            [EnumMember(Value = "profession")]
            Profession = 10,

            /// <summary>
            /// Enum Designproduction for value: design_production
            /// </summary>
            [EnumMember(Value = "design_production")]
            Designproduction = 11,

            /// <summary>
            /// Enum Food for value: food
            /// </summary>
            [EnumMember(Value = "food")]
            Food = 12,

            /// <summary>
            /// Enum Lifestyle for value: lifestyle
            /// </summary>
            [EnumMember(Value = "lifestyle")]
            Lifestyle = 13,

            /// <summary>
            /// Enum Education for value: education
            /// </summary>
            [EnumMember(Value = "education")]
            Education = 14,

            /// <summary>
            /// Enum Medicalwelfare for value: medical_welfare
            /// </summary>
            [EnumMember(Value = "medical_welfare")]
            Medicalwelfare = 15,

            /// <summary>
            /// Enum Otherservices for value: other_services
            /// </summary>
            [EnumMember(Value = "other_services")]
            Otherservices = 16,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 17

        }

        /// <summary>
        /// 種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）
        /// </summary>
        /// <value>種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）</value>
        [DataMember(Name="industry_class", EmitDefaultValue=false)]
        public IndustryClassEnum IndustryClass { get; set; }
        /// <summary>
        /// コード（transport_delivery: 輸送業/配送業、delivery: バイク便等の配達業、other_transportation_logistics: その他の運輸業、物流業）
        /// </summary>
        /// <value>コード（transport_delivery: 輸送業/配送業、delivery: バイク便等の配達業、other_transportation_logistics: その他の運輸業、物流業）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IndustryCodeEnum
        {
            /// <summary>
            /// Enum Empty for value: 
            /// </summary>
            [EnumMember(Value = "")]
            Empty = 1,

            /// <summary>
            /// Enum Transportdelivery for value: transport_delivery
            /// </summary>
            [EnumMember(Value = "transport_delivery")]
            Transportdelivery = 2,

            /// <summary>
            /// Enum Delivery for value: delivery
            /// </summary>
            [EnumMember(Value = "delivery")]
            Delivery = 3,

            /// <summary>
            /// Enum Othertransportationlogistics for value: other_transportation_logistics
            /// </summary>
            [EnumMember(Value = "other_transportation_logistics")]
            Othertransportationlogistics = 4

        }

        /// <summary>
        /// コード（transport_delivery: 輸送業/配送業、delivery: バイク便等の配達業、other_transportation_logistics: その他の運輸業、物流業）
        /// </summary>
        /// <value>コード（transport_delivery: 輸送業/配送業、delivery: バイク便等の配達業、other_transportation_logistics: その他の運輸業、物流業）</value>
        [DataMember(Name="industry_code", EmitDefaultValue=false)]
        public IndustryCodeEnum IndustryCode { get; set; }
        /// <summary>
        /// 仕訳承認フロー（enable: 有効、 disable: 無効）
        /// </summary>
        /// <value>仕訳承認フロー（enable: 有効、 disable: 無効）</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum WorkflowSettingEnum
        {
            /// <summary>
            /// Enum Enable for value: enable
            /// </summary>
            [EnumMember(Value = "enable")]
            Enable = 1,

            /// <summary>
            /// Enum Disable for value: disable
            /// </summary>
            [EnumMember(Value = "disable")]
            Disable = 2

        }

        /// <summary>
        /// 仕訳承認フロー（enable: 有効、 disable: 無効）
        /// </summary>
        /// <value>仕訳承認フロー（enable: 有効、 disable: 無効）</value>
        [DataMember(Name="workflow_setting", EmitDefaultValue=false)]
        public WorkflowSettingEnum WorkflowSetting { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesShowResponseCompany" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CompaniesShowResponseCompany() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesShowResponseCompany" /> class.
        /// </summary>
        /// <param name="id">事業所ID (required).</param>
        /// <param name="name">事業所の正式名称 (100文字以内) (required).</param>
        /// <param name="nameKana">正式名称フリガナ (100文字以内) (required).</param>
        /// <param name="displayName">事業所名 (required).</param>
        /// <param name="taxAtSourceCalcType">源泉徴収税計算（0: 消費税を含める、1: 消費税を含めない） (required).</param>
        /// <param name="contactName">担当者名 (50文字以内) (required).</param>
        /// <param name="headCount">従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上 (required).</param>
        /// <param name="corporateNumber">法人番号 (半角数字13桁、法人のみ) (required).</param>
        /// <param name="txnNumberFormat">仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P）） (required).</param>
        /// <param name="defaultWalletAccountId">決済口座のデフォルト.</param>
        /// <param name="privateSettlement">プライベート資金/役員資金（false: 使用しない、true: 使用する） (required).</param>
        /// <param name="minusFormat">マイナスの表示方法（0: -、 1: △） (required).</param>
        /// <param name="role">ユーザーの権限 (required).</param>
        /// <param name="phone1">電話番号１ (required).</param>
        /// <param name="phone2">電話番号２ (required).</param>
        /// <param name="fax">FAX (required).</param>
        /// <param name="zipcode">郵便番号 (required).</param>
        /// <param name="prefectureCode">都道府県コード（0: 北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄 (required).</param>
        /// <param name="streetName1">市区町村・番地 (required).</param>
        /// <param name="streetName2">建物名・部屋番号など (required).</param>
        /// <param name="invoiceLayout">レイアウト(0: レイアウト1, 1:レイアウト2, 3:封筒1, 4:レイアウト3(繰越金額欄あり), 5: 封筒2(繰越金額欄あり)) (required).</param>
        /// <param name="invoiceStyle">スタイル(0: クラシック, 1: モダン) (required).</param>
        /// <param name="amountFraction">金額端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入） (required).</param>
        /// <param name="industryClass">種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他） (required).</param>
        /// <param name="industryCode">コード（transport_delivery: 輸送業/配送業、delivery: バイク便等の配達業、other_transportation_logistics: その他の運輸業、物流業） (required).</param>
        /// <param name="workflowSetting">仕訳承認フロー（enable: 有効、 disable: 無効） (required).</param>
        /// <param name="usePartnerCode">取引先コードの利用設定（true: 有効、 false: 無効） (required).</param>
        public CompaniesShowResponseCompany(int id = default(int), string name = default(string), string nameKana = default(string), string displayName = default(string), int taxAtSourceCalcType = default(int), string contactName = default(string), int? headCount = default(int?), string corporateNumber = default(string), TxnNumberFormatEnum txnNumberFormat = default(TxnNumberFormatEnum), int defaultWalletAccountId = default(int), bool privateSettlement = default(bool), int minusFormat = default(int), RoleEnum role = default(RoleEnum), string phone1 = default(string), string phone2 = default(string), string fax = default(string), string zipcode = default(string), int prefectureCode = default(int), string streetName1 = default(string), string streetName2 = default(string), int invoiceLayout = default(int), int invoiceStyle = default(int), int amountFraction = default(int), IndustryClassEnum industryClass = default(IndustryClassEnum), IndustryCodeEnum industryCode = default(IndustryCodeEnum), WorkflowSettingEnum workflowSetting = default(WorkflowSettingEnum), bool usePartnerCode = default(bool))
        {
            this.Id = id;
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "nameKana" is required (not null)
            this.NameKana = nameKana ?? throw new ArgumentNullException("nameKana is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "displayName" is required (not null)
            this.DisplayName = displayName ?? throw new ArgumentNullException("displayName is a required property for CompaniesShowResponseCompany and cannot be null");;
            this.TaxAtSourceCalcType = taxAtSourceCalcType;
            // to ensure "contactName" is required (not null)
            this.ContactName = contactName ?? throw new ArgumentNullException("contactName is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "headCount" is required (not null)
            this.HeadCount = headCount ?? throw new ArgumentNullException("headCount is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "corporateNumber" is required (not null)
            this.CorporateNumber = corporateNumber ?? throw new ArgumentNullException("corporateNumber is a required property for CompaniesShowResponseCompany and cannot be null");;
            this.TxnNumberFormat = txnNumberFormat;
            this.PrivateSettlement = privateSettlement;
            this.MinusFormat = minusFormat;
            this.Role = role;
            // to ensure "phone1" is required (not null)
            this.Phone1 = phone1 ?? throw new ArgumentNullException("phone1 is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "phone2" is required (not null)
            this.Phone2 = phone2 ?? throw new ArgumentNullException("phone2 is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "fax" is required (not null)
            this.Fax = fax ?? throw new ArgumentNullException("fax is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "zipcode" is required (not null)
            this.Zipcode = zipcode ?? throw new ArgumentNullException("zipcode is a required property for CompaniesShowResponseCompany and cannot be null");;
            this.PrefectureCode = prefectureCode;
            // to ensure "streetName1" is required (not null)
            this.StreetName1 = streetName1 ?? throw new ArgumentNullException("streetName1 is a required property for CompaniesShowResponseCompany and cannot be null");;
            // to ensure "streetName2" is required (not null)
            this.StreetName2 = streetName2 ?? throw new ArgumentNullException("streetName2 is a required property for CompaniesShowResponseCompany and cannot be null");;
            this.InvoiceLayout = invoiceLayout;
            this.InvoiceStyle = invoiceStyle;
            this.AmountFraction = amountFraction;
            this.IndustryClass = industryClass;
            this.IndustryCode = industryCode;
            this.WorkflowSetting = workflowSetting;
            this.UsePartnerCode = usePartnerCode;
            this.DefaultWalletAccountId = defaultWalletAccountId;
        }
        
        /// <summary>
        /// 事業所ID
        /// </summary>
        /// <value>事業所ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// 事業所の正式名称 (100文字以内)
        /// </summary>
        /// <value>事業所の正式名称 (100文字以内)</value>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// 正式名称フリガナ (100文字以内)
        /// </summary>
        /// <value>正式名称フリガナ (100文字以内)</value>
        [DataMember(Name="name_kana", EmitDefaultValue=true)]
        public string NameKana { get; set; }

        /// <summary>
        /// 事業所名
        /// </summary>
        /// <value>事業所名</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// 源泉徴収税計算（0: 消費税を含める、1: 消費税を含めない）
        /// </summary>
        /// <value>源泉徴収税計算（0: 消費税を含める、1: 消費税を含めない）</value>
        [DataMember(Name="tax_at_source_calc_type", EmitDefaultValue=false)]
        public int TaxAtSourceCalcType { get; set; }

        /// <summary>
        /// 担当者名 (50文字以内)
        /// </summary>
        /// <value>担当者名 (50文字以内)</value>
        [DataMember(Name="contact_name", EmitDefaultValue=true)]
        public string ContactName { get; set; }

        /// <summary>
        /// 従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上
        /// </summary>
        /// <value>従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上</value>
        [DataMember(Name="head_count", EmitDefaultValue=true)]
        public int? HeadCount { get; set; }

        /// <summary>
        /// 法人番号 (半角数字13桁、法人のみ)
        /// </summary>
        /// <value>法人番号 (半角数字13桁、法人のみ)</value>
        [DataMember(Name="corporate_number", EmitDefaultValue=false)]
        public string CorporateNumber { get; set; }

        /// <summary>
        /// 決済口座のデフォルト
        /// </summary>
        /// <value>決済口座のデフォルト</value>
        [DataMember(Name="default_wallet_account_id", EmitDefaultValue=false)]
        public int DefaultWalletAccountId { get; set; }

        /// <summary>
        /// プライベート資金/役員資金（false: 使用しない、true: 使用する）
        /// </summary>
        /// <value>プライベート資金/役員資金（false: 使用しない、true: 使用する）</value>
        [DataMember(Name="private_settlement", EmitDefaultValue=false)]
        public bool PrivateSettlement { get; set; }

        /// <summary>
        /// マイナスの表示方法（0: -、 1: △）
        /// </summary>
        /// <value>マイナスの表示方法（0: -、 1: △）</value>
        [DataMember(Name="minus_format", EmitDefaultValue=false)]
        public int MinusFormat { get; set; }

        /// <summary>
        /// 電話番号１
        /// </summary>
        /// <value>電話番号１</value>
        [DataMember(Name="phone1", EmitDefaultValue=false)]
        public string Phone1 { get; set; }

        /// <summary>
        /// 電話番号２
        /// </summary>
        /// <value>電話番号２</value>
        [DataMember(Name="phone2", EmitDefaultValue=true)]
        public string Phone2 { get; set; }

        /// <summary>
        /// FAX
        /// </summary>
        /// <value>FAX</value>
        [DataMember(Name="fax", EmitDefaultValue=true)]
        public string Fax { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        /// <value>郵便番号</value>
        [DataMember(Name="zipcode", EmitDefaultValue=false)]
        public string Zipcode { get; set; }

        /// <summary>
        /// 都道府県コード（0: 北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄
        /// </summary>
        /// <value>都道府県コード（0: 北海道、1:青森、2:岩手、3:宮城、4:秋田、5:山形、6:福島、7:茨城、8:栃木、9:群馬、10:埼玉、11:千葉、12:東京、13:神奈川、14:新潟、15:富山、16:石川、17:福井、18:山梨、19:長野、20:岐阜、21:静岡、22:愛知、23:三重、24:滋賀、25:京都、26:大阪、27:兵庫、28:奈良、29:和歌山、30:鳥取、31:島根、32:岡山、33:広島、34:山口、35:徳島、36:香川、37:愛媛、38:高知、39:福岡、40:佐賀、41:長崎、42:熊本、43:大分、44:宮崎、45:鹿児島、46:沖縄</value>
        [DataMember(Name="prefecture_code", EmitDefaultValue=false)]
        public int PrefectureCode { get; set; }

        /// <summary>
        /// 市区町村・番地
        /// </summary>
        /// <value>市区町村・番地</value>
        [DataMember(Name="street_name1", EmitDefaultValue=false)]
        public string StreetName1 { get; set; }

        /// <summary>
        /// 建物名・部屋番号など
        /// </summary>
        /// <value>建物名・部屋番号など</value>
        [DataMember(Name="street_name2", EmitDefaultValue=false)]
        public string StreetName2 { get; set; }

        /// <summary>
        /// レイアウト(0: レイアウト1, 1:レイアウト2, 3:封筒1, 4:レイアウト3(繰越金額欄あり), 5: 封筒2(繰越金額欄あり))
        /// </summary>
        /// <value>レイアウト(0: レイアウト1, 1:レイアウト2, 3:封筒1, 4:レイアウト3(繰越金額欄あり), 5: 封筒2(繰越金額欄あり))</value>
        [DataMember(Name="invoice_layout", EmitDefaultValue=false)]
        public int InvoiceLayout { get; set; }

        /// <summary>
        /// スタイル(0: クラシック, 1: モダン)
        /// </summary>
        /// <value>スタイル(0: クラシック, 1: モダン)</value>
        [DataMember(Name="invoice_style", EmitDefaultValue=false)]
        public int InvoiceStyle { get; set; }

        /// <summary>
        /// 金額端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入）
        /// </summary>
        /// <value>金額端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入）</value>
        [DataMember(Name="amount_fraction", EmitDefaultValue=false)]
        public int AmountFraction { get; set; }

        /// <summary>
        /// 取引先コードの利用設定（true: 有効、 false: 無効）
        /// </summary>
        /// <value>取引先コードの利用設定（true: 有効、 false: 無効）</value>
        [DataMember(Name="use_partner_code", EmitDefaultValue=false)]
        public bool UsePartnerCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CompaniesShowResponseCompany {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NameKana: ").Append(NameKana).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  TaxAtSourceCalcType: ").Append(TaxAtSourceCalcType).Append("\n");
            sb.Append("  ContactName: ").Append(ContactName).Append("\n");
            sb.Append("  HeadCount: ").Append(HeadCount).Append("\n");
            sb.Append("  CorporateNumber: ").Append(CorporateNumber).Append("\n");
            sb.Append("  TxnNumberFormat: ").Append(TxnNumberFormat).Append("\n");
            sb.Append("  DefaultWalletAccountId: ").Append(DefaultWalletAccountId).Append("\n");
            sb.Append("  PrivateSettlement: ").Append(PrivateSettlement).Append("\n");
            sb.Append("  MinusFormat: ").Append(MinusFormat).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Phone1: ").Append(Phone1).Append("\n");
            sb.Append("  Phone2: ").Append(Phone2).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  Zipcode: ").Append(Zipcode).Append("\n");
            sb.Append("  PrefectureCode: ").Append(PrefectureCode).Append("\n");
            sb.Append("  StreetName1: ").Append(StreetName1).Append("\n");
            sb.Append("  StreetName2: ").Append(StreetName2).Append("\n");
            sb.Append("  InvoiceLayout: ").Append(InvoiceLayout).Append("\n");
            sb.Append("  InvoiceStyle: ").Append(InvoiceStyle).Append("\n");
            sb.Append("  AmountFraction: ").Append(AmountFraction).Append("\n");
            sb.Append("  IndustryClass: ").Append(IndustryClass).Append("\n");
            sb.Append("  IndustryCode: ").Append(IndustryCode).Append("\n");
            sb.Append("  WorkflowSetting: ").Append(WorkflowSetting).Append("\n");
            sb.Append("  UsePartnerCode: ").Append(UsePartnerCode).Append("\n");
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
            return this.Equals(input as CompaniesShowResponseCompany);
        }

        /// <summary>
        /// Returns true if CompaniesShowResponseCompany instances are equal
        /// </summary>
        /// <param name="input">Instance of CompaniesShowResponseCompany to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CompaniesShowResponseCompany input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.NameKana == input.NameKana ||
                    (this.NameKana != null &&
                    this.NameKana.Equals(input.NameKana))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.TaxAtSourceCalcType == input.TaxAtSourceCalcType ||
                    this.TaxAtSourceCalcType.Equals(input.TaxAtSourceCalcType)
                ) && 
                (
                    this.ContactName == input.ContactName ||
                    (this.ContactName != null &&
                    this.ContactName.Equals(input.ContactName))
                ) && 
                (
                    this.HeadCount == input.HeadCount ||
                    (this.HeadCount != null &&
                    this.HeadCount.Equals(input.HeadCount))
                ) && 
                (
                    this.CorporateNumber == input.CorporateNumber ||
                    (this.CorporateNumber != null &&
                    this.CorporateNumber.Equals(input.CorporateNumber))
                ) && 
                (
                    this.TxnNumberFormat == input.TxnNumberFormat ||
                    this.TxnNumberFormat.Equals(input.TxnNumberFormat)
                ) && 
                (
                    this.DefaultWalletAccountId == input.DefaultWalletAccountId ||
                    this.DefaultWalletAccountId.Equals(input.DefaultWalletAccountId)
                ) && 
                (
                    this.PrivateSettlement == input.PrivateSettlement ||
                    this.PrivateSettlement.Equals(input.PrivateSettlement)
                ) && 
                (
                    this.MinusFormat == input.MinusFormat ||
                    this.MinusFormat.Equals(input.MinusFormat)
                ) && 
                (
                    this.Role == input.Role ||
                    this.Role.Equals(input.Role)
                ) && 
                (
                    this.Phone1 == input.Phone1 ||
                    (this.Phone1 != null &&
                    this.Phone1.Equals(input.Phone1))
                ) && 
                (
                    this.Phone2 == input.Phone2 ||
                    (this.Phone2 != null &&
                    this.Phone2.Equals(input.Phone2))
                ) && 
                (
                    this.Fax == input.Fax ||
                    (this.Fax != null &&
                    this.Fax.Equals(input.Fax))
                ) && 
                (
                    this.Zipcode == input.Zipcode ||
                    (this.Zipcode != null &&
                    this.Zipcode.Equals(input.Zipcode))
                ) && 
                (
                    this.PrefectureCode == input.PrefectureCode ||
                    this.PrefectureCode.Equals(input.PrefectureCode)
                ) && 
                (
                    this.StreetName1 == input.StreetName1 ||
                    (this.StreetName1 != null &&
                    this.StreetName1.Equals(input.StreetName1))
                ) && 
                (
                    this.StreetName2 == input.StreetName2 ||
                    (this.StreetName2 != null &&
                    this.StreetName2.Equals(input.StreetName2))
                ) && 
                (
                    this.InvoiceLayout == input.InvoiceLayout ||
                    this.InvoiceLayout.Equals(input.InvoiceLayout)
                ) && 
                (
                    this.InvoiceStyle == input.InvoiceStyle ||
                    this.InvoiceStyle.Equals(input.InvoiceStyle)
                ) && 
                (
                    this.AmountFraction == input.AmountFraction ||
                    this.AmountFraction.Equals(input.AmountFraction)
                ) && 
                (
                    this.IndustryClass == input.IndustryClass ||
                    this.IndustryClass.Equals(input.IndustryClass)
                ) && 
                (
                    this.IndustryCode == input.IndustryCode ||
                    this.IndustryCode.Equals(input.IndustryCode)
                ) && 
                (
                    this.WorkflowSetting == input.WorkflowSetting ||
                    this.WorkflowSetting.Equals(input.WorkflowSetting)
                ) && 
                (
                    this.UsePartnerCode == input.UsePartnerCode ||
                    this.UsePartnerCode.Equals(input.UsePartnerCode)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.NameKana != null)
                    hashCode = hashCode * 59 + this.NameKana.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                hashCode = hashCode * 59 + this.TaxAtSourceCalcType.GetHashCode();
                if (this.ContactName != null)
                    hashCode = hashCode * 59 + this.ContactName.GetHashCode();
                if (this.HeadCount != null)
                    hashCode = hashCode * 59 + this.HeadCount.GetHashCode();
                if (this.CorporateNumber != null)
                    hashCode = hashCode * 59 + this.CorporateNumber.GetHashCode();
                hashCode = hashCode * 59 + this.TxnNumberFormat.GetHashCode();
                hashCode = hashCode * 59 + this.DefaultWalletAccountId.GetHashCode();
                hashCode = hashCode * 59 + this.PrivateSettlement.GetHashCode();
                hashCode = hashCode * 59 + this.MinusFormat.GetHashCode();
                hashCode = hashCode * 59 + this.Role.GetHashCode();
                if (this.Phone1 != null)
                    hashCode = hashCode * 59 + this.Phone1.GetHashCode();
                if (this.Phone2 != null)
                    hashCode = hashCode * 59 + this.Phone2.GetHashCode();
                if (this.Fax != null)
                    hashCode = hashCode * 59 + this.Fax.GetHashCode();
                if (this.Zipcode != null)
                    hashCode = hashCode * 59 + this.Zipcode.GetHashCode();
                hashCode = hashCode * 59 + this.PrefectureCode.GetHashCode();
                if (this.StreetName1 != null)
                    hashCode = hashCode * 59 + this.StreetName1.GetHashCode();
                if (this.StreetName2 != null)
                    hashCode = hashCode * 59 + this.StreetName2.GetHashCode();
                hashCode = hashCode * 59 + this.InvoiceLayout.GetHashCode();
                hashCode = hashCode * 59 + this.InvoiceStyle.GetHashCode();
                hashCode = hashCode * 59 + this.AmountFraction.GetHashCode();
                hashCode = hashCode * 59 + this.IndustryClass.GetHashCode();
                hashCode = hashCode * 59 + this.IndustryCode.GetHashCode();
                hashCode = hashCode * 59 + this.WorkflowSetting.GetHashCode();
                hashCode = hashCode * 59 + this.UsePartnerCode.GetHashCode();
                return hashCode;
            }
        }

    }

}
