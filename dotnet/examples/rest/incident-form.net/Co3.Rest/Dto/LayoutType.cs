/*
 * Resilient Systems, Inc. ("Resilient") is willing to license software
 * or access to software to the company or entity that will be using or
 * accessing the software and documentation and that you represent as
 * an employee or authorized agent ("you" or "your") only on the condition
 * that you accept all of the terms of this license agreement.
 *
 * The software and documentation within Resilient's Development Kit are
 * copyrighted by and contain confidential information of Resilient. By
 * accessing and/or using this software and documentation, you agree that
 * while you may make derivative works of them, you:
 *
 * 1)  will not use the software and documentation or any derivative
 *     works for anything but your internal business purposes in
 *     conjunction your licensed used of Resilient's software, nor
 * 2)  provide or disclose the software and documentation or any
 *     derivative works to any third party.
 *
 * THIS SOFTWARE AND DOCUMENTATION IS PROVIDED "AS IS" AND ANY EXPRESS
 * OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL RESILIENT BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */

// <auto-generated>
// Generated by <a href="http://enunciate.webcohesion.com">Enunciate</a>.
// </auto-generated>

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Co3.Rest.Dto
{
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LayoutType
    {
        /// <summary>
        /// Unspecified enum value.
        /// </summary>
        [JsonIgnore]
        Undefined,

        /// <summary>
        /// Dashboard layout type.  These are used on the system dashboard.
        /// </summary>
        [EnumMember(Value = "dashboard")]
        Dashboard,

        /// <summary>
        /// Incident snapshot report.  These are used in the "create printable report" area.
        /// </summary>
        [EnumMember(Value = "incident_snapshot_report")]
        IncidentSnapshotReport,

        /// <summary>
        /// The layout type for the incident wizard (this is a singleton layout...meaning there can only be one
        /// for the org).
        /// </summary>
        [EnumMember(Value = "incident_wizard")]
        IncidentWizard,

        /// <summary>
        /// Deprecated - do not use.
        /// </summary>
        [EnumMember(Value = "incident_details")]
        IncidentDetails,

        /// <summary>
        /// Deprecated - do not use.
        /// </summary>
        [EnumMember(Value = "incident_breach")]
        IncidentBreach,

        /// <summary>
        /// The layout type for the incident close view (this is a singleton layout...meaning there can only be one
        /// for the org).
        /// </summary>
        [EnumMember(Value = "incident_closed")]
        IncidentClosed,

        /// <summary>
        /// Layout used to store query filters.
        /// </summary>
        [EnumMember(Value = "incident_query_filter")]
        IncidentQueryFilter,

        /// <summary>
        /// The layout type for the incident tabs view (this is a singleton layout...meaning there can only be one
        /// for the org).  Note that there is only one layout for all tabs.
        /// </summary>
        [EnumMember(Value = "incident_tabs")]
        IncidentTabs,

        /// <summary>
        /// The layout type for the incident side bar (the bar along the left side of the page).  This is also a
        /// singleton layout so there can only be one definition.
        /// </summary>
        [EnumMember(Value = "incident_summary")]
        IncidentSummary
    }
}
