using System.IO;
using System.Threading.Tasks;

using Freee.Accounting;
using Freee.Accounting.Models;

using Microsoft.Rest;

namespace CreateExpenseApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var companyId = 0;
            var accessToken = "";

            // Freee AccountingClient を作成
            var accountingClient = new AccountingClient(new TokenCredentials(accessToken));

            // 領収書をアップロード
            var receipt = await accountingClient.Receipts.CreateAsync(companyId, File.OpenRead("receipt.jpg"));

            // 経費精算を作成する
            await accountingClient.ExpenseApplications.CreateAsync(new CreateExpenseApplicationParams
            {
                CompanyId = companyId,
                Title = "テスト経費精算",
                Description = "これは SDK のテストで作成したデータです",
                IssueDate = "2019-07-22",
                ExpenseApplicationLines = new[]
                {
                    new CreateExpenseApplicationParamsExpenseApplicationLinesItem
                    {
                        ExpenseApplicationLineTemplateId = null,
                        TransactionDate = "2019-07-20",
                        Amount = 10000,
                        Description = "テスト経費",
                        ReceiptId = receipt.Receipt.Id
                    }
                }
            });
        }
    }
}
