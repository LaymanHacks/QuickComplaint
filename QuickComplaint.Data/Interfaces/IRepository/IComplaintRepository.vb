'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Generated by Merlin Version: 1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections.Generic
Imports QuickComplaint.Data
Imports QuickComplaint.Domain.Entities

  
 Namespace QuickComplaint.Data.Repository     
    Public Interface IComplaintRepository
        Function GetData()  as ICollection(Of Complaint)
        Sub Update( ByVal complaintTypeId As Int32,  ByVal description As String,  ByVal locationDetails As String,  ByVal reportingPartyId As Int32,  ByVal id As Int32) 
        Sub Update(ByVal complaint as Complaint) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal complaint as Complaint) 
        Function Insert( ByVal complaintTypeId As Int32,  ByVal description As String,  ByVal locationDetails As String,  ByVal reportingPartyId As Int32)  as Int32
        Function Insert(ByVal complaint as Complaint)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Complaint)
        Function GetDataById( ByVal id As Int32)  as ICollection(Of Complaint)
        Function GetDataByComplaintTypeId( ByVal complaintTypeId As Int32)  as ICollection(Of Complaint)
        Function GetDataByComplaintTypeIdPageable( ByVal complaintTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Complaint)
        Function GetDataByReportingPartyId( ByVal reportingPartyId As Int32)  as ICollection(Of Complaint)
        Function GetDataByReportingPartyIdPageable( ByVal reportingPartyId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Complaint)
    End Interface 
End NameSpace
  