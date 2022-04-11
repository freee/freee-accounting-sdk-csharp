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
    /// TrialCrSectionsResponseTrialCrSectionsSections
    /// </summary>
    [DataContract(Name = "trialCrSectionsResponse_trial_cr_sections_sections")]
    public partial class TrialCrSectionsResponseTrialCrSectionsSections : IEquatable<TrialCrSectionsResponseTrialCrSectionsSections>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialCrSectionsResponseTrialCrSectionsSections" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TrialCrSectionsResponseTrialCrSectionsSections() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialCrSectionsResponseTrialCrSectionsSections" /> class.
        /// </summary>
        /// <param name="closingBalance">期末残高.</param>
        /// <param name="id">部門ID (required).</param>
        /// <param name="items">breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="name">部門名.</param>
        /// <param name="partners">breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="segment1Tags">breakdown_display_type:segment_1_tag, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="segment2Tags">breakdown_display_type:segment_2_tag, account_item_display_type:account_item指定時のみ含まれる.</param>
        /// <param name="segment3Tags">breakdown_display_type:segment_3_tag, account_item_display_type:account_item指定時のみ含まれる.</param>
        public TrialCrSectionsResponseTrialCrSectionsSections(int closingBalance = default(int), int id = default(int), List<TrialCrSectionsResponseTrialCrSectionsItems> items = default(List<TrialCrSectionsResponseTrialCrSectionsItems>), string name = default(string), List<TrialCrSectionsResponseTrialCrSectionsPartners> partners = default(List<TrialCrSectionsResponseTrialCrSectionsPartners>), List<TrialCrSectionsResponseTrialCrSectionsSegment1Tags> segment1Tags = default(List<TrialCrSectionsResponseTrialCrSectionsSegment1Tags>), List<TrialCrSectionsResponseTrialCrSectionsSegment2Tags> segment2Tags = default(List<TrialCrSectionsResponseTrialCrSectionsSegment2Tags>), List<TrialCrSectionsResponseTrialCrSectionsSegment3Tags> segment3Tags = default(List<TrialCrSectionsResponseTrialCrSectionsSegment3Tags>))
        {
            this.Id = id;
            this.ClosingBalance = closingBalance;
            this.Items = items;
            this.Name = name;
            this.Partners = partners;
            this.Segment1Tags = segment1Tags;
            this.Segment2Tags = segment2Tags;
            this.Segment3Tags = segment3Tags;
        }

        /// <summary>
        /// 期末残高
        /// </summary>
        /// <value>期末残高</value>
        [DataMember(Name = "closing_balance", EmitDefaultValue = false)]
        public int ClosingBalance { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        /// <value>部門ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:item, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<TrialCrSectionsResponseTrialCrSectionsItems> Items { get; set; }

        /// <summary>
        /// 部門名
        /// </summary>
        /// <value>部門名</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:partner, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name = "partners", EmitDefaultValue = false)]
        public List<TrialCrSectionsResponseTrialCrSectionsPartners> Partners { get; set; }

        /// <summary>
        /// breakdown_display_type:segment_1_tag, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:segment_1_tag, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name = "segment_1_tags", EmitDefaultValue = false)]
        public List<TrialCrSectionsResponseTrialCrSectionsSegment1Tags> Segment1Tags { get; set; }

        /// <summary>
        /// breakdown_display_type:segment_2_tag, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:segment_2_tag, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name = "segment_2_tags", EmitDefaultValue = false)]
        public List<TrialCrSectionsResponseTrialCrSectionsSegment2Tags> Segment2Tags { get; set; }

        /// <summary>
        /// breakdown_display_type:segment_3_tag, account_item_display_type:account_item指定時のみ含まれる
        /// </summary>
        /// <value>breakdown_display_type:segment_3_tag, account_item_display_type:account_item指定時のみ含まれる</value>
        [DataMember(Name = "segment_3_tags", EmitDefaultValue = false)]
        public List<TrialCrSectionsResponseTrialCrSectionsSegment3Tags> Segment3Tags { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TrialCrSectionsResponseTrialCrSectionsSections {\n");
            sb.Append("  ClosingBalance: ").Append(ClosingBalance).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Partners: ").Append(Partners).Append("\n");
            sb.Append("  Segment1Tags: ").Append(Segment1Tags).Append("\n");
            sb.Append("  Segment2Tags: ").Append(Segment2Tags).Append("\n");
            sb.Append("  Segment3Tags: ").Append(Segment3Tags).Append("\n");
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
            return this.Equals(input as TrialCrSectionsResponseTrialCrSectionsSections);
        }

        /// <summary>
        /// Returns true if TrialCrSectionsResponseTrialCrSectionsSections instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialCrSectionsResponseTrialCrSectionsSections to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialCrSectionsResponseTrialCrSectionsSections input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ClosingBalance == input.ClosingBalance ||
                    this.ClosingBalance.Equals(input.ClosingBalance)
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    input.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Partners == input.Partners ||
                    this.Partners != null &&
                    input.Partners != null &&
                    this.Partners.SequenceEqual(input.Partners)
                ) && 
                (
                    this.Segment1Tags == input.Segment1Tags ||
                    this.Segment1Tags != null &&
                    input.Segment1Tags != null &&
                    this.Segment1Tags.SequenceEqual(input.Segment1Tags)
                ) && 
                (
                    this.Segment2Tags == input.Segment2Tags ||
                    this.Segment2Tags != null &&
                    input.Segment2Tags != null &&
                    this.Segment2Tags.SequenceEqual(input.Segment2Tags)
                ) && 
                (
                    this.Segment3Tags == input.Segment3Tags ||
                    this.Segment3Tags != null &&
                    input.Segment3Tags != null &&
                    this.Segment3Tags.SequenceEqual(input.Segment3Tags)
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
                hashCode = (hashCode * 59) + this.ClosingBalance.GetHashCode();
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                if (this.Items != null)
                {
                    hashCode = (hashCode * 59) + this.Items.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Partners != null)
                {
                    hashCode = (hashCode * 59) + this.Partners.GetHashCode();
                }
                if (this.Segment1Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Segment1Tags.GetHashCode();
                }
                if (this.Segment2Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Segment2Tags.GetHashCode();
                }
                if (this.Segment3Tags != null)
                {
                    hashCode = (hashCode * 59) + this.Segment3Tags.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}