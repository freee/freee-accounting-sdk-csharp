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
    /// TrialPlResponseTrialPlBalances
    /// </summary>
    [DataContract]
    public partial class TrialPlResponseTrialPlBalances :  IEquatable<TrialPlResponseTrialPlBalances>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialPlResponseTrialPlBalances" /> class.
        /// </summary>
        /// <param name="accountItemId">勘定科目ID(勘定科目の時のみ含まれる).</param>
        /// <param name="accountItemName">勘定科目名(勘定科目の時のみ含まれる).</param>
        /// <param name="partners">breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="items">breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="sections">breakdown_display_type:section, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="accountCategoryId">勘定科目カテゴリーID(勘定科目カテゴリーの時のみ含まれる).</param>
        /// <param name="accountCategoryName">勘定科目カテゴリー名(勘定科目カテゴリーの時のみ含まれる).</param>
        /// <param name="totalLine">合計行(勘定科目カテゴリー名の時のみ含まれる).</param>
        /// <param name="hierarchyLevel">階層レベル.</param>
        /// <param name="parentAccountCategoryId">上位科目カテゴリーID(上層が存在する場合含まれる).</param>
        /// <param name="parentAccountCategoryName">上位勘定科目カテゴリー名(上層が存在する場合含まれる).</param>
        /// <param name="openingBalance">期首残高.</param>
        /// <param name="debitAmount">借方金額.</param>
        /// <param name="creditAmount">貸方金額.</param>
        /// <param name="closingBalance">期末残高.</param>
        /// <param name="compositionRatio">構成比.</param>
        public TrialPlResponseTrialPlBalances(int accountItemId = default(int), string accountItemName = default(string), List<TrialBsResponseTrialBsPartners> partners = default(List<TrialBsResponseTrialBsPartners>), List<TrialBsResponseTrialBsItems> items = default(List<TrialBsResponseTrialBsItems>), List<TrialPlResponseTrialPlSections> sections = default(List<TrialPlResponseTrialPlSections>), int accountCategoryId = default(int), string accountCategoryName = default(string), bool totalLine = default(bool), int hierarchyLevel = default(int), int parentAccountCategoryId = default(int), string parentAccountCategoryName = default(string), int openingBalance = default(int), int debitAmount = default(int), int creditAmount = default(int), int closingBalance = default(int), decimal compositionRatio = default(decimal))
        {
            this.AccountItemId = accountItemId;
            this.AccountItemName = accountItemName;
            this.Partners = partners;
            this.Items = items;
            this.Sections = sections;
            this.AccountCategoryId = accountCategoryId;
            this.AccountCategoryName = accountCategoryName;
            this.TotalLine = totalLine;
            this.HierarchyLevel = hierarchyLevel;
            this.ParentAccountCategoryId = parentAccountCategoryId;
            this.ParentAccountCategoryName = parentAccountCategoryName;
            this.OpeningBalance = openingBalance;
            this.DebitAmount = debitAmount;
            this.CreditAmount = creditAmount;
            this.ClosingBalance = closingBalance;
            this.CompositionRatio = compositionRatio;
        }
        
        /// <summary>
        /// 勘定科目ID(勘定科目の時のみ含まれる)
        /// </summary>
        /// <value>勘定科目ID(勘定科目の時のみ含まれる)</value>
        [DataMember(Name="account_item_id", EmitDefaultValue=false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 勘定科目名(勘定科目の時のみ含まれる)
        /// </summary>
        /// <value>勘定科目名(勘定科目の時のみ含まれる)</value>
        [DataMember(Name="account_item_name", EmitDefaultValue=false)]
        public string AccountItemName { get; set; }

        /// <summary>
        /// breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name="partners", EmitDefaultValue=false)]
        public List<TrialBsResponseTrialBsPartners> Partners { get; set; }

        /// <summary>
        /// breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<TrialBsResponseTrialBsItems> Items { get; set; }

        /// <summary>
        /// breakdown_display_type:section, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:section, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name="sections", EmitDefaultValue=false)]
        public List<TrialPlResponseTrialPlSections> Sections { get; set; }

        /// <summary>
        /// 勘定科目カテゴリーID(勘定科目カテゴリーの時のみ含まれる)
        /// </summary>
        /// <value>勘定科目カテゴリーID(勘定科目カテゴリーの時のみ含まれる)</value>
        [DataMember(Name="account_category_id", EmitDefaultValue=false)]
        public int AccountCategoryId { get; set; }

        /// <summary>
        /// 勘定科目カテゴリー名(勘定科目カテゴリーの時のみ含まれる)
        /// </summary>
        /// <value>勘定科目カテゴリー名(勘定科目カテゴリーの時のみ含まれる)</value>
        [DataMember(Name="account_category_name", EmitDefaultValue=false)]
        public string AccountCategoryName { get; set; }

        /// <summary>
        /// 合計行(勘定科目カテゴリー名の時のみ含まれる)
        /// </summary>
        /// <value>合計行(勘定科目カテゴリー名の時のみ含まれる)</value>
        [DataMember(Name="total_line", EmitDefaultValue=false)]
        public bool TotalLine { get; set; }

        /// <summary>
        /// 階層レベル
        /// </summary>
        /// <value>階層レベル</value>
        [DataMember(Name="hierarchy_level", EmitDefaultValue=false)]
        public int HierarchyLevel { get; set; }

        /// <summary>
        /// 上位科目カテゴリーID(上層が存在する場合含まれる)
        /// </summary>
        /// <value>上位科目カテゴリーID(上層が存在する場合含まれる)</value>
        [DataMember(Name="parent_account_category_id", EmitDefaultValue=false)]
        public int ParentAccountCategoryId { get; set; }

        /// <summary>
        /// 上位勘定科目カテゴリー名(上層が存在する場合含まれる)
        /// </summary>
        /// <value>上位勘定科目カテゴリー名(上層が存在する場合含まれる)</value>
        [DataMember(Name="parent_account_category_name", EmitDefaultValue=false)]
        public string ParentAccountCategoryName { get; set; }

        /// <summary>
        /// 期首残高
        /// </summary>
        /// <value>期首残高</value>
        [DataMember(Name="opening_balance", EmitDefaultValue=false)]
        public int OpeningBalance { get; set; }

        /// <summary>
        /// 借方金額
        /// </summary>
        /// <value>借方金額</value>
        [DataMember(Name="debit_amount", EmitDefaultValue=false)]
        public int DebitAmount { get; set; }

        /// <summary>
        /// 貸方金額
        /// </summary>
        /// <value>貸方金額</value>
        [DataMember(Name="credit_amount", EmitDefaultValue=false)]
        public int CreditAmount { get; set; }

        /// <summary>
        /// 期末残高
        /// </summary>
        /// <value>期末残高</value>
        [DataMember(Name="closing_balance", EmitDefaultValue=false)]
        public int ClosingBalance { get; set; }

        /// <summary>
        /// 構成比
        /// </summary>
        /// <value>構成比</value>
        [DataMember(Name="composition_ratio", EmitDefaultValue=false)]
        public decimal CompositionRatio { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrialPlResponseTrialPlBalances {\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  AccountItemName: ").Append(AccountItemName).Append("\n");
            sb.Append("  Partners: ").Append(Partners).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  Sections: ").Append(Sections).Append("\n");
            sb.Append("  AccountCategoryId: ").Append(AccountCategoryId).Append("\n");
            sb.Append("  AccountCategoryName: ").Append(AccountCategoryName).Append("\n");
            sb.Append("  TotalLine: ").Append(TotalLine).Append("\n");
            sb.Append("  HierarchyLevel: ").Append(HierarchyLevel).Append("\n");
            sb.Append("  ParentAccountCategoryId: ").Append(ParentAccountCategoryId).Append("\n");
            sb.Append("  ParentAccountCategoryName: ").Append(ParentAccountCategoryName).Append("\n");
            sb.Append("  OpeningBalance: ").Append(OpeningBalance).Append("\n");
            sb.Append("  DebitAmount: ").Append(DebitAmount).Append("\n");
            sb.Append("  CreditAmount: ").Append(CreditAmount).Append("\n");
            sb.Append("  ClosingBalance: ").Append(ClosingBalance).Append("\n");
            sb.Append("  CompositionRatio: ").Append(CompositionRatio).Append("\n");
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
            return this.Equals(input as TrialPlResponseTrialPlBalances);
        }

        /// <summary>
        /// Returns true if TrialPlResponseTrialPlBalances instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialPlResponseTrialPlBalances to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialPlResponseTrialPlBalances input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.AccountItemName == input.AccountItemName ||
                    (this.AccountItemName != null &&
                    this.AccountItemName.Equals(input.AccountItemName))
                ) && 
                (
                    this.Partners == input.Partners ||
                    this.Partners != null &&
                    input.Partners != null &&
                    this.Partners.SequenceEqual(input.Partners)
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    input.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && 
                (
                    this.Sections == input.Sections ||
                    this.Sections != null &&
                    input.Sections != null &&
                    this.Sections.SequenceEqual(input.Sections)
                ) && 
                (
                    this.AccountCategoryId == input.AccountCategoryId ||
                    this.AccountCategoryId.Equals(input.AccountCategoryId)
                ) && 
                (
                    this.AccountCategoryName == input.AccountCategoryName ||
                    (this.AccountCategoryName != null &&
                    this.AccountCategoryName.Equals(input.AccountCategoryName))
                ) && 
                (
                    this.TotalLine == input.TotalLine ||
                    this.TotalLine.Equals(input.TotalLine)
                ) && 
                (
                    this.HierarchyLevel == input.HierarchyLevel ||
                    this.HierarchyLevel.Equals(input.HierarchyLevel)
                ) && 
                (
                    this.ParentAccountCategoryId == input.ParentAccountCategoryId ||
                    this.ParentAccountCategoryId.Equals(input.ParentAccountCategoryId)
                ) && 
                (
                    this.ParentAccountCategoryName == input.ParentAccountCategoryName ||
                    (this.ParentAccountCategoryName != null &&
                    this.ParentAccountCategoryName.Equals(input.ParentAccountCategoryName))
                ) && 
                (
                    this.OpeningBalance == input.OpeningBalance ||
                    this.OpeningBalance.Equals(input.OpeningBalance)
                ) && 
                (
                    this.DebitAmount == input.DebitAmount ||
                    this.DebitAmount.Equals(input.DebitAmount)
                ) && 
                (
                    this.CreditAmount == input.CreditAmount ||
                    this.CreditAmount.Equals(input.CreditAmount)
                ) && 
                (
                    this.ClosingBalance == input.ClosingBalance ||
                    this.ClosingBalance.Equals(input.ClosingBalance)
                ) && 
                (
                    this.CompositionRatio == input.CompositionRatio ||
                    this.CompositionRatio.Equals(input.CompositionRatio)
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
                if (this.AccountItemName != null)
                    hashCode = hashCode * 59 + this.AccountItemName.GetHashCode();
                if (this.Partners != null)
                    hashCode = hashCode * 59 + this.Partners.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
                if (this.Sections != null)
                    hashCode = hashCode * 59 + this.Sections.GetHashCode();
                hashCode = hashCode * 59 + this.AccountCategoryId.GetHashCode();
                if (this.AccountCategoryName != null)
                    hashCode = hashCode * 59 + this.AccountCategoryName.GetHashCode();
                hashCode = hashCode * 59 + this.TotalLine.GetHashCode();
                hashCode = hashCode * 59 + this.HierarchyLevel.GetHashCode();
                hashCode = hashCode * 59 + this.ParentAccountCategoryId.GetHashCode();
                if (this.ParentAccountCategoryName != null)
                    hashCode = hashCode * 59 + this.ParentAccountCategoryName.GetHashCode();
                hashCode = hashCode * 59 + this.OpeningBalance.GetHashCode();
                hashCode = hashCode * 59 + this.DebitAmount.GetHashCode();
                hashCode = hashCode * 59 + this.CreditAmount.GetHashCode();
                hashCode = hashCode * 59 + this.ClosingBalance.GetHashCode();
                hashCode = hashCode * 59 + this.CompositionRatio.GetHashCode();
                return hashCode;
            }
        }

    }

}
