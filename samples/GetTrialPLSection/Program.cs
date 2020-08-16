using System;
using System.Linq;
using System.Threading.Tasks;

using Freee.Accounting.Api;
using Freee.Accounting.Client;

namespace GetTrialPLSection
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

            var trialPl = await new TrialBalanceApi(config).GetTrialPlAsync(companyId, 2019);

            foreach (var balance in trialPl.TrialPl.Balances.OrderBy(x => x.ParentAccountCategoryName).ThenBy(x => x.HierarchyLevel))
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
