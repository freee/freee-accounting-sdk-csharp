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
    /// DealDetails1
    /// </summary>
    [DataContract(Name = "deal_details_1")]
    public partial class DealDetails1 : IEquatable<DealDetails1>
    {
        /// <summary>
        /// 貸借(貸方: credit, 借方: debit)
        /// </summary>
        /// <value>貸借(貸方: credit, 借方: debit)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EntrySideEnum
        {
            /// <summary>
            /// Enum Credit for value: credit
            /// </summary>
            [EnumMember(Value = "credit")]
            Credit = 1,

            /// <summary>
            /// Enum Debit for value: debit
            /// </summary>
            [EnumMember(Value = "debit")]
            Debit = 2

        }


        /// <summary>
        /// 貸借(貸方: credit, 借方: debit)
        /// </summary>
        /// <value>貸借(貸方: credit, 借方: debit)</value>
        [DataMember(Name = "entry_side", IsRequired = true, EmitDefaultValue = false)]
        public EntrySideEnum EntrySide { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealDetails1" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DealDetails1() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DealDetails1" /> class.
        /// </summary>
        /// <param name="accountItemId">勘定科目ID (required).</param>
        /// <param name="amount">金額（税込で指定してください） (required).</param>
        /// <param name="description">備考.</param>
        /// <param name="entrySide">貸借(貸方: credit, 借方: debit) (required).</param>
        /// <param name="id">+更新の明細行ID (required).</param>
        /// <param name="itemId">品目ID.</param>
        /// <param name="sectionId">部門ID.</param>
        /// <param name="segment1TagId">セグメント１ID.</param>
        /// <param name="segment2TagId">セグメント２ID.</param>
        /// <param name="segment3TagId">セグメント３ID.</param>
        /// <param name="tagIds">tagIds (required).</param>
        /// <param name="taxCode">税区分コード (required).</param>
        /// <param name="vat">消費税額（指定しない場合は自動で計算されます） (required).</param>
        public DealDetails1(int accountItemId = default(int), long amount = default(long), string description = default(string), EntrySideEnum entrySide = default(EntrySideEnum), long id = default(long), int? itemId = default(int?), int? sectionId = default(int?), long? segment1TagId = default(long?), long? segment2TagId = default(long?), long? segment3TagId = default(long?), List<int> tagIds = default(List<int>), int taxCode = default(int), int vat = default(int))
        {
            this.AccountItemId = accountItemId;
            this.Amount = amount;
            this.EntrySide = entrySide;
            this.Id = id;
            // to ensure "tagIds" is required (not null)
            if (tagIds == null) {
                throw new ArgumentNullException("tagIds is a required property for DealDetails1 and cannot be null");
            }
            this.TagIds = tagIds;
            this.TaxCode = taxCode;
            this.Vat = vat;
            this.Description = description;
            this.ItemId = itemId;
            this.SectionId = sectionId;
            this.Segment1TagId = segment1TagId;
            this.Segment2TagId = segment2TagId;
            this.Segment3TagId = segment3TagId;
        }

        /// <summary>
        /// 勘定科目ID
        /// </summary>
        /// <value>勘定科目ID</value>
        [DataMember(Name = "account_item_id", IsRequired = true, EmitDefaultValue = false)]
        public int AccountItemId { get; set; }

        /// <summary>
        /// 金額（税込で指定してください）
        /// </summary>
        /// <value>金額（税込で指定してください）</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = false)]
        public long Amount { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        /// <value>備考</value>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// +更新の明細行ID
        /// </summary>
        /// <value>+更新の明細行ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// 品目ID
        /// </summary>
        /// <value>品目ID</value>
        [DataMember(Name = "item_id", EmitDefaultValue = true)]
        public int? ItemId { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        /// <value>部門ID</value>
        [DataMember(Name = "section_id", EmitDefaultValue = true)]
        public int? SectionId { get; set; }

        /// <summary>
        /// セグメント１ID
        /// </summary>
        /// <value>セグメント１ID</value>
        [DataMember(Name = "segment_1_tag_id", EmitDefaultValue = true)]
        public long? Segment1TagId { get; set; }

        /// <summary>
        /// セグメント２ID
        /// </summary>
        /// <value>セグメント２ID</value>
        [DataMember(Name = "segment_2_tag_id", EmitDefaultValue = true)]
        public long? Segment2TagId { get; set; }

        /// <summary>
        /// セグメント３ID
        /// </summary>
        /// <value>セグメント３ID</value>
        [DataMember(Name = "segment_3_tag_id", EmitDefaultValue = true)]
        public long? Segment3TagId { get; set; }

        /// <summary>
        /// Gets or Sets TagIds
        /// </summary>
        [DataMember(Name = "tag_ids", IsRequired = true, EmitDefaultValue = false)]
        public List<int> TagIds { get; set; }

        /// <summary>
        /// 税区分コード
        /// </summary>
        /// <value>税区分コード</value>
        [DataMember(Name = "tax_code", IsRequired = true, EmitDefaultValue = false)]
        public int TaxCode { get; set; }

        /// <summary>
        /// 消費税額（指定しない場合は自動で計算されます）
        /// </summary>
        /// <value>消費税額（指定しない場合は自動で計算されます）</value>
        [DataMember(Name = "vat", IsRequired = true, EmitDefaultValue = false)]
        public int Vat { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DealDetails1 {\n");
            sb.Append("  AccountItemId: ").Append(AccountItemId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EntrySide: ").Append(EntrySide).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  SectionId: ").Append(SectionId).Append("\n");
            sb.Append("  Segment1TagId: ").Append(Segment1TagId).Append("\n");
            sb.Append("  Segment2TagId: ").Append(Segment2TagId).Append("\n");
            sb.Append("  Segment3TagId: ").Append(Segment3TagId).Append("\n");
            sb.Append("  TagIds: ").Append(TagIds).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  Vat: ").Append(Vat).Append("\n");
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
            return this.Equals(input as DealDetails1);
        }

        /// <summary>
        /// Returns true if DealDetails1 instances are equal
        /// </summary>
        /// <param name="input">Instance of DealDetails1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DealDetails1 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountItemId == input.AccountItemId ||
                    this.AccountItemId.Equals(input.AccountItemId)
                ) && 
                (
                    this.Amount == input.Amount ||
                    this.Amount.Equals(input.Amount)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.EntrySide == input.EntrySide ||
                    this.EntrySide.Equals(input.EntrySide)
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.ItemId == input.ItemId ||
                    (this.ItemId != null &&
                    this.ItemId.Equals(input.ItemId))
                ) && 
                (
                    this.SectionId == input.SectionId ||
                    (this.SectionId != null &&
                    this.SectionId.Equals(input.SectionId))
                ) && 
                (
                    this.Segment1TagId == input.Segment1TagId ||
                    (this.Segment1TagId != null &&
                    this.Segment1TagId.Equals(input.Segment1TagId))
                ) && 
                (
                    this.Segment2TagId == input.Segment2TagId ||
                    (this.Segment2TagId != null &&
                    this.Segment2TagId.Equals(input.Segment2TagId))
                ) && 
                (
                    this.Segment3TagId == input.Segment3TagId ||
                    (this.Segment3TagId != null &&
                    this.Segment3TagId.Equals(input.Segment3TagId))
                ) && 
                (
                    this.TagIds == input.TagIds ||
                    this.TagIds != null &&
                    input.TagIds != null &&
                    this.TagIds.SequenceEqual(input.TagIds)
                ) && 
                (
                    this.TaxCode == input.TaxCode ||
                    this.TaxCode.Equals(input.TaxCode)
                ) && 
                (
                    this.Vat == input.Vat ||
                    this.Vat.Equals(input.Vat)
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
                hashCode = (hashCode * 59) + this.AccountItemId.GetHashCode();
                hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.EntrySide.GetHashCode();
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.ItemId != null)
                {
                    hashCode = (hashCode * 59) + this.ItemId.GetHashCode();
                }
                if (this.SectionId != null)
                {
                    hashCode = (hashCode * 59) + this.SectionId.GetHashCode();
                }
                if (this.Segment1TagId != null)
                {
                    hashCode = (hashCode * 59) + this.Segment1TagId.GetHashCode();
                }
                if (this.Segment2TagId != null)
                {
                    hashCode = (hashCode * 59) + this.Segment2TagId.GetHashCode();
                }
                if (this.Segment3TagId != null)
                {
                    hashCode = (hashCode * 59) + this.Segment3TagId.GetHashCode();
                }
                if (this.TagIds != null)
                {
                    hashCode = (hashCode * 59) + this.TagIds.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TaxCode.GetHashCode();
                hashCode = (hashCode * 59) + this.Vat.GetHashCode();
                return hashCode;
            }
        }

    }

}
