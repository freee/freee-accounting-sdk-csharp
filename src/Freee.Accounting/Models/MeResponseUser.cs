/* 
 * freee API
 *
 *  <h1 id=\"freee_api\">freee API</h1> <hr /> <h2 id=\"start_guide\">スタートガイド</h2>  <p>freee API開発がはじめての方は<a href=\"https://developer.freee.co.jp/getting-started\">freee API スタートガイド</a>を参照してください。</p>  <hr /> <h2 id=\"specification\">仕様</h2>  <pre><code>【重要】会計freee APIの新バージョンについて 2020年12月まで、2つのバージョンが利用できる状態です。古いものは2020年12月に利用不可となります。<br> 新しいAPIを利用するにはリクエストヘッダーに以下を指定します。 X-Api-Version: 2020-06-15<br> 指定がない場合は2020年12月に廃止予定のAPIを利用することとなります。<br> 【重要】APIのバージョン指定をせずに利用し続ける場合 2020年12月に新しいバージョンのAPIに自動的に切り替わります。 詳細は、<a href=\"https://developer.freee.co.jp/release-note/2948\" target=\"_blank\">リリースノート</a>をご覧ください。<br> 旧バージョンのAPIリファレンスを確認したい場合は、<a href=\"https://freee.github.io/freee-api-schema/\" target=\"_blank\">旧バージョンのAPIリファレンスページ</a>をご覧ください。 </code></pre>  <h3 id=\"api_endpoint\">APIエンドポイント</h3>  <p>https://api.freee.co.jp/ (httpsのみ)</p>  <h3 id=\"about_authorize\">認証について</h3> <p>OAuth2.0を利用します。詳細は<a href=\"https://developer.freee.co.jp/docs\" target=\"_blank\">ドキュメントの認証</a>パートを参照してください。</p>  <h3 id=\"data_format\">データフォーマット</h3>  <p>リクエスト、レスポンスともにJSON形式をサポートしていますが、詳細は、API毎の説明欄（application/jsonなど）を確認してください。</p>  <h3 id=\"compatibility\">後方互換性ありの変更</h3>  <p>freeeでは、APIを改善していくために以下のような変更は後方互換性ありとして通知なく変更を入れることがあります。アプリケーション実装者は以下を踏まえて開発を行ってください。</p>  <ul> <li>新しいAPIリソース・エンドポイントの追加</li> <li>既存のAPIに対して必須ではない新しいリクエストパラメータの追加</li> <li>既存のAPIレスポンスに対する新しいプロパティの追加</li> <li>既存のAPIレスポンスに対するプロパティの順番の入れ変え</li> <li>keyとなっているidやcodeの長さの変更（長くする）</li> </ul>  <h3 id=\"common_response_header\">共通レスポンスヘッダー</h3>  <p>すべてのAPIのレスポンスには以下のHTTPヘッダーが含まれます。</p>  <ul> <li> <p>X-Freee-Request-ID</p> <ul> <li>各リクエスト毎に発行されるID</li> </ul> </li> </ul>  <h3 id=\"common_error_response\">共通エラーレスポンス</h3>  <ul> <li> <p>ステータスコードはレスポンス内のJSONに含まれる他、HTTPヘッダにも含まれる</p> </li> <li> <p>一部のエラーレスポンスにはエラーコードが含まれます。<br>詳細は、<a href=\"https://developer.freee.co.jp/tips/faq/40x-checkpoint\">HTTPステータスコード400台エラー時のチェックポイント</a>を参照してください</p> </li> <p>type</p>  <ul> <li>status : HTTPステータスコードの説明</li>  <li>validation : エラーの詳細の説明（開発者向け）</li> </ul> </li> </ul>  <p>レスポンスの例</p>  <pre><code>  {     &quot;status_code&quot; : 400,     &quot;errors&quot; : [       {         &quot;type&quot; : &quot;status&quot;,         &quot;messages&quot; : [&quot;不正なリクエストです。&quot;]       },       {         &quot;type&quot; : &quot;validation&quot;,         &quot;messages&quot; : [&quot;Date は不正な日付フォーマットです。入力例：2013-01-01&quot;]       }     ]   }</code></pre>  </br>  <h3 id=\"api_rate_limit\">API使用制限</h3>    <p>freeeは一定期間に過度のアクセスを検知した場合、APIアクセスをコントロールする場合があります。</p>   <p>その際のhttp status codeは403となります。制限がかかってから10分程度が過ぎると再度使用することができるようになります。</p>  <h4 id=\"reports_api_endpoint\">/reportsエンドポイント</h4>  <p>freeeは/reportsエンドポイントに対して1秒間に10以上のアクセスを検知した場合、APIアクセスをコントロールする場合があります。その際のhttp status codeは429（too many requests）となります。</p>  <p>レスポンスボディのmetaプロパティに以下を含めます。</p>  <ul>   <li>設定されている上限値</li>   <li>上限に達するまでの使用可能回数</li>   <li>（上限値に達した場合）使用回数がリセットされる時刻</li> </ul>  <h3 id=\"plan_api_rate_limit\">プラン別のAPI Rate Limit</h3>   <table border=\"1\">     <tbody>       <tr>         <th style=\"padding: 10px\"><strong>会計freeeプラン名</strong></th>         <th style=\"padding: 10px\"><strong>事業所とアプリケーション毎に1日でのAPIコール数</strong></th>       </tr>       <tr>         <td style=\"padding: 10px\">エンタープライズ</td>         <td style=\"padding: 10px\">10,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">プロフェッショナル</td>         <td style=\"padding: 10px\">5,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ベーシック</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">ミニマム</td>         <td style=\"padding: 10px\">3,000</td>       </tr>       <tr>         <td style=\"padding: 10px\">上記以外</td>         <td style=\"padding: 10px\">3,000</td>       </tr>     </tbody>   </table>  <hr /> <h2 id=\"contact\">連絡先</h2>  <p>ご不明点、ご要望等は <a href=\"https://support.freee.co.jp/hc/ja/requests/new\">freee サポートデスクへのお問い合わせフォーム</a> からご連絡ください。</p> <hr />&copy; Since 2013 freee K.K.
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
    /// MeResponseUser
    /// </summary>
    [DataContract]
    public partial class MeResponseUser :  IEquatable<MeResponseUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeResponseUser" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MeResponseUser() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MeResponseUser" /> class.
        /// </summary>
        /// <param name="companies">companies.</param>
        /// <param name="displayName">表示ユーザー名.</param>
        /// <param name="email">メールアドレス (required).</param>
        /// <param name="firstName">名.</param>
        /// <param name="firstNameKana">名（カナ）.</param>
        /// <param name="id">ユーザーID (required).</param>
        /// <param name="lastName">姓.</param>
        /// <param name="lastNameKana">姓（カナ）.</param>
        public MeResponseUser(List<MeResponseUserCompanies> companies = default(List<MeResponseUserCompanies>), string displayName = default(string), string email = default(string), string firstName = default(string), string firstNameKana = default(string), int id = default(int), string lastName = default(string), string lastNameKana = default(string))
        {
            // to ensure "email" is required (not null)
            this.Email = email ?? throw new ArgumentNullException("email is a required property for MeResponseUser and cannot be null");
            this.Id = id;
            this.Companies = companies;
            this.DisplayName = displayName;
            this.FirstName = firstName;
            this.FirstNameKana = firstNameKana;
            this.LastName = lastName;
            this.LastNameKana = lastNameKana;
        }
        
        /// <summary>
        /// Gets or Sets Companies
        /// </summary>
        [DataMember(Name="companies", EmitDefaultValue=false)]
        public List<MeResponseUserCompanies> Companies { get; set; }

        /// <summary>
        /// 表示ユーザー名
        /// </summary>
        /// <value>表示ユーザー名</value>
        [DataMember(Name="display_name", EmitDefaultValue=true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        /// <value>メールアドレス</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        /// <value>名</value>
        [DataMember(Name="first_name", EmitDefaultValue=true)]
        public string FirstName { get; set; }

        /// <summary>
        /// 名（カナ）
        /// </summary>
        /// <value>名（カナ）</value>
        [DataMember(Name="first_name_kana", EmitDefaultValue=true)]
        public string FirstNameKana { get; set; }

        /// <summary>
        /// ユーザーID
        /// </summary>
        /// <value>ユーザーID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        /// <value>姓</value>
        [DataMember(Name="last_name", EmitDefaultValue=true)]
        public string LastName { get; set; }

        /// <summary>
        /// 姓（カナ）
        /// </summary>
        /// <value>姓（カナ）</value>
        [DataMember(Name="last_name_kana", EmitDefaultValue=true)]
        public string LastNameKana { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MeResponseUser {\n");
            sb.Append("  Companies: ").Append(Companies).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  FirstNameKana: ").Append(FirstNameKana).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LastNameKana: ").Append(LastNameKana).Append("\n");
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
            return this.Equals(input as MeResponseUser);
        }

        /// <summary>
        /// Returns true if MeResponseUser instances are equal
        /// </summary>
        /// <param name="input">Instance of MeResponseUser to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MeResponseUser input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Companies == input.Companies ||
                    this.Companies != null &&
                    input.Companies != null &&
                    this.Companies.SequenceEqual(input.Companies)
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.FirstNameKana == input.FirstNameKana ||
                    (this.FirstNameKana != null &&
                    this.FirstNameKana.Equals(input.FirstNameKana))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.LastNameKana == input.LastNameKana ||
                    (this.LastNameKana != null &&
                    this.LastNameKana.Equals(input.LastNameKana))
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
                if (this.Companies != null)
                    hashCode = hashCode * 59 + this.Companies.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.FirstNameKana != null)
                    hashCode = hashCode * 59 + this.FirstNameKana.GetHashCode();
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.LastNameKana != null)
                    hashCode = hashCode * 59 + this.LastNameKana.GetHashCode();
                return hashCode;
            }
        }

    }

}