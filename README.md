# 会計freee C# SDK #

会計freee APIを C# で利用するための SDK です。

会計APIの詳細については、[会計API 概要 | freee Developers Community](https://developer.freee.co.jp/docs/accounting) をご参照ください。

## 目次 ##

- [チュートリアル](#チュートリアル)
  - [前提条件](#前提条件)
  - [実行環境](#実行環境)
  - [freeeアプリストアへのアプリケーション登録](#freeeアプリストアへのアプリケーション登録)
  - [サンプルの実行方法](#サンプルの実行方法)
  - [SDKの導入方法](#SDKの導入方法)
- [コントリビューションについて](#コントリビューションについて)
- [ライセンス](#ライセンス)

## チュートリアル ##

会計freee API C# SDK を利用する手順について記載します。

### 前提条件 ###

本SDKを利用する前に下記をご確認ください。

- freee 本体のアカウントがあること
- ASP.NET Core および ASP.NET Core MVC の基礎について理解があること

freee 本体のアカウントは、後述する [freeeアプリストアへのアプリケーション登録](#freeeアプリストアへのアプリケーション登録) で必要になります。

freee API に関しては、[チュートリアルガイド](https://app.secure.freee.co.jp/developers/tutorials/1-freee%20API%E3%82%92%E5%A7%8B%E3%82%81%E3%82%8B#freee%20API%E3%82%92%E5%A7%8B%E3%82%81%E3%82%8B) をご参照ください。

ASP.NET Core の基礎知識については、[ASP.NET Core - ASP.NET のドキュメント | Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/?view=aspnetcore-2.2#pivot=core) をご参照ください。

### 実行環境 ###

このリポジトリは以下の環境を想定しています。

- .NET Core 2.2 以上
  - dotnet コマンド
- [Visual Studio Code](https://code.visualstudio.com/)
  - [C# エクステンション](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

このリポジトリは、.NET Core 2.2 を対象としています。SDK をお持ちでない方は、[.NET のダウンロードページ](https://dotnet.microsoft.com/download) から .NET Core SDK をダウンロードしインストールして下さい。dotnet コマンドは、 .NET Core SDK と同時にインストールされます。

Visual Studio Code をお持ちでない方は、[Visual Studio Code ダウンロードページ](https://code.visualstudio.com/Download) より入手し、前述の C# エクステンションをインストールしてください。

### freeeアプリストアへのアプリケーション登録 ###

本 SDK で利用する `ClientId` および `ClientSecret` を取得するため、freeeアプリストアの開発者ページでアプリケーションを登録します。

こちらの [チュートリアル | freee アプリストア](https://app.secure.freee.co.jp/developers/tutorials/2-%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E4%BD%9C%E6%88%90%E3%81%99%E3%82%8B) を参考に、アプリケーションを登録して下さい。

本 SDK と接続するには、コールバックURLに、`https://localhost:5001/signin-freee` を設定します。

### サンプルの実行方法 ###

#### WebApp のサンプル ####

本リポジトリをクローンしたのち、Visual Studio Code を開き、統合ターミナルで下記を実行します。

```powershell
# Visual Studio Code でプロジェクトを開く
cd <freee-accounting-sdk-csharpのクローン先ディレクトリ>
code -r samples\BasicWebApp
```

プロジェクトが開いたら、再び統合ターミナルを開きます。上記で取得した `ClientId` および `ClientSecret` を、下記のようにシークレット情報として設定します。

```powershell
# シークレット情報を追加する
dotnet user-secrets set "Freee:ClientId" "<freee ClientId>"
dotnet user-secrets set "Freee:ClientSecret" "<freee ClientSecret>"
```

シークレットを設定できたら、統合ターミナルで下記を実行し、ブラウザで `https://localhost:5001` を開いてください。

```powershell
dotnet run
```

Welcome と書かれたページが表示されれば正常に起動できています。

右上の `Login` をクリックすると、freeeアプリストアのアプリケーションに対して認証が行われます。初回は「アプリ連携の開始」という画面が表示されますので、内容を確認し「許可する」ボタンをクリックしてください。

正常に認証されれば、 `https://localhost:5001` にリダイレクトされます。上部のバーに _Hello <ユーザー名>!_ と表示され、freeeの情報を取得できていることが確認できます。

### SDKの導入方法 ###

ASP.NET Core MVC プロジェクトに、本 SDK を導入する方法を説明します。

ASP.NET Core MVC のプロジェクトを新規に作成する場合は、[ASP.NET Core MVC の概要 | Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-2.2&tabs=visual-studio-code) をご参照ください。

大まかな作業は下記のとおりです。

- プロジェクトファイルを編集する
- freeeアプリストアに登録したアプリケーションの `ClientId` および `ClientSecret` をシークレット情報として設定する
- `Startup.cs` に認証処理を追加する
- `AccountController` を作成し、 _login_, _logout_ などの処理を実装する
- _View_ に _Login_, _Logout_ を実装する

まず、プロジェクトファイル `<プロジェクト名>.csproj` を以下のように、_[1][2]_ を追加して更新します。 `<UserSecretsId>` には任意の GUID を指定してください。

```xml
  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
    <!-- [1] ここから -->
    <!-- [1] ※ 値には新規に生成したGUIDを指定してください -->
    <UserSecretsId>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</UserSecretsId>
    <!-- [1] ここまでを追加 -->
  </PropertyGroup>

  <ItemGroup>
    ...
    <!-- [2] ここから -->
    <PackageReference Include="Freee.Accounting.Sdk" Version="1.0.0-preview" />
    <PackageReference Include="Freee.OAuth.AspNetCore" Version="1.0.0-preview" />
    <!-- [2] ここまでを追加 -->
  </ItemGroup>
```

プロジェクトファイルを編集出来たら、前述の [サンプルの実行方法](#サンプルの実行方法) を参考にシークレット情報を追加します。なお、追加したパッケージは、初回に実行する際に自動でリストアされます。

次に、認証処理を追加します。`Startup.cs` を以下のように、_[1][2][3]_ を追加して更新します。

```cs
// -- [1] ここから ----
using Freee.OAuth.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
// -- [1] ここまでを追加 ----

// ... 略 ...

namespace BasicWebApp
{
    public class Startup
    {

        // ... 略 ...

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // -- [2] ここから ----
            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = FreeeAuthenticationDefaults.AuthenticationScheme;
                    })
                    .AddCookie()
                    .AddFreee(options =>
                    {
                        options.ClientId = Configuration["Freee:ClientId"];
                        options.ClientSecret = Configuration["Freee:ClientSecret"];
                        options.SaveTokens = true;
                    });
            // -- [2] ここまでを追加 ----

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // -- [3] ここから ----
            app.UseAuthentication();
            // -- [3] ここまでを追加 ----

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
```

アカウントの処理を行うコントローラ `AccountController` を作成します。`Controllers\AccountController.cs` を新規作成し、下記を記述します。ここでは、 _login_、 _logout_、および _me_ （アカウント情報を表示する）処理を作成します。

```cs
using System.Threading.Tasks;

using Freee.Accounting;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;

namespace BasicWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }

        public IActionResult Logout(string returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties { RedirectUri = returnUrl }, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var accountingClient = new AccountingClient(new TokenCredentials(accessToken));

            var user = await accountingClient.Users.GetMeAsync(companies: true);

            var deals = await accountingClient.Deals.ListAsync(user.User.Companies[0].Id, limit: 5);

            ViewBag.Deals = deals.Deals;

            return View(user.User);
        }
    }
}
```

つぎに、View を作成・編集します。

まず、レイアウトに _login/logout_ の機能を追加しましょう。

`Views\Shared\_LoginPartial.cshtml` を新規作成し、下記を記述します。

```html
<ul class="navbar-nav">
@if (User.Identity.IsAuthenticated)
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-action="Me" asp-controller="Account">Hello @User.Identity.Name!</a>
    </li>
    <li class="nav-item">
        <form class="form-inline" asp-action="Logout" asp-controller="Account" asp-route-returnUrl="@Url.Action("Index", "Home", new { area = "" })">
            <button  type="submit" class="nav-link btn btn-link text-dark">Logout</button>
        </form>
    </li>
}
else
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-action="Login" asp-controller="Account">Login</a>
    </li>
}
</ul>
```

`Views\Shared\_Layout.cshtml` を編集し、`<header>` に作成した `_LoginPartial` パーシャルを追加します。

```html
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">MvcSample</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                    <!-- [1] ここから -->
                    <partial name="_LoginPartial" />
                    <!-- [1] ここまで追加 -->
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                    </ul>
```

つぎに、アカウント情報を表示する `Account/Me` のビューを作成します。`Views\Account\Me.cshtml` を新規作成し、下記を記述してください。

```html
@model Freee.Accounting.Models.UsersMeResponseUser
@{
    ViewData["Title"] = "User info";
}

<h1>User info</h1>

<dl>
  <dt>@nameof(Model.Email)</dt>
  <dd>@Model.Email</dd>
  <dt>@nameof(Model.LastName)</dt>
  <dd>@Model.LastName</dd>
  <dt>@nameof(Model.FirstName)</dt>
  <dd>@Model.FirstName</dd>
</dl>

<h2>Deals</h2>

<ul>
  @foreach (Freee.Accounting.Models.Deals deal in ViewBag.Deals)
  {
    <li>
      <span>@deal.IssueDate - @deal.Type</span>
      <br />
      <span>Amount: @deal.Amount</span>
    </li>
  }
</ul>
```

ここまで更新が完了したら、統合ターミナルで下記を実行し、ブラウザで `https://localhost:5001` を開いてください。

```powershell
dotnet run
```

サンプルと同じように動作すれば正常に導入できました。エラーが出る場合は、サンプルを参考に修正してください。

## コントリビューションについて ##

このプロジェクトへのコントリビューションを歓迎いたします。詳細については[コントリビューションガイド](./CONTRIBUTION_GUIDE.md)をご覧ください。

- [機能リクエスト](./CONTRIBUTION_GUIDE.md#機能リクエスト)
- [不具合報告](./CONTRIBUTION_GUIDE.md#不具合報告)
- [プルリクエストの作成について](./CONTRIBUTION_GUIDE.md#プルリクエストの作成について)

## ライセンス ##

ライセンスについては下記をご参照ください。

[MIT License](./LICENSE)
