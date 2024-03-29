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
    /// TrialBsTwoYearsResponse
    /// </summary>
    [DataContract(Name = "trialBsTwoYearsResponse")]
    public partial class TrialBsTwoYearsResponse : IEquatable<TrialBsTwoYearsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TrialBsTwoYearsResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponse" /> class.
        /// </summary>
        /// <param name="trialBsTwoYears">trialBsTwoYears (required).</param>
        /// <param name="upToDate">集計結果が最新かどうか (required).</param>
        /// <param name="upToDateReasons">集計が最新でない場合の要因情報.</param>
        public TrialBsTwoYearsResponse(TrialBsTwoYearsResponseTrialBsTwoYears trialBsTwoYears = default(TrialBsTwoYearsResponseTrialBsTwoYears), bool upToDate = default(bool), List<JournalsResponseJournalsUpToDateReasons> upToDateReasons = default(List<JournalsResponseJournalsUpToDateReasons>))
        {
            // to ensure "trialBsTwoYears" is required (not null)
            if (trialBsTwoYears == null) {
                throw new ArgumentNullException("trialBsTwoYears is a required property for TrialBsTwoYearsResponse and cannot be null");
            }
            this.TrialBsTwoYears = trialBsTwoYears;
            this.UpToDate = upToDate;
            this.UpToDateReasons = upToDateReasons;
        }

        /// <summary>
        /// Gets or Sets TrialBsTwoYears
        /// </summary>
        [DataMember(Name = "trial_bs_two_years", IsRequired = true, EmitDefaultValue = false)]
        public TrialBsTwoYearsResponseTrialBsTwoYears TrialBsTwoYears { get; set; }

        /// <summary>
        /// 集計結果が最新かどうか
        /// </summary>
        /// <value>集計結果が最新かどうか</value>
        [DataMember(Name = "up_to_date", IsRequired = true, EmitDefaultValue = true)]
        public bool UpToDate { get; set; }

        /// <summary>
        /// 集計が最新でない場合の要因情報
        /// </summary>
        /// <value>集計が最新でない場合の要因情報</value>
        [DataMember(Name = "up_to_date_reasons", EmitDefaultValue = false)]
        public List<JournalsResponseJournalsUpToDateReasons> UpToDateReasons { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TrialBsTwoYearsResponse {\n");
            sb.Append("  TrialBsTwoYears: ").Append(TrialBsTwoYears).Append("\n");
            sb.Append("  UpToDate: ").Append(UpToDate).Append("\n");
            sb.Append("  UpToDateReasons: ").Append(UpToDateReasons).Append("\n");
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
            return this.Equals(input as TrialBsTwoYearsResponse);
        }

        /// <summary>
        /// Returns true if TrialBsTwoYearsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialBsTwoYearsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialBsTwoYearsResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TrialBsTwoYears == input.TrialBsTwoYears ||
                    (this.TrialBsTwoYears != null &&
                    this.TrialBsTwoYears.Equals(input.TrialBsTwoYears))
                ) && 
                (
                    this.UpToDate == input.UpToDate ||
                    this.UpToDate.Equals(input.UpToDate)
                ) && 
                (
                    this.UpToDateReasons == input.UpToDateReasons ||
                    this.UpToDateReasons != null &&
                    input.UpToDateReasons != null &&
                    this.UpToDateReasons.SequenceEqual(input.UpToDateReasons)
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
                if (this.TrialBsTwoYears != null)
                {
                    hashCode = (hashCode * 59) + this.TrialBsTwoYears.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UpToDate.GetHashCode();
                if (this.UpToDateReasons != null)
                {
                    hashCode = (hashCode * 59) + this.UpToDateReasons.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
