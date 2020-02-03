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
    public interface IManualJournalsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 振替伝票の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>ManualJournalsCreateResponse</returns>
        ManualJournalsCreateResponse CreateManualJournal (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams));

        /// <summary>
        /// 振替伝票の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>ApiResponse of ManualJournalsCreateResponse</returns>
        ApiResponse<ManualJournalsCreateResponse> CreateManualJournalWithHttpInfo (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams));
        /// <summary>
        /// 振替伝票の削除
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        void DestroyManualJournal (int id, int companyId);

        /// <summary>
        /// 振替伝票の削除
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DestroyManualJournalWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 振替伝票の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>ManualJournalsShowResponse</returns>
        ManualJournalsShowResponse GetManualJournal (int companyId, int id);

        /// <summary>
        /// 振替伝票の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of ManualJournalsShowResponse</returns>
        ApiResponse<ManualJournalsShowResponse> GetManualJournalWithHttpInfo (int companyId, int id);
        /// <summary>
        /// 振替伝票一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>ManualJournalsIndexResponse</returns>
        ManualJournalsIndexResponse GetManualJournals (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?));

        /// <summary>
        /// 振替伝票一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>ApiResponse of ManualJournalsIndexResponse</returns>
        ApiResponse<ManualJournalsIndexResponse> GetManualJournalsWithHttpInfo (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?));
        /// <summary>
        /// 振替伝票の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>ManualJournalsUpdateResponse</returns>
        ManualJournalsUpdateResponse UpdateManualJournal (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams));

        /// <summary>
        /// 振替伝票の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>ApiResponse of ManualJournalsUpdateResponse</returns>
        ApiResponse<ManualJournalsUpdateResponse> UpdateManualJournalWithHttpInfo (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IManualJournalsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 振替伝票の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>Task of ManualJournalsCreateResponse</returns>
        System.Threading.Tasks.Task<ManualJournalsCreateResponse> CreateManualJournalAsync (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams));

        /// <summary>
        /// 振替伝票の作成
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsCreateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ManualJournalsCreateResponse>> CreateManualJournalAsyncWithHttpInfo (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams));
        /// <summary>
        /// 振替伝票の削除
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DestroyManualJournalAsync (int id, int companyId);

        /// <summary>
        /// 振替伝票の削除
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DestroyManualJournalAsyncWithHttpInfo (int id, int companyId);
        /// <summary>
        /// 振替伝票の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>Task of ManualJournalsShowResponse</returns>
        System.Threading.Tasks.Task<ManualJournalsShowResponse> GetManualJournalAsync (int companyId, int id);

        /// <summary>
        /// 振替伝票の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>Task of ApiResponse (ManualJournalsShowResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ManualJournalsShowResponse>> GetManualJournalAsyncWithHttpInfo (int companyId, int id);
        /// <summary>
        /// 振替伝票一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>Task of ManualJournalsIndexResponse</returns>
        System.Threading.Tasks.Task<ManualJournalsIndexResponse> GetManualJournalsAsync (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?));

        /// <summary>
        /// 振替伝票一覧の取得
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsIndexResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ManualJournalsIndexResponse>> GetManualJournalsAsyncWithHttpInfo (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?));
        /// <summary>
        /// 振替伝票の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>Task of ManualJournalsUpdateResponse</returns>
        System.Threading.Tasks.Task<ManualJournalsUpdateResponse> UpdateManualJournalAsync (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams));

        /// <summary>
        /// 振替伝票の更新
        /// </summary>
        /// <remarks>
        ///  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </remarks>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsUpdateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ManualJournalsUpdateResponse>> UpdateManualJournalAsyncWithHttpInfo (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IManualJournalsApi : IManualJournalsApiSync, IManualJournalsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ManualJournalsApi : IManualJournalsApi
    {
        private Freee.Accounting.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ManualJournalsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManualJournalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ManualJournalsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="ManualJournalsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ManualJournalsApi(Freee.Accounting.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ManualJournalsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ManualJournalsApi(Freee.Accounting.Client.ISynchronousClient client,Freee.Accounting.Client.IAsynchronousClient asyncClient, Freee.Accounting.Client.IReadableConfiguration configuration)
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
        /// 振替伝票の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>ManualJournalsCreateResponse</returns>
        public ManualJournalsCreateResponse CreateManualJournal (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsCreateResponse> localVarResponse = CreateManualJournalWithHttpInfo(parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 振替伝票の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>ApiResponse of ManualJournalsCreateResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ManualJournalsCreateResponse > CreateManualJournalWithHttpInfo (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams))
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
            var localVarResponse = this.Client.Post< ManualJournalsCreateResponse >("/api/1/manual_journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>Task of ManualJournalsCreateResponse</returns>
        public async System.Threading.Tasks.Task<ManualJournalsCreateResponse> CreateManualJournalAsync (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsCreateResponse> localVarResponse = await CreateManualJournalAsyncWithHttpInfo(parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 振替伝票の作成  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を作成する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters">振替伝票の作成 (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsCreateResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ManualJournalsCreateResponse>> CreateManualJournalAsyncWithHttpInfo (ManualJournalsCreateParams parameters = default(ManualJournalsCreateParams))
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

            var localVarResponse = await this.AsynchronousClient.PostAsync<ManualJournalsCreateResponse>("/api/1/manual_journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の削除  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns></returns>
        public void DestroyManualJournal (int id, int companyId)
        {
             DestroyManualJournalWithHttpInfo(id, companyId);
        }

        /// <summary>
        /// 振替伝票の削除  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Freee.Accounting.Client.ApiResponse<Object> DestroyManualJournalWithHttpInfo (int id, int companyId)
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
            var localVarResponse = this.Client.Delete<Object>("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の削除  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DestroyManualJournalAsync (int id, int companyId)
        {
             await DestroyManualJournalAsyncWithHttpInfo(id, companyId);

        }

        /// <summary>
        /// 振替伝票の削除  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を削除する&lt;/p&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="companyId">事業所ID</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<Object>> DestroyManualJournalAsyncWithHttpInfo (int id, int companyId)
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

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DestroyManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>ManualJournalsShowResponse</returns>
        public ManualJournalsShowResponse GetManualJournal (int companyId, int id)
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsShowResponse> localVarResponse = GetManualJournalWithHttpInfo(companyId, id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 振替伝票の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>ApiResponse of ManualJournalsShowResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ManualJournalsShowResponse > GetManualJournalWithHttpInfo (int companyId, int id)
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
            var localVarResponse = this.Client.Get< ManualJournalsShowResponse >("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>Task of ManualJournalsShowResponse</returns>
        public async System.Threading.Tasks.Task<ManualJournalsShowResponse> GetManualJournalAsync (int companyId, int id)
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsShowResponse> localVarResponse = await GetManualJournalAsyncWithHttpInfo(companyId, id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 振替伝票の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt; &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt; &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt; &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="id"></param>
        /// <returns>Task of ApiResponse (ManualJournalsShowResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ManualJournalsShowResponse>> GetManualJournalAsyncWithHttpInfo (int companyId, int id)
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<ManualJournalsShowResponse>("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>ManualJournalsIndexResponse</returns>
        public ManualJournalsIndexResponse GetManualJournals (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsIndexResponse> localVarResponse = GetManualJournalsWithHttpInfo(companyId, startIssueDate, endIssueDate, entrySide, accountItemId, minAmount, maxAmount, partnerId, partnerCode, itemId, sectionId, segment1TagId, segment2TagId, segment3TagId, commentStatus, commentImportant, adjustment, txnNumber, offset, limit);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 振替伝票一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>ApiResponse of ManualJournalsIndexResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ManualJournalsIndexResponse > GetManualJournalsWithHttpInfo (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?))
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
            if (startIssueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_issue_date", startIssueDate));
            }
            if (endIssueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_issue_date", endIssueDate));
            }
            if (entrySide != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "entry_side", entrySide));
            }
            if (accountItemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_id", accountItemId));
            }
            if (minAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "min_amount", minAmount));
            }
            if (maxAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "max_amount", maxAmount));
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
            if (segment1TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_1_tag_id", segment1TagId));
            }
            if (segment2TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_2_tag_id", segment2TagId));
            }
            if (segment3TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_3_tag_id", segment3TagId));
            }
            if (commentStatus != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "comment_status", commentStatus));
            }
            if (commentImportant != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "comment_important", commentImportant));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (txnNumber != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "txn_number", txnNumber));
            }
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
            var localVarResponse = this.Client.Get< ManualJournalsIndexResponse >("/api/1/manual_journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetManualJournals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>Task of ManualJournalsIndexResponse</returns>
        public async System.Threading.Tasks.Task<ManualJournalsIndexResponse> GetManualJournalsAsync (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsIndexResponse> localVarResponse = await GetManualJournalsAsyncWithHttpInfo(companyId, startIssueDate, endIssueDate, entrySide, accountItemId, minAmount, maxAmount, partnerId, partnerCode, itemId, sectionId, segment1TagId, segment2TagId, segment3TagId, commentStatus, commentImportant, adjustment, txnNumber, offset, limit);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 振替伝票一覧の取得  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票一覧を取得する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt; &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="companyId">事業所ID</param>
        /// <param name="startIssueDate">発生日で絞込：開始日(yyyy-mm-dd) (optional)</param>
        /// <param name="endIssueDate">発生日で絞込：終了日(yyyy-mm-dd) (optional)</param>
        /// <param name="entrySide">貸借で絞込 (貸方: credit, 借方: debit) (optional)</param>
        /// <param name="accountItemId">勘定科目IDで絞込 (optional)</param>
        /// <param name="minAmount">金額で絞込：下限 (optional)</param>
        /// <param name="maxAmount">金額で絞込：上限 (optional)</param>
        /// <param name="partnerId">取引先IDで絞込（0を指定すると、取引先が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="partnerCode">取引先コードで絞込 (optional)</param>
        /// <param name="itemId">品目IDで絞込（0を指定すると、品目が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="sectionId">部門IDで絞込（0を指定すると、部門が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment1TagId">セグメント１IDで絞り込み（0を指定すると、セグメント１が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment2TagId">セグメント２IDで絞り込み（0を指定すると、セグメント２が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="segment3TagId">セグメント３IDで絞り込み（0を指定すると、セグメント３が未選択の貸借行を絞り込めます） (optional)</param>
        /// <param name="commentStatus">コメント状態で絞込（自分宛のコメント: posted_with_mention, 自分宛のコメント-未解決: raised_with_mention, 自分宛のコメント-解決済: resolved_with_mention, コメントあり: posted, 未解決: raised, 解決済: resolved, コメントなし: none） (optional)</param>
        /// <param name="commentImportant">重要コメント付きの振替伝票を絞込 (optional)</param>
        /// <param name="adjustment">決算整理仕訳で絞込（決算整理仕訳のみ: only, 決算整理仕訳以外: without） (optional)</param>
        /// <param name="txnNumber">仕訳番号で絞込（事業所の仕訳番号形式が有効な場合のみ） (optional)</param>
        /// <param name="offset">取得レコードのオフセット (デフォルト: 0) (optional)</param>
        /// <param name="limit">取得レコードの件数 (デフォルト: 20, 最大: 500)  (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsIndexResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ManualJournalsIndexResponse>> GetManualJournalsAsyncWithHttpInfo (int companyId, string startIssueDate = default(string), string endIssueDate = default(string), string entrySide = default(string), int? accountItemId = default(int?), int? minAmount = default(int?), int? maxAmount = default(int?), int? partnerId = default(int?), string partnerCode = default(string), int? itemId = default(int?), int? sectionId = default(int?), int? segment1TagId = default(int?), int? segment2TagId = default(int?), int? segment3TagId = default(int?), string commentStatus = default(string), bool? commentImportant = default(bool?), string adjustment = default(string), string txnNumber = default(string), int? offset = default(int?), int? limit = default(int?))
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
            if (startIssueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "start_issue_date", startIssueDate));
            }
            if (endIssueDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "end_issue_date", endIssueDate));
            }
            if (entrySide != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "entry_side", entrySide));
            }
            if (accountItemId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "account_item_id", accountItemId));
            }
            if (minAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "min_amount", minAmount));
            }
            if (maxAmount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "max_amount", maxAmount));
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
            if (segment1TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_1_tag_id", segment1TagId));
            }
            if (segment2TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_2_tag_id", segment2TagId));
            }
            if (segment3TagId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "segment_3_tag_id", segment3TagId));
            }
            if (commentStatus != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "comment_status", commentStatus));
            }
            if (commentImportant != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "comment_important", commentImportant));
            }
            if (adjustment != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "adjustment", adjustment));
            }
            if (txnNumber != null)
            {
                localVarRequestOptions.QueryParameters.Add(Freee.Accounting.Client.ClientUtils.ParameterToMultiMap("", "txn_number", txnNumber));
            }
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<ManualJournalsIndexResponse>("/api/1/manual_journals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetManualJournals", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>ManualJournalsUpdateResponse</returns>
        public ManualJournalsUpdateResponse UpdateManualJournal (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsUpdateResponse> localVarResponse = UpdateManualJournalWithHttpInfo(id, parameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// 振替伝票の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>ApiResponse of ManualJournalsUpdateResponse</returns>
        public Freee.Accounting.Client.ApiResponse< ManualJournalsUpdateResponse > UpdateManualJournalWithHttpInfo (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams))
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
            var localVarResponse = this.Client.Put< ManualJournalsUpdateResponse >("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// 振替伝票の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>Task of ManualJournalsUpdateResponse</returns>
        public async System.Threading.Tasks.Task<ManualJournalsUpdateResponse> UpdateManualJournalAsync (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams))
        {
             Freee.Accounting.Client.ApiResponse<ManualJournalsUpdateResponse> localVarResponse = await UpdateManualJournalAsyncWithHttpInfo(id, parameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// 振替伝票の更新  &lt;h2 id&#x3D;\&quot;\&quot;&gt;概要&lt;/h2&gt;  &lt;p&gt;指定した事業所の振替伝票を更新する&lt;/p&gt;  &lt;h2 id&#x3D;\&quot;_2\&quot;&gt;定義&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt; &lt;p&gt;issue_date : 発生日&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;adjustment : 決算整理仕訳フラグ（true: 決算整理仕訳, false: 日常仕訳）&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;txn_number : 仕訳番号&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;details : 振替伝票の貸借行&lt;/p&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;entry_side : 貸借区分&lt;/p&gt;  &lt;ul&gt; &lt;li&gt;credit : 貸方&lt;/li&gt;  &lt;li&gt;debit : 借方&lt;/li&gt; &lt;/ul&gt; &lt;/li&gt;  &lt;li&gt; &lt;p&gt;amount : 金額&lt;/p&gt; &lt;/li&gt; &lt;/ul&gt;  &lt;h2 id&#x3D;\&quot;_3\&quot;&gt;注意点&lt;/h2&gt;  &lt;ul&gt; &lt;li&gt;振替伝票は売掛・買掛レポートには反映されません。債権・債務データの登録は取引(Deals)をお使いください。&lt;/li&gt;  &lt;li&gt;事業所の仕訳番号形式が有効な場合のみ、レスポンスで仕訳番号(txn_number)を返します。&lt;/li&gt; &lt;li&gt;貸借合わせて100行まで仕訳行を登録できます。&lt;/li&gt;  &lt;li&gt;detailsに含まれない既存の貸借行は削除されます。更新後も残したい行は、必ず貸借行IDを指定してdetailsに含めてください。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がある行は、更新行として扱われ更新されます。&lt;/li&gt;  &lt;li&gt;detailsに含まれる貸借行IDの指定がない行は、新規行として扱われ追加されます。&lt;/li&gt; &lt;li&gt;セグメントタグ情報は法人向けのプロフェッショナルプラン以上で利用可能です。利用可能なセグメントの数は、法人向けのプロフェッショナルプランの場合は1つ、エンタープライズプランの場合は3つです。&lt;/li&gt; &lt;li&gt;partner_codeを利用するには、事業所の設定から取引先コードの利用を有効にする必要があります。またpartner_codeとpartner_idは同時に指定することはできません。&lt;/li&gt;&lt;/ul&gt;  
        /// </summary>
        /// <exception cref="Freee.Accounting.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="parameters">振替伝票の更新 (optional)</param>
        /// <returns>Task of ApiResponse (ManualJournalsUpdateResponse)</returns>
        public async System.Threading.Tasks.Task<Freee.Accounting.Client.ApiResponse<ManualJournalsUpdateResponse>> UpdateManualJournalAsyncWithHttpInfo (int id, ManualJournalsUpdateParams parameters = default(ManualJournalsUpdateParams))
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

            var localVarResponse = await this.AsynchronousClient.PutAsync<ManualJournalsUpdateResponse>("/api/1/manual_journals/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateManualJournal", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
