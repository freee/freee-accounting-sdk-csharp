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
    /// Receipt
    /// </summary>
    [DataContract]
    public partial class Receipt :  IEquatable<Receipt>
    {
        /// <summary>
        /// ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Unconfirmed for value: unconfirmed
            /// </summary>
            [EnumMember(Value = "unconfirmed")]
            Unconfirmed = 1,

            /// <summary>
            /// Enum Confirmed for value: confirmed
            /// </summary>
            [EnumMember(Value = "confirmed")]
            Confirmed = 2,

            /// <summary>
            /// Enum Deleted for value: deleted
            /// </summary>
            [EnumMember(Value = "deleted")]
            Deleted = 3,

            /// <summary>
            /// Enum Ignored for value: ignored
            /// </summary>
            [EnumMember(Value = "ignored")]
            Ignored = 4

        }

        /// <summary>
        /// ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)
        /// </summary>
        /// <value>ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視)</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// アップロード元種別
        /// </summary>
        /// <value>アップロード元種別</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OriginEnum
        {
            /// <summary>
            /// Enum Unknown for value: unknown
            /// </summary>
            [EnumMember(Value = "unknown")]
            Unknown = 1,

            /// <summary>
            /// Enum Web for value: web
            /// </summary>
            [EnumMember(Value = "web")]
            Web = 2,

            /// <summary>
            /// Enum Mobilecamera for value: mobile_camera
            /// </summary>
            [EnumMember(Value = "mobile_camera")]
            Mobilecamera = 3,

            /// <summary>
            /// Enum Mobilealbum for value: mobile_album
            /// </summary>
            [EnumMember(Value = "mobile_album")]
            Mobilealbum = 4,

            /// <summary>
            /// Enum Scansnap for value: scansnap
            /// </summary>
            [EnumMember(Value = "scansnap")]
            Scansnap = 5,

            /// <summary>
            /// Enum Scannable for value: scannable
            /// </summary>
            [EnumMember(Value = "scannable")]
            Scannable = 6,

            /// <summary>
            /// Enum Dropbox for value: dropbox
            /// </summary>
            [EnumMember(Value = "dropbox")]
            Dropbox = 7,

            /// <summary>
            /// Enum Mail for value: mail
            /// </summary>
            [EnumMember(Value = "mail")]
            Mail = 8,

            /// <summary>
            /// Enum Safetycontactfile for value: safety_contact_file
            /// </summary>
            [EnumMember(Value = "safety_contact_file")]
            Safetycontactfile = 9,

            /// <summary>
            /// Enum Publicapi for value: public_api
            /// </summary>
            [EnumMember(Value = "public_api")]
            Publicapi = 10

        }

        /// <summary>
        /// アップロード元種別
        /// </summary>
        /// <value>アップロード元種別</value>
        [DataMember(Name="origin", EmitDefaultValue=false)]
        public OriginEnum Origin { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Receipt() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Receipt" /> class.
        /// </summary>
        /// <param name="id">証憑ID (required).</param>
        /// <param name="status">ステータス(unconfirmed:確認待ち、confirmed:確認済み、deleted:削除済み、ignored:無視) (required).</param>
        /// <param name="description">メモ.</param>
        /// <param name="mimeType">MIMEタイプ (required).</param>
        /// <param name="issueDate">発生日.</param>
        /// <param name="origin">アップロード元種別 (required).</param>
        /// <param name="createdAt">作成日時（ISO8601形式） (required).</param>
        /// <param name="fileSrc">ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。） (required).</param>
        /// <param name="user">user (required).</param>
        public Receipt(int id = default(int), StatusEnum status = default(StatusEnum), string description = default(string), string mimeType = default(string), string issueDate = default(string), OriginEnum origin = default(OriginEnum), string createdAt = default(string), string fileSrc = default(string), ReceiptUser user = default(ReceiptUser))
        {
            this.Id = id;
            this.Status = status;
            // to ensure "mimeType" is required (not null)
            this.MimeType = mimeType ?? throw new ArgumentNullException("mimeType is a required property for Receipt and cannot be null");;
            this.Origin = origin;
            // to ensure "createdAt" is required (not null)
            this.CreatedAt = createdAt ?? throw new ArgumentNullException("createdAt is a required property for Receipt and cannot be null");;
            // to ensure "fileSrc" is required (not null)
            this.FileSrc = fileSrc ?? throw new ArgumentNullException("fileSrc is a required property for Receipt and cannot be null");;
            // to ensure "user" is required (not null)
            this.User = user ?? throw new ArgumentNullException("user is a required property for Receipt and cannot be null");;
            this.Description = description;
            this.IssueDate = issueDate;
        }
        
        /// <summary>
        /// 証憑ID
        /// </summary>
        /// <value>証憑ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        /// <value>メモ</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// MIMEタイプ
        /// </summary>
        /// <value>MIMEタイプ</value>
        [DataMember(Name="mime_type", EmitDefaultValue=false)]
        public string MimeType { get; set; }

        /// <summary>
        /// 発生日
        /// </summary>
        /// <value>発生日</value>
        [DataMember(Name="issue_date", EmitDefaultValue=false)]
        public string IssueDate { get; set; }

        /// <summary>
        /// 作成日時（ISO8601形式）
        /// </summary>
        /// <value>作成日時（ISO8601形式）</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。）
        /// </summary>
        /// <value>ファイルのダウンロードURL（freeeにログインした状態でのみ閲覧可能です。）</value>
        [DataMember(Name="file_src", EmitDefaultValue=false)]
        public string FileSrc { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="user", EmitDefaultValue=false)]
        public ReceiptUser User { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Receipt {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  IssueDate: ").Append(IssueDate).Append("\n");
            sb.Append("  Origin: ").Append(Origin).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  FileSrc: ").Append(FileSrc).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
            return this.Equals(input as Receipt);
        }

        /// <summary>
        /// Returns true if Receipt instances are equal
        /// </summary>
        /// <param name="input">Instance of Receipt to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Receipt input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.MimeType == input.MimeType ||
                    (this.MimeType != null &&
                    this.MimeType.Equals(input.MimeType))
                ) && 
                (
                    this.IssueDate == input.IssueDate ||
                    (this.IssueDate != null &&
                    this.IssueDate.Equals(input.IssueDate))
                ) && 
                (
                    this.Origin == input.Origin ||
                    this.Origin.Equals(input.Origin)
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.FileSrc == input.FileSrc ||
                    (this.FileSrc != null &&
                    this.FileSrc.Equals(input.FileSrc))
                ) && 
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
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
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.MimeType != null)
                    hashCode = hashCode * 59 + this.MimeType.GetHashCode();
                if (this.IssueDate != null)
                    hashCode = hashCode * 59 + this.IssueDate.GetHashCode();
                hashCode = hashCode * 59 + this.Origin.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.FileSrc != null)
                    hashCode = hashCode * 59 + this.FileSrc.GetHashCode();
                if (this.User != null)
                    hashCode = hashCode * 59 + this.User.GetHashCode();
                return hashCode;
            }
        }

    }

}
