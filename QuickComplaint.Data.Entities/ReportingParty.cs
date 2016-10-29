//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace QuickComplaint.Data.Entities
{
    
    public partial class ReportingParty{
      
        private Int32 _id;
        private String _name;
        private String _email;
        private String _phone1;
        private Int32? _phone1TypeId;
        private String _phone2;
        private Int32? _phone2TypeId;
        private Collection<Complaint> _complaints; 
        private PhoneType _phone1TypePhoneType; 
        private PhoneType _phone2TypePhoneType;  

      public ReportingParty() : base()
      {
      }

      public ReportingParty(Int32 id, String name, String email, String phone1, Int32? phone1TypeId, String phone2, Int32? phone2TypeId) : base()
      {
          
           _id = id;
           _name = name;
           _email = email;
           _phone1 = phone1;
           _phone1TypeId = phone1TypeId;
           _phone2 = phone2;
           _phone2TypeId = phone2TypeId;
      }
  
    
        /// <summary>
        /// Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        public virtual Int32 Id
        {
            get{return this._id;}
            set{this._id = value;}
        }

        /// <summary>
        /// Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        public virtual String Name
        {
            get{return this._name;}
            set{this._name = value;}
        }

        /// <summary>
        /// Public Property Email
        /// </summary>
        /// <returns>Email as String</returns>
        /// <remarks></remarks>
        public virtual String Email
        {
            get{return this._email;}
            set{this._email = value;}
        }

        /// <summary>
        /// Public Property Phone1
        /// </summary>
        /// <returns>Phone1 as String</returns>
        /// <remarks></remarks>
        public virtual String Phone1
        {
            get{return this._phone1;}
            set{this._phone1 = value;}
        }

        /// <summary>
        /// Public Property Phone1TypeId
        /// </summary>
        /// <returns>Phone1TypeId as Int32?</returns>
        /// <remarks></remarks>
        public virtual Int32? Phone1TypeId
        {
            get{return this._phone1TypeId;}
            set{this._phone1TypeId = value;}
        }

        /// <summary>
        /// Public Property Phone2
        /// </summary>
        /// <returns>Phone2 as String</returns>
        /// <remarks></remarks>
        public virtual String Phone2
        {
            get{return this._phone2;}
            set{this._phone2 = value;}
        }

        /// <summary>
        /// Public Property Phone2TypeId
        /// </summary>
        /// <returns>Phone2TypeId as Int32?</returns>
        /// <remarks></remarks>
        public virtual Int32? Phone2TypeId
        {
            get{return this._phone2TypeId;}
            set{this._phone2TypeId = value;}
        }

        public virtual Collection<Complaint> Complaints 
        {
          get { return  _complaints;}
          set { _complaints = value;}
        }
  
      
        public virtual PhoneType Phone1TypePhoneType 
        {
          get { return  _phone1TypePhoneType;}
          set { _phone1TypePhoneType = value;}
        }
  
      
        public virtual PhoneType Phone2TypePhoneType 
        {
          get { return  _phone2TypePhoneType;}
          set { _phone2TypePhoneType = value;}
        }
  
      
    }
 }     
