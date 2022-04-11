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
    /// TrialBsTwoYearsResponseTrialBsTwoYearsSections
    /// </summary>
    [DataContract(Name = "trialBsTwoYearsResponse_trial_bs_two_years_sections")]
    public partial class TrialBsTwoYearsResponseTrialBsTwoYearsSections : IEquatable<TrialBsTwoYearsResponseTrialBsTwoYearsSections>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponseTrialBsTwoYearsSections" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TrialBsTwoYearsResponseTrialBsTwoYearsSections() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrialBsTwoYearsResponseTrialBsTwoYearsSections" /> class.
        /// </summary>
        /// <param name="closingBalance">期末残高.</param>
        /// <param name="id">部門ID (required).</param>
        /// <param name="lastYearClosingBalance">前年度期末残高.</param>
        /// <param name="name">部門名.</param>
        /// <param name="yearOnYear">前年比.</param>
        public TrialBsTwoYearsResponseTrialBsTwoYearsSections(int closingBalance = default(int), int id = default(int), int lastYearClosingBalance = default(int), string name = default(string), decimal yearOnYear = default(decimal))
        {
            this.Id = id;
            this.ClosingBalance = closingBalance;
            this.LastYearClosingBalance = lastYearClosingBalance;
            this.Name = name;
            this.YearOnYear = yearOnYear;
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
        /// 前年度期末残高
        /// </summary>
        /// <value>前年度期末残高</value>
        [DataMember(Name = "last_year_closing_balance", EmitDefaultValue = false)]
        public int LastYearClosingBalance { get; set; }

        /// <summary>
        /// 部門名
        /// </summary>
        /// <value>部門名</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// 前年比
        /// </summary>
        /// <value>前年比</value>
        [DataMember(Name = "year_on_year", EmitDefaultValue = false)]
        public decimal YearOnYear { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TrialBsTwoYearsResponseTrialBsTwoYearsSections {\n");
            sb.Append("  ClosingBalance: ").Append(ClosingBalance).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastYearClosingBalance: ").Append(LastYearClosingBalance).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  YearOnYear: ").Append(YearOnYear).Append("\n");
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
            return this.Equals(input as TrialBsTwoYearsResponseTrialBsTwoYearsSections);
        }

        /// <summary>
        /// Returns true if TrialBsTwoYearsResponseTrialBsTwoYearsSections instances are equal
        /// </summary>
        /// <param name="input">Instance of TrialBsTwoYearsResponseTrialBsTwoYearsSections to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrialBsTwoYearsResponseTrialBsTwoYearsSections input)
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
                    this.LastYearClosingBalance == input.LastYearClosingBalance ||
                    this.LastYearClosingBalance.Equals(input.LastYearClosingBalance)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.YearOnYear == input.YearOnYear ||
                    this.YearOnYear.Equals(input.YearOnYear)
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
                hashCode = (hashCode * 59) + this.LastYearClosingBalance.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.YearOnYear.GetHashCode();
                return hashCode;
            }
        }

    }

}