using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WorkFlowServices.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class HistoryItem : IEquatable<HistoryItem>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets ProcessId
        /// </summary>
        [Required]
        [DataMember(Name = "ProcessId")]
        public Guid? ProcessId { get; set; }

        /// <summary>
        /// Gets or Sets IdentityId
        /// </summary>
        [DataMember(Name = "IdentityId")]
        public string IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets AllowedToEmployeeNames
        /// </summary>
        [DataMember(Name = "AllowedToEmployeeNames")]
        public string AllowedToEmployeeNames { get; set; }

        /// <summary>
        /// Gets or Sets TransitionTime
        /// </summary>
        [DataMember(Name = "TransitionTime")]
        public DateTime? TransitionTime { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [Required]
        [DataMember(Name = "Order")]
        public int? Order { get; set; }

        /// <summary>
        /// Gets or Sets InitialState
        /// </summary>
        [Required]
        [DataMember(Name = "InitialState")]
        public string InitialState { get; set; }

        /// <summary>
        /// Gets or Sets DestinationState
        /// </summary>
        [Required]
        [DataMember(Name = "DestinationState")]
        public string DestinationState { get; set; }

        /// <summary>
        /// Gets or Sets Command
        /// </summary>
        [DataMember(Name = "Command")]
        public string Command { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistoryItem {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProcessId: ").Append(ProcessId).Append("\n");
            sb.Append("  IdentityId: ").Append(IdentityId).Append("\n");
            sb.Append("  AllowedToEmployeeNames: ").Append(AllowedToEmployeeNames).Append("\n");
            sb.Append("  TransitionTime: ").Append(TransitionTime).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  InitialState: ").Append(InitialState).Append("\n");
            sb.Append("  DestinationState: ").Append(DestinationState).Append("\n");
            sb.Append("  Command: ").Append(Command).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((HistoryItem)obj);
        }

        /// <summary>
        /// Returns true if HistoryItem instances are equal
        /// </summary>
        /// <param name="other">Instance of HistoryItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HistoryItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    ProcessId == other.ProcessId ||
                    ProcessId != null &&
                    ProcessId.Equals(other.ProcessId)
                ) &&
                (
                    IdentityId == other.IdentityId ||
                    IdentityId != null &&
                    IdentityId.Equals(other.IdentityId)
                ) &&
                (
                    AllowedToEmployeeNames == other.AllowedToEmployeeNames ||
                    AllowedToEmployeeNames != null &&
                    AllowedToEmployeeNames.Equals(other.AllowedToEmployeeNames)
                ) &&
                (
                    TransitionTime == other.TransitionTime ||
                    TransitionTime != null &&
                    TransitionTime.Equals(other.TransitionTime)
                ) &&
                (
                    Order == other.Order ||
                    Order != null &&
                    Order.Equals(other.Order)
                ) &&
                (
                    InitialState == other.InitialState ||
                    InitialState != null &&
                    InitialState.Equals(other.InitialState)
                ) &&
                (
                    DestinationState == other.DestinationState ||
                    DestinationState != null &&
                    DestinationState.Equals(other.DestinationState)
                ) &&
                (
                    Command == other.Command ||
                    Command != null &&
                    Command.Equals(other.Command)
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
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (ProcessId != null)
                    hashCode = hashCode * 59 + ProcessId.GetHashCode();
                if (IdentityId != null)
                    hashCode = hashCode * 59 + IdentityId.GetHashCode();
                if (AllowedToEmployeeNames != null)
                    hashCode = hashCode * 59 + AllowedToEmployeeNames.GetHashCode();
                if (TransitionTime != null)
                    hashCode = hashCode * 59 + TransitionTime.GetHashCode();
                if (Order != null)
                    hashCode = hashCode * 59 + Order.GetHashCode();
                if (InitialState != null)
                    hashCode = hashCode * 59 + InitialState.GetHashCode();
                if (DestinationState != null)
                    hashCode = hashCode * 59 + DestinationState.GetHashCode();
                if (Command != null)
                    hashCode = hashCode * 59 + Command.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(HistoryItem left, HistoryItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HistoryItem left, HistoryItem right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
