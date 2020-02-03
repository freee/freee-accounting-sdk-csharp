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
    /// UpdateCompanyParams
    /// </summary>
    [DataContract]
    public partial class UpdateCompanyParams :  IEquatable<UpdateCompanyParams>
    {
        /// <summary>
        /// 仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））Available values : not_used, digits, alnum
        /// </summary>
        /// <value>仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））Available values : not_used, digits, alnum</value>
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
        /// 仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））Available values : not_used, digits, alnum
        /// </summary>
        /// <value>仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））Available values : not_used, digits, alnum</value>
        [DataMember(Name="txn_number_format", EmitDefaultValue=false)]
        public TxnNumberFormatEnum? TxnNumberFormat { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompanyParams" /> class.
        /// </summary>
        /// <param name="name">事業所の正式名称 (100文字以内).</param>
        /// <param name="nameKana">正式名称フリガナ (100文字以内).</param>
        /// <param name="contactName">user1.</param>
        /// <param name="addressAttributes">addressAttributes.</param>
        /// <param name="phone1">電話番号１.</param>
        /// <param name="phone2">電話番号２.</param>
        /// <param name="fax">FAX.</param>
        /// <param name="salesInformationAttributes">salesInformationAttributes.</param>
        /// <param name="headCount">従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上.</param>
        /// <param name="corporateNumber">法人番号 (半角数字13桁、法人のみ).</param>
        /// <param name="fiscalYearsAttributes">fiscalYearsAttributes.</param>
        /// <param name="docTemplate">docTemplate.</param>
        /// <param name="txnNumberFormat">仕訳番号形式（not_used: 使用しない、digits: 数字（例：5091824）、alnum: 英数字（例：59J0P））Available values : not_used, digits, alnum.</param>
        /// <param name="privateSettlement">プライベート資金/役員資金（0: 使用しない、1: 使用する）.</param>
        public UpdateCompanyParams(string name = default(string), string nameKana = default(string), string contactName = default(string), UpdateCompanyParamsAddressAttributes addressAttributes = default(UpdateCompanyParamsAddressAttributes), string phone1 = default(string), string phone2 = default(string), string fax = default(string), UpdateCompanyParamsSalesInformationAttributes salesInformationAttributes = default(UpdateCompanyParamsSalesInformationAttributes), decimal headCount = default(decimal), string corporateNumber = default(string), UpdateCompanyParamsFiscalYearsAttributes fiscalYearsAttributes = default(UpdateCompanyParamsFiscalYearsAttributes), UpdateCompanyParamsDocTemplate docTemplate = default(UpdateCompanyParamsDocTemplate), TxnNumberFormatEnum? txnNumberFormat = default(TxnNumberFormatEnum?), int privateSettlement = default(int))
        {
            this.Name = name;
            this.NameKana = nameKana;
            this.ContactName = contactName;
            this.AddressAttributes = addressAttributes;
            this.Phone1 = phone1;
            this.Phone2 = phone2;
            this.Fax = fax;
            this.SalesInformationAttributes = salesInformationAttributes;
            this.HeadCount = headCount;
            this.CorporateNumber = corporateNumber;
            this.FiscalYearsAttributes = fiscalYearsAttributes;
            this.DocTemplate = docTemplate;
            this.TxnNumberFormat = txnNumberFormat;
            this.PrivateSettlement = privateSettlement;
        }
        
        /// <summary>
        /// 事業所の正式名称 (100文字以内)
        /// </summary>
        /// <value>事業所の正式名称 (100文字以内)</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// 正式名称フリガナ (100文字以内)
        /// </summary>
        /// <value>正式名称フリガナ (100文字以内)</value>
        [DataMember(Name="name_kana", EmitDefaultValue=false)]
        public string NameKana { get; set; }

        /// <summary>
        /// user1
        /// </summary>
        /// <value>user1</value>
        [DataMember(Name="contact_name", EmitDefaultValue=false)]
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or Sets AddressAttributes
        /// </summary>
        [DataMember(Name="address_attributes", EmitDefaultValue=false)]
        public UpdateCompanyParamsAddressAttributes AddressAttributes { get; set; }

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
        [DataMember(Name="phone2", EmitDefaultValue=false)]
        public string Phone2 { get; set; }

        /// <summary>
        /// FAX
        /// </summary>
        /// <value>FAX</value>
        [DataMember(Name="fax", EmitDefaultValue=false)]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or Sets SalesInformationAttributes
        /// </summary>
        [DataMember(Name="sales_information_attributes", EmitDefaultValue=false)]
        public UpdateCompanyParamsSalesInformationAttributes SalesInformationAttributes { get; set; }

        /// <summary>
        /// 従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上
        /// </summary>
        /// <value>従業員数（0: 経営者のみ、1: 2~5人、2: 6~10人、3: 11~20人、4: 21~30人、5: 31~40人、6: 41~100人、7: 100人以上</value>
        [DataMember(Name="head_count", EmitDefaultValue=false)]
        public decimal HeadCount { get; set; }

        /// <summary>
        /// 法人番号 (半角数字13桁、法人のみ)
        /// </summary>
        /// <value>法人番号 (半角数字13桁、法人のみ)</value>
        [DataMember(Name="corporate_number", EmitDefaultValue=false)]
        public string CorporateNumber { get; set; }

        /// <summary>
        /// Gets or Sets FiscalYearsAttributes
        /// </summary>
        [DataMember(Name="fiscal_years_attributes", EmitDefaultValue=false)]
        public UpdateCompanyParamsFiscalYearsAttributes FiscalYearsAttributes { get; set; }

        /// <summary>
        /// Gets or Sets DocTemplate
        /// </summary>
        [DataMember(Name="doc_template", EmitDefaultValue=false)]
        public UpdateCompanyParamsDocTemplate DocTemplate { get; set; }

        /// <summary>
        /// プライベート資金/役員資金（0: 使用しない、1: 使用する）
        /// </summary>
        /// <value>プライベート資金/役員資金（0: 使用しない、1: 使用する）</value>
        [DataMember(Name="private_settlement", EmitDefaultValue=false)]
        public int PrivateSettlement { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCompanyParams {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NameKana: ").Append(NameKana).Append("\n");
            sb.Append("  ContactName: ").Append(ContactName).Append("\n");
            sb.Append("  AddressAttributes: ").Append(AddressAttributes).Append("\n");
            sb.Append("  Phone1: ").Append(Phone1).Append("\n");
            sb.Append("  Phone2: ").Append(Phone2).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  SalesInformationAttributes: ").Append(SalesInformationAttributes).Append("\n");
            sb.Append("  HeadCount: ").Append(HeadCount).Append("\n");
            sb.Append("  CorporateNumber: ").Append(CorporateNumber).Append("\n");
            sb.Append("  FiscalYearsAttributes: ").Append(FiscalYearsAttributes).Append("\n");
            sb.Append("  DocTemplate: ").Append(DocTemplate).Append("\n");
            sb.Append("  TxnNumberFormat: ").Append(TxnNumberFormat).Append("\n");
            sb.Append("  PrivateSettlement: ").Append(PrivateSettlement).Append("\n");
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
            return this.Equals(input as UpdateCompanyParams);
        }

        /// <summary>
        /// Returns true if UpdateCompanyParams instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCompanyParams to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCompanyParams input)
        {
            if (input == null)
                return false;

            return 
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
                    this.ContactName == input.ContactName ||
                    (this.ContactName != null &&
                    this.ContactName.Equals(input.ContactName))
                ) && 
                (
                    this.AddressAttributes == input.AddressAttributes ||
                    (this.AddressAttributes != null &&
                    this.AddressAttributes.Equals(input.AddressAttributes))
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
                    this.SalesInformationAttributes == input.SalesInformationAttributes ||
                    (this.SalesInformationAttributes != null &&
                    this.SalesInformationAttributes.Equals(input.SalesInformationAttributes))
                ) && 
                (
                    this.HeadCount == input.HeadCount ||
                    this.HeadCount.Equals(input.HeadCount)
                ) && 
                (
                    this.CorporateNumber == input.CorporateNumber ||
                    (this.CorporateNumber != null &&
                    this.CorporateNumber.Equals(input.CorporateNumber))
                ) && 
                (
                    this.FiscalYearsAttributes == input.FiscalYearsAttributes ||
                    (this.FiscalYearsAttributes != null &&
                    this.FiscalYearsAttributes.Equals(input.FiscalYearsAttributes))
                ) && 
                (
                    this.DocTemplate == input.DocTemplate ||
                    (this.DocTemplate != null &&
                    this.DocTemplate.Equals(input.DocTemplate))
                ) && 
                (
                    this.TxnNumberFormat == input.TxnNumberFormat ||
                    this.TxnNumberFormat.Equals(input.TxnNumberFormat)
                ) && 
                (
                    this.PrivateSettlement == input.PrivateSettlement ||
                    this.PrivateSettlement.Equals(input.PrivateSettlement)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.NameKana != null)
                    hashCode = hashCode * 59 + this.NameKana.GetHashCode();
                if (this.ContactName != null)
                    hashCode = hashCode * 59 + this.ContactName.GetHashCode();
                if (this.AddressAttributes != null)
                    hashCode = hashCode * 59 + this.AddressAttributes.GetHashCode();
                if (this.Phone1 != null)
                    hashCode = hashCode * 59 + this.Phone1.GetHashCode();
                if (this.Phone2 != null)
                    hashCode = hashCode * 59 + this.Phone2.GetHashCode();
                if (this.Fax != null)
                    hashCode = hashCode * 59 + this.Fax.GetHashCode();
                if (this.SalesInformationAttributes != null)
                    hashCode = hashCode * 59 + this.SalesInformationAttributes.GetHashCode();
                hashCode = hashCode * 59 + this.HeadCount.GetHashCode();
                if (this.CorporateNumber != null)
                    hashCode = hashCode * 59 + this.CorporateNumber.GetHashCode();
                if (this.FiscalYearsAttributes != null)
                    hashCode = hashCode * 59 + this.FiscalYearsAttributes.GetHashCode();
                if (this.DocTemplate != null)
                    hashCode = hashCode * 59 + this.DocTemplate.GetHashCode();
                hashCode = hashCode * 59 + this.TxnNumberFormat.GetHashCode();
                hashCode = hashCode * 59 + this.PrivateSettlement.GetHashCode();
                return hashCode;
            }
        }

    }

}
