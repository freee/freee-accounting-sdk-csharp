using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Freee.Accounting.Api;
using Freee.Accounting.Client;
using Freee.Accounting.Models;

namespace CreateExpenseApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var companyId = 0;
            var accessToken = "";

            // Configuration を作成
            var config = new Configuration
            {
                AccessToken = accessToken
            };

            // 領収書をアップロード
            var receipt = await new ReceiptsApi(config).CreateReceiptAsync(companyId, File.OpenRead("receipt.jpg"));

            // 経費精算を作成する
            await new ExpenseApplicationsApi(config).CreateExpenseApplicationAsync(new CreateExpenseApplicationParams(
                companyId, "テスト経費精算", "2019-07-22", "これは SDK のテストで作成したデータです",
                expenseApplicationLines: new List<CreateExpenseApplicationParamsExpenseApplicationLines>
                {
                    new CreateExpenseApplicationParamsExpenseApplicationLines
                    {
                        ExpenseApplicationLineTemplateId = 0,
                        TransactionDate = "2019-07-20",
                        Amount = 10000,
                        Description = "テスト経費",
                        ReceiptId = receipt.Receipt.Id
                    }
                }));
        }
    }
}
