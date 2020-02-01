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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Freee.Accounting.Client;
using Freee.Accounting.Models;

namespace Freee.Accounting.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IExpenseApplicationLineTemplatesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 経費科目の作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        ExpenseApplicationLineTemplatesResponse CreateExpenseApplicationLineTemplate (ExpenseApplicationLineTemplateParams parameters);

        /// <summary>
        /// 経費科目の作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        ApiResponse<ExpenseApplicationLineTemplatesResponse> CreateExpenseApplicationLineTemplateWithHttpInfo (ExpenseApplicationLineTemplateParams parameters);
        /// <summary>
        /// 経費科目の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        void DestroyExpenseApplicationLineTemplate (int id, int companyId);

        /// <summary>
        /// 経費科目の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DestroyExpenseApplicationLineTemplateWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 経費科目の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        ExpenseApplicationLineTemplatesResponse GetExpenseApplicationLineTemplate (int id, int companyId);

        /// <summary>
        /// 経費科目の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        ApiResponse<ExpenseApplicationLineTemplatesResponse> GetExpenseApplicationLineTemplateWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 経費科目一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>ExpenseApplicationLineTemplatesIndexResponse</returns>
        ExpenseApplicationLineTemplatesIndexResponse GetExpenseApplicationLineTemplates (int companyId, int? offset = default(int?), int? limit = default(int?));

        /// <summary>
        /// 経費科目一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesIndexResponse</returns>
        ApiResponse<ExpenseApplicationLineTemplatesIndexResponse> GetExpenseApplicationLineTemplatesWithHttpInfo (int companyId, int? offset = default(int?), int? limit = default(int?));
        /// <summary>
        /// 経費科目の更新
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        ExpenseApplicationLineTemplatesResponse UpdateExpenseApplicationLineTemplate (int id, ExpenseApplicationLineTemplateParams parameters);

        /// <summary>
        /// 経費科目の更新
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        ApiResponse<ExpenseApplicationLineTemplatesResponse> UpdateExpenseApplicationLineTemplateWithHttpInfo (int id, ExpenseApplicationLineTemplateParams parameters);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IExpenseApplicationLineTemplatesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 経費科目の作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> CreateExpenseApplicationLineTemplateAsync (ExpenseApplicationLineTemplateParams parameters);

        /// <summary>
        /// 経費科目の作成
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ExpenseApplicationLineTemplatesResponse>> CreateExpenseApplicationLineTemplateAsyncWithHttpInfo (ExpenseApplicationLineTemplateParams parameters);
        /// <summary>
        /// 経費科目の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DestroyExpenseApplicationLineTemplateAsync (int id, int companyId);

        /// <summary>
        /// 経費科目の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DestroyExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 経費科目の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> GetExpenseApplicationLineTemplateAsync (int id, int companyId);

        /// <summary>
        /// 経費科目の取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ExpenseApplicationLineTemplatesResponse>> GetExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 経費科目一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesIndexResponse</returns>
        System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesIndexResponse> GetExpenseApplicationLineTemplatesAsync (int companyId, int? offset = default(int?), int? limit = default(int?));

        /// <summary>
        /// 経費科目一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesIndexResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ExpenseApplicationLineTemplatesIndexResponse>> GetExpenseApplicationLineTemplatesAsyncWithHttpInfo (int companyId, int? offset = default(int?), int? limit = default(int?));
        /// <summary>
        /// 経費科目の更新
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> UpdateExpenseApplicationLineTemplateAsync (int id, ExpenseApplicationLineTemplateParams parameters);

        /// <summary>
        /// 経費科目の更新
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ExpenseApplicationLineTemplatesResponse>> UpdateExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, ExpenseApplicationLineTemplateParams parameters);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IExpenseApplicationLineTemplatesApi : IExpenseApplicationLineTemplatesApiSync, IExpenseApplicationLineTemplatesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ExpenseApplicationLineTemplatesApi : IExpenseApplicationLineTemplatesApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplatesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ExpenseApplicationLineTemplatesApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplatesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ExpenseApplicationLineTemplatesApi(String basePath)
        {
            this.Configuration = Freee.Accounting.Client.Configuration.MergeConfigurations(
                Freee.Accounting.Client.GlobalConfiguration.Instance,
                new Freee.Accounting.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplatesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ExpenseApplicationLineTemplatesApi(Freee.Accounting.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Freee.Accounting.Client.Configuration.MergeConfigurations(
                Freee.Accounting.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Freee.Accounting.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseApplicationLineTemplatesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ExpenseApplicationLineTemplatesApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
        {
            if(client == null) throw new ArgumentNullException("client");
            if(asyncClient == null) throw new ArgumentNullException("asyncClient");
            if(configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Freee.Accounting.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Freee.Accounting.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Freee.Accounting.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Freee.Accounting.Client.IReadableConfiguration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Freee.Accounting.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// 経費科目の作成 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        public ExpenseApplicationLineTemplatesResponse CreateExpenseApplicationLineTemplate (ExpenseApplicationLineTemplateParams parameters)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = CreateExpenseApplicationLineTemplateWithHttpInfo(parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 経費科目の作成 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ExpenseApplicationLineTemplatesResponse > CreateExpenseApplicationLineTemplateWithHttpInfo (ExpenseApplicationLineTemplateParams parameters)
        {
            // verify the required parameter 'parameters' is set
            if (parameters == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'parameters' when calling ExpenseApplicationLineTemplatesApi->CreateExpenseApplicationLineTemplate");

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post< ExpenseApplicationLineTemplatesResponse >("/api/1/expense_application_line_templates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の作成 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        public async System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> CreateExpenseApplicationLineTemplateAsync (ExpenseApplicationLineTemplateParams parameters)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = await CreateExpenseApplicationLineTemplateAsyncWithHttpInfo(parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 経費科目の作成 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">経費科目の作成</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse>> CreateExpenseApplicationLineTemplateAsyncWithHttpInfo (ExpenseApplicationLineTemplateParams parameters)
        {
            // verify the required parameter 'parameters' is set
            if (parameters == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'parameters' when calling ExpenseApplicationLineTemplatesApi->CreateExpenseApplicationLineTemplate");


            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ExpenseApplicationLineTemplatesResponse>("/api/1/expense_application_line_templates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        public void DestroyExpenseApplicationLineTemplate (int id, int companyId)
        {
             DestroyExpenseApplicationLineTemplateWithHttpInfo(id, companyId);
        }

        /// <summary>
        /// 経費科目の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Freee.Accounting.Client.ApiResponse<Object> DestroyExpenseApplicationLineTemplateWithHttpInfo (int id, int companyId)
        {
            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DestroyExpenseApplicationLineTemplateAsync (int id, int companyId)
        {
             await DestroyExpenseApplicationLineTemplateAsyncWithHttpInfo(id, companyId);

        }

        /// <summary>
        /// 経費科目の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<Object>> DestroyExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, int companyId)
        {

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        public ExpenseApplicationLineTemplatesResponse GetExpenseApplicationLineTemplate (int id, int companyId)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = GetExpenseApplicationLineTemplateWithHttpInfo(id, companyId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 経費科目の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ExpenseApplicationLineTemplatesResponse > GetExpenseApplicationLineTemplateWithHttpInfo (int id, int companyId)
        {
            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< ExpenseApplicationLineTemplatesResponse >("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        public async System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> GetExpenseApplicationLineTemplateAsync (int id, int companyId)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = await GetExpenseApplicationLineTemplateAsyncWithHttpInfo(id, companyId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 経費科目の取得 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse>> GetExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, int companyId)
        {

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ExpenseApplicationLineTemplatesResponse>("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>ExpenseApplicationLineTemplatesIndexResponse</returns>
        public ExpenseApplicationLineTemplatesIndexResponse GetExpenseApplicationLineTemplates (int companyId, int? offset = default(int?), int? limit = default(int?))
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesIndexResponse> localVarResponse = GetExpenseApplicationLineTemplatesWithHttpInfo(companyId, offset, limit);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 経費科目一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesIndexResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ExpenseApplicationLineTemplatesIndexResponse > GetExpenseApplicationLineTemplatesWithHttpInfo (int companyId, int? offset = default(int?), int? limit = default(int?))
        {
            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< ExpenseApplicationLineTemplatesIndexResponse >("/api/1/expense_application_line_templates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExpenseApplicationLineTemplates", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesIndexResponse</returns>
        public async System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesIndexResponse> GetExpenseApplicationLineTemplatesAsync (int companyId, int? offset = default(int?), int? limit = default(int?))
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesIndexResponse> localVarResponse = await GetExpenseApplicationLineTemplatesAsyncWithHttpInfo(companyId, offset, limit);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 経費科目一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の経費科目一覧を取得する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100) (optional)</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesIndexResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesIndexResponse>> GetExpenseApplicationLineTemplatesAsyncWithHttpInfo (int companyId, int? offset = default(int?), int? limit = default(int?))
        {

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId));
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ExpenseApplicationLineTemplatesIndexResponse>("/api/1/expense_application_line_templates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExpenseApplicationLineTemplates", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の更新 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>ExpenseApplicationLineTemplatesResponse</returns>
        public ExpenseApplicationLineTemplatesResponse UpdateExpenseApplicationLineTemplate (int id, ExpenseApplicationLineTemplateParams parameters)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = UpdateExpenseApplicationLineTemplateWithHttpInfo(id, parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 経費科目の更新 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>ApiResponse of ExpenseApplicationLineTemplatesResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ExpenseApplicationLineTemplatesResponse > UpdateExpenseApplicationLineTemplateWithHttpInfo (int id, ExpenseApplicationLineTemplateParams parameters)
        {
            // verify the required parameter 'parameters' is set
            if (parameters == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'parameters' when calling ExpenseApplicationLineTemplatesApi->UpdateExpenseApplicationLineTemplate");

            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = Freee.Accounting.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Freee.Accounting.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Put< ExpenseApplicationLineTemplatesResponse >("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 経費科目の更新 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>Task of ExpenseApplicationLineTemplatesResponse</returns>
        public async System.Threading.Tasks.Task<ExpenseApplicationLineTemplatesResponse> UpdateExpenseApplicationLineTemplateAsync (int id, ExpenseApplicationLineTemplateParams parameters)
        {
             Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse> localVarResponse = await UpdateExpenseApplicationLineTemplateAsyncWithHttpInfo(id, parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 経費科目の更新 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">経費科目ID</param>
        /// <param name="parameters">経費科目の更新</param>
        /// <returns>Task of ApiResponse (ExpenseApplicationLineTemplatesResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ExpenseApplicationLineTemplatesResponse>> UpdateExpenseApplicationLineTemplateAsyncWithHttpInfo (int id, ExpenseApplicationLineTemplateParams parameters)
        {
            // verify the required parameter 'parameters' is set
            if (parameters == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'parameters' when calling ExpenseApplicationLineTemplatesApi->UpdateExpenseApplicationLineTemplate");


            Freee.Accounting.Client.RequestOptions localVarRequestOptions = new Freee.Accounting.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.PathParameters.Add("id", Freee.Accounting.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<ExpenseApplicationLineTemplatesResponse>("/api/1/expense_application_line_templates/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateExpenseApplicationLineTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
