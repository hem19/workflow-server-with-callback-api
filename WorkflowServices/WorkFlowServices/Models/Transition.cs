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
    public partial class Transition : IEquatable<Transition>
    {
        /// <summary>
        /// Gets or Sets ProcessId
        /// </summary>
        [Required]
        [DataMember(Name = "ProcessId")]
        public Guid? ProcessId { get; set; }

        /// <summary>
        /// Gets or Sets ActorIdentityId
        /// </summary>
        [DataMember(Name = "ActorIdentityId")]
        public string ActorIdentityId { get; set; }

        /// <summary>
        /// Gets or Sets ExecutorIdentityId
        /// </summary>
        [DataMember(Name = "ExecutorIdentityId")]
        public string ExecutorIdentityId { get; set; }

        /// <summary>
        /// Gets or Sets FromActivityName
        /// </summary>
        [Required]
        [DataMember(Name = "FromActivityName")]
        public string FromActivityName { get; set; }

        /// <summary>
        /// Gets or Sets FromStateName
        /// </summary>
        [DataMember(Name = "FromStateName")]
        public string FromStateName { get; set; }

        /// <summary>
        /// Gets or Sets IsFinalised
        /// </summary>
        [DataMember(Name = "IsFinalised")]
        public bool? IsFinalised { get; set; }

        /// <summary>
        /// Gets or Sets ToActivityName
        /// </summary>
        [Required]
        [DataMember(Name = "ToActivityName")]
        public string ToActivityName { get; set; }

        /// <summary>
        /// Gets or Sets ToStateName
        /// </summary>
        [DataMember(Name = "ToStateName")]
        public string ToStateName { get; set; }

        /// <summary>
        /// Gets or Sets TransitionClassifier
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum TransitionClassifierEnum
        {

            /// <summary>
            /// Enum NotSpecifiedEnum for NotSpecified
            /// </summary>
            [EnumMember(Value = "NotSpecified")]
            NotSpecifiedEnum = 1,

            /// <summary>
            /// Enum DirectEnum for Direct
            /// </summary>
            [EnumMember(Value = "Direct")]
            DirectEnum = 2,

            /// <summary>
            /// Enum ReverseEnum for Reverse
            /// </summary>
            [EnumMember(Value = "Reverse")]
            ReverseEnum = 3
        }

        /// <summary>
        /// Gets or Sets TransitionClassifier
        /// </summary>
        [Required]
        [DataMember(Name = "TransitionClassifier")]
        public TransitionClassifierEnum? TransitionClassifier { get; set; }

        /// <summary>
        /// Gets or Sets TransitionTime
        /// </summary>
        [Required]
        [DataMember(Name = "TransitionTime")]
        public DateTime? TransitionTime { get; set; }

        /// <summary>
        /// Gets or Sets TriggerName
        /// </summary>
        [DataMember(Name = "TriggerName")]
        public string TriggerName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Transition {\n");
            sb.Append("  ProcessId: ").Append(ProcessId).Append("\n");
            sb.Append("  ActorIdentityId: ").Append(ActorIdentityId).Append("\n");
            sb.Append("  ExecutorIdentityId: ").Append(ExecutorIdentityId).Append("\n");
            sb.Append("  FromActivityName: ").Append(FromActivityName).Append("\n");
            sb.Append("  FromStateName: ").Append(FromStateName).Append("\n");
            sb.Append("  IsFinalised: ").Append(IsFinalised).Append("\n");
            sb.Append("  ToActivityName: ").Append(ToActivityName).Append("\n");
            sb.Append("  ToStateName: ").Append(ToStateName).Append("\n");
            sb.Append("  TransitionClassifier: ").Append(TransitionClassifier).Append("\n");
            sb.Append("  TransitionTime: ").Append(TransitionTime).Append("\n");
            sb.Append("  TriggerName: ").Append(TriggerName).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Transition)obj);
        }

        /// <summary>
        /// Returns true if Transition instances are equal
        /// </summary>
        /// <param name="other">Instance of Transition to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Transition other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ProcessId == other.ProcessId ||
                    ProcessId != null &&
                    ProcessId.Equals(other.ProcessId)
                ) &&
                (
                    ActorIdentityId == other.ActorIdentityId ||
                    ActorIdentityId != null &&
                    ActorIdentityId.Equals(other.ActorIdentityId)
                ) &&
                (
                    ExecutorIdentityId == other.ExecutorIdentityId ||
                    ExecutorIdentityId != null &&
                    ExecutorIdentityId.Equals(other.ExecutorIdentityId)
                ) &&
                (
                    FromActivityName == other.FromActivityName ||
                    FromActivityName != null &&
                    FromActivityName.Equals(other.FromActivityName)
                ) &&
                (
                    FromStateName == other.FromStateName ||
                    FromStateName != null &&
                    FromStateName.Equals(other.FromStateName)
                ) &&
                (
                    IsFinalised == other.IsFinalised ||
                    IsFinalised != null &&
                    IsFinalised.Equals(other.IsFinalised)
                ) &&
                (
                    ToActivityName == other.ToActivityName ||
                    ToActivityName != null &&
                    ToActivityName.Equals(other.ToActivityName)
                ) &&
                (
                    ToStateName == other.ToStateName ||
                    ToStateName != null &&
                    ToStateName.Equals(other.ToStateName)
                ) &&
                (
                    TransitionClassifier == other.TransitionClassifier ||
                    TransitionClassifier != null &&
                    TransitionClassifier.Equals(other.TransitionClassifier)
                ) &&
                (
                    TransitionTime == other.TransitionTime ||
                    TransitionTime != null &&
                    TransitionTime.Equals(other.TransitionTime)
                ) &&
                (
                    TriggerName == other.TriggerName ||
                    TriggerName != null &&
                    TriggerName.Equals(other.TriggerName)
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
                if (ProcessId != null)
                    hashCode = hashCode * 59 + ProcessId.GetHashCode();
                if (ActorIdentityId != null)
                    hashCode = hashCode * 59 + ActorIdentityId.GetHashCode();
                if (ExecutorIdentityId != null)
                    hashCode = hashCode * 59 + ExecutorIdentityId.GetHashCode();
                if (FromActivityName != null)
                    hashCode = hashCode * 59 + FromActivityName.GetHashCode();
                if (FromStateName != null)
                    hashCode = hashCode * 59 + FromStateName.GetHashCode();
                if (IsFinalised != null)
                    hashCode = hashCode * 59 + IsFinalised.GetHashCode();
                if (ToActivityName != null)
                    hashCode = hashCode * 59 + ToActivityName.GetHashCode();
                if (ToStateName != null)
                    hashCode = hashCode * 59 + ToStateName.GetHashCode();
                if (TransitionClassifier != null)
                    hashCode = hashCode * 59 + TransitionClassifier.GetHashCode();
                if (TransitionTime != null)
                    hashCode = hashCode * 59 + TransitionTime.GetHashCode();
                if (TriggerName != null)
                    hashCode = hashCode * 59 + TriggerName.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Transition left, Transition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Transition left, Transition right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}