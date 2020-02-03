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
    public interface ITrialBalanceApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 貸借対照表の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsResponse</returns>
        TrialBsResponse GetTrialBs (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsResponse</returns>
        ApiResponse<TrialBsResponse> GetTrialBsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 貸借対照表(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsThreeYearsResponse</returns>
        TrialBsThreeYearsResponse GetTrialBsThreeYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsThreeYearsResponse</returns>
        ApiResponse<TrialBsThreeYearsResponse> GetTrialBsThreeYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 貸借対照表(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsTwoYearsResponse</returns>
        TrialBsTwoYearsResponse GetTrialBsTwoYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsTwoYearsResponse</returns>
        ApiResponse<TrialBsTwoYearsResponse> GetTrialBsTwoYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 損益計算書の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlResponse</returns>
        TrialPlResponse GetTrialPl (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlResponse</returns>
        ApiResponse<TrialPlResponse> GetTrialPlWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(部門比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlSectionsResponse</returns>
        TrialPlSectionsResponse GetTrialPlSections (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(部門比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlSectionsResponse</returns>
        ApiResponse<TrialPlSectionsResponse> GetTrialPlSectionsWithHttpInfo (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlThreeYearsResponse</returns>
        TrialPlThreeYearsResponse GetTrialPlThreeYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlThreeYearsResponse</returns>
        ApiResponse<TrialPlThreeYearsResponse> GetTrialPlThreeYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlTwoYearsResponse</returns>
        TrialPlTwoYearsResponse GetTrialPlTwoYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlTwoYearsResponse</returns>
        ApiResponse<TrialPlTwoYearsResponse> GetTrialPlTwoYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITrialBalanceApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 貸借対照表の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsResponse</returns>
        System.Threading.Tasks.Task<TrialBsResponse> GetTrialBsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialBsResponse>> GetTrialBsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 貸借対照表(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsThreeYearsResponse</returns>
        System.Threading.Tasks.Task<TrialBsThreeYearsResponse> GetTrialBsThreeYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsThreeYearsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialBsThreeYearsResponse>> GetTrialBsThreeYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 貸借対照表(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsTwoYearsResponse</returns>
        System.Threading.Tasks.Task<TrialBsTwoYearsResponse> GetTrialBsTwoYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));

        /// <summary>
        /// 貸借対照表(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsTwoYearsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialBsTwoYearsResponse>> GetTrialBsTwoYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string));
        /// <summary>
        /// 損益計算書の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlResponse</returns>
        System.Threading.Tasks.Task<TrialPlResponse> GetTrialPlAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialPlResponse>> GetTrialPlAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(部門比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlSectionsResponse</returns>
        System.Threading.Tasks.Task<TrialPlSectionsResponse> GetTrialPlSectionsAsync (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(部門比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlSectionsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialPlSectionsResponse>> GetTrialPlSectionsAsyncWithHttpInfo (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlThreeYearsResponse</returns>
        System.Threading.Tasks.Task<TrialPlThreeYearsResponse> GetTrialPlThreeYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(３期間比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlThreeYearsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialPlThreeYearsResponse>> GetTrialPlThreeYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        /// <summary>
        /// 損益計算書(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlTwoYearsResponse</returns>
        System.Threading.Tasks.Task<TrialPlTwoYearsResponse> GetTrialPlTwoYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));

        /// <summary>
        /// 損益計算書(前年比較)の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlTwoYearsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<TrialPlTwoYearsResponse>> GetTrialPlTwoYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITrialBalanceApi : ITrialBalanceApiSync, ITrialBalanceApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TrialBalanceApi : ITrialBalanceApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBalanceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TrialBalanceApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBalanceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TrialBalanceApi(String basePath)
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
        /// Initializes a new instance of the <see cref="TrialBalanceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TrialBalanceApi(Freee.Accounting.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="TrialBalanceApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public TrialBalanceApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
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
        /// 貸借対照表の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsResponse</returns>
        public TrialBsResponse GetTrialBs (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsResponse> localVarResponse = GetTrialBsWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 貸借対照表の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialBsResponse > GetTrialBsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialBsResponse >("/api/1/reports/trial_bs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 貸借対照表の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsResponse</returns>
        public async System.Threading.Tasks.Task<TrialBsResponse> GetTrialBsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsResponse> localVarResponse = await GetTrialBsAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 貸借対照表の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialBsResponse>> GetTrialBsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialBsResponse>("/api/1/reports/trial_bs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 貸借対照表(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsThreeYearsResponse</returns>
        public TrialBsThreeYearsResponse GetTrialBsThreeYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsThreeYearsResponse> localVarResponse = GetTrialBsThreeYearsWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 貸借対照表(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsThreeYearsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialBsThreeYearsResponse > GetTrialBsThreeYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialBsThreeYearsResponse >("/api/1/reports/trial_bs_three_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBsThreeYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 貸借対照表(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsThreeYearsResponse</returns>
        public async System.Threading.Tasks.Task<TrialBsThreeYearsResponse> GetTrialBsThreeYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsThreeYearsResponse> localVarResponse = await GetTrialBsThreeYearsAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 貸借対照表(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_three_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsThreeYearsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialBsThreeYearsResponse>> GetTrialBsThreeYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialBsThreeYearsResponse>("/api/1/reports/trial_bs_three_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBsThreeYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 貸借対照表(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>TrialBsTwoYearsResponse</returns>
        public TrialBsTwoYearsResponse GetTrialBsTwoYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsTwoYearsResponse> localVarResponse = GetTrialBsTwoYearsWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 貸借対照表(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>ApiResponse of TrialBsTwoYearsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialBsTwoYearsResponse > GetTrialBsTwoYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialBsTwoYearsResponse >("/api/1/reports/trial_bs_two_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBsTwoYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 貸借対照表(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of TrialBsTwoYearsResponse</returns>
        public async System.Threading.Tasks.Task<TrialBsTwoYearsResponse> GetTrialBsTwoYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialBsTwoYearsResponse> localVarResponse = await GetTrialBsTwoYearsAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 貸借対照表(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の貸借対照表(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_bs_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_bs_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1000,         &amp;quot;account_item_name&amp;quot; : &amp;quot;現金&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;流動資産&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialBsTwoYearsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialBsTwoYearsResponse>> GetTrialBsTwoYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialBsTwoYearsResponse>("/api/1/reports/trial_bs_two_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBsTwoYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlResponse</returns>
        public TrialPlResponse GetTrialPl (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlResponse> localVarResponse = GetTrialPlWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 損益計算書の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialPlResponse > GetTrialPlWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialPlResponse >("/api/1/reports/trial_pl", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPl", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlResponse</returns>
        public async System.Threading.Tasks.Task<TrialPlResponse> GetTrialPlAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlResponse> localVarResponse = await GetTrialPlAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 損益計算書の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;opening_balance : 期首残高 &lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;debit_amount : 借方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;credit_amount:  貸方金額 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;composition_ratio : 構成比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&amp;amp;breakdown_display_type&#x3D;partner&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;breakdown_display_type&amp;quot; : &amp;quot;partner&amp;quot;,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;opening_balance&amp;quot; : 100000,         &amp;quot;debit_amount&amp;quot; : 50000,         &amp;quot;credit_amount&amp;quot; : 20000,         &amp;quot;closing_balance&amp;quot; : 130000,         &amp;quot;composition_ratio&amp;quot; : 0.25         &amp;quot;partners&amp;quot; : [{           &amp;quot;id&amp;quot; : 123,           &amp;quot;name&amp;quot; : &amp;quot;freee&amp;quot;,           &amp;quot;long_name&amp;quot; : &amp;quot;freee株式会社&amp;quot;,           &amp;quot;opening_balance&amp;quot; : 100000,           &amp;quot;debit_amount&amp;quot; : 50000,           &amp;quot;credit_amount&amp;quot; : 20000,           &amp;quot;closing_balance&amp;quot; : 130000,           &amp;quot;composition_ratio&amp;quot; : 0.25           },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialPlResponse>> GetTrialPlAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialPlResponse>("/api/1/reports/trial_pl", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPl", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(部門比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlSectionsResponse</returns>
        public TrialPlSectionsResponse GetTrialPlSections (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlSectionsResponse> localVarResponse = GetTrialPlSectionsWithHttpInfo(companyId, sectionIds, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment, costAllocation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 損益計算書(部門比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlSectionsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialPlSectionsResponse > GetTrialPlSectionsWithHttpInfo (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
            // verify the required parameter 'sectionIds' is set
            if (sectionIds == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'sectionIds' when calling TrialBalanceApi->GetTrialPlSections");

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
            if (sectionIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_ids", sectionIds));
            }
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialPlSectionsResponse >("/api/1/reports/trial_pl_sections", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlSections", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(部門比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlSectionsResponse</returns>
        public async System.Threading.Tasks.Task<TrialPlSectionsResponse> GetTrialPlSectionsAsync (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlSectionsResponse> localVarResponse = await GetTrialPlSectionsAsyncWithHttpInfo(companyId, sectionIds, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, adjustment, costAllocation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 損益計算書(部門比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(部門比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;個人向けのプレミアムプラン、法人向けのビジネスプラン以上で利用可能なAPIです。対象外のプランでは401エラーを返却します。&lt;/li&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;amp;section_ids&#x3D;1,2,3&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt;&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_sections&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;section_ids&amp;quot; : &amp;quot;1,2,3&amp;quot;,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;closing_balance&amp;quot; : 1000000,         &amp;quot;sections&amp;quot; : [{           &amp;quot;id&amp;quot;: 1           &amp;quot;name&amp;quot;: &amp;quot;営業部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 100000         },         {           &amp;quot;id&amp;quot;: 2           &amp;quot;name&amp;quot;: &amp;quot;広報部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 200000         },         {           &amp;quot;id&amp;quot;: 3           &amp;quot;name&amp;quot;: &amp;quot;人事部&amp;quot;,           &amp;quot;closing_balance&amp;quot; : 300000         },         ...         ]       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="sectionIds">出力する部門の指定（半角数字のidを半角カンマ区切りスペースなしで指定してください）</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlSectionsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialPlSectionsResponse>> GetTrialPlSectionsAsyncWithHttpInfo (int companyId, string sectionIds, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
            // verify the required parameter 'sectionIds' is set
            if (sectionIds == null)
                throw new Freee.Accounting.Client.ApiException(400, "Missing required parameter 'sectionIds' when calling TrialBalanceApi->GetTrialPlSections");


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
            if (sectionIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_ids", sectionIds));
            }
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialPlSectionsResponse>("/api/1/reports/trial_pl_sections", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlSections", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlThreeYearsResponse</returns>
        public TrialPlThreeYearsResponse GetTrialPlThreeYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlThreeYearsResponse> localVarResponse = GetTrialPlThreeYearsWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 損益計算書(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlThreeYearsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialPlThreeYearsResponse > GetTrialPlThreeYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialPlThreeYearsResponse >("/api/1/reports/trial_pl_three_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlThreeYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlThreeYearsResponse</returns>
        public async System.Threading.Tasks.Task<TrialPlThreeYearsResponse> GetTrialPlThreeYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlThreeYearsResponse> localVarResponse = await GetTrialPlThreeYearsAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 損益計算書(３期間比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(３期間比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;two_years_before_closing_balance:  前々年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt; &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_three_years?company_id&#x3D;1&amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_three_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;two_year_before_closing_balance&amp;quot; : 50000,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85       },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlThreeYearsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialPlThreeYearsResponse>> GetTrialPlThreeYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialPlThreeYearsResponse>("/api/1/reports/trial_pl_three_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlThreeYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>TrialPlTwoYearsResponse</returns>
        public TrialPlTwoYearsResponse GetTrialPlTwoYears (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlTwoYearsResponse> localVarResponse = GetTrialPlTwoYearsWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 損益計算書(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>ApiResponse of TrialPlTwoYearsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< TrialPlTwoYearsResponse > GetTrialPlTwoYearsWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< TrialPlTwoYearsResponse >("/api/1/reports/trial_pl_two_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlTwoYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 損益計算書(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of TrialPlTwoYearsResponse</returns>
        public async System.Threading.Tasks.Task<TrialPlTwoYearsResponse> GetTrialPlTwoYearsAsync (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
        {
             Freee.Accounting.Client.ApiResponse<TrialPlTwoYearsResponse> localVarResponse = await GetTrialPlTwoYearsAsyncWithHttpInfo(companyId, fiscalYear, startMonth, endMonth, startDate, endDate, accountItemDisplayType, breakdownDisplayType, partnerId, partnerCode, itemId, sectionId, adjustment, costAllocation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 損益計算書(前年比較)の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の損益計算書(前年比較)を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt;  &lt;li&gt; &lt;p&gt;created_at : 作成日時&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;account_item_name : 勘定科目名&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;hierarchy_level: 階層レベル&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;parent_account_item_name: 親の勘定科目名&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;last_year_closing_balance:  前年度期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;closing_balance : 期末残高 &lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;year_on_year : 前年比&lt;/p&gt; &lt;/li&gt; &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt; &lt;ul&gt; &lt;li&gt;会計年度が指定されない場合、現在の会計年度がデフォルトとなります。&lt;/li&gt; &lt;li&gt;絞り込み条件の日付と、月または年度は同時に指定することはできません。&lt;/li&gt; &lt;li&gt;up_to_dateがfalseの場合、残高の集計が完了していません。最新の集計結果を確認したい場合は、時間を空けて再度取得する必要があります。&lt;/li&gt;  &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_4\&quot;&gt;レスポンスの例&lt;/h2&gt;  &lt;blockquote&gt; &lt;p&gt;GET https://api.freee.co.jp/api/1/reports/trial_pl_two_years?company_id&#x3D;1&amp;amp;fiscal_year&#x3D;2017&lt;/p&gt; &lt;/blockquote&gt;  &lt;pre&gt;&lt;code&gt;{   &amp;quot;trial_pl_two_years&amp;quot; :     {       &amp;quot;company_id&amp;quot; : 1,       &amp;quot;fiscal_year&amp;quot; : 2017,       &amp;quot;created_at&amp;quot; : &amp;quot;2018-05-01 12:00:50&amp;quot       &amp;quot;balances&amp;quot; : [{         &amp;quot;account_item_id&amp;quot; : 1500,         &amp;quot;account_item_name&amp;quot; : &amp;quot;売上高&amp;quot;,         &amp;quot;hierarchy_level&amp;quot; : 2,         &amp;quot;parent_account_item_id&amp;quot; : 100;         &amp;quot;parent_account_item_name&amp;quot; : &amp;quot;営業収益&amp;quot;,         &amp;quot;last_year_closing_balance&amp;quot; : 25000,         &amp;quot;closing_balance&amp;quot; : 100000,         &amp;quot;year_on_year&amp;quot; : 0.85        },       ...       ]     } }&lt;/code&gt;&lt;/pre&gt; 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="fiscalYear">会計年度 (optional)</param>
        /// <param name="startMonth">発生月で絞込：開始会計月(mm) (optional)</param>
        /// <param name="endMonth">発生月で絞込：終了会計月(mm) (optional)</param>
        /// <param name="startDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="accountItemDisplayType">勘定科目の表示（勘定科目: account_item, 決算書表示:group） (optional)</param>
        /// <param name="breakdownDisplayType">内訳の表示（取引先: partner, 品目: item, 部門: section, 勘定科目: account_item） ※勘定科目はaccount_item_display_typeが「group」の時のみ指定できます (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択で絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込（事業所設定で取引先コードの利用を有効にしている場合のみ利用可能です） (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択で絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択で絞り込めます） (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="costAllocation">配賦仕訳で絞込（配賦仕訳のみ：only,配賦仕訳以外：without） (optional)</param>
        /// <returns>Task of ApiResponse (TrialPlTwoYearsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<TrialPlTwoYearsResponse>> GetTrialPlTwoYearsAsyncWithHttpInfo (int companyId, int? fiscalYear = default(int?), int? startMonth = default(int?), int? endMonth = default(int?), string startDate = default(string), string endDate = default(string), string accountItemDisplayType = default(string), string breakdownDisplayType = default(string), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), string adjustment = default(string), string costAllocation = default(string))
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
            if (fiscalYear != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "fiscal_year", fiscalYear));
            }
            if (startMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_month", startMonth));
            }
            if (endMonth != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_month", endMonth));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (accountItemDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_display_type", accountItemDisplayType));
            }
            if (breakdownDisplayType != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "breakdown_display_type", breakdownDisplayType));
            }
            if (partnerId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId));
            }
            if (partnerCode != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode));
            }
            if (itemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "item_id", itemId));
            }
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (costAllocation != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "cost_allocation", costAllocation));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TrialPlTwoYearsResponse>("/api/1/reports/trial_pl_two_years", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialPlTwoYears", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
