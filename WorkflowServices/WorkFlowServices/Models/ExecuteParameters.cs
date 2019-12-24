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
    public partial class ExecuteParameters : IEquatable<ExecuteParameters>
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets IdentityId
        /// </summary>
        [DataMember(Name = "IdentityId")]
        public string IdentityId { get; set; }

        /// <summary>
        /// Gets or Sets Parameter
        /// </summary>
        [DataMember(Name = "Parameter")]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or Sets ProcessInstance
        /// </summary>
        [DataMember(Name = "ProcessInstance")]
        public ProcessInfo ProcessInstance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExecuteParameters {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  IdentityId: ").Append(IdentityId).Append("\n");
            sb.Append("  Parameter: ").Append(Parameter).Append("\n");
            sb.Append("  ProcessInstance: ").Append(ProcessInstance).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ExecuteParameters)obj);
        }

        /// <summary>
        /// Returns true if ExecuteParameters instances are equal
        /// </summary>
        /// <param name="other">Instance of ExecuteParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExecuteParameters other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    IdentityId == other.IdentityId ||
                    IdentityId != null &&
                    IdentityId.Equals(other.IdentityId)
                ) &&
                (
                    Parameter == other.Parameter ||
                    Parameter != null &&
                    Parameter.Equals(other.Parameter)
                ) &&
                (
                    ProcessInstance == other.ProcessInstance ||
                    ProcessInstance != null &&
                    ProcessInstance.Equals(other.ProcessInstance)
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (IdentityId != null)
                    hashCode = hashCode * 59 + IdentityId.GetHashCode();
                if (Parameter != null)
                    hashCode = hashCode * 59 + Parameter.GetHashCode();
                if (ProcessInstance != null)
                    hashCode = hashCode * 59 + ProcessInstance.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ExecuteParameters left, ExecuteParameters right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExecuteParameters left, ExecuteParameters right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
