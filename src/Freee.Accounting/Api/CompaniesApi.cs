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
    public interface ICompaniesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 事業所一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>CompaniesIndexResponse</returns>
        CompaniesIndexResponse GetCompanies ();

        /// <summary>
        /// 事業所一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of CompaniesIndexResponse</returns>
        ApiResponse<CompaniesIndexResponse> GetCompaniesWithHttpInfo ();
        /// <summary>
        /// 事業所の詳細情報の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>CompaniesShowResponse</returns>
        CompaniesShowResponse GetCompany (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?));

        /// <summary>
        /// 事業所の詳細情報の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>ApiResponse of CompaniesShowResponse</returns>
        ApiResponse<CompaniesShowResponse> GetCompanyWithHttpInfo (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?));
        /// <summary>
        /// 事業所情報の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>CompaniesUpdateResponse</returns>
        CompaniesUpdateResponse UpdateCompany (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams));

        /// <summary>
        /// 事業所情報の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of CompaniesUpdateResponse</returns>
        ApiResponse<CompaniesUpdateResponse> UpdateCompanyWithHttpInfo (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICompaniesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 事業所一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of CompaniesIndexResponse</returns>
        System.Threading.Tasks.Task<CompaniesIndexResponse> GetCompaniesAsync ();

        /// <summary>
        /// 事業所一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (CompaniesIndexResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CompaniesIndexResponse>> GetCompaniesAsyncWithHttpInfo ();
        /// <summary>
        /// 事業所の詳細情報の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>Task of CompaniesShowResponse</returns>
        System.Threading.Tasks.Task<CompaniesShowResponse> GetCompanyAsync (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?));

        /// <summary>
        /// 事業所の詳細情報の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>Task of ApiResponse (CompaniesShowResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CompaniesShowResponse>> GetCompanyAsyncWithHttpInfo (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?));
        /// <summary>
        /// 事業所情報の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of CompaniesUpdateResponse</returns>
        System.Threading.Tasks.Task<CompaniesUpdateResponse> UpdateCompanyAsync (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams));

        /// <summary>
        /// 事業所情報の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse (CompaniesUpdateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CompaniesUpdateResponse>> UpdateCompanyAsyncWithHttpInfo (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICompaniesApi : ICompaniesApiSync, ICompaniesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CompaniesApi : ICompaniesApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CompaniesApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CompaniesApi(String basePath)
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
        /// Initializes a new instance of the <see cref="CompaniesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CompaniesApi(Freee.Accounting.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="CompaniesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public CompaniesApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
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
        /// 事業所一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>CompaniesIndexResponse</returns>
        public CompaniesIndexResponse GetCompanies ()
        {
             Freee.Accounting.Client.ApiResponse<CompaniesIndexResponse> localVarResponse = GetCompaniesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// 事業所一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of CompaniesIndexResponse</returns>
        public Freee.Accounting.Client.ApiResponse< CompaniesIndexResponse > GetCompaniesWithHttpInfo ()
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

            localVarRequestOptions.HeaderParameters.Add("X-Api-Version", "2020-06-15");

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< CompaniesIndexResponse >("/api/1/companies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCompanies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 事業所一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of CompaniesIndexResponse</returns>
        public async System.Threading.Tasks.Task<CompaniesIndexResponse> GetCompaniesAsync ()
        {
             Freee.Accounting.Client.ApiResponse<CompaniesIndexResponse> localVarResponse = await GetCompaniesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// 事業所一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (CompaniesIndexResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<CompaniesIndexResponse>> GetCompaniesAsyncWithHttpInfo ()
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

            localVarRequestOptions.HeaderParameters.Add("X-Api-Version", "2020-06-15");

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CompaniesIndexResponse>("/api/1/companies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCompanies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 事業所の詳細情報の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>CompaniesShowResponse</returns>
        public CompaniesShowResponse GetCompany (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?))
        {
             Freee.Accounting.Client.ApiResponse<CompaniesShowResponse> localVarResponse = GetCompanyWithHttpInfo(id, details, accountItems, taxes, items, partners, sections, tags, walletables);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 事業所の詳細情報の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>ApiResponse of CompaniesShowResponse</returns>
        public Freee.Accounting.Client.ApiResponse< CompaniesShowResponse > GetCompanyWithHttpInfo (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?))
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
            if (details != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "details", details));
            }
            if (accountItems != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_items", accountItems));
            }
            if (taxes != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "taxes", taxes));
            }
            if (items != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "items", items));
            }
            if (partners != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partners", partners));
            }
            if (sections != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "sections", sections));
            }
            if (tags != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "tags", tags));
            }
            if (walletables != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "walletables", walletables));
            }

            localVarRequestOptions.HeaderParameters.Add("X-Api-Version", "2020-06-15");

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< CompaniesShowResponse >("/api/1/companies/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCompany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 事業所の詳細情報の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>Task of CompaniesShowResponse</returns>
        public async System.Threading.Tasks.Task<CompaniesShowResponse> GetCompanyAsync (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?))
        {
             Freee.Accounting.Client.ApiResponse<CompaniesShowResponse> localVarResponse = await GetCompanyAsyncWithHttpInfo(id, details, accountItems, taxes, items, partners, sections, tags, walletables);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 事業所の詳細情報の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の詳細を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;role &lt;ul&gt; &lt;li&gt;admin : 管理者&lt;/li&gt;  &lt;li&gt;simple_accounting : 一般&lt;/li&gt;  &lt;li&gt;self_only : 取引登録のみ&lt;/li&gt;  &lt;li&gt;read_only : 閲覧のみ&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="details">取得情報に勘定科目・税区分コード・税区分・品目・取引先・部門・メモタグ・口座の一覧を含める (optional)</param>
        /// <param name="accountItems">取得情報に勘定科目一覧を含める (optional)</param>
        /// <param name="taxes">取得情報に税区分コード・税区分一覧を含める (optional)</param>
        /// <param name="items">取得情報に品目一覧を含める (optional)</param>
        /// <param name="partners">取得情報に取引先一覧を含める (optional)</param>
        /// <param name="sections">取得情報に部門一覧を含める (optional)</param>
        /// <param name="tags">取得情報にメモタグ一覧を含める (optional)</param>
        /// <param name="walletables">取得情報に口座一覧を含める (optional)</param>
        /// <returns>Task of ApiResponse (CompaniesShowResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<CompaniesShowResponse>> GetCompanyAsyncWithHttpInfo (int id, bool? details = default(bool?), bool? accountItems = default(bool?), bool? taxes = default(bool?), bool? items = default(bool?), bool? partners = default(bool?), bool? sections = default(bool?), bool? tags = default(bool?), bool? walletables = default(bool?))
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
            if (details != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "details", details));
            }
            if (accountItems != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_items", accountItems));
            }
            if (taxes != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "taxes", taxes));
            }
            if (items != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "items", items));
            }
            if (partners != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partners", partners));
            }
            if (sections != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "sections", sections));
            }
            if (tags != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "tags", tags));
            }
            if (walletables != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "walletables", walletables));
            }

            localVarRequestOptions.HeaderParameters.Add("X-Api-Version", "2020-06-15");

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CompaniesShowResponse>("/api/1/companies/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCompany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 事業所情報の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>CompaniesUpdateResponse</returns>
        public CompaniesUpdateResponse UpdateCompany (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams))
        {
             Freee.Accounting.Client.ApiResponse<CompaniesUpdateResponse> localVarResponse = UpdateCompanyWithHttpInfo(id, parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 事業所情報の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of CompaniesUpdateResponse</returns>
        public Freee.Accounting.Client.ApiResponse< CompaniesUpdateResponse > UpdateCompanyWithHttpInfo (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams))
        {
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
            var localVarResponse = this.Client.Put< CompaniesUpdateResponse >("/api/1/companies/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateCompany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 事業所情報の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of CompaniesUpdateResponse</returns>
        public async System.Threading.Tasks.Task<CompaniesUpdateResponse> UpdateCompanyAsync (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams))
        {
             Freee.Accounting.Client.ApiResponse<CompaniesUpdateResponse> localVarResponse = await UpdateCompanyAsyncWithHttpInfo(id, parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 事業所情報の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の情報を更新する&lt;/p&gt;  &lt;p&gt;※同時に複数のリクエストを受け付けない&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">事業所ID</param>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse (CompaniesUpdateResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<CompaniesUpdateResponse>> UpdateCompanyAsyncWithHttpInfo (int id, UpdateCompanyParams parameters = default(UpdateCompanyParams))
        {

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

            var localVarResponse = await this.AsynchronousClient.PutAsync<CompaniesUpdateResponse>("/api/1/companies/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateCompany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
