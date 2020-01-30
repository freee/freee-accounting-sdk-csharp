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
    public interface IJournalsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// ダウンロード実行
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        void DownloadJournal (int id, int companyId);

        /// <summary>
        /// ダウンロード実行
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DownloadJournalWithHttpInfo (int id, int companyId);
        /// <summary>
        /// ステータス確認
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>JournalsStatusResponse</returns>
        JournalsStatusResponse GetJournalStatus (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));

        /// <summary>
        /// ステータス確認
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>ApiResponse of JournalsStatusResponse</returns>
        ApiResponse<JournalsStatusResponse> GetJournalStatusWithHttpInfo (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));
        /// <summary>
        /// ダウンロード要求
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>JournalsEnqueueJournalsResponse</returns>
        JournalsEnqueueJournalsResponse GetJournals (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));

        /// <summary>
        /// ダウンロード要求
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>ApiResponse of JournalsEnqueueJournalsResponse</returns>
        ApiResponse<JournalsEnqueueJournalsResponse> GetJournalsWithHttpInfo (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJournalsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// ダウンロード実行
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DownloadJournalAsync (int id, int companyId);

        /// <summary>
        /// ダウンロード実行
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DownloadJournalAsyncWithHttpInfo (int id, int companyId);
        /// <summary>
        /// ステータス確認
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of JournalsStatusResponse</returns>
        System.Threading.Tasks.Task<JournalsStatusResponse> GetJournalStatusAsync (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));

        /// <summary>
        /// ステータス確認
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of ApiResponse (JournalsStatusResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<JournalsStatusResponse>> GetJournalStatusAsyncWithHttpInfo (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));
        /// <summary>
        /// ダウンロード要求
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of JournalsEnqueueJournalsResponse</returns>
        System.Threading.Tasks.Task<JournalsEnqueueJournalsResponse> GetJournalsAsync (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));

        /// <summary>
        /// ダウンロード要求
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of ApiResponse (JournalsEnqueueJournalsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<JournalsEnqueueJournalsResponse>> GetJournalsAsyncWithHttpInfo (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IJournalsApi : IJournalsApiSync, IJournalsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class JournalsApi : IJournalsApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JournalsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JournalsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="JournalsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public JournalsApi(Freee.Accounting.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="JournalsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public JournalsApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
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
        /// ダウンロード実行  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        public void DownloadJournal (int id, int companyId)
        {
             DownloadJournalWithHttpInfo(id, companyId);
        }

        /// <summary>
        /// ダウンロード実行  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Freee.Accounting.Client.ApiResponse<Object> DownloadJournalWithHttpInfo (int id, int companyId)
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
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/api/1/journals/reports/{id}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DownloadJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ダウンロード実行  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DownloadJournalAsync (int id, int companyId)
        {
             await DownloadJournalAsyncWithHttpInfo(id, companyId);

        }

        /// <summary>
        /// ダウンロード実行  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードを実行する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">受け付けID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<Object>> DownloadJournalAsyncWithHttpInfo (int id, int companyId)
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
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/api/1/journals/reports/{id}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DownloadJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ステータス確認  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>JournalsStatusResponse</returns>
        public JournalsStatusResponse GetJournalStatus (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
             Freee.Accounting.Client.ApiResponse<JournalsStatusResponse> localVarResponse = GetJournalStatusWithHttpInfo(companyId, id, visibleTags, startDate, endDate);
             return localVarResponse.Data;
        }

        /// <summary>
        /// ステータス確認  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>ApiResponse of JournalsStatusResponse</returns>
        public Freee.Accounting.Client.ApiResponse< JournalsStatusResponse > GetJournalStatusWithHttpInfo (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
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
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (visibleTags != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("csv", "visible_tags", visibleTags))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< JournalsStatusResponse >("/api/1/journals/reports/{id}/status", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournalStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ステータス確認  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of JournalsStatusResponse</returns>
        public async System.Threading.Tasks.Task<JournalsStatusResponse> GetJournalStatusAsync (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
             Freee.Accounting.Client.ApiResponse<JournalsStatusResponse> localVarResponse = await GetJournalStatusAsyncWithHttpInfo(companyId, id, visibleTags, startDate, endDate);
             return localVarResponse.Data;

        }

        /// <summary>
        /// ステータス確認  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ダウンロードリクエストのステータスを確認する&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;status&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;enqueued : 実行待ち&lt;/li&gt;  &lt;li&gt;working : 実行中&lt;/li&gt;  &lt;li&gt;uploaded : 準備完了&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;id : 受け付けID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id">受け付けID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of ApiResponse (JournalsStatusResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<JournalsStatusResponse>> GetJournalStatusAsyncWithHttpInfo (int companyId, int id, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
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
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (visibleTags != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("csv", "visible_tags", visibleTags))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<JournalsStatusResponse>("/api/1/journals/reports/{id}/status", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournalStatus", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ダウンロード要求  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>JournalsEnqueueJournalsResponse</returns>
        public JournalsEnqueueJournalsResponse GetJournals (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
             Freee.Accounting.Client.ApiResponse<JournalsEnqueueJournalsResponse> localVarResponse = GetJournalsWithHttpInfo(downloadType, companyId, visibleTags, startDate, endDate);
             return localVarResponse.Data;
        }

        /// <summary>
        /// ダウンロード要求  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>ApiResponse of JournalsEnqueueJournalsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< JournalsEnqueueJournalsResponse > GetJournalsWithHttpInfo (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
            // verify the required parameter 'downloadType' is set
            if (downloadType == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'downloadType' when calling JournalsApi->GetJournals");

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

            if (downloadType != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "download_type", downloadType))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (visibleTags != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("csv", "visible_tags", visibleTags))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< JournalsEnqueueJournalsResponse >("/api/1/journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// ダウンロード要求  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of JournalsEnqueueJournalsResponse</returns>
        public async System.Threading.Tasks.Task<JournalsEnqueueJournalsResponse> GetJournalsAsync (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
             Freee.Accounting.Client.ApiResponse<JournalsEnqueueJournalsResponse> localVarResponse = await GetJournalsAsyncWithHttpInfo(downloadType, companyId, visibleTags, startDate, endDate);
             return localVarResponse.Data;

        }

        /// <summary>
        /// ダウンロード要求  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;ユーザが所属する事業所の仕訳帳のダウンロードをリクエストします 生成されるファイルに関しては、&lt;a href&#x3D;\&quot;https://support.freee.co.jp/hc/ja/articles/204599604#2\&quot;&gt;ヘルプページ&lt;/a&gt;をご参照ください&lt;/p&gt;  &lt;p&gt;＊このAPIは無料プランのアカウントではご利用になれません&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;download_type &lt;ul&gt; &lt;li&gt;csv&lt;/li&gt;  &lt;li&gt;pdf&lt;/li&gt;  &lt;li&gt;yayoi (csv alias)&lt;/li&gt;  &lt;li&gt;generic&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;visible_tags : 指定しない場合は従来の仕様の仕訳帳が出力されます &lt;ul&gt; &lt;li&gt;partner : 取引先タグ&lt;/li&gt;  &lt;li&gt;item : 品目タグ&lt;/li&gt;  &lt;li&gt;tag : メモタグ&lt;/li&gt;  &lt;li&gt;section : 部門タグ&lt;/li&gt;  &lt;li&gt;description : 備考欄&lt;/li&gt;  &lt;li&gt;wallet_txn_description : 明細の備考欄&lt;/li&gt;  &lt;li&gt;all : 指定された場合は上記の設定をすべて有効として扱います&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt;id : 受け付けID&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="downloadType">ダウンロード形式</param>
        /// <param name="companyId">事業所ID</param>
        /// <param name="visibleTags">補助科目やコメントとして出力する項目 (optional)</param>
        /// <param name="startDate">取得開始日 (yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">取得終了日 (yyyy-mm-dd) (optional)</param>
        /// <returns>Task of ApiResponse (JournalsEnqueueJournalsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<JournalsEnqueueJournalsResponse>> GetJournalsAsyncWithHttpInfo (string downloadType, int companyId, List<string> visibleTags = default(List<string>), string startDate = default(string), string endDate = default(string))
        {
            // verify the required parameter 'downloadType' is set
            if (downloadType == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'downloadType' when calling JournalsApi->GetJournals");


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
            
            if (downloadType != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "download_type", downloadType))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (visibleTags != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("csv", "visible_tags", visibleTags))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<JournalsEnqueueJournalsResponse>("/api/1/journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
