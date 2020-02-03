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
    /// UpdateCompanyParamsSalesInformationAttributes
    /// </summary>
    [DataContract]
    public partial class UpdateCompanyParamsSalesInformationAttributes :  IEquatable<UpdateCompanyParamsSalesInformationAttributes>
    {
        /// <summary>
        /// 種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）Available values : agriculture_forestry_fisheries_ore, construction, manufacturing_processing, it, transportation_logistics, retail_wholesale, finance_insurance, real_estate_rental, profession, design_production, food, leisure_entertainment, lifestyle, education, medical_welfare, other_services, other
        /// </summary>
        /// <value>種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）Available values : agriculture_forestry_fisheries_ore, construction, manufacturing_processing, it, transportation_logistics, retail_wholesale, finance_insurance, real_estate_rental, profession, design_production, food, leisure_entertainment, lifestyle, education, medical_welfare, other_services, other</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IndustryClassEnum
        {
            /// <summary>
            /// Enum Agricultureforestryfisheriesore for value: agriculture_forestry_fisheries_ore
            /// </summary>
            [EnumMember(Value = "agriculture_forestry_fisheries_ore")]
            Agricultureforestryfisheriesore = 1,

            /// <summary>
            /// Enum Construction for value: construction
            /// </summary>
            [EnumMember(Value = "construction")]
            Construction = 2,

            /// <summary>
            /// Enum Manufacturingprocessing for value: manufacturing_processing
            /// </summary>
            [EnumMember(Value = "manufacturing_processing")]
            Manufacturingprocessing = 3,

            /// <summary>
            /// Enum It for value: it
            /// </summary>
            [EnumMember(Value = "it")]
            It = 4,

            /// <summary>
            /// Enum Transportationlogistics for value: transportation_logistics
            /// </summary>
            [EnumMember(Value = "transportation_logistics")]
            Transportationlogistics = 5,

            /// <summary>
            /// Enum Retailwholesale for value: retail_wholesale
            /// </summary>
            [EnumMember(Value = "retail_wholesale")]
            Retailwholesale = 6,

            /// <summary>
            /// Enum Financeinsurance for value: finance_insurance
            /// </summary>
            [EnumMember(Value = "finance_insurance")]
            Financeinsurance = 7,

            /// <summary>
            /// Enum Realestaterental for value: real_estate_rental
            /// </summary>
            [EnumMember(Value = "real_estate_rental")]
            Realestaterental = 8,

            /// <summary>
            /// Enum Profession for value: profession
            /// </summary>
            [EnumMember(Value = "profession")]
            Profession = 9,

            /// <summary>
            /// Enum Designproduction for value: design_production
            /// </summary>
            [EnumMember(Value = "design_production")]
            Designproduction = 10,

            /// <summary>
            /// Enum Food for value: food
            /// </summary>
            [EnumMember(Value = "food")]
            Food = 11,

            /// <summary>
            /// Enum Leisureentertainment for value: leisure_entertainment
            /// </summary>
            [EnumMember(Value = "leisure_entertainment")]
            Leisureentertainment = 12,

            /// <summary>
            /// Enum Lifestyle for value: lifestyle
            /// </summary>
            [EnumMember(Value = "lifestyle")]
            Lifestyle = 13,

            /// <summary>
            /// Enum Education for value: education
            /// </summary>
            [EnumMember(Value = "education")]
            Education = 14,

            /// <summary>
            /// Enum Medicalwelfare for value: medical_welfare
            /// </summary>
            [EnumMember(Value = "medical_welfare")]
            Medicalwelfare = 15,

            /// <summary>
            /// Enum Otherservices for value: other_services
            /// </summary>
            [EnumMember(Value = "other_services")]
            Otherservices = 16,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 17

        }

        /// <summary>
        /// 種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）Available values : agriculture_forestry_fisheries_ore, construction, manufacturing_processing, it, transportation_logistics, retail_wholesale, finance_insurance, real_estate_rental, profession, design_production, food, leisure_entertainment, lifestyle, education, medical_welfare, other_services, other
        /// </summary>
        /// <value>種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）Available values : agriculture_forestry_fisheries_ore, construction, manufacturing_processing, it, transportation_logistics, retail_wholesale, finance_insurance, real_estate_rental, profession, design_production, food, leisure_entertainment, lifestyle, education, medical_welfare, other_services, other</value>
        [DataMember(Name="industry_class", EmitDefaultValue=false)]
        public IndustryClassEnum? IndustryClass { get; set; }
        /// <summary>
        /// 業種（agriculture: 農業, forestry: 林業, fishing_industry: 漁業、水産養殖業, mining: 鉱業、採石業、砂利採取業, civil_contractors: 土木工事業, pavement: 舗装工事業, carpenter: とび、大工、左官等の建設工事業, renovation: リフォーム工事業, electrical_plumbing: 電気、管工事等の設備工事業, grocery: 食料品の製造加工業, machinery_manufacturing: 機械器具の製造加工業, printing: 印刷業, other_manufacturing: その他の製造加工業, software_development: 受託：ソフトウェア、アプリ開発業, system_development: 受託：システム開発業, survey_analysis: 受託：調査、分析等の情報処理業, server_management: 受託：サーバー運営管理, website_production: 受託：ウェブサイト制作, online_service_management: オンラインサービス運営業, online_advertising_agency: オンライン広告代理店業, online_advertising_planning_production: オンライン広告企画・制作業, online_media_management: オンラインメディア運営業, portal_site_management: ポータルサイト運営業, other_it_services: その他、IT サービス業, transport_delivery: 輸送業、配送業, delivery: バイク便等の配達業, other_transportation_logistics: その他の運輸業、物流業, other_wholesale: 卸売業：その他, clothing_wholesale_fiber: 卸売業：衣類卸売／繊維, food_wholesale: 卸売業：飲食料品, entrusted_development_wholesale: 卸売業：機械器具, online_shop: 小売業：無店舗　オンラインショップ, fashion_grocery_store: 小売業：店舗あり　ファッション、雑貨, food_store: 小売業：店舗あり　生鮮食品、飲食料品, entrusted_store: 小売業：店舗あり　機械、器具, other_store: 小売業：店舗あり　その他, financial_instruments_exchange: 金融業：金融商品取引, commodity_futures_investment_advisor: 金融業：商品先物取引、商品投資顧問, other_financial: 金融業：その他, brokerage_insurance: 保険業：仲介、代理, other_insurance: 保険業：その他, real_estate_developer: 不動産業：ディベロッパー, real_estate_brokerage: 不動産業：売買、仲介, rent_coin_parking_management: 不動産業：賃貸、コインパーキング、管理, rental_office_co_working_space: 不動産業：レンタルオフィス、コワーキングスペース, rental_lease: レンタル業、リース業, cpa_tax_accountant: 士業：公認会計士事務所、税理士事務所, law_office: 士業：法律事務所, judicial_and_administrative_scrivener: 士業：司法書士事務所／行政書士事務所, labor_consultant: 士業：社会保険労務士事務所, other_profession: 士業：その他, business_consultant: 経営コンサルタント, academic_research_development: 学術・開発研究機関, advertising_agency: 広告代理店, advertising_planning_production: 広告企画／制作, design_development: ソフトウェア、アプリ開発業（受託）, apparel_industry_design: 服飾デザイン業、工業デザイン業, website_design: ウェブサイト制作（受託）, advertising_planning_design: 広告企画／制作業, other_design: その他、デザイン／制作, restaurants_coffee_shops: レストラン、喫茶店等の飲食店業, sale_of_lunch: 弁当の販売業, bread_confectionery_manufacture_sale: パン、菓子等の製造販売業, delivery_catering_mobile_catering: デリバリー業、ケータリング業、移動販売業, hotel_inn: 宿泊業：ホテル、旅館, homestay: 宿泊業：民泊, travel_agency: 旅行代理店業, leisure_sports_facility_management: レジャー、スポーツ等の施設運営業, show_event_management: ショー、イベント等の興行、イベント運営業, barber: ビューティ、ヘルスケア業：床屋、理容室, beauty_salon: ビューティ、ヘルスケア業：美容室, spa_sand_bath_sauna: ビューティ、ヘルスケア業：スパ、砂風呂、サウナ等, este_ail_salon: ビューティ、ヘルスケア業：その他、エステサロン、ネイルサロン等, bridal_planning_introduce_wedding: 冠婚葬祭業：ブライダルプランニング、結婚式場紹介等, memorial_ceremony_funeral: 冠婚葬祭業：メモリアルセレモニー、葬儀等, moving: 引っ越し業, courier_industry: 宅配業, house_maid_cleaning_agency: 家事代行サービス業：無店舗　ハウスメイド、掃除代行等, re_tailoring_clothes: 家事代行サービス業：店舗あり　衣類修理、衣類仕立て直し等, training_institute_management: 研修所等の施設運営業, tutoring_school: 学習塾、進学塾等の教育・学習支援業, music_calligraphy_abacus_classroom: 音楽教室、書道教室、そろばん教室等のの教育・学習支援業, english_school: 英会話スクール等の語学学習支援業, tennis_yoga_judo_school: テニススクール、ヨガ教室、柔道場等のスポーツ指導、支援業, culture_school: その他、カルチャースクール等の教育・学習支援業, seminar_planning_management: セミナー等の企画、運営業, hospital_clinic: 医療業：病院、一般診療所、クリニック等, dental_clinic: 医療業：歯科診療所, other_medical_services: 医療業：その他、医療サービス等, nursery: 福祉業：保育所等、児童向け施設型サービス, nursing_home: 福祉業：老人ホーム等、老人向け施設型サービス, rehabilitation_support_services: 福祉業：療育支援サービス等、障害者等向け施設型サービス, other_welfare: 福祉業：その他、施設型福祉サービス, visit_welfare_service: 福祉業：訪問型福祉サービス, recruitment_temporary_staffing: 人材紹介業、人材派遣業, life_related_recruitment_temporary_staffing: 生活関連サービスの人材紹介業、人材派遣業, car_maintenance_car_repair: 自動車整備業、自動車修理業, machinery_equipment_maintenance_repair: 機械機器類の整備業、修理業, cleaning_maintenance_building_management: 清掃業、メンテナンス業、建物管理業, security: 警備業, other_services: その他のサービス業, npo: NPO, general_incorporated_association: 一般社団法人, general_incorporated_foundation: 一般財団法人, other_association: その他組織)
        /// </summary>
        /// <value>業種（agriculture: 農業, forestry: 林業, fishing_industry: 漁業、水産養殖業, mining: 鉱業、採石業、砂利採取業, civil_contractors: 土木工事業, pavement: 舗装工事業, carpenter: とび、大工、左官等の建設工事業, renovation: リフォーム工事業, electrical_plumbing: 電気、管工事等の設備工事業, grocery: 食料品の製造加工業, machinery_manufacturing: 機械器具の製造加工業, printing: 印刷業, other_manufacturing: その他の製造加工業, software_development: 受託：ソフトウェア、アプリ開発業, system_development: 受託：システム開発業, survey_analysis: 受託：調査、分析等の情報処理業, server_management: 受託：サーバー運営管理, website_production: 受託：ウェブサイト制作, online_service_management: オンラインサービス運営業, online_advertising_agency: オンライン広告代理店業, online_advertising_planning_production: オンライン広告企画・制作業, online_media_management: オンラインメディア運営業, portal_site_management: ポータルサイト運営業, other_it_services: その他、IT サービス業, transport_delivery: 輸送業、配送業, delivery: バイク便等の配達業, other_transportation_logistics: その他の運輸業、物流業, other_wholesale: 卸売業：その他, clothing_wholesale_fiber: 卸売業：衣類卸売／繊維, food_wholesale: 卸売業：飲食料品, entrusted_development_wholesale: 卸売業：機械器具, online_shop: 小売業：無店舗　オンラインショップ, fashion_grocery_store: 小売業：店舗あり　ファッション、雑貨, food_store: 小売業：店舗あり　生鮮食品、飲食料品, entrusted_store: 小売業：店舗あり　機械、器具, other_store: 小売業：店舗あり　その他, financial_instruments_exchange: 金融業：金融商品取引, commodity_futures_investment_advisor: 金融業：商品先物取引、商品投資顧問, other_financial: 金融業：その他, brokerage_insurance: 保険業：仲介、代理, other_insurance: 保険業：その他, real_estate_developer: 不動産業：ディベロッパー, real_estate_brokerage: 不動産業：売買、仲介, rent_coin_parking_management: 不動産業：賃貸、コインパーキング、管理, rental_office_co_working_space: 不動産業：レンタルオフィス、コワーキングスペース, rental_lease: レンタル業、リース業, cpa_tax_accountant: 士業：公認会計士事務所、税理士事務所, law_office: 士業：法律事務所, judicial_and_administrative_scrivener: 士業：司法書士事務所／行政書士事務所, labor_consultant: 士業：社会保険労務士事務所, other_profession: 士業：その他, business_consultant: 経営コンサルタント, academic_research_development: 学術・開発研究機関, advertising_agency: 広告代理店, advertising_planning_production: 広告企画／制作, design_development: ソフトウェア、アプリ開発業（受託）, apparel_industry_design: 服飾デザイン業、工業デザイン業, website_design: ウェブサイト制作（受託）, advertising_planning_design: 広告企画／制作業, other_design: その他、デザイン／制作, restaurants_coffee_shops: レストラン、喫茶店等の飲食店業, sale_of_lunch: 弁当の販売業, bread_confectionery_manufacture_sale: パン、菓子等の製造販売業, delivery_catering_mobile_catering: デリバリー業、ケータリング業、移動販売業, hotel_inn: 宿泊業：ホテル、旅館, homestay: 宿泊業：民泊, travel_agency: 旅行代理店業, leisure_sports_facility_management: レジャー、スポーツ等の施設運営業, show_event_management: ショー、イベント等の興行、イベント運営業, barber: ビューティ、ヘルスケア業：床屋、理容室, beauty_salon: ビューティ、ヘルスケア業：美容室, spa_sand_bath_sauna: ビューティ、ヘルスケア業：スパ、砂風呂、サウナ等, este_ail_salon: ビューティ、ヘルスケア業：その他、エステサロン、ネイルサロン等, bridal_planning_introduce_wedding: 冠婚葬祭業：ブライダルプランニング、結婚式場紹介等, memorial_ceremony_funeral: 冠婚葬祭業：メモリアルセレモニー、葬儀等, moving: 引っ越し業, courier_industry: 宅配業, house_maid_cleaning_agency: 家事代行サービス業：無店舗　ハウスメイド、掃除代行等, re_tailoring_clothes: 家事代行サービス業：店舗あり　衣類修理、衣類仕立て直し等, training_institute_management: 研修所等の施設運営業, tutoring_school: 学習塾、進学塾等の教育・学習支援業, music_calligraphy_abacus_classroom: 音楽教室、書道教室、そろばん教室等のの教育・学習支援業, english_school: 英会話スクール等の語学学習支援業, tennis_yoga_judo_school: テニススクール、ヨガ教室、柔道場等のスポーツ指導、支援業, culture_school: その他、カルチャースクール等の教育・学習支援業, seminar_planning_management: セミナー等の企画、運営業, hospital_clinic: 医療業：病院、一般診療所、クリニック等, dental_clinic: 医療業：歯科診療所, other_medical_services: 医療業：その他、医療サービス等, nursery: 福祉業：保育所等、児童向け施設型サービス, nursing_home: 福祉業：老人ホーム等、老人向け施設型サービス, rehabilitation_support_services: 福祉業：療育支援サービス等、障害者等向け施設型サービス, other_welfare: 福祉業：その他、施設型福祉サービス, visit_welfare_service: 福祉業：訪問型福祉サービス, recruitment_temporary_staffing: 人材紹介業、人材派遣業, life_related_recruitment_temporary_staffing: 生活関連サービスの人材紹介業、人材派遣業, car_maintenance_car_repair: 自動車整備業、自動車修理業, machinery_equipment_maintenance_repair: 機械機器類の整備業、修理業, cleaning_maintenance_building_management: 清掃業、メンテナンス業、建物管理業, security: 警備業, other_services: その他のサービス業, npo: NPO, general_incorporated_association: 一般社団法人, general_incorporated_foundation: 一般財団法人, other_association: その他組織)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IndustryCodeEnum
        {
            /// <summary>
            /// Enum Agriculture for value: agriculture
            /// </summary>
            [EnumMember(Value = "agriculture")]
            Agriculture = 1,

            /// <summary>
            /// Enum Forestry for value: forestry
            /// </summary>
            [EnumMember(Value = "forestry")]
            Forestry = 2,

            /// <summary>
            /// Enum Fishingindustry for value: fishing_industry
            /// </summary>
            [EnumMember(Value = "fishing_industry")]
            Fishingindustry = 3,

            /// <summary>
            /// Enum Mining for value: mining
            /// </summary>
            [EnumMember(Value = "mining")]
            Mining = 4,

            /// <summary>
            /// Enum Civilcontractors for value: civil_contractors
            /// </summary>
            [EnumMember(Value = "civil_contractors")]
            Civilcontractors = 5,

            /// <summary>
            /// Enum Pavement for value: pavement
            /// </summary>
            [EnumMember(Value = "pavement")]
            Pavement = 6,

            /// <summary>
            /// Enum Carpenter for value: carpenter
            /// </summary>
            [EnumMember(Value = "carpenter")]
            Carpenter = 7,

            /// <summary>
            /// Enum Renovation for value: renovation
            /// </summary>
            [EnumMember(Value = "renovation")]
            Renovation = 8,

            /// <summary>
            /// Enum Electricalplumbing for value: electrical_plumbing
            /// </summary>
            [EnumMember(Value = "electrical_plumbing")]
            Electricalplumbing = 9,

            /// <summary>
            /// Enum Grocery for value: grocery
            /// </summary>
            [EnumMember(Value = "grocery")]
            Grocery = 10,

            /// <summary>
            /// Enum Machinerymanufacturing for value: machinery_manufacturing
            /// </summary>
            [EnumMember(Value = "machinery_manufacturing")]
            Machinerymanufacturing = 11,

            /// <summary>
            /// Enum Printing for value: printing
            /// </summary>
            [EnumMember(Value = "printing")]
            Printing = 12,

            /// <summary>
            /// Enum Othermanufacturing for value: other_manufacturing
            /// </summary>
            [EnumMember(Value = "other_manufacturing")]
            Othermanufacturing = 13,

            /// <summary>
            /// Enum Softwaredevelopment for value: software_development
            /// </summary>
            [EnumMember(Value = "software_development")]
            Softwaredevelopment = 14,

            /// <summary>
            /// Enum Systemdevelopment for value: system_development
            /// </summary>
            [EnumMember(Value = "system_development")]
            Systemdevelopment = 15,

            /// <summary>
            /// Enum Surveyanalysis for value: survey_analysis
            /// </summary>
            [EnumMember(Value = "survey_analysis")]
            Surveyanalysis = 16,

            /// <summary>
            /// Enum Servermanagement for value: server_management
            /// </summary>
            [EnumMember(Value = "server_management")]
            Servermanagement = 17,

            /// <summary>
            /// Enum Websiteproduction for value: website_production
            /// </summary>
            [EnumMember(Value = "website_production")]
            Websiteproduction = 18,

            /// <summary>
            /// Enum Onlineservicemanagement for value: online_service_management
            /// </summary>
            [EnumMember(Value = "online_service_management")]
            Onlineservicemanagement = 19,

            /// <summary>
            /// Enum Onlineadvertisingagency for value: online_advertising_agency
            /// </summary>
            [EnumMember(Value = "online_advertising_agency")]
            Onlineadvertisingagency = 20,

            /// <summary>
            /// Enum Onlineadvertisingplanningproduction for value: online_advertising_planning_production
            /// </summary>
            [EnumMember(Value = "online_advertising_planning_production")]
            Onlineadvertisingplanningproduction = 21,

            /// <summary>
            /// Enum Onlinemediamanagement for value: online_media_management
            /// </summary>
            [EnumMember(Value = "online_media_management")]
            Onlinemediamanagement = 22,

            /// <summary>
            /// Enum Portalsitemanagement for value: portal_site_management
            /// </summary>
            [EnumMember(Value = "portal_site_management")]
            Portalsitemanagement = 23,

            /// <summary>
            /// Enum Otheritservices for value: other_it_services
            /// </summary>
            [EnumMember(Value = "other_it_services")]
            Otheritservices = 24,

            /// <summary>
            /// Enum Transportdelivery for value: transport_delivery
            /// </summary>
            [EnumMember(Value = "transport_delivery")]
            Transportdelivery = 25,

            /// <summary>
            /// Enum Delivery for value: delivery
            /// </summary>
            [EnumMember(Value = "delivery")]
            Delivery = 26,

            /// <summary>
            /// Enum Othertransportationlogistics for value: other_transportation_logistics
            /// </summary>
            [EnumMember(Value = "other_transportation_logistics")]
            Othertransportationlogistics = 27,

            /// <summary>
            /// Enum Otherwholesale for value: other_wholesale
            /// </summary>
            [EnumMember(Value = "other_wholesale")]
            Otherwholesale = 28,

            /// <summary>
            /// Enum Clothingwholesalefiber for value: clothing_wholesale_fiber
            /// </summary>
            [EnumMember(Value = "clothing_wholesale_fiber")]
            Clothingwholesalefiber = 29,

            /// <summary>
            /// Enum Foodwholesale for value: food_wholesale
            /// </summary>
            [EnumMember(Value = "food_wholesale")]
            Foodwholesale = 30,

            /// <summary>
            /// Enum Entrusteddevelopmentwholesale for value: entrusted_development_wholesale
            /// </summary>
            [EnumMember(Value = "entrusted_development_wholesale")]
            Entrusteddevelopmentwholesale = 31,

            /// <summary>
            /// Enum Onlineshop for value: online_shop
            /// </summary>
            [EnumMember(Value = "online_shop")]
            Onlineshop = 32,

            /// <summary>
            /// Enum Fashiongrocerystore for value: fashion_grocery_store
            /// </summary>
            [EnumMember(Value = "fashion_grocery_store")]
            Fashiongrocerystore = 33,

            /// <summary>
            /// Enum Foodstore for value: food_store
            /// </summary>
            [EnumMember(Value = "food_store")]
            Foodstore = 34,

            /// <summary>
            /// Enum Entrustedstore for value: entrusted_store
            /// </summary>
            [EnumMember(Value = "entrusted_store")]
            Entrustedstore = 35,

            /// <summary>
            /// Enum Otherstore for value: other_store
            /// </summary>
            [EnumMember(Value = "other_store")]
            Otherstore = 36,

            /// <summary>
            /// Enum Financialinstrumentsexchange for value: financial_instruments_exchange
            /// </summary>
            [EnumMember(Value = "financial_instruments_exchange")]
            Financialinstrumentsexchange = 37,

            /// <summary>
            /// Enum Commodityfuturesinvestmentadvisor for value: commodity_futures_investment_advisor
            /// </summary>
            [EnumMember(Value = "commodity_futures_investment_advisor")]
            Commodityfuturesinvestmentadvisor = 38,

            /// <summary>
            /// Enum Otherfinancial for value: other_financial
            /// </summary>
            [EnumMember(Value = "other_financial")]
            Otherfinancial = 39,

            /// <summary>
            /// Enum Brokerageinsurance for value: brokerage_insurance
            /// </summary>
            [EnumMember(Value = "brokerage_insurance")]
            Brokerageinsurance = 40,

            /// <summary>
            /// Enum Otherinsurance for value: other_insurance
            /// </summary>
            [EnumMember(Value = "other_insurance")]
            Otherinsurance = 41,

            /// <summary>
            /// Enum Realestatedeveloper for value: real_estate_developer
            /// </summary>
            [EnumMember(Value = "real_estate_developer")]
            Realestatedeveloper = 42,

            /// <summary>
            /// Enum Realestatebrokerage for value: real_estate_brokerage
            /// </summary>
            [EnumMember(Value = "real_estate_brokerage")]
            Realestatebrokerage = 43,

            /// <summary>
            /// Enum Rentcoinparkingmanagement for value: rent_coin_parking_management
            /// </summary>
            [EnumMember(Value = "rent_coin_parking_management")]
            Rentcoinparkingmanagement = 44,

            /// <summary>
            /// Enum Rentalofficecoworkingspace for value: rental_office_co_working_space
            /// </summary>
            [EnumMember(Value = "rental_office_co_working_space")]
            Rentalofficecoworkingspace = 45,

            /// <summary>
            /// Enum Rentallease for value: rental_lease
            /// </summary>
            [EnumMember(Value = "rental_lease")]
            Rentallease = 46,

            /// <summary>
            /// Enum Cpataxaccountant for value: cpa_tax_accountant
            /// </summary>
            [EnumMember(Value = "cpa_tax_accountant")]
            Cpataxaccountant = 47,

            /// <summary>
            /// Enum Lawoffice for value: law_office
            /// </summary>
            [EnumMember(Value = "law_office")]
            Lawoffice = 48,

            /// <summary>
            /// Enum Judicialandadministrativescrivener for value: judicial_and_administrative_scrivener
            /// </summary>
            [EnumMember(Value = "judicial_and_administrative_scrivener")]
            Judicialandadministrativescrivener = 49,

            /// <summary>
            /// Enum Laborconsultant for value: labor_consultant
            /// </summary>
            [EnumMember(Value = "labor_consultant")]
            Laborconsultant = 50,

            /// <summary>
            /// Enum Otherprofession for value: other_profession
            /// </summary>
            [EnumMember(Value = "other_profession")]
            Otherprofession = 51,

            /// <summary>
            /// Enum Businessconsultant for value: business_consultant
            /// </summary>
            [EnumMember(Value = "business_consultant")]
            Businessconsultant = 52,

            /// <summary>
            /// Enum Academicresearchdevelopment for value: academic_research_development
            /// </summary>
            [EnumMember(Value = "academic_research_development")]
            Academicresearchdevelopment = 53,

            /// <summary>
            /// Enum Advertisingagency for value: advertising_agency
            /// </summary>
            [EnumMember(Value = "advertising_agency")]
            Advertisingagency = 54,

            /// <summary>
            /// Enum Advertisingplanningproduction for value: advertising_planning_production
            /// </summary>
            [EnumMember(Value = "advertising_planning_production")]
            Advertisingplanningproduction = 55,

            /// <summary>
            /// Enum Designdevelopment for value: design_development
            /// </summary>
            [EnumMember(Value = "design_development")]
            Designdevelopment = 56,

            /// <summary>
            /// Enum Apparelindustrydesign for value: apparel_industry_design
            /// </summary>
            [EnumMember(Value = "apparel_industry_design")]
            Apparelindustrydesign = 57,

            /// <summary>
            /// Enum Websitedesign for value: website_design
            /// </summary>
            [EnumMember(Value = "website_design")]
            Websitedesign = 58,

            /// <summary>
            /// Enum Advertisingplanningdesign for value: advertising_planning_design
            /// </summary>
            [EnumMember(Value = "advertising_planning_design")]
            Advertisingplanningdesign = 59,

            /// <summary>
            /// Enum Otherdesign for value: other_design
            /// </summary>
            [EnumMember(Value = "other_design")]
            Otherdesign = 60,

            /// <summary>
            /// Enum Restaurantscoffeeshops for value: restaurants_coffee_shops
            /// </summary>
            [EnumMember(Value = "restaurants_coffee_shops")]
            Restaurantscoffeeshops = 61,

            /// <summary>
            /// Enum Saleoflunch for value: sale_of_lunch
            /// </summary>
            [EnumMember(Value = "sale_of_lunch")]
            Saleoflunch = 62,

            /// <summary>
            /// Enum Breadconfectionerymanufacturesale for value: bread_confectionery_manufacture_sale
            /// </summary>
            [EnumMember(Value = "bread_confectionery_manufacture_sale")]
            Breadconfectionerymanufacturesale = 63,

            /// <summary>
            /// Enum Deliverycateringmobilecatering for value: delivery_catering_mobile_catering
            /// </summary>
            [EnumMember(Value = "delivery_catering_mobile_catering")]
            Deliverycateringmobilecatering = 64,

            /// <summary>
            /// Enum Hotelinn for value: hotel_inn
            /// </summary>
            [EnumMember(Value = "hotel_inn")]
            Hotelinn = 65,

            /// <summary>
            /// Enum Homestay for value: homestay
            /// </summary>
            [EnumMember(Value = "homestay")]
            Homestay = 66,

            /// <summary>
            /// Enum Travelagency for value: travel_agency
            /// </summary>
            [EnumMember(Value = "travel_agency")]
            Travelagency = 67,

            /// <summary>
            /// Enum Leisuresportsfacilitymanagement for value: leisure_sports_facility_management
            /// </summary>
            [EnumMember(Value = "leisure_sports_facility_management")]
            Leisuresportsfacilitymanagement = 68,

            /// <summary>
            /// Enum Showeventmanagement for value: show_event_management
            /// </summary>
            [EnumMember(Value = "show_event_management")]
            Showeventmanagement = 69,

            /// <summary>
            /// Enum Barber for value: barber
            /// </summary>
            [EnumMember(Value = "barber")]
            Barber = 70,

            /// <summary>
            /// Enum Beautysalon for value: beauty_salon
            /// </summary>
            [EnumMember(Value = "beauty_salon")]
            Beautysalon = 71,

            /// <summary>
            /// Enum Spasandbathsauna for value: spa_sand_bath_sauna
            /// </summary>
            [EnumMember(Value = "spa_sand_bath_sauna")]
            Spasandbathsauna = 72,

            /// <summary>
            /// Enum Esteailsalon for value: este_ail_salon
            /// </summary>
            [EnumMember(Value = "este_ail_salon")]
            Esteailsalon = 73,

            /// <summary>
            /// Enum Bridalplanningintroducewedding for value: bridal_planning_introduce_wedding
            /// </summary>
            [EnumMember(Value = "bridal_planning_introduce_wedding")]
            Bridalplanningintroducewedding = 74,

            /// <summary>
            /// Enum Memorialceremonyfuneral for value: memorial_ceremony_funeral
            /// </summary>
            [EnumMember(Value = "memorial_ceremony_funeral")]
            Memorialceremonyfuneral = 75,

            /// <summary>
            /// Enum Moving for value: moving
            /// </summary>
            [EnumMember(Value = "moving")]
            Moving = 76,

            /// <summary>
            /// Enum Courierindustry for value: courier_industry
            /// </summary>
            [EnumMember(Value = "courier_industry")]
            Courierindustry = 77,

            /// <summary>
            /// Enum Housemaidcleaningagency for value: house_maid_cleaning_agency
            /// </summary>
            [EnumMember(Value = "house_maid_cleaning_agency")]
            Housemaidcleaningagency = 78,

            /// <summary>
            /// Enum Retailoringclothes for value: re_tailoring_clothes
            /// </summary>
            [EnumMember(Value = "re_tailoring_clothes")]
            Retailoringclothes = 79,

            /// <summary>
            /// Enum Traininginstitutemanagement for value: training_institute_management
            /// </summary>
            [EnumMember(Value = "training_institute_management")]
            Traininginstitutemanagement = 80,

            /// <summary>
            /// Enum Tutoringschool for value: tutoring_school
            /// </summary>
            [EnumMember(Value = "tutoring_school")]
            Tutoringschool = 81,

            /// <summary>
            /// Enum Musiccalligraphyabacusclassroom for value: music_calligraphy_abacus_classroom
            /// </summary>
            [EnumMember(Value = "music_calligraphy_abacus_classroom")]
            Musiccalligraphyabacusclassroom = 82,

            /// <summary>
            /// Enum Englishschool for value: english_school
            /// </summary>
            [EnumMember(Value = "english_school")]
            Englishschool = 83,

            /// <summary>
            /// Enum Tennisyogajudoschool for value: tennis_yoga_judo_school
            /// </summary>
            [EnumMember(Value = "tennis_yoga_judo_school")]
            Tennisyogajudoschool = 84,

            /// <summary>
            /// Enum Cultureschool for value: culture_school
            /// </summary>
            [EnumMember(Value = "culture_school")]
            Cultureschool = 85,

            /// <summary>
            /// Enum Seminarplanningmanagement for value: seminar_planning_management
            /// </summary>
            [EnumMember(Value = "seminar_planning_management")]
            Seminarplanningmanagement = 86,

            /// <summary>
            /// Enum Hospitalclinic for value: hospital_clinic
            /// </summary>
            [EnumMember(Value = "hospital_clinic")]
            Hospitalclinic = 87,

            /// <summary>
            /// Enum Dentalclinic for value: dental_clinic
            /// </summary>
            [EnumMember(Value = "dental_clinic")]
            Dentalclinic = 88,

            /// <summary>
            /// Enum Othermedicalservices for value: other_medical_services
            /// </summary>
            [EnumMember(Value = "other_medical_services")]
            Othermedicalservices = 89,

            /// <summary>
            /// Enum Nursery for value: nursery
            /// </summary>
            [EnumMember(Value = "nursery")]
            Nursery = 90,

            /// <summary>
            /// Enum Nursinghome for value: nursing_home
            /// </summary>
            [EnumMember(Value = "nursing_home")]
            Nursinghome = 91,

            /// <summary>
            /// Enum Rehabilitationsupportservices for value: rehabilitation_support_services
            /// </summary>
            [EnumMember(Value = "rehabilitation_support_services")]
            Rehabilitationsupportservices = 92,

            /// <summary>
            /// Enum Otherwelfare for value: other_welfare
            /// </summary>
            [EnumMember(Value = "other_welfare")]
            Otherwelfare = 93,

            /// <summary>
            /// Enum Visitwelfareservice for value: visit_welfare_service
            /// </summary>
            [EnumMember(Value = "visit_welfare_service")]
            Visitwelfareservice = 94,

            /// <summary>
            /// Enum Recruitmenttemporarystaffing for value: recruitment_temporary_staffing
            /// </summary>
            [EnumMember(Value = "recruitment_temporary_staffing")]
            Recruitmenttemporarystaffing = 95,

            /// <summary>
            /// Enum Liferelatedrecruitmenttemporarystaffing for value: life_related_recruitment_temporary_staffing
            /// </summary>
            [EnumMember(Value = "life_related_recruitment_temporary_staffing")]
            Liferelatedrecruitmenttemporarystaffing = 96,

            /// <summary>
            /// Enum Carmaintenancecarrepair for value: car_maintenance_car_repair
            /// </summary>
            [EnumMember(Value = "car_maintenance_car_repair")]
            Carmaintenancecarrepair = 97,

            /// <summary>
            /// Enum Machineryequipmentmaintenancerepair for value: machinery_equipment_maintenance_repair
            /// </summary>
            [EnumMember(Value = "machinery_equipment_maintenance_repair")]
            Machineryequipmentmaintenancerepair = 98,

            /// <summary>
            /// Enum Cleaningmaintenancebuildingmanagement for value: cleaning_maintenance_building_management
            /// </summary>
            [EnumMember(Value = "cleaning_maintenance_building_management")]
            Cleaningmaintenancebuildingmanagement = 99,

            /// <summary>
            /// Enum Security for value: security
            /// </summary>
            [EnumMember(Value = "security")]
            Security = 100,

            /// <summary>
            /// Enum Otherservices for value: other_services
            /// </summary>
            [EnumMember(Value = "other_services")]
            Otherservices = 101,

            /// <summary>
            /// Enum Npo for value: npo
            /// </summary>
            [EnumMember(Value = "npo")]
            Npo = 102,

            /// <summary>
            /// Enum Generalincorporatedassociation for value: general_incorporated_association
            /// </summary>
            [EnumMember(Value = "general_incorporated_association")]
            Generalincorporatedassociation = 103,

            /// <summary>
            /// Enum Generalincorporatedfoundation for value: general_incorporated_foundation
            /// </summary>
            [EnumMember(Value = "general_incorporated_foundation")]
            Generalincorporatedfoundation = 104,

            /// <summary>
            /// Enum Otherassociation for value: other_association
            /// </summary>
            [EnumMember(Value = "other_association")]
            Otherassociation = 105

        }

        /// <summary>
        /// 業種（agriculture: 農業, forestry: 林業, fishing_industry: 漁業、水産養殖業, mining: 鉱業、採石業、砂利採取業, civil_contractors: 土木工事業, pavement: 舗装工事業, carpenter: とび、大工、左官等の建設工事業, renovation: リフォーム工事業, electrical_plumbing: 電気、管工事等の設備工事業, grocery: 食料品の製造加工業, machinery_manufacturing: 機械器具の製造加工業, printing: 印刷業, other_manufacturing: その他の製造加工業, software_development: 受託：ソフトウェア、アプリ開発業, system_development: 受託：システム開発業, survey_analysis: 受託：調査、分析等の情報処理業, server_management: 受託：サーバー運営管理, website_production: 受託：ウェブサイト制作, online_service_management: オンラインサービス運営業, online_advertising_agency: オンライン広告代理店業, online_advertising_planning_production: オンライン広告企画・制作業, online_media_management: オンラインメディア運営業, portal_site_management: ポータルサイト運営業, other_it_services: その他、IT サービス業, transport_delivery: 輸送業、配送業, delivery: バイク便等の配達業, other_transportation_logistics: その他の運輸業、物流業, other_wholesale: 卸売業：その他, clothing_wholesale_fiber: 卸売業：衣類卸売／繊維, food_wholesale: 卸売業：飲食料品, entrusted_development_wholesale: 卸売業：機械器具, online_shop: 小売業：無店舗　オンラインショップ, fashion_grocery_store: 小売業：店舗あり　ファッション、雑貨, food_store: 小売業：店舗あり　生鮮食品、飲食料品, entrusted_store: 小売業：店舗あり　機械、器具, other_store: 小売業：店舗あり　その他, financial_instruments_exchange: 金融業：金融商品取引, commodity_futures_investment_advisor: 金融業：商品先物取引、商品投資顧問, other_financial: 金融業：その他, brokerage_insurance: 保険業：仲介、代理, other_insurance: 保険業：その他, real_estate_developer: 不動産業：ディベロッパー, real_estate_brokerage: 不動産業：売買、仲介, rent_coin_parking_management: 不動産業：賃貸、コインパーキング、管理, rental_office_co_working_space: 不動産業：レンタルオフィス、コワーキングスペース, rental_lease: レンタル業、リース業, cpa_tax_accountant: 士業：公認会計士事務所、税理士事務所, law_office: 士業：法律事務所, judicial_and_administrative_scrivener: 士業：司法書士事務所／行政書士事務所, labor_consultant: 士業：社会保険労務士事務所, other_profession: 士業：その他, business_consultant: 経営コンサルタント, academic_research_development: 学術・開発研究機関, advertising_agency: 広告代理店, advertising_planning_production: 広告企画／制作, design_development: ソフトウェア、アプリ開発業（受託）, apparel_industry_design: 服飾デザイン業、工業デザイン業, website_design: ウェブサイト制作（受託）, advertising_planning_design: 広告企画／制作業, other_design: その他、デザイン／制作, restaurants_coffee_shops: レストラン、喫茶店等の飲食店業, sale_of_lunch: 弁当の販売業, bread_confectionery_manufacture_sale: パン、菓子等の製造販売業, delivery_catering_mobile_catering: デリバリー業、ケータリング業、移動販売業, hotel_inn: 宿泊業：ホテル、旅館, homestay: 宿泊業：民泊, travel_agency: 旅行代理店業, leisure_sports_facility_management: レジャー、スポーツ等の施設運営業, show_event_management: ショー、イベント等の興行、イベント運営業, barber: ビューティ、ヘルスケア業：床屋、理容室, beauty_salon: ビューティ、ヘルスケア業：美容室, spa_sand_bath_sauna: ビューティ、ヘルスケア業：スパ、砂風呂、サウナ等, este_ail_salon: ビューティ、ヘルスケア業：その他、エステサロン、ネイルサロン等, bridal_planning_introduce_wedding: 冠婚葬祭業：ブライダルプランニング、結婚式場紹介等, memorial_ceremony_funeral: 冠婚葬祭業：メモリアルセレモニー、葬儀等, moving: 引っ越し業, courier_industry: 宅配業, house_maid_cleaning_agency: 家事代行サービス業：無店舗　ハウスメイド、掃除代行等, re_tailoring_clothes: 家事代行サービス業：店舗あり　衣類修理、衣類仕立て直し等, training_institute_management: 研修所等の施設運営業, tutoring_school: 学習塾、進学塾等の教育・学習支援業, music_calligraphy_abacus_classroom: 音楽教室、書道教室、そろばん教室等のの教育・学習支援業, english_school: 英会話スクール等の語学学習支援業, tennis_yoga_judo_school: テニススクール、ヨガ教室、柔道場等のスポーツ指導、支援業, culture_school: その他、カルチャースクール等の教育・学習支援業, seminar_planning_management: セミナー等の企画、運営業, hospital_clinic: 医療業：病院、一般診療所、クリニック等, dental_clinic: 医療業：歯科診療所, other_medical_services: 医療業：その他、医療サービス等, nursery: 福祉業：保育所等、児童向け施設型サービス, nursing_home: 福祉業：老人ホーム等、老人向け施設型サービス, rehabilitation_support_services: 福祉業：療育支援サービス等、障害者等向け施設型サービス, other_welfare: 福祉業：その他、施設型福祉サービス, visit_welfare_service: 福祉業：訪問型福祉サービス, recruitment_temporary_staffing: 人材紹介業、人材派遣業, life_related_recruitment_temporary_staffing: 生活関連サービスの人材紹介業、人材派遣業, car_maintenance_car_repair: 自動車整備業、自動車修理業, machinery_equipment_maintenance_repair: 機械機器類の整備業、修理業, cleaning_maintenance_building_management: 清掃業、メンテナンス業、建物管理業, security: 警備業, other_services: その他のサービス業, npo: NPO, general_incorporated_association: 一般社団法人, general_incorporated_foundation: 一般財団法人, other_association: その他組織)
        /// </summary>
        /// <value>業種（agriculture: 農業, forestry: 林業, fishing_industry: 漁業、水産養殖業, mining: 鉱業、採石業、砂利採取業, civil_contractors: 土木工事業, pavement: 舗装工事業, carpenter: とび、大工、左官等の建設工事業, renovation: リフォーム工事業, electrical_plumbing: 電気、管工事等の設備工事業, grocery: 食料品の製造加工業, machinery_manufacturing: 機械器具の製造加工業, printing: 印刷業, other_manufacturing: その他の製造加工業, software_development: 受託：ソフトウェア、アプリ開発業, system_development: 受託：システム開発業, survey_analysis: 受託：調査、分析等の情報処理業, server_management: 受託：サーバー運営管理, website_production: 受託：ウェブサイト制作, online_service_management: オンラインサービス運営業, online_advertising_agency: オンライン広告代理店業, online_advertising_planning_production: オンライン広告企画・制作業, online_media_management: オンラインメディア運営業, portal_site_management: ポータルサイト運営業, other_it_services: その他、IT サービス業, transport_delivery: 輸送業、配送業, delivery: バイク便等の配達業, other_transportation_logistics: その他の運輸業、物流業, other_wholesale: 卸売業：その他, clothing_wholesale_fiber: 卸売業：衣類卸売／繊維, food_wholesale: 卸売業：飲食料品, entrusted_development_wholesale: 卸売業：機械器具, online_shop: 小売業：無店舗　オンラインショップ, fashion_grocery_store: 小売業：店舗あり　ファッション、雑貨, food_store: 小売業：店舗あり　生鮮食品、飲食料品, entrusted_store: 小売業：店舗あり　機械、器具, other_store: 小売業：店舗あり　その他, financial_instruments_exchange: 金融業：金融商品取引, commodity_futures_investment_advisor: 金融業：商品先物取引、商品投資顧問, other_financial: 金融業：その他, brokerage_insurance: 保険業：仲介、代理, other_insurance: 保険業：その他, real_estate_developer: 不動産業：ディベロッパー, real_estate_brokerage: 不動産業：売買、仲介, rent_coin_parking_management: 不動産業：賃貸、コインパーキング、管理, rental_office_co_working_space: 不動産業：レンタルオフィス、コワーキングスペース, rental_lease: レンタル業、リース業, cpa_tax_accountant: 士業：公認会計士事務所、税理士事務所, law_office: 士業：法律事務所, judicial_and_administrative_scrivener: 士業：司法書士事務所／行政書士事務所, labor_consultant: 士業：社会保険労務士事務所, other_profession: 士業：その他, business_consultant: 経営コンサルタント, academic_research_development: 学術・開発研究機関, advertising_agency: 広告代理店, advertising_planning_production: 広告企画／制作, design_development: ソフトウェア、アプリ開発業（受託）, apparel_industry_design: 服飾デザイン業、工業デザイン業, website_design: ウェブサイト制作（受託）, advertising_planning_design: 広告企画／制作業, other_design: その他、デザイン／制作, restaurants_coffee_shops: レストラン、喫茶店等の飲食店業, sale_of_lunch: 弁当の販売業, bread_confectionery_manufacture_sale: パン、菓子等の製造販売業, delivery_catering_mobile_catering: デリバリー業、ケータリング業、移動販売業, hotel_inn: 宿泊業：ホテル、旅館, homestay: 宿泊業：民泊, travel_agency: 旅行代理店業, leisure_sports_facility_management: レジャー、スポーツ等の施設運営業, show_event_management: ショー、イベント等の興行、イベント運営業, barber: ビューティ、ヘルスケア業：床屋、理容室, beauty_salon: ビューティ、ヘルスケア業：美容室, spa_sand_bath_sauna: ビューティ、ヘルスケア業：スパ、砂風呂、サウナ等, este_ail_salon: ビューティ、ヘルスケア業：その他、エステサロン、ネイルサロン等, bridal_planning_introduce_wedding: 冠婚葬祭業：ブライダルプランニング、結婚式場紹介等, memorial_ceremony_funeral: 冠婚葬祭業：メモリアルセレモニー、葬儀等, moving: 引っ越し業, courier_industry: 宅配業, house_maid_cleaning_agency: 家事代行サービス業：無店舗　ハウスメイド、掃除代行等, re_tailoring_clothes: 家事代行サービス業：店舗あり　衣類修理、衣類仕立て直し等, training_institute_management: 研修所等の施設運営業, tutoring_school: 学習塾、進学塾等の教育・学習支援業, music_calligraphy_abacus_classroom: 音楽教室、書道教室、そろばん教室等のの教育・学習支援業, english_school: 英会話スクール等の語学学習支援業, tennis_yoga_judo_school: テニススクール、ヨガ教室、柔道場等のスポーツ指導、支援業, culture_school: その他、カルチャースクール等の教育・学習支援業, seminar_planning_management: セミナー等の企画、運営業, hospital_clinic: 医療業：病院、一般診療所、クリニック等, dental_clinic: 医療業：歯科診療所, other_medical_services: 医療業：その他、医療サービス等, nursery: 福祉業：保育所等、児童向け施設型サービス, nursing_home: 福祉業：老人ホーム等、老人向け施設型サービス, rehabilitation_support_services: 福祉業：療育支援サービス等、障害者等向け施設型サービス, other_welfare: 福祉業：その他、施設型福祉サービス, visit_welfare_service: 福祉業：訪問型福祉サービス, recruitment_temporary_staffing: 人材紹介業、人材派遣業, life_related_recruitment_temporary_staffing: 生活関連サービスの人材紹介業、人材派遣業, car_maintenance_car_repair: 自動車整備業、自動車修理業, machinery_equipment_maintenance_repair: 機械機器類の整備業、修理業, cleaning_maintenance_building_management: 清掃業、メンテナンス業、建物管理業, security: 警備業, other_services: その他のサービス業, npo: NPO, general_incorporated_association: 一般社団法人, general_incorporated_foundation: 一般財団法人, other_association: その他組織)</value>
        [DataMember(Name="industry_code", EmitDefaultValue=false)]
        public IndustryCodeEnum? IndustryCode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCompanyParamsSalesInformationAttributes" /> class.
        /// </summary>
        /// <param name="industryClass">種別（agriculture_forestry_fisheries_ore: 農林水産業/鉱業、construction: 建設、manufacturing_processing: 製造/加工、it: IT、transportation_logistics: 運輸/物流、retail_wholesale: 小売/卸売、finance_insurance: 金融/保険、real_estate_rental: 不動産/レンタル、profession: 士業/学術/専門技術サービス、design_production: デザイン/制作、food: 飲食、leisure_entertainment: レジャー/娯楽、lifestyle: 生活関連サービス、education: 教育/学習支援、medical_welfare: 医療/福祉、other_services: その他サービス、other: その他）Available values : agriculture_forestry_fisheries_ore, construction, manufacturing_processing, it, transportation_logistics, retail_wholesale, finance_insurance, real_estate_rental, profession, design_production, food, leisure_entertainment, lifestyle, education, medical_welfare, other_services, other.</param>
        /// <param name="industryCode">業種（agriculture: 農業, forestry: 林業, fishing_industry: 漁業、水産養殖業, mining: 鉱業、採石業、砂利採取業, civil_contractors: 土木工事業, pavement: 舗装工事業, carpenter: とび、大工、左官等の建設工事業, renovation: リフォーム工事業, electrical_plumbing: 電気、管工事等の設備工事業, grocery: 食料品の製造加工業, machinery_manufacturing: 機械器具の製造加工業, printing: 印刷業, other_manufacturing: その他の製造加工業, software_development: 受託：ソフトウェア、アプリ開発業, system_development: 受託：システム開発業, survey_analysis: 受託：調査、分析等の情報処理業, server_management: 受託：サーバー運営管理, website_production: 受託：ウェブサイト制作, online_service_management: オンラインサービス運営業, online_advertising_agency: オンライン広告代理店業, online_advertising_planning_production: オンライン広告企画・制作業, online_media_management: オンラインメディア運営業, portal_site_management: ポータルサイト運営業, other_it_services: その他、IT サービス業, transport_delivery: 輸送業、配送業, delivery: バイク便等の配達業, other_transportation_logistics: その他の運輸業、物流業, other_wholesale: 卸売業：その他, clothing_wholesale_fiber: 卸売業：衣類卸売／繊維, food_wholesale: 卸売業：飲食料品, entrusted_development_wholesale: 卸売業：機械器具, online_shop: 小売業：無店舗　オンラインショップ, fashion_grocery_store: 小売業：店舗あり　ファッション、雑貨, food_store: 小売業：店舗あり　生鮮食品、飲食料品, entrusted_store: 小売業：店舗あり　機械、器具, other_store: 小売業：店舗あり　その他, financial_instruments_exchange: 金融業：金融商品取引, commodity_futures_investment_advisor: 金融業：商品先物取引、商品投資顧問, other_financial: 金融業：その他, brokerage_insurance: 保険業：仲介、代理, other_insurance: 保険業：その他, real_estate_developer: 不動産業：ディベロッパー, real_estate_brokerage: 不動産業：売買、仲介, rent_coin_parking_management: 不動産業：賃貸、コインパーキング、管理, rental_office_co_working_space: 不動産業：レンタルオフィス、コワーキングスペース, rental_lease: レンタル業、リース業, cpa_tax_accountant: 士業：公認会計士事務所、税理士事務所, law_office: 士業：法律事務所, judicial_and_administrative_scrivener: 士業：司法書士事務所／行政書士事務所, labor_consultant: 士業：社会保険労務士事務所, other_profession: 士業：その他, business_consultant: 経営コンサルタント, academic_research_development: 学術・開発研究機関, advertising_agency: 広告代理店, advertising_planning_production: 広告企画／制作, design_development: ソフトウェア、アプリ開発業（受託）, apparel_industry_design: 服飾デザイン業、工業デザイン業, website_design: ウェブサイト制作（受託）, advertising_planning_design: 広告企画／制作業, other_design: その他、デザイン／制作, restaurants_coffee_shops: レストラン、喫茶店等の飲食店業, sale_of_lunch: 弁当の販売業, bread_confectionery_manufacture_sale: パン、菓子等の製造販売業, delivery_catering_mobile_catering: デリバリー業、ケータリング業、移動販売業, hotel_inn: 宿泊業：ホテル、旅館, homestay: 宿泊業：民泊, travel_agency: 旅行代理店業, leisure_sports_facility_management: レジャー、スポーツ等の施設運営業, show_event_management: ショー、イベント等の興行、イベント運営業, barber: ビューティ、ヘルスケア業：床屋、理容室, beauty_salon: ビューティ、ヘルスケア業：美容室, spa_sand_bath_sauna: ビューティ、ヘルスケア業：スパ、砂風呂、サウナ等, este_ail_salon: ビューティ、ヘルスケア業：その他、エステサロン、ネイルサロン等, bridal_planning_introduce_wedding: 冠婚葬祭業：ブライダルプランニング、結婚式場紹介等, memorial_ceremony_funeral: 冠婚葬祭業：メモリアルセレモニー、葬儀等, moving: 引っ越し業, courier_industry: 宅配業, house_maid_cleaning_agency: 家事代行サービス業：無店舗　ハウスメイド、掃除代行等, re_tailoring_clothes: 家事代行サービス業：店舗あり　衣類修理、衣類仕立て直し等, training_institute_management: 研修所等の施設運営業, tutoring_school: 学習塾、進学塾等の教育・学習支援業, music_calligraphy_abacus_classroom: 音楽教室、書道教室、そろばん教室等のの教育・学習支援業, english_school: 英会話スクール等の語学学習支援業, tennis_yoga_judo_school: テニススクール、ヨガ教室、柔道場等のスポーツ指導、支援業, culture_school: その他、カルチャースクール等の教育・学習支援業, seminar_planning_management: セミナー等の企画、運営業, hospital_clinic: 医療業：病院、一般診療所、クリニック等, dental_clinic: 医療業：歯科診療所, other_medical_services: 医療業：その他、医療サービス等, nursery: 福祉業：保育所等、児童向け施設型サービス, nursing_home: 福祉業：老人ホーム等、老人向け施設型サービス, rehabilitation_support_services: 福祉業：療育支援サービス等、障害者等向け施設型サービス, other_welfare: 福祉業：その他、施設型福祉サービス, visit_welfare_service: 福祉業：訪問型福祉サービス, recruitment_temporary_staffing: 人材紹介業、人材派遣業, life_related_recruitment_temporary_staffing: 生活関連サービスの人材紹介業、人材派遣業, car_maintenance_car_repair: 自動車整備業、自動車修理業, machinery_equipment_maintenance_repair: 機械機器類の整備業、修理業, cleaning_maintenance_building_management: 清掃業、メンテナンス業、建物管理業, security: 警備業, other_services: その他のサービス業, npo: NPO, general_incorporated_association: 一般社団法人, general_incorporated_foundation: 一般財団法人, other_association: その他組織).</param>
        public UpdateCompanyParamsSalesInformationAttributes(IndustryClassEnum? industryClass = default(IndustryClassEnum?), IndustryCodeEnum? industryCode = default(IndustryCodeEnum?))
        {
            this.IndustryClass = industryClass;
            this.IndustryCode = industryCode;
        }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCompanyParamsSalesInformationAttributes {\n");
            sb.Append("  IndustryClass: ").Append(IndustryClass).Append("\n");
            sb.Append("  IndustryCode: ").Append(IndustryCode).Append("\n");
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
            return this.Equals(input as UpdateCompanyParamsSalesInformationAttributes);
        }

        /// <summary>
        /// Returns true if UpdateCompanyParamsSalesInformationAttributes instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCompanyParamsSalesInformationAttributes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCompanyParamsSalesInformationAttributes input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.IndustryClass == input.IndustryClass ||
                    this.IndustryClass.Equals(input.IndustryClass)
                ) && 
                (
                    this.IndustryCode == input.IndustryCode ||
                    this.IndustryCode.Equals(input.IndustryCode)
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
                hashCode = hashCode * 59 + this.IndustryClass.GetHashCode();
                hashCode = hashCode * 59 + this.IndustryCode.GetHashCode();
                return hashCode;
            }
        }

    }

}
