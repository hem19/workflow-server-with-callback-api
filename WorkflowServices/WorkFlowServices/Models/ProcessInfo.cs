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
    public partial class ProcessInfo : IEquatable<ProcessInfo>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets StateName
        /// </summary>
        [DataMember(Name = "StateName")]
        public string StateName { get; set; }

        /// <summary>
        /// Gets or Sets ActivityName
        /// </summary>
        [Required]
        [DataMember(Name = "ActivityName")]
        public string ActivityName { get; set; }

        /// <summary>
        /// Gets or Sets SchemeId
        /// </summary>
        [DataMember(Name = "SchemeId")]
        public Guid? SchemeId { get; set; }

        /// <summary>
        /// Gets or Sets SchemeCode
        /// </summary>
        [Required]
        [DataMember(Name = "SchemeCode")]
        public string SchemeCode { get; set; }

        /// <summary>
        /// Gets or Sets PreviousState
        /// </summary>
        [DataMember(Name = "PreviousState")]
        public string PreviousState { get; set; }

        /// <summary>
        /// Gets or Sets PreviousStateForDirect
        /// </summary>
        [DataMember(Name = "PreviousStateForDirect")]
        public string PreviousStateForDirect { get; set; }

        /// <summary>
        /// Gets or Sets PreviousStateForReverse
        /// </summary>
        [DataMember(Name = "PreviousStateForReverse")]
        public string PreviousStateForReverse { get; set; }

        /// <summary>
        /// Gets or Sets PreviousActivity
        /// </summary>
        [DataMember(Name = "PreviousActivity")]
        public string PreviousActivity { get; set; }

        /// <summary>
        /// Gets or Sets PreviousActivityForDirect
        /// </summary>
        [DataMember(Name = "PreviousActivityForDirect")]
        public string PreviousActivityForDirect { get; set; }

        /// <summary>
        /// Gets or Sets PreviousActivityForReverse
        /// </summary>
        [DataMember(Name = "PreviousActivityForReverse")]
        public string PreviousActivityForReverse { get; set; }

        /// <summary>
        /// Gets or Sets ParentProcessId
        /// </summary>
        [DataMember(Name = "ParentProcessId")]
        public Guid? ParentProcessId { get; set; }

        /// <summary>
        /// Gets or Sets RootProcessId
        /// </summary>
        [DataMember(Name = "RootProcessId")]
        public Guid? RootProcessId { get; set; }

        /// <summary>
        /// Gets or Sets InstanceStatus
        /// </summary>
        [Required]
        [DataMember(Name = "InstanceStatus")]
        public int? InstanceStatus { get; set; }

        /// <summary>
        /// Gets or Sets Transitions
        /// </summary>
        [DataMember(Name = "Transitions")]
        public List<Transition> Transitions { get; set; }

        /// <summary>
        /// Gets or Sets History
        /// </summary>
        [DataMember(Name = "History")]
        public List<HistoryItem> History { get; set; }

        /// <summary>
        /// Gets or Sets ProcessParameters
        /// </summary>
        [DataMember(Name = "ProcessParameters")]
        public ProcessParameters ProcessParameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProcessInfo {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  StateName: ").Append(StateName).Append("\n");
            sb.Append("  ActivityName: ").Append(ActivityName).Append("\n");
            sb.Append("  SchemeId: ").Append(SchemeId).Append("\n");
            sb.Append("  SchemeCode: ").Append(SchemeCode).Append("\n");
            sb.Append("  PreviousState: ").Append(PreviousState).Append("\n");
            sb.Append("  PreviousStateForDirect: ").Append(PreviousStateForDirect).Append("\n");
            sb.Append("  PreviousStateForReverse: ").Append(PreviousStateForReverse).Append("\n");
            sb.Append("  PreviousActivity: ").Append(PreviousActivity).Append("\n");
            sb.Append("  PreviousActivityForDirect: ").Append(PreviousActivityForDirect).Append("\n");
            sb.Append("  PreviousActivityForReverse: ").Append(PreviousActivityForReverse).Append("\n");
            sb.Append("  ParentProcessId: ").Append(ParentProcessId).Append("\n");
            sb.Append("  RootProcessId: ").Append(RootProcessId).Append("\n");
            sb.Append("  InstanceStatus: ").Append(InstanceStatus).Append("\n");
            sb.Append("  Transitions: ").Append(Transitions).Append("\n");
            sb.Append("  History: ").Append(History).Append("\n");
            sb.Append("  ProcessParameters: ").Append(ProcessParameters).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ProcessInfo)obj);
        }

        /// <summary>
        /// Returns true if ProcessInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of ProcessInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProcessInfo other)
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
                    StateName == other.StateName ||
                    StateName != null &&
                    StateName.Equals(other.StateName)
                ) &&
                (
                    ActivityName == other.ActivityName ||
                    ActivityName != null &&
                    ActivityName.Equals(other.ActivityName)
                ) &&
                (
                    SchemeId == other.SchemeId ||
                    SchemeId != null &&
                    SchemeId.Equals(other.SchemeId)
                ) &&
                (
                    SchemeCode == other.SchemeCode ||
                    SchemeCode != null &&
                    SchemeCode.Equals(other.SchemeCode)
                ) &&
                (
                    PreviousState == other.PreviousState ||
                    PreviousState != null &&
                    PreviousState.Equals(other.PreviousState)
                ) &&
                (
                    PreviousStateForDirect == other.PreviousStateForDirect ||
                    PreviousStateForDirect != null &&
                    PreviousStateForDirect.Equals(other.PreviousStateForDirect)
                ) &&
                (
                    PreviousStateForReverse == other.PreviousStateForReverse ||
                    PreviousStateForReverse != null &&
                    PreviousStateForReverse.Equals(other.PreviousStateForReverse)
                ) &&
                (
                    PreviousActivity == other.PreviousActivity ||
                    PreviousActivity != null &&
                    PreviousActivity.Equals(other.PreviousActivity)
                ) &&
                (
                    PreviousActivityForDirect == other.PreviousActivityForDirect ||
                    PreviousActivityForDirect != null &&
                    PreviousActivityForDirect.Equals(other.PreviousActivityForDirect)
                ) &&
                (
                    PreviousActivityForReverse == other.PreviousActivityForReverse ||
                    PreviousActivityForReverse != null &&
                    PreviousActivityForReverse.Equals(other.PreviousActivityForReverse)
                ) &&
                (
                    ParentProcessId == other.ParentProcessId ||
                    ParentProcessId != null &&
                    ParentProcessId.Equals(other.ParentProcessId)
                ) &&
                (
                    RootProcessId == other.RootProcessId ||
                    RootProcessId != null &&
                    RootProcessId.Equals(other.RootProcessId)
                ) &&
                (
                    InstanceStatus == other.InstanceStatus ||
                    InstanceStatus != null &&
                    InstanceStatus.Equals(other.InstanceStatus)
                ) &&
                (
                    Transitions == other.Transitions ||
                    Transitions != null &&
                    Transitions.SequenceEqual(other.Transitions)
                ) &&
                (
                    History == other.History ||
                    History != null &&
                    History.SequenceEqual(other.History)
                ) &&
                (
                    ProcessParameters == other.ProcessParameters ||
                    ProcessParameters != null &&
                    ProcessParameters.Equals(other.ProcessParameters)
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
                if (StateName != null)
                    hashCode = hashCode * 59 + StateName.GetHashCode();
                if (ActivityName != null)
                    hashCode = hashCode * 59 + ActivityName.GetHashCode();
                if (SchemeId != null)
                    hashCode = hashCode * 59 + SchemeId.GetHashCode();
                if (SchemeCode != null)
                    hashCode = hashCode * 59 + SchemeCode.GetHashCode();
                if (PreviousState != null)
                    hashCode = hashCode * 59 + PreviousState.GetHashCode();
                if (PreviousStateForDirect != null)
                    hashCode = hashCode * 59 + PreviousStateForDirect.GetHashCode();
                if (PreviousStateForReverse != null)
                    hashCode = hashCode * 59 + PreviousStateForReverse.GetHashCode();
                if (PreviousActivity != null)
                    hashCode = hashCode * 59 + PreviousActivity.GetHashCode();
                if (PreviousActivityForDirect != null)
                    hashCode = hashCode * 59 + PreviousActivityForDirect.GetHashCode();
                if (PreviousActivityForReverse != null)
                    hashCode = hashCode * 59 + PreviousActivityForReverse.GetHashCode();
                if (ParentProcessId != null)
                    hashCode = hashCode * 59 + ParentProcessId.GetHashCode();
                if (RootProcessId != null)
                    hashCode = hashCode * 59 + RootProcessId.GetHashCode();
                if (InstanceStatus != null)
                    hashCode = hashCode * 59 + InstanceStatus.GetHashCode();
                if (Transitions != null)
                    hashCode = hashCode * 59 + Transitions.GetHashCode();
                if (History != null)
                    hashCode = hashCode * 59 + History.GetHashCode();
                if (ProcessParameters != null)
                    hashCode = hashCode * 59 + ProcessParameters.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ProcessInfo left, ProcessInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProcessInfo left, ProcessInfo right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
