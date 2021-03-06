//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace QuickComplaint.Data.Entities
{
    public class Complaint
    {
        private int _complaintTypeId;
        private string _description;

        private int _id;
        private string _locationDetails;
        private int _reportingPartyId;

        public Complaint()
        {
        }

        public Complaint(int id, int complaintTypeId, string description, string locationDetails, int reportingPartyId)
        {
            _id = id;
            _complaintTypeId = complaintTypeId;
            _description = description;
            _locationDetails = locationDetails;
            _reportingPartyId = reportingPartyId;
        }

        public virtual ComplaintType ComplaintType { get; set; }

        /// <summary>
        ///     Public Property ComplaintTypeId
        /// </summary>
        /// <returns>ComplaintTypeId as Int32</returns>
        /// <remarks></remarks>
        public virtual int ComplaintTypeId
        {
            get { return _complaintTypeId; }
            set { _complaintTypeId = value; }
        }

        /// <summary>
        ///     Public Property Description
        /// </summary>
        /// <returns>Description as String</returns>
        /// <remarks></remarks>
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        /// <summary>
        ///     Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        ///     Public Property LocationDetails
        /// </summary>
        /// <returns>LocationDetails as String</returns>
        /// <remarks></remarks>
        public virtual string LocationDetails
        {
            get { return _locationDetails; }
            set { _locationDetails = value; }
        }


        public virtual ReportingParty ReportingParty { get; set; }

        /// <summary>
        ///     Public Property ReportingPartyId
        /// </summary>
        /// <returns>ReportingPartyId as Int32</returns>
        /// <remarks></remarks>
        public virtual int ReportingPartyId
        {
            get { return _reportingPartyId; }
            set { _reportingPartyId = value; }
        }
    }
}