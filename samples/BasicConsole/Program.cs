using System;
using System.Threading.Tasks;

using Freee.Accounting;

using Microsoft.Rest;

namespace BasicConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var companyId = 0;
            var accessToken = "";

            // アクセストークンを指定して、クライアントを作成する
            var accountClient = new AccountingClient(new TokenCredentials(accessToken));

            // 事業所の詳細情報を取得する
            var company = await accountClient.Companies.GetAsync(companyId);

            Console.WriteLine($"事業所名 : {company.Company.DisplayName}");

            // 登録されている口座の一覧を取得する
            var walletablesIndex = await accountClient.Walletables.ListAsync(companyId, true);

            foreach (var walletable in walletablesIndex.Walletables)
            {
                Console.WriteLine($"口座名 : {walletable.Name} / 登録残高 : \\{walletable.WalletableBalance:#,0}");
            }

            // 請求書の一覧を取得する
            var invoicesIndex = await accountClient.Invoices.ListAsync(companyId);

            foreach (var invoice in invoicesIndex.Invoices)
            {
                Console.WriteLine($"売上計上日 : {invoice.BookingDate ?? "未設定"} / 合計金額 : \\{invoice.TotalAmount:#,0}");
            }
        }
    }
}
