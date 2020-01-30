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
    /// FiscalYears
    /// </summary>
    [DataContract]
    public partial class FiscalYears :  IEquatable<FiscalYears>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FiscalYears" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FiscalYears() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FiscalYears" /> class.
        /// </summary>
        /// <param name="useIndustryTemplate">製造業向け機能（true: 使用する、false: 使用しない） (required).</param>
        /// <param name="indirectWriteOffMethod">固定資産の控除法(false: 減価償却累計額でまとめる、true: 独立間接控除方式) (required).</param>
        /// <param name="startDate">期首日.</param>
        /// <param name="endDate">期末日.</param>
        /// <param name="depreciationRecordMethod">月次償却（0: しない、1: する） (required).</param>
        /// <param name="taxMethod">課税区分（0: 免税、1: 簡易課税、2: 本則課税（個別対応方式）、3: 本則課税（一括比例配分方式）、4: 本則課税（全額控除）） (required).</param>
        /// <param name="salesTaxBusinessCode">簡易課税用事業区分（0: 第一種：卸売業、1: 第二種：小売業、2: 第三種：農林水産業、工業、建設業、製造業など、3: 第四種：飲食店業など、4: 第五種：金融・保険業、運輸通信業、サービス業など、5: 第六種：不動産業など (required).</param>
        /// <param name="taxFraction">消費税端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入） (required).</param>
        /// <param name="taxAccountMethod">消費税経理処理方法（0: 税込経理、1: 旧税抜経理、2: 税抜経理） (required).</param>
        /// <param name="returnCode">不動産所得使用区分（0: 一般、1: 一般/不動産） ※個人事業主のみ設定可能 (required).</param>
        public FiscalYears(bool useIndustryTemplate = default(bool), bool indirectWriteOffMethod = default(bool), string startDate = default(string), string endDate = default(string), int depreciationRecordMethod = default(int), int taxMethod = default(int), int salesTaxBusinessCode = default(int), int taxFraction = default(int), int taxAccountMethod = default(int), int returnCode = default(int))
        {
            this.UseIndustryTemplate = useIndustryTemplate;
            this.IndirectWriteOffMethod = indirectWriteOffMethod;
            this.DepreciationRecordMethod = depreciationRecordMethod;
            this.TaxMethod = taxMethod;
            this.SalesTaxBusinessCode = salesTaxBusinessCode;
            this.TaxFraction = taxFraction;
            this.TaxAccountMethod = taxAccountMethod;
            this.ReturnCode = returnCode;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        
        /// <summary>
        /// 製造業向け機能（true: 使用する、false: 使用しない）
        /// </summary>
        /// <value>製造業向け機能（true: 使用する、false: 使用しない）</value>
        [DataMember(Name="use_industry_template", EmitDefaultValue=false)]
        public bool UseIndustryTemplate { get; set; }

        /// <summary>
        /// 固定資産の控除法(false: 減価償却累計額でまとめる、true: 独立間接控除方式)
        /// </summary>
        /// <value>固定資産の控除法(false: 減価償却累計額でまとめる、true: 独立間接控除方式)</value>
        [DataMember(Name="indirect_write_off_method", EmitDefaultValue=false)]
        public bool IndirectWriteOffMethod { get; set; }

        /// <summary>
        /// 期首日
        /// </summary>
        /// <value>期首日</value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        /// 期末日
        /// </summary>
        /// <value>期末日</value>
        [DataMember(Name="end_date", EmitDefaultValue=false)]
        public string EndDate { get; set; }

        /// <summary>
        /// 月次償却（0: しない、1: する）
        /// </summary>
        /// <value>月次償却（0: しない、1: する）</value>
        [DataMember(Name="depreciation_record_method", EmitDefaultValue=false)]
        public int DepreciationRecordMethod { get; set; }

        /// <summary>
        /// 課税区分（0: 免税、1: 簡易課税、2: 本則課税（個別対応方式）、3: 本則課税（一括比例配分方式）、4: 本則課税（全額控除））
        /// </summary>
        /// <value>課税区分（0: 免税、1: 簡易課税、2: 本則課税（個別対応方式）、3: 本則課税（一括比例配分方式）、4: 本則課税（全額控除））</value>
        [DataMember(Name="tax_method", EmitDefaultValue=false)]
        public int TaxMethod { get; set; }

        /// <summary>
        /// 簡易課税用事業区分（0: 第一種：卸売業、1: 第二種：小売業、2: 第三種：農林水産業、工業、建設業、製造業など、3: 第四種：飲食店業など、4: 第五種：金融・保険業、運輸通信業、サービス業など、5: 第六種：不動産業など
        /// </summary>
        /// <value>簡易課税用事業区分（0: 第一種：卸売業、1: 第二種：小売業、2: 第三種：農林水産業、工業、建設業、製造業など、3: 第四種：飲食店業など、4: 第五種：金融・保険業、運輸通信業、サービス業など、5: 第六種：不動産業など</value>
        [DataMember(Name="sales_tax_business_code", EmitDefaultValue=false)]
        public int SalesTaxBusinessCode { get; set; }

        /// <summary>
        /// 消費税端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入）
        /// </summary>
        /// <value>消費税端数処理方法（0: 切り捨て、1: 切り上げ、2: 四捨五入）</value>
        [DataMember(Name="tax_fraction", EmitDefaultValue=false)]
        public int TaxFraction { get; set; }

        /// <summary>
        /// 消費税経理処理方法（0: 税込経理、1: 旧税抜経理、2: 税抜経理）
        /// </summary>
        /// <value>消費税経理処理方法（0: 税込経理、1: 旧税抜経理、2: 税抜経理）</value>
        [DataMember(Name="tax_account_method", EmitDefaultValue=false)]
        public int TaxAccountMethod { get; set; }

        /// <summary>
        /// 不動産所得使用区分（0: 一般、1: 一般/不動産） ※個人事業主のみ設定可能
        /// </summary>
        /// <value>不動産所得使用区分（0: 一般、1: 一般/不動産） ※個人事業主のみ設定可能</value>
        [DataMember(Name="return_code", EmitDefaultValue=false)]
        public int ReturnCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FiscalYears {\n");
            sb.Append("  UseIndustryTemplate: ").Append(UseIndustryTemplate).Append("\n");
            sb.Append("  IndirectWriteOffMethod: ").Append(IndirectWriteOffMethod).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  DepreciationRecordMethod: ").Append(DepreciationRecordMethod).Append("\n");
            sb.Append("  TaxMethod: ").Append(TaxMethod).Append("\n");
            sb.Append("  SalesTaxBusinessCode: ").Append(SalesTaxBusinessCode).Append("\n");
            sb.Append("  TaxFraction: ").Append(TaxFraction).Append("\n");
            sb.Append("  TaxAccountMethod: ").Append(TaxAccountMethod).Append("\n");
            sb.Append("  ReturnCode: ").Append(ReturnCode).Append("\n");
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
            return this.Equals(input as FiscalYears);
        }

        /// <summary>
        /// Returns true if FiscalYears instances are equal
        /// </summary>
        /// <param name="input">Instance of FiscalYears to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FiscalYears input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UseIndustryTemplate == input.UseIndustryTemplate ||
                    this.UseIndustryTemplate.Equals(input.UseIndustryTemplate)
                ) && 
                (
                    this.IndirectWriteOffMethod == input.IndirectWriteOffMethod ||
                    this.IndirectWriteOffMethod.Equals(input.IndirectWriteOffMethod)
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
                    this.DepreciationRecordMethod == input.DepreciationRecordMethod ||
                    this.DepreciationRecordMethod.Equals(input.DepreciationRecordMethod)
                ) && 
                (
                    this.TaxMethod == input.TaxMethod ||
                    this.TaxMethod.Equals(input.TaxMethod)
                ) && 
                (
                    this.SalesTaxBusinessCode == input.SalesTaxBusinessCode ||
                    this.SalesTaxBusinessCode.Equals(input.SalesTaxBusinessCode)
                ) && 
                (
                    this.TaxFraction == input.TaxFraction ||
                    this.TaxFraction.Equals(input.TaxFraction)
                ) && 
                (
                    this.TaxAccountMethod == input.TaxAccountMethod ||
                    this.TaxAccountMethod.Equals(input.TaxAccountMethod)
                ) && 
                (
                    this.ReturnCode == input.ReturnCode ||
                    this.ReturnCode.Equals(input.ReturnCode)
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
                hashCode = hashCode * 59 + this.UseIndustryTemplate.GetHashCode();
                hashCode = hashCode * 59 + this.IndirectWriteOffMethod.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                hashCode = hashCode * 59 + this.DepreciationRecordMethod.GetHashCode();
                hashCode = hashCode * 59 + this.TaxMethod.GetHashCode();
                hashCode = hashCode * 59 + this.SalesTaxBusinessCode.GetHashCode();
                hashCode = hashCode * 59 + this.TaxFraction.GetHashCode();
                hashCode = hashCode * 59 + this.TaxAccountMethod.GetHashCode();
                hashCode = hashCode * 59 + this.ReturnCode.GetHashCode();
                return hashCode;
            }
        }

    }

}
