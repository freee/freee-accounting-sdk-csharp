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
    public interface IDealsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 取引（収入／支出）の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>DealsCreateResponse</returns>
        DealsCreateResponse CreateDeal (CreateDealParams parameters = default(CreateDealParams));

        /// <summary>
        /// 取引（収入／支出）の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>ApiResponse of DealsCreateResponse</returns>
        ApiResponse<DealsCreateResponse> CreateDealWithHttpInfo (CreateDealParams parameters = default(CreateDealParams));
        /// <summary>
        /// 取引（収入／支出）の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        void DestroyDeal (int id, int companyId);

        /// <summary>
        /// 取引（収入／支出）の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DestroyDealWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 取引（収入／支出）の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>DealsResponse</returns>
        DealsResponse GetDeal (int companyId, int id, string accruals = default(string));

        /// <summary>
        /// 取引（収入／支出）の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>ApiResponse of DealsResponse</returns>
        ApiResponse<DealsResponse> GetDealWithHttpInfo (int companyId, int id, string accruals = default(string));
        /// <summary>
        /// 取引（収入／支出）一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>DealsIndexResponse</returns>
        DealsIndexResponse GetDeals (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string));

        /// <summary>
        /// 取引（収入／支出）一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>ApiResponse of DealsIndexResponse</returns>
        ApiResponse<DealsIndexResponse> GetDealsWithHttpInfo (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string));
        /// <summary>
        /// 取引（収入／支出）の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>DealsResponse</returns>
        DealsResponse UpdateDeal (int id, UpdateDealParams parameters = default(UpdateDealParams));

        /// <summary>
        /// 取引（収入／支出）の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>ApiResponse of DealsResponse</returns>
        ApiResponse<DealsResponse> UpdateDealWithHttpInfo (int id, UpdateDealParams parameters = default(UpdateDealParams));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDealsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 取引（収入／支出）の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>Task of DealsCreateResponse</returns>
        System.Threading.Tasks.Task<DealsCreateResponse> CreateDealAsync (CreateDealParams parameters = default(CreateDealParams));

        /// <summary>
        /// 取引（収入／支出）の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>Task of ApiResponse (DealsCreateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DealsCreateResponse>> CreateDealAsyncWithHttpInfo (CreateDealParams parameters = default(CreateDealParams));
        /// <summary>
        /// 取引（収入／支出）の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DestroyDealAsync (int id, int companyId);

        /// <summary>
        /// 取引（収入／支出）の削除
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DestroyDealAsyncWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 取引（収入／支出）の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of DealsResponse</returns>
        System.Threading.Tasks.Task<DealsResponse> GetDealAsync (int companyId, int id, string accruals = default(string));

        /// <summary>
        /// 取引（収入／支出）の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of ApiResponse (DealsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DealsResponse>> GetDealAsyncWithHttpInfo (int companyId, int id, string accruals = default(string));
        /// <summary>
        /// 取引（収入／支出）一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of DealsIndexResponse</returns>
        System.Threading.Tasks.Task<DealsIndexResponse> GetDealsAsync (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string));

        /// <summary>
        /// 取引（収入／支出）一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of ApiResponse (DealsIndexResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DealsIndexResponse>> GetDealsAsyncWithHttpInfo (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string));
        /// <summary>
        /// 取引（収入／支出）の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>Task of DealsResponse</returns>
        System.Threading.Tasks.Task<DealsResponse> UpdateDealAsync (int id, UpdateDealParams parameters = default(UpdateDealParams));

        /// <summary>
        /// 取引（収入／支出）の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>Task of ApiResponse (DealsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DealsResponse>> UpdateDealAsyncWithHttpInfo (int id, UpdateDealParams parameters = default(UpdateDealParams));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDealsApi : IDealsApiSync, IDealsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DealsApi : IDealsApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DealsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DealsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DealsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DealsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="DealsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DealsApi(Freee.Accounting.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="DealsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DealsApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
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
        /// 取引（収入／支出）の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>DealsCreateResponse</returns>
        public DealsCreateResponse CreateDeal (CreateDealParams parameters = default(CreateDealParams))
        {
             Freee.Accounting.Client.ApiResponse<DealsCreateResponse> localVarResponse = CreateDealWithHttpInfo(parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 取引（収入／支出）の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>ApiResponse of DealsCreateResponse</returns>
        public Freee.Accounting.Client.ApiResponse< DealsCreateResponse > CreateDealWithHttpInfo (CreateDealParams parameters = default(CreateDealParams))
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

            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post< DealsCreateResponse >("/api/1/deals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>Task of DealsCreateResponse</returns>
        public async System.Threading.Tasks.Task<DealsCreateResponse> CreateDealAsync (CreateDealParams parameters = default(CreateDealParams))
        {
             Freee.Accounting.Client.ApiResponse<DealsCreateResponse> localVarResponse = await CreateDealAsyncWithHttpInfo(parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 取引（収入／支出）の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;ref_number : 管理番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;tax_code, tax_idはどちらかの指定が必須です。両方指定した場合はtax_codeが優先されます。&lt;/p&gt; &lt;/li&gt; &lt;p&gt;&lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成APIをご利用ください。&lt;/p&gt;&lt;/li&gt;  &lt;p&gt;&lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/p&gt;&lt;/li&gt;  &lt;li&gt; &lt;p&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/p&gt;&lt;/li&gt; &lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">取引（収入／支出）の作成 (optional)</param>
        /// <returns>Task of ApiResponse (DealsCreateResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<DealsCreateResponse>> CreateDealAsyncWithHttpInfo (CreateDealParams parameters = default(CreateDealParams))
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
            
            localVarRequestOptions.Data = parameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DealsCreateResponse>("/api/1/deals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        public void DestroyDeal (int id, int companyId)
        {
             DestroyDealWithHttpInfo(id, companyId);
        }

        /// <summary>
        /// 取引（収入／支出）の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Freee.Accounting.Client.ApiResponse<Object> DestroyDealWithHttpInfo (int id, int companyId)
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
            var localVarResponse = this.Client.Delete<Object>("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DestroyDealAsync (int id, int companyId)
        {
             await DestroyDealAsyncWithHttpInfo(id, companyId);

        }

        /// <summary>
        /// 取引（収入／支出）の削除 
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<Object>> DestroyDealAsyncWithHttpInfo (int id, int companyId)
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

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>DealsResponse</returns>
        public DealsResponse GetDeal (int companyId, int id, string accruals = default(string))
        {
             Freee.Accounting.Client.ApiResponse<DealsResponse> localVarResponse = GetDealWithHttpInfo(companyId, id, accruals);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 取引（収入／支出）の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>ApiResponse of DealsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< DealsResponse > GetDealWithHttpInfo (int companyId, int id, string accruals = default(string))
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
            if (accruals != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "accruals", accruals))
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
            var localVarResponse = this.Client.Get< DealsResponse >("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of DealsResponse</returns>
        public async System.Threading.Tasks.Task<DealsResponse> GetDealAsync (int companyId, int id, string accruals = default(string))
        {
             Freee.Accounting.Client.ApiResponse<DealsResponse> localVarResponse = await GetDealAsyncWithHttpInfo(companyId, id, accruals);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 取引（収入／支出）の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of ApiResponse (DealsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<DealsResponse>> GetDealAsyncWithHttpInfo (int companyId, int id, string accruals = default(string))
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
            if (accruals != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "accruals", accruals))
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<DealsResponse>("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>DealsIndexResponse</returns>
        public DealsIndexResponse GetDeals (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string))
        {
             Freee.Accounting.Client.ApiResponse<DealsIndexResponse> localVarResponse = GetDealsWithHttpInfo(companyId, partnerId, accountItemId, partnerCode, status, type, startIssueDate, endIssueDate, startDueDate, endDueDate, startRenewDate, endRenewDate, offset, limit, registeredFrom, accruals);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 取引（収入／支出）一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>ApiResponse of DealsIndexResponse</returns>
        public Freee.Accounting.Client.ApiResponse< DealsIndexResponse > GetDealsWithHttpInfo (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string))
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

            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (partnerId != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (accountItemId != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_id", accountItemId))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (partnerCode != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (status != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "status", status))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (type != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "type", type))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startIssueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_issue_date", startIssueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endIssueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_issue_date", endIssueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_due_date", startDueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_due_date", endDueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startRenewDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_renew_date", startRenewDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endRenewDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_renew_date", endRenewDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (offset != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "offset", offset))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (limit != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "limit", limit))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (registeredFrom != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "registered_from", registeredFrom))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (accruals != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "accruals", accruals))
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
            var localVarResponse = this.Client.Get< DealsIndexResponse >("/api/1/deals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDeals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of DealsIndexResponse</returns>
        public async System.Threading.Tasks.Task<DealsIndexResponse> GetDealsAsync (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string))
        {
             Freee.Accounting.Client.ApiResponse<DealsIndexResponse> localVarResponse = await GetDealsAsyncWithHttpInfo(companyId, partnerId, accountItemId, partnerCode, status, type, startIssueDate, endIssueDate, startDueDate, endDueDate, startRenewDate, endRenewDate, offset, limit, registeredFrom, accruals);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 取引（収入／支出）一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引一覧（収入／支出）を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;accruals : 取引の債権債務行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt;  &lt;li&gt;credit_card : クレジットカード&lt;/li&gt;  &lt;li&gt;wallet : 現金&lt;/li&gt;  &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;registered_from&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;all : すべての取引&lt;/li&gt;  &lt;li&gt;me : 自身が登録した取引&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;tax_idは廃止予定です。tax_codeをご利用ください。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="partnerId">取引先IDで絞込 (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="status">決済状況で絞込 (未決済: unsettled, 完了: settled) (optional)</param>
        /// <param name="type">収支区分 (収入: income, 支出: expense) (optional)</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startDueDate">支払期日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endDueDate">支払期日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="startRenewDate">+更新日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endRenewDate">+更新日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 100)  (optional)</param>
        /// <param name="registeredFrom">取引登録元アプリで絞込（me: 本APIを叩くアプリ自身から登録した取引のみ） (optional)</param>
        /// <param name="accruals">取引の債権債務行の表示（without: 表示しない(デフォルト), with: 表示する） (optional)</param>
        /// <returns>Task of ApiResponse (DealsIndexResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<DealsIndexResponse>> GetDealsAsyncWithHttpInfo (int companyId, int? partnerId = default(int?), int? accountItemId = default(int?), string partnerCode = default(string), string status = default(string), string type = default(string), string startIssueDate = default(string), string endIssueDate = default(string), string startDueDate = default(string), string endDueDate = default(string), string startRenewDate = default(string), string endRenewDate = default(string), int? offset = default(int?), int? limit = default(int?), string registeredFrom = default(string), string accruals = default(string))
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
            
            foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "company_id", companyId))
            {
                foreach (var _kvpValue in _kvp.Value)
                {
                    localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                }
            }
            if (partnerId != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_id", partnerId))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (accountItemId != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_id", accountItemId))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (partnerCode != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "partner_code", partnerCode))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (status != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "status", status))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (type != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "type", type))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startIssueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_issue_date", startIssueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endIssueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_issue_date", endIssueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startDueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_due_date", startDueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endDueDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_due_date", endDueDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (startRenewDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_renew_date", startRenewDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (endRenewDate != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_renew_date", endRenewDate))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (offset != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "offset", offset))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (limit != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "limit", limit))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (registeredFrom != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "registered_from", registeredFrom))
                {
                    foreach (var _kvpValue in _kvp.Value)
                    {
                        localVarRequestOptions.QueryParameters.Add(_kvp.Key, _kvpValue);
                    }
                }
            }
            if (accruals != null)
            {
                foreach (var _kvp in Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "accruals", accruals))
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<DealsIndexResponse>("/api/1/deals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDeals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>DealsResponse</returns>
        public DealsResponse UpdateDeal (int id, UpdateDealParams parameters = default(UpdateDealParams))
        {
             Freee.Accounting.Client.ApiResponse<DealsResponse> localVarResponse = UpdateDealWithHttpInfo(id, parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 取引（収入／支出）の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>ApiResponse of DealsResponse</returns>
        public Freee.Accounting.Client.ApiResponse< DealsResponse > UpdateDealWithHttpInfo (int id, UpdateDealParams parameters = default(UpdateDealParams))
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
            var localVarResponse = this.Client.Put< DealsResponse >("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 取引（収入／支出）の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>Task of DealsResponse</returns>
        public async System.Threading.Tasks.Task<DealsResponse> UpdateDealAsync (int id, UpdateDealParams parameters = default(UpdateDealParams))
        {
             Freee.Accounting.Client.ApiResponse<DealsResponse> localVarResponse = await UpdateDealAsyncWithHttpInfo(id, parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 取引（収入／支出）の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の取引（収入／支出）を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_date : 支払期日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;due_amount : 支払残額&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;type&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;income : 収入&lt;/li&gt;  &lt;li&gt;expense : 支出&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 取引の明細行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;renews : 取引の+更新行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;payments : 取引の支払行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;from_walletable_type&lt;/p&gt; &lt;ul&gt; &lt;li&gt;bank_account : 銀行口座&lt;/li&gt; &lt;li&gt;credit_card : クレジットカード&lt;/li&gt; &lt;li&gt;wallet : 現金&lt;/li&gt; &lt;li&gt;private_account_item : プライベート資金（法人の場合は役員借入金もしくは役員借入金、個人の場合は事業主貸もしくは事業主借）&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;receipt_ids : 証憑ファイルID&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;本APIでは支払行(payments)の操作ができません。支払行の作成・更新・削除APIをご利用ください。&lt;/li&gt; &lt;li&gt;本APIでは+更新行(renews)の操作ができません。+更新行の作成・更新・削除APIをご利用ください。&lt;/li&gt;  &lt;li&gt;本APIでは収入／支出の切替えができません。既存の取引を削除後、再度作成してください。&lt;/li&gt;  &lt;li&gt;本APIで取引を更新すると、消費税の計算方法は必ず内税方式が選択されます。&lt;/li&gt;  &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">取引ID</param>
        /// <param name="parameters">取引（収入／支出）の更新 (optional)</param>
        /// <returns>Task of ApiResponse (DealsResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<DealsResponse>> UpdateDealAsyncWithHttpInfo (int id, UpdateDealParams parameters = default(UpdateDealParams))
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

            var localVarResponse = await this.AsynchronousClient.PutAsync<DealsResponse>("/api/1/deals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateDeal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
