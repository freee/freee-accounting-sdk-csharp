using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Freee.Accounting.Api;
using Freee.Accounting.Client;
using Freee.Accounting.Models;

using Sharprompt;

namespace CreateDeal
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

            // 各種マスタの取得
            var accountItems = await new AccountItemsApi(config).GetAccountItemsAsync(companyId);
            var taxesCodes = await new TaxesApi(config).GetTaxCodesAsync();
            var partners = await new PartnersApi(config).GetPartnersAsync(companyId);
            var sections = await new SectionsApi(config).GetSectionsAsync(companyId);
            var items = await new ItemsApi(config).GetItemsAsync(companyId);
            var tags = await new TagsApi(config).GetTagsAsync(companyId);

            // ユーザー入力
            var selectedAccountItem = Prompt.Select("勘定科目", accountItems.AccountItems, valueSelector: x => x.Name);
            var selectedTaxesCode = Prompt.Select("税区分コード", taxesCodes.Taxes, valueSelector: x => x.NameJa);
            var selectedPartner = Prompt.Select("取引先", partners.Partners, valueSelector: x => x.Name);
            var selectedSection = Prompt.Select("部門", sections.Sections, valueSelector: x => x.Name);
            var selectedItem = Prompt.Select("品目", items.Items, valueSelector: x => x.Name);
            var selectedTag = Prompt.Select("タグ", tags.Tags, valueSelector: x => x.Name);

            var amount = Prompt.Input<int>("取引金額");

            // 未決済取引の作成
            var details = new List<DealCreateParamsDetails>
            {
                new DealCreateParamsDetails
                {
                    AccountItemId = selectedAccountItem.Id,
                    Amount = amount,
                    ItemId = selectedItem.Id,
                    SectionId = selectedSection.Id,
                    TagIds = new List<int> { selectedTag.Id },
                    TaxCode = selectedTaxesCode.Code
                }
            };

            var dealResponse = await new DealsApi(config).CreateDealAsync(new DealCreateParams
            {
                CompanyId = companyId,
                Details = details,
                IssueDate = "2019-07-01",
                DueDate = "2019-08-31",
                PartnerId = selectedPartner.Id,
                RefNumber = "100",
                Type = DealCreateParams.TypeEnum.Income
            });

            var newDeal = dealResponse.Deal;

            Console.WriteLine("取引（未決済）を作成しました。");

            // ユーザー入力
            var walletables = await new WalletablesApi(config).GetWalletablesAsync(companyId);

            var selectedWalletable = Prompt.Select("決済口座", walletables.Walletables, valueSelector: x => x.Name);

            // 決済の登録
            var paymentResponse = await new PaymentsApi(config).CreateDealPaymentAsync(newDeal.Id, new PaymentParams
            {
                CompanyId = companyId,
                Date = "2019-07-30",
                Amount = amount,
                FromWalletableId = selectedWalletable.Id,
                FromWalletableType = ToWalletableTypeEnum(selectedWalletable.Type)
            });

            Console.WriteLine("決済を登録しました。");

            var updateDeal = paymentResponse.Deal;

            // 更新の登録
            await new RenewsApi(config).CreateDealRenewAsync(updateDeal.Id, new RenewCreateParams
            {
                CompanyId = companyId,
                UpdateDate = "2019-07-30",
                RenewTargetId = updateDeal.Details[0].Id,
                Details = new List<RenewCreateParamsDetails>
                {
                    new RenewCreateParamsDetails
                    {
                        AccountItemId = selectedAccountItem.Id,
                        Amount = amount,
                        ItemId = selectedItem.Id,
                        SectionId = selectedSection.Id,
                        TagIds = new List<int> { selectedTag.Id },
                        TaxCode = selectedTaxesCode.Code
                    }
                }
            });
        }

        private static PaymentParams.FromWalletableTypeEnum ToWalletableTypeEnum(Walletable.TypeEnum type)
        {
            switch (type)
            {
                case Walletable.TypeEnum.Bankaccount:
                    return PaymentParams.FromWalletableTypeEnum.Bankaccount;
                case Walletable.TypeEnum.Creditcard:
                    return PaymentParams.FromWalletableTypeEnum.Creditcard;
                case Walletable.TypeEnum.Wallet:
                    return PaymentParams.FromWalletableTypeEnum.Wallet;
                default:
                    throw new NotSupportedException(nameof(type));
            }
        }
    }
}
