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
    /// Walletable
    /// </summary>
    [DataContract(Name = "walletable")]
    public partial class Walletable : IEquatable<Walletable>
    {
        /// <summary>
        /// 口座区分 (銀行口座: bank_account, クレジットカード: credit_card, 現金: wallet)
        /// </summary>
        /// <value>口座区分 (銀行口座: bank_account, クレジットカード: credit_card, 現金: wallet)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum BankAccount for value: bank_account
            /// </summary>
            [EnumMember(Value = "bank_account")]
            BankAccount = 1,

            /// <summary>
            /// Enum CreditCard for value: credit_card
            /// </summary>
            [EnumMember(Value = "credit_card")]
            CreditCard = 2,

            /// <summary>
            /// Enum Wallet for value: wallet
            /// </summary>
            [EnumMember(Value = "wallet")]
            Wallet = 3

        }


        /// <summary>
        /// 口座区分 (銀行口座: bank_account, クレジットカード: credit_card, 現金: wallet)
        /// </summary>
        /// <value>口座区分 (銀行口座: bank_account, クレジットカード: credit_card, 現金: wallet)</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Walletable" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Walletable() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Walletable" /> class.
        /// </summary>
        /// <param name="bankId">サービスID (required).</param>
        /// <param name="id">口座ID (required).</param>
        /// <param name="lastBalance">同期残高.</param>
        /// <param name="name">口座名 (255文字以内) (required).</param>
        /// <param name="type">口座区分 (銀行口座: bank_account, クレジットカード: credit_card, 現金: wallet) (required).</param>
        /// <param name="walletableBalance">登録残高.</param>
        public Walletable(int? bankId = default(int?), int id = default(int), int lastBalance = default(int), string name = default(string), TypeEnum type = default(TypeEnum), int walletableBalance = default(int))
        {
            // to ensure "bankId" is required (not null)
            if (bankId == null)
            {
                throw new ArgumentNullException("bankId is a required property for Walletable and cannot be null");
            }
            this.BankId = bankId;
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Walletable and cannot be null");
            }
            this.Name = name;
            this.Type = type;
            this.LastBalance = lastBalance;
            this.WalletableBalance = walletableBalance;
        }

        /// <summary>
        /// サービスID
        /// </summary>
        /// <value>サービスID</value>
        [DataMember(Name = "bank_id", IsRequired = true, EmitDefaultValue = true)]
        public int? BankId { get; set; }

        /// <summary>
        /// 口座ID
        /// </summary>
        /// <value>口座ID</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// 同期残高
        /// </summary>
        /// <value>同期残高</value>
        [DataMember(Name = "last_balance", EmitDefaultValue = false)]
        public int LastBalance { get; set; }

        /// <summary>
        /// 口座名 (255文字以内)
        /// </summary>
        /// <value>口座名 (255文字以内)</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// 登録残高
        /// </summary>
        /// <value>登録残高</value>
        [DataMember(Name = "walletable_balance", EmitDefaultValue = false)]
        public int WalletableBalance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Walletable {\n");
            sb.Append("  BankId: ").Append(BankId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastBalance: ").Append(LastBalance).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  WalletableBalance: ").Append(WalletableBalance).Append("\n");
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
            return this.Equals(input as Walletable);
        }

        /// <summary>
        /// Returns true if Walletable instances are equal
        /// </summary>
        /// <param name="input">Instance of Walletable to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Walletable input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BankId == input.BankId ||
                    (this.BankId != null &&
                    this.BankId.Equals(input.BankId))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.LastBalance == input.LastBalance ||
                    this.LastBalance.Equals(input.LastBalance)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.WalletableBalance == input.WalletableBalance ||
                    this.WalletableBalance.Equals(input.WalletableBalance)
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
                if (this.BankId != null)
                {
                    hashCode = (hashCode * 59) + this.BankId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                hashCode = (hashCode * 59) + this.LastBalance.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                hashCode = (hashCode * 59) + this.WalletableBalance.GetHashCode();
                return hashCode;
            }
        }

    }

}
