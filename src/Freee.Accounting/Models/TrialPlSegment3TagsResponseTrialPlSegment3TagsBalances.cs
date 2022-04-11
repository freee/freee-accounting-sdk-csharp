/*
 * freee API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Freee.Accounting.Client.OpenAPIDateConverter;

namespace Freee.Accounting.Models
{
    /// <summary>
    /// TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances
    /// </summary>
    [DataContract(Name = "trialPlSegment_3TagsResponse_trial_pl_segment_3_tags_balances")]
    public partial class TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances : IEquatable<TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances" /> class.
        /// </summary>
        /// <param name="accountCategoryName">勘定科目カテゴリー名.</param>
        /// <param name="accountGroupName">決算書表示名(account_item_display_type:group指定時に決算書表示名の時のみ含まれる).</param>
        /// <param name="accountItemId">勘定科目ID(勘定科目の時のみ含まれる).</param>
        /// <param name="accountItemName">勘定科目名(勘定科目の時のみ含まれる).</param>
        /// <param name="closingBalance">期末残高.</param>
        /// <param name="hierarchyLevel">階層レベル.</param>
        /// <param name="parentAccountCategoryName">上位勘定科目カテゴリー名(勘定科目カテゴリーの時のみ、上層が存在する場合含まれる).</param>
        /// <param name="segment3Tags">セグメント3タグ.</param>
        /// <param name="totalLine">合計行(勘定科目カテゴリーの時のみ含まれる).</param>
        public TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances(string accountCategoryName = default(string), string accountGroupName = default(string), int accountItemId = default(int), string accountItemName = default(string), int closingBalance = default(int), int hierarchyLevel = default(int), string parentAccountCategoryName = default(string), List<TrialPlSegment3TagsResponseTrialPlSegment3TagsSegment3Tags> segment3Tags = default(List<TrialPlSegment3TagsResponseTrialPlSegment3TagsSegment3Tags>), bool totalLine = default(bool))
        {
            this.AccountCategoryName = accountCategoryName;
            this.AccountGroupName = accountGroupName;
            this.AccountItemId = accountItemId;
            this.AccountItemName = accountItemName;
            this.ClosingBalance = closingBalance;
            this.HierarchyLevel = hierarchyLevel;
            this.ParentAccountCategoryName = parentAccountCategoryName;
            this.Segment3Tags = segment3Tags;
            this.TotalLine = totalLine;
        }

        /// <summary>
        /// 勘定科目カテゴリー名
        /// </summary>
        /// <value>勘定科目カテゴリー名</value>
        [DataMember(Name = "account_category_name", EmitDefaultValue = false)]
        public string AccountCategoryName { get; set; }

        /// <summary>
        /// 決算書表示名(account_item_display_type:group指定時に決算書表示名の時のみ含まれる)
        /// </summary>
        /// <value>決算書表示名(account_item_display_type:group指定時に決算書表示名の時のみ含まれる)</value>
        [DataMember(Name = "account_group_name", EmitDefaultValue = false)]
        public string AccountGroupName { get; set; }

        /// <summary>
        /// 勘定科目ID(勘定科目の時のみ含まれる)
        /// </summary>
        /// <value>勘定科目ID(勘定科目の時のみ含まれる)</value>
        [DataMember(Name = "account_item_id", EmitDefaultValue = false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 勘定科目名(勘定科目の時のみ含まれる)
        /// </summary>
        /// <value>勘定科目名(勘定科目の時のみ含まれる)</value>
        [DataMember(Name = "account_item_name", EmitDefaultValue = false)]
        public string AccountItemName { get; set; }

        /// <summary>
        /// 期末残高
        /// </summary>
        /// <value>期末残高</value>
        [DataMember(Name = "closing_balance", EmitDefaultValue = false)]
        public int ClosingBalance { get; set; }

        /// <summary>
        /// 階層レベル
        /// </summary>
        /// <value>階層レベル</value>
        [DataMember(Name = "hierarchy_level", EmitDefaultValue = false)]
        public int HierarchyLevel { get; set; }

        /// <summary>
        /// 上位勘定科目カテゴリー名(勘定科目カテゴリーの時のみ、上層が存在する場合含まれる)
        /// </summary>
        /// <value>上位勘定科目カテゴリー名(勘定科目カテゴリーの時のみ、上層が存在する場合含まれる)</value>
        [DataMember(Name = "parent_account_category_name", EmitDefaultValue = false)]
        public string ParentAccountCategoryName { get; set; }

        /// <summary>
        /// セグメント3タグ
        /// </summary>
        /// <value>セグメント3タグ</value>
        [DataMember(Name = "segment_3_tags", EmitDefaultValue = false)]
        public List<TrialPlSegment3TagsResponseTrialPlSegment3TagsSegment3Tags> Segment3Tags { get; set; }

        /// <summary>
        /// 合計行(勘定科目カテゴリーの時のみ含まれる)
        /// </summary>
        /// <value>合計行(勘定科目カテゴリーの時のみ含まれる)</value>
        [DataMember(Name = "total_line", EmitDefaultValue = true)]
        public bool TotalLine { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances {\n");
            sb.Append("  AccountCategoryName: ").Append(AccountCategoryName).Append("\n");
            sb.Append("  AccountGroupName: ").Append(AccountGroupName).Append("\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  AccountItemName: ").Append(AccountItemName).Append("\n");
            sb.Append("  ClosingBalance: ").Append(ClosingBalance).Append("\n");
            sb.Append("  HierarchyLevel: ").Append(HierarchyLevel).Append("\n");
            sb.Append("  ParentAccountCategoryName: ").Append(ParentAccountCategoryName).Append("\n");
            sb.Append("  Segment3Tags: ").Append(Segment3Tags).Append("\n");
            sb.Append("  TotalLine: ").Append(TotalLine).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances);
        }

        /// <summary>
        /// Returns true if TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialPlSegment3TagsResponseTrialPlSegment3TagsBalances input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountCategoryName == input.AccountCategoryName ||
                    (this.AccountCategoryName != null &&
                    this.AccountCategoryName.Equals(input.AccountCategoryName))
                ) && 
                (
                    this.AccountGroupName == input.AccountGroupName ||
                    (this.AccountGroupName != null &&
                    this.AccountGroupName.Equals(input.AccountGroupName))
                ) && 
                (
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.AccountItemName == input.AccountItemName ||
                    (this.AccountItemName != null &&
                    this.AccountItemName.Equals(input.AccountItemName))
                ) && 
                (
                    this.ClosingBalance == input.ClosingBalance ||
                    this.ClosingBalance.Equals(input.ClosingBalance)
                ) && 
                (
                    this.HierarchyLevel == input.HierarchyLevel ||
                    this.HierarchyLevel.Equals(input.HierarchyLevel)
                ) && 
                (
                    this.ParentAccountCategoryName == input.ParentAccountCategoryName ||
                    (this.ParentAccountCategoryName != null &&
                    this.ParentAccountCategoryName.Equals(input.ParentAccountCategoryName))
                ) && 
                (
                    this.Segment3Tags == input.Segment3Tags ||
                    this.Segment3Tags != null &&
                    input.Segment3Tags != null &&
                    this.Segment3Tags.SequenceEqual(input.Segment3Tags)
                ) && 
                (
                    this.TotalLine == input.TotalLine ||
                    this.TotalLine.Equals(input.TotalLine)
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
                if (this.AccountCategoryName != null)
                {
                    hashCode = (hashCode * 59) + this.AccountCategoryName.GetHashCode();
                }
                if (this.AccountGroupName != null)
                {
                    hashCode = (hashCode * 59) + this.AccountGroupName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AccountItemId.GetHashCode();
                if (this.AccountItemName != null)
                {
                    hashCode = (hashCode * 59) + this.AccountItemName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ClosingBalance.GetHashCode();
                hashCode = (hashCode * 59) + this.HierarchyLevel.GetHashCode();
                if (this.ParentAccountCategoryName != null)
                {
                    hashCode = (hashCode * 59) + this.ParentAccountCategoryName.GetHashCode();
                }
                if (this.Segment3Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Segment3Tags.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TotalLine.GetHashCode();
                return hashCode;
            }
        }

    }

}