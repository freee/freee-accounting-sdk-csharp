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
    /// UsersCapabilitiesResponse
    /// </summary>
    [DataContract]
    public partial class UsersCapabilitiesResponse :  IEquatable<UsersCapabilitiesResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersCapabilitiesResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UsersCapabilitiesResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersCapabilitiesResponse" /> class.
        /// </summary>
        /// <param name="walletTxns">walletTxns (required).</param>
        /// <param name="deals">deals (required).</param>
        /// <param name="transfers">transfers (required).</param>
        /// <param name="docs">docs (required).</param>
        /// <param name="docPostings">docPostings (required).</param>
        /// <param name="receipts">receipts (required).</param>
        /// <param name="receiptStreamEditor">receiptStreamEditor (required).</param>
        /// <param name="expenseApplications">expenseApplications (required).</param>
        /// <param name="spreadsheets">spreadsheets (required).</param>
        /// <param name="paymentRequests">paymentRequests (required).</param>
        /// <param name="requestForms">requestForms (required).</param>
        /// <param name="approvalRequests">approvalRequests (required).</param>
        /// <param name="reports">reports (required).</param>
        /// <param name="reportsIncomeExpense">reportsIncomeExpense (required).</param>
        /// <param name="reportsReceivables">reportsReceivables (required).</param>
        /// <param name="reportsPayables">reportsPayables (required).</param>
        /// <param name="reportsCashBalance">reportsCashBalance (required).</param>
        /// <param name="reportsCrosstabs">reportsCrosstabs (required).</param>
        /// <param name="reportsGeneralLedgers">reportsGeneralLedgers (required).</param>
        /// <param name="reportsPl">reportsPl (required).</param>
        /// <param name="reportsBs">reportsBs (required).</param>
        /// <param name="reportsJournals">reportsJournals (required).</param>
        /// <param name="reportsManagementsPlanning">reportsManagementsPlanning (required).</param>
        /// <param name="reportsManagementsNavigation">reportsManagementsNavigation (required).</param>
        /// <param name="manualJournals">manualJournals (required).</param>
        /// <param name="fixedAssets">fixedAssets (required).</param>
        /// <param name="inventoryRefreshes">inventoryRefreshes (required).</param>
        /// <param name="bizAllocations">bizAllocations (required).</param>
        /// <param name="paymentRecords">paymentRecords (required).</param>
        /// <param name="annualReports">annualReports (required).</param>
        /// <param name="taxReports">taxReports (required).</param>
        /// <param name="consumptionEntries">consumptionEntries (required).</param>
        /// <param name="taxReturn">taxReturn (required).</param>
        /// <param name="accountItemStatements">accountItemStatements (required).</param>
        /// <param name="monthEnd">monthEnd (required).</param>
        /// <param name="yearEnd">yearEnd (required).</param>
        /// <param name="walletables">walletables (required).</param>
        /// <param name="companies">companies (required).</param>
        /// <param name="invitations">invitations (required).</param>
        /// <param name="signInLogs">signInLogs (required).</param>
        /// <param name="backups">backups (required).</param>
        /// <param name="openingBalances">openingBalances (required).</param>
        /// <param name="systemConversion">systemConversion (required).</param>
        /// <param name="resets">resets (required).</param>
        /// <param name="partners">partners (required).</param>
        /// <param name="items">items (required).</param>
        /// <param name="sections">sections (required).</param>
        /// <param name="tags">tags (required).</param>
        /// <param name="accountItems">accountItems (required).</param>
        /// <param name="taxes">taxes (required).</param>
        /// <param name="userMatchers">userMatchers (required).</param>
        /// <param name="dealTemplates">dealTemplates (required).</param>
        /// <param name="manualJournalTemplates">manualJournalTemplates (required).</param>
        /// <param name="costAllocations">costAllocations (required).</param>
        /// <param name="approvalFlowRoutes">approvalFlowRoutes (required).</param>
        /// <param name="expenseApplicationTemplates">expenseApplicationTemplates (required).</param>
        /// <param name="workflows">workflows (required).</param>
        /// <param name="oauthApplications">oauthApplications (required).</param>
        /// <param name="oauthAuthorizations">oauthAuthorizations (required).</param>
        /// <param name="bankAccountantStaffUsers">bankAccountantStaffUsers (required).</param>
        public UsersCapabilitiesResponse(UsersCapability walletTxns = default(UsersCapability), UsersCapability deals = default(UsersCapability), UsersCapability transfers = default(UsersCapability), UsersCapability docs = default(UsersCapability), UsersCapability docPostings = default(UsersCapability), UsersCapability receipts = default(UsersCapability), UsersCapability receiptStreamEditor = default(UsersCapability), UsersCapability expenseApplications = default(UsersCapability), UsersCapability spreadsheets = default(UsersCapability), UsersCapability paymentRequests = default(UsersCapability), UsersCapability requestForms = default(UsersCapability), UsersCapability approvalRequests = default(UsersCapability), UsersCapability reports = default(UsersCapability), UsersCapability reportsIncomeExpense = default(UsersCapability), UsersCapability reportsReceivables = default(UsersCapability), UsersCapability reportsPayables = default(UsersCapability), UsersCapability reportsCashBalance = default(UsersCapability), UsersCapability reportsCrosstabs = default(UsersCapability), UsersCapability reportsGeneralLedgers = default(UsersCapability), UsersCapability reportsPl = default(UsersCapability), UsersCapability reportsBs = default(UsersCapability), UsersCapability reportsJournals = default(UsersCapability), UsersCapability reportsManagementsPlanning = default(UsersCapability), UsersCapability reportsManagementsNavigation = default(UsersCapability), UsersCapability manualJournals = default(UsersCapability), UsersCapability fixedAssets = default(UsersCapability), UsersCapability inventoryRefreshes = default(UsersCapability), UsersCapability bizAllocations = default(UsersCapability), UsersCapability paymentRecords = default(UsersCapability), UsersCapability annualReports = default(UsersCapability), UsersCapability taxReports = default(UsersCapability), UsersCapability consumptionEntries = default(UsersCapability), UsersCapability taxReturn = default(UsersCapability), UsersCapability accountItemStatements = default(UsersCapability), UsersCapability monthEnd = default(UsersCapability), UsersCapability yearEnd = default(UsersCapability), UsersCapability walletables = default(UsersCapability), UsersCapability companies = default(UsersCapability), UsersCapability invitations = default(UsersCapability), UsersCapability signInLogs = default(UsersCapability), UsersCapability backups = default(UsersCapability), UsersCapability openingBalances = default(UsersCapability), UsersCapability systemConversion = default(UsersCapability), UsersCapability resets = default(UsersCapability), UsersCapability partners = default(UsersCapability), UsersCapability items = default(UsersCapability), UsersCapability sections = default(UsersCapability), UsersCapability tags = default(UsersCapability), UsersCapability accountItems = default(UsersCapability), UsersCapability taxes = default(UsersCapability), UsersCapability userMatchers = default(UsersCapability), UsersCapability dealTemplates = default(UsersCapability), UsersCapability manualJournalTemplates = default(UsersCapability), UsersCapability costAllocations = default(UsersCapability), UsersCapability approvalFlowRoutes = default(UsersCapability), UsersCapability expenseApplicationTemplates = default(UsersCapability), UsersCapability workflows = default(UsersCapability), UsersCapability oauthApplications = default(UsersCapability), UsersCapability oauthAuthorizations = default(UsersCapability), UsersCapability bankAccountantStaffUsers = default(UsersCapability))
        {
            // to ensure "walletTxns" is required (not null)
            this.WalletTxns = walletTxns ?? throw new ArgumentNullException("walletTxns is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "deals" is required (not null)
            this.Deals = deals ?? throw new ArgumentNullException("deals is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "transfers" is required (not null)
            this.Transfers = transfers ?? throw new ArgumentNullException("transfers is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "docs" is required (not null)
            this.Docs = docs ?? throw new ArgumentNullException("docs is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "docPostings" is required (not null)
            this.DocPostings = docPostings ?? throw new ArgumentNullException("docPostings is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "receipts" is required (not null)
            this.Receipts = receipts ?? throw new ArgumentNullException("receipts is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "receiptStreamEditor" is required (not null)
            this.ReceiptStreamEditor = receiptStreamEditor ?? throw new ArgumentNullException("receiptStreamEditor is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "expenseApplications" is required (not null)
            this.ExpenseApplications = expenseApplications ?? throw new ArgumentNullException("expenseApplications is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "spreadsheets" is required (not null)
            this.Spreadsheets = spreadsheets ?? throw new ArgumentNullException("spreadsheets is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "paymentRequests" is required (not null)
            this.PaymentRequests = paymentRequests ?? throw new ArgumentNullException("paymentRequests is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "requestForms" is required (not null)
            this.RequestForms = requestForms ?? throw new ArgumentNullException("requestForms is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "approvalRequests" is required (not null)
            this.ApprovalRequests = approvalRequests ?? throw new ArgumentNullException("approvalRequests is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reports" is required (not null)
            this.Reports = reports ?? throw new ArgumentNullException("reports is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsIncomeExpense" is required (not null)
            this.ReportsIncomeExpense = reportsIncomeExpense ?? throw new ArgumentNullException("reportsIncomeExpense is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsReceivables" is required (not null)
            this.ReportsReceivables = reportsReceivables ?? throw new ArgumentNullException("reportsReceivables is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsPayables" is required (not null)
            this.ReportsPayables = reportsPayables ?? throw new ArgumentNullException("reportsPayables is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsCashBalance" is required (not null)
            this.ReportsCashBalance = reportsCashBalance ?? throw new ArgumentNullException("reportsCashBalance is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsCrosstabs" is required (not null)
            this.ReportsCrosstabs = reportsCrosstabs ?? throw new ArgumentNullException("reportsCrosstabs is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsGeneralLedgers" is required (not null)
            this.ReportsGeneralLedgers = reportsGeneralLedgers ?? throw new ArgumentNullException("reportsGeneralLedgers is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsPl" is required (not null)
            this.ReportsPl = reportsPl ?? throw new ArgumentNullException("reportsPl is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsBs" is required (not null)
            this.ReportsBs = reportsBs ?? throw new ArgumentNullException("reportsBs is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsJournals" is required (not null)
            this.ReportsJournals = reportsJournals ?? throw new ArgumentNullException("reportsJournals is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsManagementsPlanning" is required (not null)
            this.ReportsManagementsPlanning = reportsManagementsPlanning ?? throw new ArgumentNullException("reportsManagementsPlanning is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "reportsManagementsNavigation" is required (not null)
            this.ReportsManagementsNavigation = reportsManagementsNavigation ?? throw new ArgumentNullException("reportsManagementsNavigation is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "manualJournals" is required (not null)
            this.ManualJournals = manualJournals ?? throw new ArgumentNullException("manualJournals is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "fixedAssets" is required (not null)
            this.FixedAssets = fixedAssets ?? throw new ArgumentNullException("fixedAssets is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "inventoryRefreshes" is required (not null)
            this.InventoryRefreshes = inventoryRefreshes ?? throw new ArgumentNullException("inventoryRefreshes is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "bizAllocations" is required (not null)
            this.BizAllocations = bizAllocations ?? throw new ArgumentNullException("bizAllocations is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "paymentRecords" is required (not null)
            this.PaymentRecords = paymentRecords ?? throw new ArgumentNullException("paymentRecords is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "annualReports" is required (not null)
            this.AnnualReports = annualReports ?? throw new ArgumentNullException("annualReports is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "taxReports" is required (not null)
            this.TaxReports = taxReports ?? throw new ArgumentNullException("taxReports is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "consumptionEntries" is required (not null)
            this.ConsumptionEntries = consumptionEntries ?? throw new ArgumentNullException("consumptionEntries is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "taxReturn" is required (not null)
            this.TaxReturn = taxReturn ?? throw new ArgumentNullException("taxReturn is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "accountItemStatements" is required (not null)
            this.AccountItemStatements = accountItemStatements ?? throw new ArgumentNullException("accountItemStatements is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "monthEnd" is required (not null)
            this.MonthEnd = monthEnd ?? throw new ArgumentNullException("monthEnd is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "yearEnd" is required (not null)
            this.YearEnd = yearEnd ?? throw new ArgumentNullException("yearEnd is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "walletables" is required (not null)
            this.Walletables = walletables ?? throw new ArgumentNullException("walletables is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "companies" is required (not null)
            this.Companies = companies ?? throw new ArgumentNullException("companies is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "invitations" is required (not null)
            this.Invitations = invitations ?? throw new ArgumentNullException("invitations is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "signInLogs" is required (not null)
            this.SignInLogs = signInLogs ?? throw new ArgumentNullException("signInLogs is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "backups" is required (not null)
            this.Backups = backups ?? throw new ArgumentNullException("backups is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "openingBalances" is required (not null)
            this.OpeningBalances = openingBalances ?? throw new ArgumentNullException("openingBalances is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "systemConversion" is required (not null)
            this.SystemConversion = systemConversion ?? throw new ArgumentNullException("systemConversion is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "resets" is required (not null)
            this.Resets = resets ?? throw new ArgumentNullException("resets is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "partners" is required (not null)
            this.Partners = partners ?? throw new ArgumentNullException("partners is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "items" is required (not null)
            this.Items = items ?? throw new ArgumentNullException("items is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "sections" is required (not null)
            this.Sections = sections ?? throw new ArgumentNullException("sections is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "tags" is required (not null)
            this.Tags = tags ?? throw new ArgumentNullException("tags is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "accountItems" is required (not null)
            this.AccountItems = accountItems ?? throw new ArgumentNullException("accountItems is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "taxes" is required (not null)
            this.Taxes = taxes ?? throw new ArgumentNullException("taxes is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "userMatchers" is required (not null)
            this.UserMatchers = userMatchers ?? throw new ArgumentNullException("userMatchers is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "dealTemplates" is required (not null)
            this.DealTemplates = dealTemplates ?? throw new ArgumentNullException("dealTemplates is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "manualJournalTemplates" is required (not null)
            this.ManualJournalTemplates = manualJournalTemplates ?? throw new ArgumentNullException("manualJournalTemplates is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "costAllocations" is required (not null)
            this.CostAllocations = costAllocations ?? throw new ArgumentNullException("costAllocations is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "approvalFlowRoutes" is required (not null)
            this.ApprovalFlowRoutes = approvalFlowRoutes ?? throw new ArgumentNullException("approvalFlowRoutes is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "expenseApplicationTemplates" is required (not null)
            this.ExpenseApplicationTemplates = expenseApplicationTemplates ?? throw new ArgumentNullException("expenseApplicationTemplates is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "workflows" is required (not null)
            this.Workflows = workflows ?? throw new ArgumentNullException("workflows is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "oauthApplications" is required (not null)
            this.OauthApplications = oauthApplications ?? throw new ArgumentNullException("oauthApplications is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "oauthAuthorizations" is required (not null)
            this.OauthAuthorizations = oauthAuthorizations ?? throw new ArgumentNullException("oauthAuthorizations is a required property for UsersCapabilitiesResponse and cannot be null");;
            // to ensure "bankAccountantStaffUsers" is required (not null)
            this.BankAccountantStaffUsers = bankAccountantStaffUsers ?? throw new ArgumentNullException("bankAccountantStaffUsers is a required property for UsersCapabilitiesResponse and cannot be null");;
        }
        
        /// <summary>
        /// Gets or Sets WalletTxns
        /// </summary>
        [DataMember(Name="wallet_txns", EmitDefaultValue=false)]
        public UsersCapability WalletTxns { get; set; }

        /// <summary>
        /// Gets or Sets Deals
        /// </summary>
        [DataMember(Name="deals", EmitDefaultValue=false)]
        public UsersCapability Deals { get; set; }

        /// <summary>
        /// Gets or Sets Transfers
        /// </summary>
        [DataMember(Name="transfers", EmitDefaultValue=false)]
        public UsersCapability Transfers { get; set; }

        /// <summary>
        /// Gets or Sets Docs
        /// </summary>
        [DataMember(Name="docs", EmitDefaultValue=false)]
        public UsersCapability Docs { get; set; }

        /// <summary>
        /// Gets or Sets DocPostings
        /// </summary>
        [DataMember(Name="doc_postings", EmitDefaultValue=false)]
        public UsersCapability DocPostings { get; set; }

        /// <summary>
        /// Gets or Sets Receipts
        /// </summary>
        [DataMember(Name="receipts", EmitDefaultValue=false)]
        public UsersCapability Receipts { get; set; }

        /// <summary>
        /// Gets or Sets ReceiptStreamEditor
        /// </summary>
        [DataMember(Name="receipt_stream_editor", EmitDefaultValue=false)]
        public UsersCapability ReceiptStreamEditor { get; set; }

        /// <summary>
        /// Gets or Sets ExpenseApplications
        /// </summary>
        [DataMember(Name="expense_applications", EmitDefaultValue=false)]
        public UsersCapability ExpenseApplications { get; set; }

        /// <summary>
        /// Gets or Sets Spreadsheets
        /// </summary>
        [DataMember(Name="spreadsheets", EmitDefaultValue=false)]
        public UsersCapability Spreadsheets { get; set; }

        /// <summary>
        /// Gets or Sets PaymentRequests
        /// </summary>
        [DataMember(Name="payment_requests", EmitDefaultValue=false)]
        public UsersCapability PaymentRequests { get; set; }

        /// <summary>
        /// Gets or Sets RequestForms
        /// </summary>
        [DataMember(Name="request_forms", EmitDefaultValue=false)]
        public UsersCapability RequestForms { get; set; }

        /// <summary>
        /// Gets or Sets ApprovalRequests
        /// </summary>
        [DataMember(Name="approval_requests", EmitDefaultValue=false)]
        public UsersCapability ApprovalRequests { get; set; }

        /// <summary>
        /// Gets or Sets Reports
        /// </summary>
        [DataMember(Name="reports", EmitDefaultValue=false)]
        public UsersCapability Reports { get; set; }

        /// <summary>
        /// Gets or Sets ReportsIncomeExpense
        /// </summary>
        [DataMember(Name="reports_income_expense", EmitDefaultValue=false)]
        public UsersCapability ReportsIncomeExpense { get; set; }

        /// <summary>
        /// Gets or Sets ReportsReceivables
        /// </summary>
        [DataMember(Name="reports_receivables", EmitDefaultValue=false)]
        public UsersCapability ReportsReceivables { get; set; }

        /// <summary>
        /// Gets or Sets ReportsPayables
        /// </summary>
        [DataMember(Name="reports_payables", EmitDefaultValue=false)]
        public UsersCapability ReportsPayables { get; set; }

        /// <summary>
        /// Gets or Sets ReportsCashBalance
        /// </summary>
        [DataMember(Name="reports_cash_balance", EmitDefaultValue=false)]
        public UsersCapability ReportsCashBalance { get; set; }

        /// <summary>
        /// Gets or Sets ReportsCrosstabs
        /// </summary>
        [DataMember(Name="reports_crosstabs", EmitDefaultValue=false)]
        public UsersCapability ReportsCrosstabs { get; set; }

        /// <summary>
        /// Gets or Sets ReportsGeneralLedgers
        /// </summary>
        [DataMember(Name="reports_general_ledgers", EmitDefaultValue=false)]
        public UsersCapability ReportsGeneralLedgers { get; set; }

        /// <summary>
        /// Gets or Sets ReportsPl
        /// </summary>
        [DataMember(Name="reports_pl", EmitDefaultValue=false)]
        public UsersCapability ReportsPl { get; set; }

        /// <summary>
        /// Gets or Sets ReportsBs
        /// </summary>
        [DataMember(Name="reports_bs", EmitDefaultValue=false)]
        public UsersCapability ReportsBs { get; set; }

        /// <summary>
        /// Gets or Sets ReportsJournals
        /// </summary>
        [DataMember(Name="reports_journals", EmitDefaultValue=false)]
        public UsersCapability ReportsJournals { get; set; }

        /// <summary>
        /// Gets or Sets ReportsManagementsPlanning
        /// </summary>
        [DataMember(Name="reports_managements_planning", EmitDefaultValue=false)]
        public UsersCapability ReportsManagementsPlanning { get; set; }

        /// <summary>
        /// Gets or Sets ReportsManagementsNavigation
        /// </summary>
        [DataMember(Name="reports_managements_navigation", EmitDefaultValue=false)]
        public UsersCapability ReportsManagementsNavigation { get; set; }

        /// <summary>
        /// Gets or Sets ManualJournals
        /// </summary>
        [DataMember(Name="manual_journals", EmitDefaultValue=false)]
        public UsersCapability ManualJournals { get; set; }

        /// <summary>
        /// Gets or Sets FixedAssets
        /// </summary>
        [DataMember(Name="fixed_assets", EmitDefaultValue=false)]
        public UsersCapability FixedAssets { get; set; }

        /// <summary>
        /// Gets or Sets InventoryRefreshes
        /// </summary>
        [DataMember(Name="inventory_refreshes", EmitDefaultValue=false)]
        public UsersCapability InventoryRefreshes { get; set; }

        /// <summary>
        /// Gets or Sets BizAllocations
        /// </summary>
        [DataMember(Name="biz_allocations", EmitDefaultValue=false)]
        public UsersCapability BizAllocations { get; set; }

        /// <summary>
        /// Gets or Sets PaymentRecords
        /// </summary>
        [DataMember(Name="payment_records", EmitDefaultValue=false)]
        public UsersCapability PaymentRecords { get; set; }

        /// <summary>
        /// Gets or Sets AnnualReports
        /// </summary>
        [DataMember(Name="annual_reports", EmitDefaultValue=false)]
        public UsersCapability AnnualReports { get; set; }

        /// <summary>
        /// Gets or Sets TaxReports
        /// </summary>
        [DataMember(Name="tax_reports", EmitDefaultValue=false)]
        public UsersCapability TaxReports { get; set; }

        /// <summary>
        /// Gets or Sets ConsumptionEntries
        /// </summary>
        [DataMember(Name="consumption_entries", EmitDefaultValue=false)]
        public UsersCapability ConsumptionEntries { get; set; }

        /// <summary>
        /// Gets or Sets TaxReturn
        /// </summary>
        [DataMember(Name="tax_return", EmitDefaultValue=false)]
        public UsersCapability TaxReturn { get; set; }

        /// <summary>
        /// Gets or Sets AccountItemStatements
        /// </summary>
        [DataMember(Name="account_item_statements", EmitDefaultValue=false)]
        public UsersCapability AccountItemStatements { get; set; }

        /// <summary>
        /// Gets or Sets MonthEnd
        /// </summary>
        [DataMember(Name="month_end", EmitDefaultValue=false)]
        public UsersCapability MonthEnd { get; set; }

        /// <summary>
        /// Gets or Sets YearEnd
        /// </summary>
        [DataMember(Name="year_end", EmitDefaultValue=false)]
        public UsersCapability YearEnd { get; set; }

        /// <summary>
        /// Gets or Sets Walletables
        /// </summary>
        [DataMember(Name="walletables", EmitDefaultValue=false)]
        public UsersCapability Walletables { get; set; }

        /// <summary>
        /// Gets or Sets Companies
        /// </summary>
        [DataMember(Name="companies", EmitDefaultValue=false)]
        public UsersCapability Companies { get; set; }

        /// <summary>
        /// Gets or Sets Invitations
        /// </summary>
        [DataMember(Name="invitations", EmitDefaultValue=false)]
        public UsersCapability Invitations { get; set; }

        /// <summary>
        /// Gets or Sets SignInLogs
        /// </summary>
        [DataMember(Name="sign_in_logs", EmitDefaultValue=false)]
        public UsersCapability SignInLogs { get; set; }

        /// <summary>
        /// Gets or Sets Backups
        /// </summary>
        [DataMember(Name="backups", EmitDefaultValue=false)]
        public UsersCapability Backups { get; set; }

        /// <summary>
        /// Gets or Sets OpeningBalances
        /// </summary>
        [DataMember(Name="opening_balances", EmitDefaultValue=false)]
        public UsersCapability OpeningBalances { get; set; }

        /// <summary>
        /// Gets or Sets SystemConversion
        /// </summary>
        [DataMember(Name="system_conversion", EmitDefaultValue=false)]
        public UsersCapability SystemConversion { get; set; }

        /// <summary>
        /// Gets or Sets Resets
        /// </summary>
        [DataMember(Name="resets", EmitDefaultValue=false)]
        public UsersCapability Resets { get; set; }

        /// <summary>
        /// Gets or Sets Partners
        /// </summary>
        [DataMember(Name="partners", EmitDefaultValue=false)]
        public UsersCapability Partners { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public UsersCapability Items { get; set; }

        /// <summary>
        /// Gets or Sets Sections
        /// </summary>
        [DataMember(Name="sections", EmitDefaultValue=false)]
        public UsersCapability Sections { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name="tags", EmitDefaultValue=false)]
        public UsersCapability Tags { get; set; }

        /// <summary>
        /// Gets or Sets AccountItems
        /// </summary>
        [DataMember(Name="account_items", EmitDefaultValue=false)]
        public UsersCapability AccountItems { get; set; }

        /// <summary>
        /// Gets or Sets Taxes
        /// </summary>
        [DataMember(Name="taxes", EmitDefaultValue=false)]
        public UsersCapability Taxes { get; set; }

        /// <summary>
        /// Gets or Sets UserMatchers
        /// </summary>
        [DataMember(Name="user_matchers", EmitDefaultValue=false)]
        public UsersCapability UserMatchers { get; set; }

        /// <summary>
        /// Gets or Sets DealTemplates
        /// </summary>
        [DataMember(Name="deal_templates", EmitDefaultValue=false)]
        public UsersCapability DealTemplates { get; set; }

        /// <summary>
        /// Gets or Sets ManualJournalTemplates
        /// </summary>
        [DataMember(Name="manual_journal_templates", EmitDefaultValue=false)]
        public UsersCapability ManualJournalTemplates { get; set; }

        /// <summary>
        /// Gets or Sets CostAllocations
        /// </summary>
        [DataMember(Name="cost_allocations", EmitDefaultValue=false)]
        public UsersCapability CostAllocations { get; set; }

        /// <summary>
        /// Gets or Sets ApprovalFlowRoutes
        /// </summary>
        [DataMember(Name="approval_flow_routes", EmitDefaultValue=false)]
        public UsersCapability ApprovalFlowRoutes { get; set; }

        /// <summary>
        /// Gets or Sets ExpenseApplicationTemplates
        /// </summary>
        [DataMember(Name="expense_application_templates", EmitDefaultValue=false)]
        public UsersCapability ExpenseApplicationTemplates { get; set; }

        /// <summary>
        /// Gets or Sets Workflows
        /// </summary>
        [DataMember(Name="workflows", EmitDefaultValue=false)]
        public UsersCapability Workflows { get; set; }

        /// <summary>
        /// Gets or Sets OauthApplications
        /// </summary>
        [DataMember(Name="oauth_applications", EmitDefaultValue=false)]
        public UsersCapability OauthApplications { get; set; }

        /// <summary>
        /// Gets or Sets OauthAuthorizations
        /// </summary>
        [DataMember(Name="oauth_authorizations", EmitDefaultValue=false)]
        public UsersCapability OauthAuthorizations { get; set; }

        /// <summary>
        /// Gets or Sets BankAccountantStaffUsers
        /// </summary>
        [DataMember(Name="bank_accountant_staff_users", EmitDefaultValue=false)]
        public UsersCapability BankAccountantStaffUsers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UsersCapabilitiesResponse {\n");
            sb.Append("  WalletTxns: ").Append(WalletTxns).Append("\n");
            sb.Append("  Deals: ").Append(Deals).Append("\n");
            sb.Append("  Transfers: ").Append(Transfers).Append("\n");
            sb.Append("  Docs: ").Append(Docs).Append("\n");
            sb.Append("  DocPostings: ").Append(DocPostings).Append("\n");
            sb.Append("  Receipts: ").Append(Receipts).Append("\n");
            sb.Append("  ReceiptStreamEditor: ").Append(ReceiptStreamEditor).Append("\n");
            sb.Append("  ExpenseApplications: ").Append(ExpenseApplications).Append("\n");
            sb.Append("  Spreadsheets: ").Append(Spreadsheets).Append("\n");
            sb.Append("  PaymentRequests: ").Append(PaymentRequests).Append("\n");
            sb.Append("  RequestForms: ").Append(RequestForms).Append("\n");
            sb.Append("  ApprovalRequests: ").Append(ApprovalRequests).Append("\n");
            sb.Append("  Reports: ").Append(Reports).Append("\n");
            sb.Append("  ReportsIncomeExpense: ").Append(ReportsIncomeExpense).Append("\n");
            sb.Append("  ReportsReceivables: ").Append(ReportsReceivables).Append("\n");
            sb.Append("  ReportsPayables: ").Append(ReportsPayables).Append("\n");
            sb.Append("  ReportsCashBalance: ").Append(ReportsCashBalance).Append("\n");
            sb.Append("  ReportsCrosstabs: ").Append(ReportsCrosstabs).Append("\n");
            sb.Append("  ReportsGeneralLedgers: ").Append(ReportsGeneralLedgers).Append("\n");
            sb.Append("  ReportsPl: ").Append(ReportsPl).Append("\n");
            sb.Append("  ReportsBs: ").Append(ReportsBs).Append("\n");
            sb.Append("  ReportsJournals: ").Append(ReportsJournals).Append("\n");
            sb.Append("  ReportsManagementsPlanning: ").Append(ReportsManagementsPlanning).Append("\n");
            sb.Append("  ReportsManagementsNavigation: ").Append(ReportsManagementsNavigation).Append("\n");
            sb.Append("  ManualJournals: ").Append(ManualJournals).Append("\n");
            sb.Append("  FixedAssets: ").Append(FixedAssets).Append("\n");
            sb.Append("  InventoryRefreshes: ").Append(InventoryRefreshes).Append("\n");
            sb.Append("  BizAllocations: ").Append(BizAllocations).Append("\n");
            sb.Append("  PaymentRecords: ").Append(PaymentRecords).Append("\n");
            sb.Append("  AnnualReports: ").Append(AnnualReports).Append("\n");
            sb.Append("  TaxReports: ").Append(TaxReports).Append("\n");
            sb.Append("  ConsumptionEntries: ").Append(ConsumptionEntries).Append("\n");
            sb.Append("  TaxReturn: ").Append(TaxReturn).Append("\n");
            sb.Append("  AccountItemStatements: ").Append(AccountItemStatements).Append("\n");
            sb.Append("  MonthEnd: ").Append(MonthEnd).Append("\n");
            sb.Append("  YearEnd: ").Append(YearEnd).Append("\n");
            sb.Append("  Walletables: ").Append(Walletables).Append("\n");
            sb.Append("  Companies: ").Append(Companies).Append("\n");
            sb.Append("  Invitations: ").Append(Invitations).Append("\n");
            sb.Append("  SignInLogs: ").Append(SignInLogs).Append("\n");
            sb.Append("  Backups: ").Append(Backups).Append("\n");
            sb.Append("  OpeningBalances: ").Append(OpeningBalances).Append("\n");
            sb.Append("  SystemConversion: ").Append(SystemConversion).Append("\n");
            sb.Append("  Resets: ").Append(Resets).Append("\n");
            sb.Append("  Partners: ").Append(Partners).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  Sections: ").Append(Sections).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  AccountItems: ").Append(AccountItems).Append("\n");
            sb.Append("  Taxes: ").Append(Taxes).Append("\n");
            sb.Append("  UserMatchers: ").Append(UserMatchers).Append("\n");
            sb.Append("  DealTemplates: ").Append(DealTemplates).Append("\n");
            sb.Append("  ManualJournalTemplates: ").Append(ManualJournalTemplates).Append("\n");
            sb.Append("  CostAllocations: ").Append(CostAllocations).Append("\n");
            sb.Append("  ApprovalFlowRoutes: ").Append(ApprovalFlowRoutes).Append("\n");
            sb.Append("  ExpenseApplicationTemplates: ").Append(ExpenseApplicationTemplates).Append("\n");
            sb.Append("  Workflows: ").Append(Workflows).Append("\n");
            sb.Append("  OauthApplications: ").Append(OauthApplications).Append("\n");
            sb.Append("  OauthAuthorizations: ").Append(OauthAuthorizations).Append("\n");
            sb.Append("  BankAccountantStaffUsers: ").Append(BankAccountantStaffUsers).Append("\n");
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
            return this.Equals(input as UsersCapabilitiesResponse);
        }

        /// <summary>
        /// Returns true if UsersCapabilitiesResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of UsersCapabilitiesResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UsersCapabilitiesResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.WalletTxns == input.WalletTxns ||
                    (this.WalletTxns != null &&
                    this.WalletTxns.Equals(input.WalletTxns))
                ) && 
                (
                    this.Deals == input.Deals ||
                    (this.Deals != null &&
                    this.Deals.Equals(input.Deals))
                ) && 
                (
                    this.Transfers == input.Transfers ||
                    (this.Transfers != null &&
                    this.Transfers.Equals(input.Transfers))
                ) && 
                (
                    this.Docs == input.Docs ||
                    (this.Docs != null &&
                    this.Docs.Equals(input.Docs))
                ) && 
                (
                    this.DocPostings == input.DocPostings ||
                    (this.DocPostings != null &&
                    this.DocPostings.Equals(input.DocPostings))
                ) && 
                (
                    this.Receipts == input.Receipts ||
                    (this.Receipts != null &&
                    this.Receipts.Equals(input.Receipts))
                ) && 
                (
                    this.ReceiptStreamEditor == input.ReceiptStreamEditor ||
                    (this.ReceiptStreamEditor != null &&
                    this.ReceiptStreamEditor.Equals(input.ReceiptStreamEditor))
                ) && 
                (
                    this.ExpenseApplications == input.ExpenseApplications ||
                    (this.ExpenseApplications != null &&
                    this.ExpenseApplications.Equals(input.ExpenseApplications))
                ) && 
                (
                    this.Spreadsheets == input.Spreadsheets ||
                    (this.Spreadsheets != null &&
                    this.Spreadsheets.Equals(input.Spreadsheets))
                ) && 
                (
                    this.PaymentRequests == input.PaymentRequests ||
                    (this.PaymentRequests != null &&
                    this.PaymentRequests.Equals(input.PaymentRequests))
                ) && 
                (
                    this.RequestForms == input.RequestForms ||
                    (this.RequestForms != null &&
                    this.RequestForms.Equals(input.RequestForms))
                ) && 
                (
                    this.ApprovalRequests == input.ApprovalRequests ||
                    (this.ApprovalRequests != null &&
                    this.ApprovalRequests.Equals(input.ApprovalRequests))
                ) && 
                (
                    this.Reports == input.Reports ||
                    (this.Reports != null &&
                    this.Reports.Equals(input.Reports))
                ) && 
                (
                    this.ReportsIncomeExpense == input.ReportsIncomeExpense ||
                    (this.ReportsIncomeExpense != null &&
                    this.ReportsIncomeExpense.Equals(input.ReportsIncomeExpense))
                ) && 
                (
                    this.ReportsReceivables == input.ReportsReceivables ||
                    (this.ReportsReceivables != null &&
                    this.ReportsReceivables.Equals(input.ReportsReceivables))
                ) && 
                (
                    this.ReportsPayables == input.ReportsPayables ||
                    (this.ReportsPayables != null &&
                    this.ReportsPayables.Equals(input.ReportsPayables))
                ) && 
                (
                    this.ReportsCashBalance == input.ReportsCashBalance ||
                    (this.ReportsCashBalance != null &&
                    this.ReportsCashBalance.Equals(input.ReportsCashBalance))
                ) && 
                (
                    this.ReportsCrosstabs == input.ReportsCrosstabs ||
                    (this.ReportsCrosstabs != null &&
                    this.ReportsCrosstabs.Equals(input.ReportsCrosstabs))
                ) && 
                (
                    this.ReportsGeneralLedgers == input.ReportsGeneralLedgers ||
                    (this.ReportsGeneralLedgers != null &&
                    this.ReportsGeneralLedgers.Equals(input.ReportsGeneralLedgers))
                ) && 
                (
                    this.ReportsPl == input.ReportsPl ||
                    (this.ReportsPl != null &&
                    this.ReportsPl.Equals(input.ReportsPl))
                ) && 
                (
                    this.ReportsBs == input.ReportsBs ||
                    (this.ReportsBs != null &&
                    this.ReportsBs.Equals(input.ReportsBs))
                ) && 
                (
                    this.ReportsJournals == input.ReportsJournals ||
                    (this.ReportsJournals != null &&
                    this.ReportsJournals.Equals(input.ReportsJournals))
                ) && 
                (
                    this.ReportsManagementsPlanning == input.ReportsManagementsPlanning ||
                    (this.ReportsManagementsPlanning != null &&
                    this.ReportsManagementsPlanning.Equals(input.ReportsManagementsPlanning))
                ) && 
                (
                    this.ReportsManagementsNavigation == input.ReportsManagementsNavigation ||
                    (this.ReportsManagementsNavigation != null &&
                    this.ReportsManagementsNavigation.Equals(input.ReportsManagementsNavigation))
                ) && 
                (
                    this.ManualJournals == input.ManualJournals ||
                    (this.ManualJournals != null &&
                    this.ManualJournals.Equals(input.ManualJournals))
                ) && 
                (
                    this.FixedAssets == input.FixedAssets ||
                    (this.FixedAssets != null &&
                    this.FixedAssets.Equals(input.FixedAssets))
                ) && 
                (
                    this.InventoryRefreshes == input.InventoryRefreshes ||
                    (this.InventoryRefreshes != null &&
                    this.InventoryRefreshes.Equals(input.InventoryRefreshes))
                ) && 
                (
                    this.BizAllocations == input.BizAllocations ||
                    (this.BizAllocations != null &&
                    this.BizAllocations.Equals(input.BizAllocations))
                ) && 
                (
                    this.PaymentRecords == input.PaymentRecords ||
                    (this.PaymentRecords != null &&
                    this.PaymentRecords.Equals(input.PaymentRecords))
                ) && 
                (
                    this.AnnualReports == input.AnnualReports ||
                    (this.AnnualReports != null &&
                    this.AnnualReports.Equals(input.AnnualReports))
                ) && 
                (
                    this.TaxReports == input.TaxReports ||
                    (this.TaxReports != null &&
                    this.TaxReports.Equals(input.TaxReports))
                ) && 
                (
                    this.ConsumptionEntries == input.ConsumptionEntries ||
                    (this.ConsumptionEntries != null &&
                    this.ConsumptionEntries.Equals(input.ConsumptionEntries))
                ) && 
                (
                    this.TaxReturn == input.TaxReturn ||
                    (this.TaxReturn != null &&
                    this.TaxReturn.Equals(input.TaxReturn))
                ) && 
                (
                    this.AccountItemStatements == input.AccountItemStatements ||
                    (this.AccountItemStatements != null &&
                    this.AccountItemStatements.Equals(input.AccountItemStatements))
                ) && 
                (
                    this.MonthEnd == input.MonthEnd ||
                    (this.MonthEnd != null &&
                    this.MonthEnd.Equals(input.MonthEnd))
                ) && 
                (
                    this.YearEnd == input.YearEnd ||
                    (this.YearEnd != null &&
                    this.YearEnd.Equals(input.YearEnd))
                ) && 
                (
                    this.Walletables == input.Walletables ||
                    (this.Walletables != null &&
                    this.Walletables.Equals(input.Walletables))
                ) && 
                (
                    this.Companies == input.Companies ||
                    (this.Companies != null &&
                    this.Companies.Equals(input.Companies))
                ) && 
                (
                    this.Invitations == input.Invitations ||
                    (this.Invitations != null &&
                    this.Invitations.Equals(input.Invitations))
                ) && 
                (
                    this.SignInLogs == input.SignInLogs ||
                    (this.SignInLogs != null &&
                    this.SignInLogs.Equals(input.SignInLogs))
                ) && 
                (
                    this.Backups == input.Backups ||
                    (this.Backups != null &&
                    this.Backups.Equals(input.Backups))
                ) && 
                (
                    this.OpeningBalances == input.OpeningBalances ||
                    (this.OpeningBalances != null &&
                    this.OpeningBalances.Equals(input.OpeningBalances))
                ) && 
                (
                    this.SystemConversion == input.SystemConversion ||
                    (this.SystemConversion != null &&
                    this.SystemConversion.Equals(input.SystemConversion))
                ) && 
                (
                    this.Resets == input.Resets ||
                    (this.Resets != null &&
                    this.Resets.Equals(input.Resets))
                ) && 
                (
                    this.Partners == input.Partners ||
                    (this.Partners != null &&
                    this.Partners.Equals(input.Partners))
                ) && 
                (
                    this.Items == input.Items ||
                    (this.Items != null &&
                    this.Items.Equals(input.Items))
                ) && 
                (
                    this.Sections == input.Sections ||
                    (this.Sections != null &&
                    this.Sections.Equals(input.Sections))
                ) && 
                (
                    this.Tags == input.Tags ||
                    (this.Tags != null &&
                    this.Tags.Equals(input.Tags))
                ) && 
                (
                    this.AccountItems == input.AccountItems ||
                    (this.AccountItems != null &&
                    this.AccountItems.Equals(input.AccountItems))
                ) && 
                (
                    this.Taxes == input.Taxes ||
                    (this.Taxes != null &&
                    this.Taxes.Equals(input.Taxes))
                ) && 
                (
                    this.UserMatchers == input.UserMatchers ||
                    (this.UserMatchers != null &&
                    this.UserMatchers.Equals(input.UserMatchers))
                ) && 
                (
                    this.DealTemplates == input.DealTemplates ||
                    (this.DealTemplates != null &&
                    this.DealTemplates.Equals(input.DealTemplates))
                ) && 
                (
                    this.ManualJournalTemplates == input.ManualJournalTemplates ||
                    (this.ManualJournalTemplates != null &&
                    this.ManualJournalTemplates.Equals(input.ManualJournalTemplates))
                ) && 
                (
                    this.CostAllocations == input.CostAllocations ||
                    (this.CostAllocations != null &&
                    this.CostAllocations.Equals(input.CostAllocations))
                ) && 
                (
                    this.ApprovalFlowRoutes == input.ApprovalFlowRoutes ||
                    (this.ApprovalFlowRoutes != null &&
                    this.ApprovalFlowRoutes.Equals(input.ApprovalFlowRoutes))
                ) && 
                (
                    this.ExpenseApplicationTemplates == input.ExpenseApplicationTemplates ||
                    (this.ExpenseApplicationTemplates != null &&
                    this.ExpenseApplicationTemplates.Equals(input.ExpenseApplicationTemplates))
                ) && 
                (
                    this.Workflows == input.Workflows ||
                    (this.Workflows != null &&
                    this.Workflows.Equals(input.Workflows))
                ) && 
                (
                    this.OauthApplications == input.OauthApplications ||
                    (this.OauthApplications != null &&
                    this.OauthApplications.Equals(input.OauthApplications))
                ) && 
                (
                    this.OauthAuthorizations == input.OauthAuthorizations ||
                    (this.OauthAuthorizations != null &&
                    this.OauthAuthorizations.Equals(input.OauthAuthorizations))
                ) && 
                (
                    this.BankAccountantStaffUsers == input.BankAccountantStaffUsers ||
                    (this.BankAccountantStaffUsers != null &&
                    this.BankAccountantStaffUsers.Equals(input.BankAccountantStaffUsers))
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
                if (this.WalletTxns != null)
                    hashCode = hashCode * 59 + this.WalletTxns.GetHashCode();
                if (this.Deals != null)
                    hashCode = hashCode * 59 + this.Deals.GetHashCode();
                if (this.Transfers != null)
                    hashCode = hashCode * 59 + this.Transfers.GetHashCode();
                if (this.Docs != null)
                    hashCode = hashCode * 59 + this.Docs.GetHashCode();
                if (this.DocPostings != null)
                    hashCode = hashCode * 59 + this.DocPostings.GetHashCode();
                if (this.Receipts != null)
                    hashCode = hashCode * 59 + this.Receipts.GetHashCode();
                if (this.ReceiptStreamEditor != null)
                    hashCode = hashCode * 59 + this.ReceiptStreamEditor.GetHashCode();
                if (this.ExpenseApplications != null)
                    hashCode = hashCode * 59 + this.ExpenseApplications.GetHashCode();
                if (this.Spreadsheets != null)
                    hashCode = hashCode * 59 + this.Spreadsheets.GetHashCode();
                if (this.PaymentRequests != null)
                    hashCode = hashCode * 59 + this.PaymentRequests.GetHashCode();
                if (this.RequestForms != null)
                    hashCode = hashCode * 59 + this.RequestForms.GetHashCode();
                if (this.ApprovalRequests != null)
                    hashCode = hashCode * 59 + this.ApprovalRequests.GetHashCode();
                if (this.Reports != null)
                    hashCode = hashCode * 59 + this.Reports.GetHashCode();
                if (this.ReportsIncomeExpense != null)
                    hashCode = hashCode * 59 + this.ReportsIncomeExpense.GetHashCode();
                if (this.ReportsReceivables != null)
                    hashCode = hashCode * 59 + this.ReportsReceivables.GetHashCode();
                if (this.ReportsPayables != null)
                    hashCode = hashCode * 59 + this.ReportsPayables.GetHashCode();
                if (this.ReportsCashBalance != null)
                    hashCode = hashCode * 59 + this.ReportsCashBalance.GetHashCode();
                if (this.ReportsCrosstabs != null)
                    hashCode = hashCode * 59 + this.ReportsCrosstabs.GetHashCode();
                if (this.ReportsGeneralLedgers != null)
                    hashCode = hashCode * 59 + this.ReportsGeneralLedgers.GetHashCode();
                if (this.ReportsPl != null)
                    hashCode = hashCode * 59 + this.ReportsPl.GetHashCode();
                if (this.ReportsBs != null)
                    hashCode = hashCode * 59 + this.ReportsBs.GetHashCode();
                if (this.ReportsJournals != null)
                    hashCode = hashCode * 59 + this.ReportsJournals.GetHashCode();
                if (this.ReportsManagementsPlanning != null)
                    hashCode = hashCode * 59 + this.ReportsManagementsPlanning.GetHashCode();
                if (this.ReportsManagementsNavigation != null)
                    hashCode = hashCode * 59 + this.ReportsManagementsNavigation.GetHashCode();
                if (this.ManualJournals != null)
                    hashCode = hashCode * 59 + this.ManualJournals.GetHashCode();
                if (this.FixedAssets != null)
                    hashCode = hashCode * 59 + this.FixedAssets.GetHashCode();
                if (this.InventoryRefreshes != null)
                    hashCode = hashCode * 59 + this.InventoryRefreshes.GetHashCode();
                if (this.BizAllocations != null)
                    hashCode = hashCode * 59 + this.BizAllocations.GetHashCode();
                if (this.PaymentRecords != null)
                    hashCode = hashCode * 59 + this.PaymentRecords.GetHashCode();
                if (this.AnnualReports != null)
                    hashCode = hashCode * 59 + this.AnnualReports.GetHashCode();
                if (this.TaxReports != null)
                    hashCode = hashCode * 59 + this.TaxReports.GetHashCode();
                if (this.ConsumptionEntries != null)
                    hashCode = hashCode * 59 + this.ConsumptionEntries.GetHashCode();
                if (this.TaxReturn != null)
                    hashCode = hashCode * 59 + this.TaxReturn.GetHashCode();
                if (this.AccountItemStatements != null)
                    hashCode = hashCode * 59 + this.AccountItemStatements.GetHashCode();
                if (this.MonthEnd != null)
                    hashCode = hashCode * 59 + this.MonthEnd.GetHashCode();
                if (this.YearEnd != null)
                    hashCode = hashCode * 59 + this.YearEnd.GetHashCode();
                if (this.Walletables != null)
                    hashCode = hashCode * 59 + this.Walletables.GetHashCode();
                if (this.Companies != null)
                    hashCode = hashCode * 59 + this.Companies.GetHashCode();
                if (this.Invitations != null)
                    hashCode = hashCode * 59 + this.Invitations.GetHashCode();
                if (this.SignInLogs != null)
                    hashCode = hashCode * 59 + this.SignInLogs.GetHashCode();
                if (this.Backups != null)
                    hashCode = hashCode * 59 + this.Backups.GetHashCode();
                if (this.OpeningBalances != null)
                    hashCode = hashCode * 59 + this.OpeningBalances.GetHashCode();
                if (this.SystemConversion != null)
                    hashCode = hashCode * 59 + this.SystemConversion.GetHashCode();
                if (this.Resets != null)
                    hashCode = hashCode * 59 + this.Resets.GetHashCode();
                if (this.Partners != null)
                    hashCode = hashCode * 59 + this.Partners.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
                if (this.Sections != null)
                    hashCode = hashCode * 59 + this.Sections.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.AccountItems != null)
                    hashCode = hashCode * 59 + this.AccountItems.GetHashCode();
                if (this.Taxes != null)
                    hashCode = hashCode * 59 + this.Taxes.GetHashCode();
                if (this.UserMatchers != null)
                    hashCode = hashCode * 59 + this.UserMatchers.GetHashCode();
                if (this.DealTemplates != null)
                    hashCode = hashCode * 59 + this.DealTemplates.GetHashCode();
                if (this.ManualJournalTemplates != null)
                    hashCode = hashCode * 59 + this.ManualJournalTemplates.GetHashCode();
                if (this.CostAllocations != null)
                    hashCode = hashCode * 59 + this.CostAllocations.GetHashCode();
                if (this.ApprovalFlowRoutes != null)
                    hashCode = hashCode * 59 + this.ApprovalFlowRoutes.GetHashCode();
                if (this.ExpenseApplicationTemplates != null)
                    hashCode = hashCode * 59 + this.ExpenseApplicationTemplates.GetHashCode();
                if (this.Workflows != null)
                    hashCode = hashCode * 59 + this.Workflows.GetHashCode();
                if (this.OauthApplications != null)
                    hashCode = hashCode * 59 + this.OauthApplications.GetHashCode();
                if (this.OauthAuthorizations != null)
                    hashCode = hashCode * 59 + this.OauthAuthorizations.GetHashCode();
                if (this.BankAccountantStaffUsers != null)
                    hashCode = hashCode * 59 + this.BankAccountantStaffUsers.GetHashCode();
                return hashCode;
            }
        }

    }

}
