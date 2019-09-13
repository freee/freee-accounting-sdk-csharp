using System;
using System.Linq;
using System.Threading.Tasks;

using Freee.Accounting;

using Microsoft.Rest;

namespace GetTrialPLSection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var companyId = 0;
            var accessToken = "";

            // Freee AccountingClient を作成
            var accountingClient = new AccountingClient(new TokenCredentials(accessToken));

            var trialPl = await accountingClient.TrialBalance.GetTrialPlAsync(companyId, 2019);

            foreach (var balance in trialPl.TrialPl.Balances.OrderBy(x => x.ParentAccountCategoryId).ThenBy(x => x.HierarchyLevel))
            {
                Console.Write(balance.ParentAccountCategoryName);
                if (balance.AccountCategoryName != null)
                {
                    Console.Write($"\t\t{balance.AccountCategoryName}");
                }

                if (balance.AccountItemName != null)
                {
                    Console.Write($"\t\t{balance.AccountItemName}");
                }

                Console.WriteLine($"\t\t\t{balance.ClosingBalance}");
            }
        }
    }
}
