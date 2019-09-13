using System;
using System.Threading.Tasks;

using Freee.Accounting;
using Freee.Accounting.Models;

using Microsoft.Rest;

using Sharprompt;

namespace CreateDeal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var companyId = 0;
            var accessToken = "";

            // Freee AccountingClient を作成
            var accountingClient = new AccountingClient(new TokenCredentials(accessToken));

            // 各種マスタの取得
            var accountItems = await accountingClient.AccountItems.ListAsync(companyId);
            var taxesCodes = await accountingClient.Taxes.ListTaxCodesAsync();
            var partners = await accountingClient.Partners.ListAsync(companyId);
            var sections = await accountingClient.Sections.ListAsync(companyId);
            var items = await accountingClient.Items.ListAsync(companyId);
            var tags = await accountingClient.Tags.ListAsync(companyId);

            // ユーザー入力
            var selectedAccountItem = Prompt.Select("勘定科目", accountItems.AccountItems, valueSelector: x => x.Name);
            var selectedTaxesCode = Prompt.Select("税区分コード", taxesCodes.Taxes, valueSelector: x => x.NameJa);
            var selectedPartner = Prompt.Select("取引先", partners.Partners, valueSelector: x => x.Name);
            var selectedSection = Prompt.Select("部門", sections.Sections, valueSelector: x => x.Name);
            var selectedItem = Prompt.Select("品目", items.Items, valueSelector: x => x.Name);
            var selectedTag = Prompt.Select("タグ", tags.Tags, valueSelector: x => x.Name);

            var amount = Prompt.Input<int>("取引金額");

            // 未決済取引の作成
            var dealResponse = await accountingClient.Deals.CreateAsync(new CreateDealParams
            {
                CompanyId = companyId,
                IssueDate = "2019-07-01",
                DueDate = "2019-08-31",
                Details = new[]
                {
                    new CreateDealParamsDetailsItem
                    {
                        AccountItemId = selectedAccountItem.Id,
                        Amount = amount,
                        ItemId = selectedItem?.Id,
                        SectionId = selectedSection?.Id,
                        TagIds = new[] {selectedTag?.Id },
                        TaxCode = selectedTaxesCode?.Code
                    }
                },
                PartnerId = selectedPartner?.Id,
                RefNumber = "100",
                Type = "income"
            });

            var newDeal = dealResponse.Deal;

            Console.WriteLine("取引（未決済）を作成しました。");

            // ユーザー入力
            var walletables = await accountingClient.Walletables.ListAsync(companyId);

            var selectedWalletable = Prompt.Select("決済口座", walletables.Walletables, valueSelector: x => x.Name);

            // 決済の登録
            var paymentResponse = await accountingClient.Payments.CreateDealAsync(newDeal.Id, new DealPaymentParams
            {
                CompanyId = companyId,
                Amount = amount,
                Date = "2019-07-30",
                FromWalletableId = selectedWalletable.Id,
                FromWalletableType = selectedWalletable.Type
            });

            Console.WriteLine("決済を登録しました。");

            var updateDeal = paymentResponse.Deal;

            // 更新の登録
            await accountingClient.Renews.CreateDealAsync(updateDeal.Id, new RenewsCreateParams
            {
                CompanyId = companyId,
                UpdateDate = "2019-07-30",
                RenewTargetId = updateDeal.Details[0].Id,
                Details = new[]
                {
                    new RenewsCreateDetailParams
                    {
                        AccountItemId = selectedAccountItem.Id,
                        Amount = amount,
                        ItemId = selectedItem?.Id,
                        SectionId = selectedSection?.Id,
                        TagIds = new[] {selectedTag?.Id },
                        TaxCode = selectedTaxesCode.Code
                    }
                }
            });
        }
    }
}
