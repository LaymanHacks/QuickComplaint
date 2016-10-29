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
    Public Interface IComplaintTypeRepository
        Function GetData()  as ICollection(Of ComplaintType)
        Sub Update( ByVal name As String,  ByVal id As Int32) 
        Sub Update(ByVal complaintType as ComplaintType) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal complaintType as ComplaintType) 
        Function Insert( ByVal name As String)  as Int32
        Function Insert(ByVal complaintType as ComplaintType)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of ComplaintType)
        Function GetDataById( ByVal id As Int32)  as ICollection(Of ComplaintType)
    End Interface 
End NameSpace
  